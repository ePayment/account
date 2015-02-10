using System;
using System.Collections.Generic;
using System.Text;

using Account.Common.Entities;
using Account.Common.Utilities;
using Account.Data.SqlServer;
using Account.Business.Base;

using log4net;

namespace Account.Business
{
    public class MakeTranday:Tranday
    {
        private DateTime _transdate;
        private ILog logger;
        private dynamic _channel;
        private xml_response _res;
        private string _msgRule;
        //private D_Tranday _dalTranday;
        private D_Account _dalAc;
        private D_TranCode _dalTrancode;
        private string _docId;

        public MakeTranday(dynamic channel)
        {
            // lấy thông tin ngày giao dịch
            logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            _channel = channel;
            _dalTranday = new D_Tranday();
            _dalAc = new D_Account();
            _dalTrancode = new D_TranCode();

            // Ghi log
            if (logger.IsDebugEnabled)
                logger.Debug(string.Format("Create MakeTranday object successfull"));
        }
        public xml_response AddFund(string trancode, string accountId, decimal amount, string descript)
        {
            _res = Retail(trancode, accountId, amount, descript);
            _res.function_name = this.ToString() +
                                 string.Format(".AddFund({0}, {1}, {2},{3})", trancode, accountId, amount, descript);
            return _res;
        }
        public xml_response Retail(string trancode, string accountId, decimal amount, string descript)
        {
            try
            {
                _res = new xml_response();
                _res.function_name = this.ToString() +
                                     string.Format(".Retail({0}, {1}, {2},{3})", trancode, accountId, amount, descript);
                if (logger.IsDebugEnabled)
                    logger.Debug(string.Format("Start function: {0}", _res.function_name));
                // kiểm tra trancode
                Trancode_Info trancodeInfo = _dalTrancode.GetOneTranCode(trancode);
                if (trancodeInfo == null)
                {
                    _res.SetError("99", string.Format("Trancode Id: {0} not found", trancode));
                    if (logger.IsErrorEnabled)
                        logger.Error(string.Format("{0}\t{1}", _res.error_code, _res.error_msg));
                    return _res;
                }
                if (trancodeInfo.CodeType == CodeType.FundTransfer)
                {
                    _res.SetError("99", string.Format("Trancode Id: {0} invalid code type", trancode));
                    if (logger.IsErrorEnabled)
                        logger.Error(string.Format("{0}\t{1}", _res.error_code, _res.error_msg));
                    return _res;
                }

                Tranday_Info trandayInfo = new Tranday_Info();
                _transdate = BaseParameters.ToDay().TransDate;
                trandayInfo.DocID = GenerateDocId(); // tạo số chứng từ mới
                trandayInfo.Trace = trandayInfo.DocID;
                trandayInfo.TransDate = _transdate;
                trandayInfo.ValueDate = _transdate;
                trandayInfo.Status = TransactionStatus.Approved;
                trandayInfo.Branch_ID = _channel.Branch;
                trandayInfo.AllowReverse = trancodeInfo.AllowReverse;
                if (string.IsNullOrEmpty(descript))
                    trandayInfo.Descript = string.Format("Retail: {0} with amount={1}", accountId, amount);
                else
                    trandayInfo.Descript = descript;
                trandayInfo.NextDocId = "";
                trandayInfo.OtherRef = "";
                trandayInfo.TranCode = trancode;
                trandayInfo.UserCreate = _channel.UserLogin;
                trandayInfo.Verified = true;
                trandayInfo.Verified_User = _channel.UserLogin;

                _dalTranday.CreateOneTranday(trandayInfo);

                // lấy mã giao dịch được định nghĩa cách hạch toán
                List<TranCodeDetail_Info> list = _dalTrancode.GetTranCodeDetailByCode(trancode);
                if (list == null)
                {
                    _res.SetError("30", string.Format("Can't load trancodedetail: {0}", trancode));
                    if (logger.IsErrorEnabled)
                        logger.Error(string.Format("{0}\t{1}", _res.error_code, _res.error_msg));
                    _dalTranday.ClearCommand();
                    return _res;
                }
                D_Account dalAc = new D_Account();
                TrandayDetail_Info tid;
                List<Account_Info> AcList;
                Account_Info tmpAc;
                D_TrandayDetail trand = new D_TrandayDetail();
                decimal remain_amnt = 0; // số tiền còn lại
                decimal db_amnt;
                decimal cr_amnt;
                decimal sum_db_amnt = 0;
                decimal sum_cr_amnt = 0;
                bool find_ac = false;

                tmpAc = dalAc.GetOneAccount(accountId);
                if (tmpAc == null)
                {
                    _res.SetError("11", string.Format("{0} does not exists", accountId));
                    if (logger.IsErrorEnabled)
                        logger.Error(string.Format("{0}\t{1}", _res.error_code, _res.error_msg));
                    _dalTranday.ClearCommand();
                    return _res;
                }
                #region Build Trandaydetail

                foreach (TranCodeDetail_Info tcdi in list)
                {
                    AcList = new List<Account_Info>();
                    tid = new TrandayDetail_Info();
                    db_amnt = 0;
                    cr_amnt = 0;

                    #region Find Account_ID

                    if (tcdi.Is_Account_Cust)
                    {
                        // là tài khoản khách hàng
                        AcList = dalAc.GetListAccountLike(tcdi.Account_ID);
                        foreach (Account_Info acInfo in AcList)
                        {
                            if (accountId == acInfo.Account_ID)
                            {
                                find_ac = true;
                                break;
                            }
                        }
                        if (find_ac == false)
                        {
                            // không xác định được nhóm tài khoản khách hàng
                            _res.SetError("31", string.Format("{0} not in group {1}", accountId, tcdi.Account_ID));
                            if (logger.IsErrorEnabled)
                                logger.Error(string.Format("{0}\t{1}", _res.error_code, _res.error_msg));
                            _dalTranday.ClearCommand();
                            return _res;
                        }
                    }
                    else
                    {
                        // là tài khoản đã được định danh chi tiết
                        AcList = dalAc.GetListAccountLike(tcdi.Account_ID);
                        if (AcList.Count > 1)
                        {
                            // nếu xác định được nhiều tài khoản thì lỗi
                            _res.SetError("31", string.Format("{0} does too many accounts", tcdi.Account_ID));
                            if (logger.IsErrorEnabled)
                                logger.Error(string.Format("{0}\t{1}", _res.error_code, _res.error_msg));
                            _dalTranday.ClearCommand();
                            return _res;
                        }
                        if (AcList.Count == 0)
                        {
                            // không xác định được tài khoản 
                            _res.SetError("31", string.Format("{0} Invalid account id", tcdi.Account_ID));
                            if (logger.IsErrorEnabled)
                                logger.Error(string.Format("{0}\t{1}", _res.error_code, _res.error_msg));
                            _dalTranday.ClearCommand();
                            return _res;
                        }
                        tmpAc = AcList[0];
                    }

                    #endregion

                    tid.Account_ID = tmpAc.Account_ID;
                    tid.Ccy = tmpAc.Ccy;
                    tid.SEQ = tcdi.SEQ;

                    if (!tcdi.Master)
                    {
                        switch (tcdi.NumberType)
                        {
                            case NumberType.FixAmount:
                                // Kiểm tra số dư fix
                                if ((decimal)tcdi.NumberValue > amount - remain_amnt)
                                {
                                    _res.SetError("",
                                                  string.Format("fix amount is {0} greater than {1}", tcdi.NumberValue,
                                                                amount - remain_amnt));
                                    if (logger.IsErrorEnabled)
                                        logger.Error(string.Format("{0}\t{1}", _res.error_code, _res.error_msg));
                                    _dalTranday.ClearCommand();
                                    return _res;
                                }
                                if (tcdi.CreditDebit == CreditDebit.DB)
                                    db_amnt = (decimal)tcdi.NumberValue;
                                else
                                    cr_amnt = (decimal)tcdi.NumberValue;
                                break;
                            case NumberType.Percentage:
                                if (tcdi.CreditDebit == CreditDebit.DB)
                                    db_amnt = amount * (decimal)tcdi.NumberValue;
                                else
                                    cr_amnt = amount * (decimal)tcdi.NumberValue;
                                break;
                            default:
                                if (tcdi.CreditDebit == CreditDebit.DB)
                                    db_amnt = amount - remain_amnt;
                                else
                                    cr_amnt = amount - remain_amnt;
                                break;
                        }
                        if (tcdi.CreditDebit == CreditDebit.DB)
                            remain_amnt += db_amnt;
                        else
                            remain_amnt += cr_amnt;
                    }
                    else
                    {
                        if (tcdi.CreditDebit == CreditDebit.DB)
                            db_amnt = amount;
                        else
                            cr_amnt = amount;
                    }
                    tid.DB_Amount = db_amnt;
                    tid.CR_Amount = cr_amnt;
                    tid.DocID = trandayInfo.DocID;
                    // ===============================
                    // kiểm tra điều kiện hạch toán ==
                    // ===============================
                    decimal temp_amnt = 0;
                    if (tcdi.CreditDebit == CreditDebit.DB)
                        temp_amnt = tid.DB_Amount;
                    else
                        temp_amnt = tid.CR_Amount;
                    if (!CheckAccountRules(tmpAc, tcdi.CreditDebit, temp_amnt))
                    {
                        _res.SetError("15", _msgRule);
                        if (logger.IsErrorEnabled)
                            logger.Error(string.Format("{0}\t{1}", _res.error_code, _res.error_msg));
                        _dalTranday.ClearCommand();
                        return _res;
                    }
                    // ===============================
                    // ghi nợ tài khoản 
                    tmpAc.d_Debit += tid.DB_Amount;
                    tmpAc.w_Debit += tid.DB_Amount;
                    tmpAc.m_Debit += tid.DB_Amount;
                    tmpAc.q_Debit += tid.DB_Amount;
                    tmpAc.y_Debit += tid.DB_Amount;
                    // ghi có tài khoản.
                    tmpAc.d_Credit += tid.CR_Amount;
                    tmpAc.w_Credit += tid.CR_Amount;
                    tmpAc.m_Credit += tid.CR_Amount;
                    tmpAc.q_Credit += tid.CR_Amount;
                    tmpAc.y_Credit += tid.CR_Amount;

                    tmpAc.Last_Date = DateTime.Now;
                    // Cập nhật số dư mới
                    tid.BalanceAvaiable = tmpAc.BalanceAvaiable;
                    // thực hiện câu lệnh
                    // Kiểm tra điều kiện số dư hạch toán nợ/có
                    if ((tid.DB_Amount == 0) && (tid.CR_Amount == 0))
                        break;
                    else
                    {
                        _dalTranday.AddCommand(trand.CreateOneTrandayDetail(tid));
                        _dalTranday.AddCommand(dalAc.EditOneAccount(tmpAc));
                        // ghi nhận tổng nợ và tổng có
                        sum_db_amnt += db_amnt;
                        sum_cr_amnt += cr_amnt;
                    }
                } // end forearch

                #endregion

                // với bút toán nhiều chân thì kiểm tra cân đối tổng nợ và tổng có
                if (list.Count > 1)
                {
                    if (sum_cr_amnt != sum_db_amnt)
                    {
                        // không cân đối giữa tổng nợ và tổng có
                        _res.SetError("52",
                                      string.Format("total debit ({0}) and total credit ({1}) is difference",
                                                    sum_db_amnt,
                                                    sum_cr_amnt));
                        if (logger.IsErrorEnabled)
                            logger.Error(string.Format("{0}\t{1}", _res.error_code, _res.error_msg));
                        _dalTranday.ClearCommand();
                        return _res;
                    }
                }
                if (string.IsNullOrEmpty(_docId))
                    _docId = trandayInfo.DocID;
                if (!string.IsNullOrEmpty(trancodeInfo.NextCode))
                {
                    Retail(trancodeInfo.NextCode, accountId, amount, descript);
                }
                else
                    // ghi nhận hạch toán
                    if (_dalTranday.Execute())
                    // Lấy thông tin giao dịch
                    {
                        _res.Transactions = base.GetTrandayById(_docId).RenderXML();
                        _docId = String.Empty;
                    }
                    else
                    {
                        _res.SetError("99", _dalTranday.GetException.Message);
                        if (logger.IsErrorEnabled)
                            logger.Error(string.Format("{0}\t{1}", _res.error_code, _res.error_msg));
                        _docId = String.Empty;
                        _dalTranday.ClearCommand();
                    }
            }
            catch (Exception ex)
            {
                _res.SetError("99", ex.Message);
                if (logger.IsErrorEnabled)
                    logger.Error(ex);
                _docId = String.Empty;
                _dalTranday.ClearCommand();
            }
            return _res;
        }
        public xml_response Fundtransfer(string trancode, string fromAccount, string toAccount, decimal amount, string descript)
        {
            try
            {
                _res = new xml_response();
                _res.function_name = this.ToString() +
                                     string.Format(".Fundtransfer({0}, {1}, {2}, {3},{4})", trancode, fromAccount,
                                                   toAccount, amount, descript);
                if (logger.IsDebugEnabled)
                    logger.Debug(string.Format("Start function: {0}", _res.function_name));
                // kiểm tra trancode
                Trancode_Info trancodeInfo = _dalTrancode.GetOneTranCode(trancode);
                if (trancodeInfo == null)
                {
                    _res.SetError("99", string.Format("Trancode Id: {0} not found", trancode));
                    if (logger.IsErrorEnabled)
                        logger.Error(string.Format("{0}\t{1}", _res.error_code, _res.error_msg));
                    return _res;
                }
                if (trancodeInfo.CodeType != CodeType.FundTransfer)
                {
                    _res.SetError("99", string.Format("Trancode Id: {0} invalid code type", trancode));
                    if (logger.IsErrorEnabled)
                        logger.Error(string.Format("{0}\t{1}", _res.error_code, _res.error_msg));
                    return _res;
                }

                // kiểm tra tài khoản đã có hay chưa
                string db_account = fromAccount;
                string cr_account = toAccount;

                if (_dalAc.GetOneAccount(db_account) == null)
                {
                    _res.SetError("11", string.Format("From account {0} does not found", db_account));
                    if (logger.IsErrorEnabled)
                        logger.Error(string.Format("{0}\t{1}", _res.error_code, _res.error_msg));
                    return _res;
                }
                if (_dalAc.GetOneAccount(cr_account)==null)
                {
                    _res.SetError("11", string.Format("From account {0} does not found", cr_account));
                    if (logger.IsErrorEnabled)
                        logger.Error(string.Format("{0}\t{1}", _res.error_code, _res.error_msg));
                    return _res;
                }
                // kiểm tra số dư chuyển khoản.
                Tranday_Info trandayInfo = new Tranday_Info();
                trandayInfo.AllowReverse = trancodeInfo.AllowReverse;
                trandayInfo.Branch_ID = _channel.Branch;
                if (string.IsNullOrEmpty(descript))
                    trandayInfo.Descript = string.Format("transfer from {0} to {1} with amount = {2}", db_account, cr_account, amount);
                else
                    trandayInfo.Descript = descript;
                trandayInfo.NextDocId = "";
                trandayInfo.Status = TransactionStatus.Approved;

                _transdate = BaseParameters.ToDay().TransDate ;

                trandayInfo.TranCode = trancode;
                trandayInfo.TransDate = _transdate;
                trandayInfo.UserCreate = _channel.UserLogin;
                trandayInfo.ValueDate = _transdate;
                trandayInfo.Verified = true;
                trandayInfo.Verified_User = _channel.UserLogin;
                trandayInfo.DocID = base.GenerateDocId();
                trandayInfo.Trace = trandayInfo.DocID;

                _dalTranday.CreateOneTranday(trandayInfo);

                D_TrandayDetail dalTrandaydetail;
                TrandayDetail_Info trandaydetailInfo;
                Account_Info ai = new Account_Info();
                List<Account_Info> ac_list = new List<Account_Info>();
                bool find_ac = false;
                D_TranCodeDetail dalTrancodedetail = new D_TranCodeDetail();
                List<TranCodeDetail_Info> list = dalTrancodedetail.GetTranCodeDetailByCode(trancode);
                if (list == null)
                {
                    _res.SetError("30", string.Format("Can't load trancodedetail: {0}", trancode));
                    if (logger.IsErrorEnabled)
                        logger.Error(string.Format("{0}\t{1}", _res.error_code, _res.error_msg));
                    _dalTranday.ClearCommand();
                    return _res;
                }
                foreach (TranCodeDetail_Info tcdi in list)
                {
                    dalTrandaydetail = new D_TrandayDetail();
                    trandaydetailInfo = new TrandayDetail_Info();
                    switch (tcdi.CreditDebit)
                    {
                        case  CreditDebit.DB:
                            ac_list = _dalAc.GetListAccountLike(tcdi.Account_ID);
                            foreach (Account_Info acInfo in ac_list)
                                if (db_account == acInfo.Account_ID)
                                {
                                    find_ac = true;
                                    break;
                                }
                            if (find_ac == false)
                            {
                                // không xác định được nhóm tài khoản khách hàng
                                _res.SetError("31", string.Format("{0} not in group {1}", db_account, tcdi.Account_ID));
                                if (logger.IsErrorEnabled)
                                    logger.Error(string.Format("{0}\t{1}", _res.error_code, _res.error_msg));
                                _dalTranday.ClearCommand();
                                return _res;
                            }
                            trandaydetailInfo.Account_ID = db_account;
                            trandaydetailInfo.DB_Amount = amount;
                            ai = _dalAc.GetOneAccount(trandaydetailInfo.Account_ID);
                            // kiểm tra luật hạch toán
                            if (!CheckAccountRules(ai, CreditDebit.DB, amount))
                            {
                                _res.SetError("15", _msgRule);
                                _dalTranday.ClearCommand();
                                return _res;
                            }
                            // ghi nợ tài khoản.
                            ai.y_Debit += amount;
                            ai.q_Debit += amount;
                            ai.m_Debit += amount;
                            ai.w_Debit += amount;
                            ai.d_Debit += amount;
                            trandaydetailInfo.Ccy = ai.Ccy;
                            break;
                        case CreditDebit.CR:
                            ac_list = _dalAc.GetListAccountLike(tcdi.Account_ID);
                            foreach (Account_Info acInfo in ac_list)
                                if (cr_account == acInfo.Account_ID)
                                {
                                    find_ac = true;
                                    break;
                                }
                            if (find_ac == false)
                            {
                                // không xác định được nhóm tài khoản khách hàng
                                _res.SetError("31", string.Format("{0} not in group {1}", cr_account, tcdi.Account_ID));
                                if (logger.IsErrorEnabled)
                                    logger.Error(string.Format("{0}\t{1}", _res.error_code, _res.error_msg));
                                _dalTranday.ClearCommand();
                                return _res;
                            }
                            trandaydetailInfo.Account_ID = cr_account;
                            trandaydetailInfo.CR_Amount = amount;
                            ai = _dalAc.GetOneAccount(trandaydetailInfo.Account_ID);
                            // kiểm tra luật hạch toán
                            if (!CheckAccountRules(ai, CreditDebit.CR, amount))
                            {
                                _res.SetError("15", _msgRule);
                                _dalTranday.ClearCommand();
                                return _res;
                            }
                            // ghi có tài khoản.
                            ai.y_Credit += amount;
                            ai.q_Credit += amount;
                            ai.m_Credit += amount;
                            ai.w_Credit += amount;
                            ai.d_Credit += amount;
                            trandaydetailInfo.Ccy = ai.Ccy;
                            break;
                    }
                    trandaydetailInfo.SEQ = tcdi.SEQ;
                    trandaydetailInfo.DocID = trandayInfo.DocID;
                    // cập nhật số dư mới
                    trandaydetailInfo.BalanceAvaiable = ai.BalanceAvaiable;
                    // cập nhật thời gian
                    ai.Last_Date = DateTime.Now;
                    // thực hiện câu lệnh
                    _dalTranday.AddCommand(dalTrandaydetail.CreateOneTrandayDetail(trandaydetailInfo));
                    _dalTranday.AddCommand(_dalAc.EditOneAccount(ai));
                }
                if (string.IsNullOrEmpty(_docId))
                    _docId = trandayInfo.DocID;
                if (!string.IsNullOrEmpty(trancodeInfo.NextCode))
                {
                    Fundtransfer(trancodeInfo.NextCode, fromAccount, toAccount, amount, descript);
                }
                else
                    // ghi nhận hạch toán
                    if (!_dalTranday.Execute())
                    {
                        _res.SetError("99", _dalTranday.GetException.Message);
                        if (logger.IsErrorEnabled)
                            logger.Error(string.Format("{0}\t{1}", _res.error_code, _res.error_msg));
                        _docId = String.Empty;
                        _dalTranday.ClearCommand();
                    }
                    else
                    // Lấy thông tin giao dịch
                    {
                        _res.Transactions = base.GetTrandayById(_docId).RenderXML();
                        _docId = String.Empty;
                    }
            }
            catch (Exception ex)
            {
                _res.SetError("99", ex.Message);
                if (logger.IsErrorEnabled)
                    logger.Error(ex);
                _docId = String.Empty;
                _dalTranday.ClearCommand();
            }
            return _res;
        }
        public xml_response Reverse(string docid)
        {
            _res = new xml_response();
            _res.function_name = this.ToString() + string.Format(".Reverse({0})", docid);
            if (logger.IsDebugEnabled)
                logger.Debug(string.Format("Start function: {0}", _res.function_name));
            
            try
            {
                Tranday_Info tranInfo = _dalTranday.GetOneTranday(docid);
                if (tranInfo == null)
                {
                    _res.SetError("40", string.Format("Transaction {0} does not exists", docid));
                    if (logger.IsErrorEnabled)
                        logger.Error(string.Format("{0}\t{1}", _res.error_code, _res.error_msg));
                    return _res;
                }
                if (tranInfo.Verified == false)
                {
                    _res.SetError("42", string.Format("{0} transaction are not verified", docid));
                    if (logger.IsErrorEnabled)
                        logger.Error(string.Format("{0}\t{1}", _res.error_code, _res.error_msg));
                    return _res;
                }
                if (string.IsNullOrEmpty(_docId))
                    if (tranInfo.AllowReverse == false)
                    {
                        _res.SetError("44", string.Format("Transaction {0} does not allow reverse", docid));
                        if (logger.IsErrorEnabled)
                            logger.Error(string.Format("{0}\t{1}", _res.error_code, _res.error_msg));
                        return _res;
                    }
                Tranday_Info oldTran = tranInfo;
                // cập nhật hồ sơ giao dịch không cho cho phép đảo ngược nữa
                tranInfo.AllowReverse = false;
                _dalTranday.EditOneTranday(tranInfo);
                tranInfo.Descript = string.Format("REVERSE: {0}", docid);
                tranInfo.DocID = base.GenerateDocId();
                tranInfo.Trace = tranInfo.DocID;
                tranInfo.OtherRef = docid;
                tranInfo.NextDocId = "";
                tranInfo.Status = TransactionStatus.Approved;

                _transdate = BaseParameters.ToDay().TransDate;   // Lấy thông tin ngày giao dịch

                tranInfo.TransDate = _transdate;
                tranInfo.ValueDate = _transdate;
                tranInfo.Verified = true;
                tranInfo.Verified_User = _channel.UserLogin;
                tranInfo.UserCreate = _channel.UserLogin;

                _dalTranday.CreateOneTranday(tranInfo);

                Account_Info acInfo;
                D_TrandayDetail dtd = new D_TrandayDetail();
                foreach (TrandayDetail_Info tdi in tranInfo.TrandayDetails)
                {
                    // đổi dấu số dư hạch toán.
                    tdi.CR_Amount *= -1;
                    tdi.DB_Amount *= -1;
                    // lấy thông tin tài khoản hạch toán
                    acInfo = _dalAc.GetOneAccount(tdi.Account_ID);
                    // kiểm tra luật hạch toán
                    if (tdi.DB_Amount != 0)
                    {
                        if (!CheckAccountRules(acInfo, CreditDebit.DB, tdi.DB_Amount))
                        {
                            _res.SetError("15", _msgRule);
                            if (logger.IsErrorEnabled)
                                logger.Error(string.Format("{0}\t{1}", _res.error_code, _res.error_msg));
                            _dalTranday.ClearCommand();
                            return _res;
                        }
                    }
                    if (tdi.CR_Amount != 0)
                    {
                        if (!CheckAccountRules(acInfo, CreditDebit.CR, tdi.CR_Amount))
                        {
                            _res.SetError("15", _msgRule);
                            if (logger.IsErrorEnabled)
                                logger.Error(string.Format("{0}\t{1}", _res.error_code, _res.error_msg));
                            _dalTranday.ClearCommand();
                            return _res;
                        }
                    }

                    // ghi có tài khoản.
                    acInfo.y_Credit += tdi.CR_Amount;
                    acInfo.q_Credit += tdi.CR_Amount;
                    acInfo.m_Credit += tdi.CR_Amount;
                    acInfo.w_Credit += tdi.CR_Amount;
                    acInfo.d_Credit += tdi.CR_Amount;
                    // ghi nợ tài khoản
                    acInfo.y_Debit += tdi.DB_Amount;
                    acInfo.q_Debit += tdi.DB_Amount;
                    acInfo.m_Debit += tdi.DB_Amount;
                    acInfo.w_Debit += tdi.DB_Amount;
                    acInfo.d_Debit += tdi.DB_Amount;
                    // cập nhật số dư
                    tdi.BalanceAvaiable = acInfo.BalanceAvaiable;
                    tdi.DocID = tranInfo.DocID;
                    // cập nhật thời gian
                    acInfo.Last_Date = DateTime.Now;
                    // thực hiện câu lệnh
                    _dalTranday.AddCommand(dtd.CreateOneTrandayDetail(tdi));
                    _dalTranday.AddCommand(_dalAc.EditOneAccount(acInfo));
                }
                if (string.IsNullOrEmpty(_docId))
                    _docId = tranInfo.DocID;
                if (!string.IsNullOrEmpty(oldTran.NextDocId))
                    Reverse(oldTran.NextDocId);
                else
                {
                    if (!_dalTranday.Execute())
                    {
                        _res.SetError("99", _dalTranday.GetException.Message);
                        if (logger.IsErrorEnabled)
                            logger.Error(string.Format("{0}\t{1}", _res.error_code, _res.error_msg));
                        _docId = String.Empty;
                        _dalTranday.ClearCommand();
                    }
                    else
                    {
                        //_res.doc_id = ti.DocID;
                        _res.Transactions = base.GetTrandayById(_docId).RenderXML();
                        _docId = String.Empty;
                    }
                }
            }
            catch (Exception ex)
            {
                _res.SetError("99", ex.Message);
                if (logger.IsErrorEnabled)
                    logger.Error(string.Format("{0}\t{1}", _res.error_code, _res.error_msg));
                _docId = String.Empty;
                _dalTranday.ClearCommand();
            }
            return _res;
        }
        public xml_response GetOneTransaction(string docid)
        {
            try
            {
                _res = new xml_response();
                _res.function_name = this.ToString() + string.Format(".Transaction({0})", docid);
                if (logger.IsDebugEnabled)
                    logger.Debug(string.Format("Start fucntion: {0}", _res.function_name));

                Tranday_Info ti = base.GetTrandayById(docid);
                if (ti == null)
                {
                    // không tìm thấy chứng từ
                    _res.SetError("17", "transaction not found");
                    if (logger.IsErrorEnabled)
                        logger.Error(string.Format("{0}\t{1}", _res.error_code, _res.error_msg));
                }
                else
                {
                    // đưa vào mảng
                    _res.Transactions = ti.RenderXML();
                }
            }
            catch (Exception ex)
            {
                _res.SetError("99", ex.Message);
                if (logger.IsErrorEnabled)
                    logger.Error(ex);
            }
            return _res;
        }
        /// <summary>
        /// Hàm kiểm tra điều kiện các luật số dư hay doanh số hạch toán,
        /// các luật này được định nghĩa chi tiết
        /// cho từng nhóm tài khoản trong bảng Account_Rules
        /// </summary>
        /// <param name="acc">thông tin tài khoản chi tiết cần kiểm tra luật</param>
        /// <param name="crdb">chuỗi ký tự quy định tài khoản sẽ được ghi nợ hay ghi có
        /// nếu chuỗi là "CR" là ghi có, còn nếu chuỗi là "DB" thì là ghi nợ</param>
        /// <param name="amnt">số dư hạch toán nợ hay có cần kiểm tra luật, 
        /// điều kiện kiểm tra bao gồm cả số dư hiện tại của tài khoản và số dư hạch toán này</param>
        /// <returns>nếu không phạm luật thì hàm trả về giá trị true,
        /// còn nếu lỗi là false và chuỗi ký tự báo phạm luật gì qua biến _msgRule của lớp thư viện</returns>
        private bool CheckAccountRules(Account_Info acc, CreditDebit crdb, decimal amnt)
        {
            bool rule = true;
            // Kiểm tra số dư theo tính chất tài khoản.
            // ======== hạch toán nợ =========
            if (crdb == CreditDebit.DB)
            {
                if (acc.CreditDebit == AccountType.DB)
                {
                    // tài khoản mang tính chất nợ
                    if (acc.b_Credit + acc.y_Credit - (acc.y_Debit + amnt) > 0)
                    {
                        _msgRule = string.Format("The {0} balance not enough ", acc.Account_ID);
                        return false;
                    }
                }
                else
                    if (acc.CreditDebit == AccountType.CR)
                    {
                        // tài khoản mang tính chất có
                        if (acc.b_Credit + acc.y_Credit - (acc.y_Debit + amnt) < 0)
                        {
                            _msgRule = string.Format("The {0} balance not enough", acc.Account_ID);
                            return false;
                        }
                    }
                    else
                    {
                        // tài khoản mang tính chất lưỡng tính luôn đúng
                        rule = true;
                    }
            }
            // ======== hạch toán có =========
            if (crdb == CreditDebit.CR)
            {
                if (acc.CreditDebit == AccountType.DB)
                {
                    // tài khoản mang tính chất nợ
                    if (acc.b_Credit + (acc.y_Credit + amnt) - acc.y_Debit > 0)
                    {
                        _msgRule = string.Format("The {0} balance not enough ", acc.Account_ID);
                        return false;
                    }
                }
                else if (acc.CreditDebit == AccountType.CR)
                {
                    // tài khoản mang tính chất có
                    if (acc.b_Credit + (acc.y_Credit + amnt) - acc.y_Debit < 0)
                    {
                        _msgRule = string.Format("The {0} balance not enough", acc.Account_ID);
                        return false;
                    }
                }
                else
                {
                    // tài khoản mang tính chất lưỡng tính luôn đúng
                    rule = true;
                }
            }
            // ======================================
            // kiểm tra điều kiện hạch toán theo luật
            // ======================================
            var dar = new D_AccountRoles();
            List<AccountRoles_Info> list = dar.GetSomething(acc.Account_ID);
            if (list == null)   // nếu không có rule thì hoàn thành check
                return true;

            foreach (AccountRoles_Info acR in list)
            {
                switch (acR.Type)
                {
                    case AccountRoleType.CreditPerDay:
                        if (crdb == CreditDebit.CR)
                            rule = OperationCompare(acc.d_Credit + amnt, acR.Operator, acR.Value);
                        break;
                    case AccountRoleType.DebitPerDay:
                        if (crdb == CreditDebit.DB)
                            rule = OperationCompare(acc.d_Debit + amnt, acR.Operator, acR.Value);
                        break;
                    case AccountRoleType.CreditPerWeek:
                        if (crdb == CreditDebit.CR)
                            rule = OperationCompare(acc.w_Credit + amnt, acR.Operator, acR.Value);
                        break;
                    case AccountRoleType.DebitPerWeek:
                        if (crdb == CreditDebit.DB)
                            rule = OperationCompare(acc.w_Debit + amnt, acR.Operator, acR.Value);
                        break;
                    case AccountRoleType.CreditPerMonth:
                        if (crdb == CreditDebit.CR)
                            rule = OperationCompare(acc.m_Credit + amnt, acR.Operator, acR.Value);
                        break;
                    case AccountRoleType.DebitPerMonth:
                        if (crdb == CreditDebit.DB)
                            rule = OperationCompare(acc.m_Debit + amnt, acR.Operator, acR.Value);
                        break;
                    case AccountRoleType.CreditPerQuarter:
                        if (crdb == CreditDebit.CR)
                            rule = OperationCompare(acc.q_Credit + amnt, acR.Operator, acR.Value);
                        break;
                    case AccountRoleType.DebitPerQuarter:
                        if (crdb == CreditDebit.DB)
                            rule = OperationCompare(acc.q_Debit + amnt, acR.Operator, acR.Value);
                        break;
                    case AccountRoleType.CreditPerYear:
                        if (crdb == CreditDebit.CR)
                            rule = OperationCompare(acc.y_Credit + amnt, acR.Operator, acR.Value);
                        break;
                    case AccountRoleType.DebitPerYear:
                        if (crdb == CreditDebit.DB)
                            rule = OperationCompare(acc.y_Debit + amnt, acR.Operator, acR.Value);
                        break;
                    case AccountRoleType.CreditPerDeal:
                        if (crdb == CreditDebit.CR)
                            rule = OperationCompare(amnt, acR.Operator, acR.Value);
                        break;
                    case AccountRoleType.DebitPerDeal:
                        if (crdb == CreditDebit.DB)
                            rule = OperationCompare(amnt, acR.Operator, acR.Value);
                        break;
                    case AccountRoleType.OnBalance:
                        decimal trial_bal = 0;
                        // nếu là hạch toán nợ
                        if (crdb == CreditDebit.DB)
                        { trial_bal = acc.b_Credit + acc.y_Credit - (acc.y_Debit + amnt); }
                        // nếu là hạch toán có
                        if (crdb == CreditDebit.CR)
                        { trial_bal = acc.b_Credit + (acc.y_Credit + amnt) - acc.y_Debit; }
                        // đổi dấu nếu tài khoản mang tính chất nợ
                        if (acc.CreditDebit == AccountType.DB)
                            trial_bal *= -1;
                        // so sánh theo số dư mới
                        rule = OperationCompare(trial_bal, acR.Operator, acR.Value);
                        break;
                }
                if (rule == false)
                {
                    _msgRule = string.Format("Rule name:({0}){1}\t{2}\t{3}\t{4}",
                        acR.ID, acR.Name, acR.Type, acR.Operator, acR.Value);
                    break;
                }
                else
                { _msgRule = ""; }
            }
            return rule;
        }
        private bool OperationCompare(decimal bal, OperatorType opt, decimal amnt)
        {
            switch (opt)
            {
                case OperatorType.Equal:
                    if (bal == amnt)
                    { return true; }
                    else
                    { return false; }
                case OperatorType.GreaterThan:
                    if (bal > amnt)
                    { return true; }
                    else
                    { return false; }
                case OperatorType.GreaterThanOrEqual:
                    if (bal >= amnt)
                    { return true; }
                    else
                    { return false; }
                case OperatorType.LessThan:
                    if (bal < amnt)
                    { return true; }
                    else
                    { return false; }
                case OperatorType.LessThanOrEqual:
                    if (bal <= amnt)
                    { return true; }
                    else
                    { return false; }
                case OperatorType.NotEqual:
                    if (bal != amnt)
                    { return true; }
                    else
                    { return false; }
                default:
                    return false;
            }
        }
    }
}
