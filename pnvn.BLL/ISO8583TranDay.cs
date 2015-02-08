using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

using Account.Common.Entities;
using Account.Common.Utilities;
using Account.Data.SqlServer;
using Account.Business.Base;

using log4net;

namespace Account.Business
{
    public class ISO8583TranDay:Tranday
    {
        ILog logger;
        string user_id;
        string retail_trancode;
        string fundtransfer_trancode;
        DateTime transdate;
        string branch_id;
        StringBuilder strb;
        ResponseMessage res_msg;
        Channel_Info _channel;
        public ResponseMessage Message
        { 
            get { return res_msg; } 
            set 
            {
                if (value == null)
                    throw new Exception("Response Message does not null");
                res_msg = value; 
            } 
        }
        public ISO8583TranDay(Channel_Info channel)
        {
            logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
            user_id = channel.UserLogin;
            branch_id = channel.Branch;
            retail_trancode = channel.Retail_Trancode;
            fundtransfer_trancode = channel.FundTranfer_Trancode;
            transdate = BaseParameters.ToDay().TransDate;
            string a = Validation();
            if (a != "")
            {
                if (logger.IsDebugEnabled)
                    logger.Debug(a);
                throw new Exception(a);
            }
            _channel = channel;
        }
        private string Validation()
        {
            // kiểm tra điều kiện tạo mới
            strb = new StringBuilder("");
            if (string.IsNullOrEmpty(branch_id))
                strb.Append("Branch_id does not null or empty");
            if (string.IsNullOrEmpty(user_id))
                strb.Append("User_id does not null or empty");
            if (string.IsNullOrEmpty(retail_trancode))
                strb.Append("Retail trancode does not null or empty");
            if (string.IsNullOrEmpty(fundtransfer_trancode))
                strb.Append("FundTransfer trancode does not null or empty");
            if (string.IsNullOrEmpty(strb.ToString()))
            { return ""; }
            else
            { return strb.ToString(); }
        }
        /// <summary>
        /// tạo mới giao dịch mua hàng
        /// </summary>
        /// <param name="docid">số chứng từ hạch toán (phải duy nhất trong giai đoạn mở sổ)</param>
        /// <param name="account_id">tài khoản ghi nợ của khách hàng mua hàng</param>
        /// <param name="amount">số tiền mua hàng</param>
        /// <param name="descript">mô tả chi tiết giao dịch mua hàng</param>
        /// <returns>trả về 1 nếu thành công và 0 nếu không thành công</returns>
        public ResponseMessage Retail(string trace, string pan, decimal amount, string descript)
        {
            ResponseMessage msg = new ResponseMessage();
            msg.LocalDate = DateTime.Now.ToString("MMdd");
            msg.LocalTime = DateTime.Now.ToString("hhmmss");
            msg.SystemTrace = trace;
            
            D_Tranday dt = new D_Tranday();
            // kiểm tra số chứng từ đã có hay chưa
            if (dt.IsExists("",trace))
            {
                logger.Error(string.Format("Transaction {0} does exists",trace));
                msg.ResponseCode = "12";
                return msg;
            }
            
            Tranday_Info ti = new Tranday_Info();
            // tạo lại số chứng từ mới
            ti.DocID = base.GenerateDocId();
            
            msg.RetrievalRefNum = ti.DocID;

            ti.Trace = trace;
            ti.TransDate = transdate;
            ti.ValueDate = transdate;
            ti.Status = TransactionStatus.Approved;
            ti.Branch_ID = branch_id;
            ti.AllowReverse = true;
            ti.Descript = descript;
            ti.NextDocId = "";
            ti.OtherRef = "";
            ti.TranCode = retail_trancode;
            ti.UserCreate = user_id;
            ti.Verified = true;
            ti.Verified_User = user_id;
            dt.CreateOneTranday(ti);
            // lấy mã giao dịch được định nghĩa cách hạch toán
            D_TranCodeDetail dtd = new D_TranCodeDetail();
            List<TranCodeDetail_Info> list = dtd.GetTranCodeDetailByCode(retail_trancode);
            if (list == null)
            {
                if (logger.IsErrorEnabled)
                    logger.Error(string.Format("Can't load trancodedetail: {0}", retail_trancode));
                msg.ResponseCode = "06";
                return msg;
            }
            D_Account da = new D_Account();
            TrandayDetail_Info tid;
            List<Account_Info> ac_list;
            Account_Info tmp_ac;
            D_TrandayDetail trand = new D_TrandayDetail();
            #region Build Trandaydetail
            foreach (TranCodeDetail_Info tcdi in list)
            {
                ac_list = new List<Account_Info>();
                tid = new TrandayDetail_Info();
                #region Xác định tài khoản hạch toán
                if (tcdi.Is_Account_Cust)
                {
                    // là tài khoản khách hàng
                    // so sánh tài khoản khách hàng có thuộc nhóm tài khoản định nghĩa.
                    // tài khoản chi tiết: 10100099992222
                    // thuộc nhóm tài khoản 101000
                    if (pan.IndexOf(tcdi.Account_ID) != 0)
                    {
                        // không xác định được nhóm tài khoản khách hàng
                        if (logger.IsErrorEnabled)
                            logger.Error(string.Format("{0} not in group {1}", pan, tcdi.Account_ID));
                        msg.ResponseCode = "14";    // Invalid card number
                        return msg;
                    }
                    tmp_ac = da.GetOneAccount(pan);
                    if (tmp_ac == null)
                    {
                        if (logger.IsErrorEnabled)
                            logger.Error(string.Format("{0} does not exists", pan));
                        msg.ResponseCode = "14";    // Invalid card number
                        return msg;
                    }
                }
                else
                {
                    // là tài khoản nội bộ
                    ac_list = da.GetListAccountLike(tcdi.Account_ID);
                    // nếu xác định được nhiều tài khoản thì lỗi
                    if (ac_list.Count > 1)
                    {
                        if (logger.IsErrorEnabled)
                            logger.Error(string.Format("{0} does too many accounts", tcdi.Account_ID));
                        msg.ResponseCode = "14";    // Invalid card number
                        return msg;
                    }
                    tmp_ac = ac_list[0];
                }
                #endregion
                tid.Account_ID = tmp_ac.Account_ID;
                tid.Ccy = tmp_ac.Ccy;
                tid.SEQ = tcdi.SEQ;
                if (!string.IsNullOrEmpty(tcdi.NumberType.ToString()))
                    switch (tcdi.NumberType)
                    {
                        case NumberType.FixAmount:
                            if (tcdi.CreditDebit == CreditDebit.DB)
                            { tid.DB_Amount = (decimal)tcdi.NumberValue; }
                            else
                            { tid.CR_Amount = (decimal)tcdi.NumberValue; }
                            break;
                        case NumberType.Percentage:
                            if (tcdi.CreditDebit == CreditDebit.DB)
                            { tid.DB_Amount = amount * (decimal)tcdi.NumberValue; }
                            else
                            { tid.CR_Amount = amount * (decimal)tcdi.NumberValue; }
                            break;
                        default:
                            if (tcdi.CreditDebit == CreditDebit.DB)
                            { tid.DB_Amount = amount; }
                            else
                            { tid.CR_Amount = amount; }
                            break;
                    }
                else
                {
                    if (tcdi.CreditDebit == CreditDebit.DB)
                    { tid.DB_Amount = amount; }
                    else
                    { tid.CR_Amount = amount; }
                }
                tid.DocID = ti.DocID;
                // cập nhật thông tin tài khoản 
                tmp_ac.d_Debit += tid.DB_Amount;
                tmp_ac.w_Debit += tid.DB_Amount;
                tmp_ac.m_Debit += tid.DB_Amount;
                tmp_ac.q_Debit += tid.DB_Amount;
                tmp_ac.y_Debit += tid.DB_Amount;

                tmp_ac.d_Credit += tid.CR_Amount;
                tmp_ac.w_Credit += tid.CR_Amount;
                tmp_ac.m_Credit += tid.CR_Amount;
                tmp_ac.q_Credit += tid.CR_Amount;
                tmp_ac.y_Credit += tid.CR_Amount;
                
                dt.AddCommand(trand.CreateOneTrandayDetail(tid));
                dt.AddCommand(da.EditOneAccount(tmp_ac));
            }
            #endregion
            if (dt.Execute() == true)
            {
                // thực hiện giao dịch thành công
                if (logger.IsDebugEnabled)
                    logger.Debug(string.Format("Done create new one retail transaction: {0}", ti.DocID));
                msg.ResponseCode = "00";    // Approved
                return msg;
            }
            else
            {
                // thực hiện giao dịch không thành công
                if (logger.IsErrorEnabled)
                    logger.Error(string.Format("Fails create new one retail transaction: {0}", ti.DocID));
                msg.ResponseCode = "06";    // Error
                return msg;
            }
        }
        /// <summary>
        /// truy vấn số dư tài khoản tại thời điểm hiện tại
        /// </summary>
        /// <param name="account_id">mã số tài khoản</param>
        /// <returns>số dư tài khoản (không bao gồm số dư bị block)</returns>
        public ResponseMessage BalanceInquiry(string pan)
        {
            ResponseMessage msg = new ResponseMessage();
            msg.LocalDate = DateTime.Now.ToString("MMdd");
            msg.LocalTime = DateTime.Now.ToString("hhmmss");
            Account_Info ai = base.Balance(pan);
            if (ai == null)
            {
                logger.Error(string.Format("Account ID: {0} does not found",pan));
                msg.ResponseCode = "14";    // Invalid card number
                return msg;
            }
            msg.BalanceParse(ai.Balance);
            return msg;
        }
        /// <summary>
        /// chuyển khoản từ tài khoản db_account sang tài khoản cr_account
        /// (ghi nợ tài khoản db_account và ghi có tài khoản cr_account)
        /// </summary>
        /// <param name="amount">số tiền chuyển khoản</param>
        /// <param name="from_account">tài khoản ghi nợ</param>
        /// <param name="to_account">tài khoản ghi có</param>
        /// <returns>
        /// 0 không thành công
        /// 1 thành công
        /// </returns>
        public ResponseMessage FundTransfer(string trace, decimal amount, string db_account, string cr_account)
        {
            ResponseMessage msg = new ResponseMessage();
            msg.LocalDate = DateTime.Now.ToString("MMdd");
            msg.LocalTime = DateTime.Now.ToString("hhmmss");

            D_Tranday dt = new D_Tranday();
            // kiểm tra số chứng từ đã tồn tại hay chưa
            if (dt.IsExists("",trace))
            {
                logger.Error(string.Format("Transaction {0} does exists",trace));
                msg.ResponseCode = "12";    // Invalid transaction
                return msg;
            }
            // kiểm tra hai tài khoản đã có hay chưa
            D_Account da = new D_Account();
            if (da.GetOneAccount(db_account)==null)
            {
                logger.Error(string.Format("From account {0} does not found", db_account));
                msg.ResponseCode = "78";    //No Account
                return msg;
            }
            if (da.GetOneAccount(cr_account)==null)
            {
                logger.Error(string.Format("To account {0} does not found", cr_account));
                msg.ResponseCode = "78";    //No Account
                return msg;
            }
            // kiểm tra số dư chuyển khoản.
            Tranday_Info ti = new Tranday_Info();
            ti.AllowReverse = true;
            ti.Branch_ID = branch_id;
            ti.Descript = string.Format("transfer from {0} to {1} with amount = {2}",db_account,cr_account,amount);
            ti.NextDocId = "";
            ti.Status = TransactionStatus.Approved;
            ti.TranCode = fundtransfer_trancode;
            ti.TransDate = transdate;
            ti.UserCreate = user_id;
            ti.ValueDate = transdate;
            ti.Verified = true;
            ti.Verified_User = user_id;
            ti.Trace = trace;
            ti.DocID = base.GenerateDocId();
            dt.CreateOneTranday(ti);
            D_TrandayDetail dtd;
            TrandayDetail_Info tdi;
            Account_Info ai=new Account_Info();
            D_TranCodeDetail dcd = new D_TranCodeDetail();
            List<TranCodeDetail_Info> list = dcd.GetTranCodeDetailByCode(fundtransfer_trancode);
            foreach (TranCodeDetail_Info tcdi in list)
            {
                dtd = new D_TrandayDetail();
                tdi = new TrandayDetail_Info();
                switch (tcdi.CreditDebit)
                {
                    case  CreditDebit.DB:
                        if (db_account.IndexOf(tcdi.Account_ID) != 0)
                        {
                            // không xác định được nhóm tài khoản khách hàng
                            if (logger.IsErrorEnabled)
                                logger.Error(string.Format("{0} not in group {1}", db_account, tcdi.Account_ID));
                            msg.ResponseCode = "78";    //No Account
                            return msg;
                        }
                        tdi.Account_ID = db_account;
                        tdi.DB_Amount = amount;
                        ai = da.GetOneAccount(tdi.Account_ID);
                        ai.y_Debit += amount;
                        ai.q_Debit += amount;
                        ai.m_Debit += amount;
                        ai.w_Debit += amount;
                        ai.d_Debit += amount;
                        tdi.Ccy = ai.Ccy;
                        break;
                    case CreditDebit.CR:
                        if (cr_account.IndexOf(tcdi.Account_ID) != 0)
                        {
                            // không xác định được nhóm tài khoản khách hàng
                            if (logger.IsErrorEnabled)
                                logger.Error(string.Format("{0} not in group {1}", cr_account, tcdi.Account_ID));
                            msg.ResponseCode = "78";    //No Account
                            return msg;
                        }
                        tdi.Account_ID = cr_account;
                        tdi.CR_Amount = amount;
                        ai = da.GetOneAccount(tdi.Account_ID);
                        ai.y_Credit += amount;
                        ai.q_Credit += amount;
                        ai.m_Credit += amount;
                        ai.w_Credit += amount;
                        ai.d_Credit += amount;
                        tdi.Ccy = ai.Ccy;
                        break;
                }
                tdi.SEQ = tcdi.SEQ;
                tdi.DocID = ti.DocID;
                dt.AddCommand(dtd.CreateOneTrandayDetail(tdi));
                dt.AddCommand(da.EditOneAccount(ai));
            }
            if (dt.Execute() == true)
            {
                if (logger.IsDebugEnabled)
                    logger.Debug(string.Format("Done transfer from {0} to {1}", db_account, cr_account));
                msg.ResponseCode = "00";    //Approved
                return msg;
            }
            else
            {
                if (logger.IsErrorEnabled)
                    logger.Error(string.Format("Fails transfer from {0} to {1}", db_account, cr_account));
                msg.ResponseCode = "06";    //Error
                return msg;
            }
        }
        /// <summary>
        /// tạo mới một giao dịch đảo ngược
        /// thêm một bản ghi vào bảng tranday
        /// thêm một bản ghi vào bảng trandaydetail
        /// nhưng với số tiền ghi âm mục đich triệt tiêu doanh số
        /// </summary>
        /// <param name="docid">
        /// số chứng từ hay mã số giao dịch cần đảo ngược
        /// hệ thống sẽ sinh ra số chứng từ mới hạch toán âm
        /// với số chứng từ là số chứng từ cần đảo ngược cộng với 2 ký tự ".1"
        /// </param>
        /// <returns>
        /// giá trị trả về là số giao dịch được tạo (1)
        /// nếu lỗi trả về giá trị 0
        /// </returns>
        public ResponseMessage Reverse(string trace, string docid)
        {
            ResponseMessage msg = new ResponseMessage();
            try
            {
                msg.LocalDate = DateTime.Now.ToString("MMdd");
                msg.LocalTime = DateTime.Now.ToString("hhmmss");

                D_Tranday dt = new D_Tranday();
                Tranday_Info ti = dt.GetOneTranday(trace);
                if (ti == null)
                {
                    logger.Error(string.Format("Transaction {0} does not exists", trace));
                    msg.ResponseCode="12";  // Invalid transaction
                    return msg;
                }
                if (ti.AllowReverse == false)
                {
                    logger.Error(string.Format("Transaction {0} does not allow reverse", trace));
                    msg.ResponseCode = "06";  // Error
                    return msg;
                }
                // cập nhật hồ sơ giao dịch không cho cho phép đảo ngược nữa
                ti.AllowReverse = false;
                dt.EditOneTranday(ti);
                ti.Descript = string.Format("REVERSE: {0}", trace);
                ti.DocID = base.GenerateDocId();
                ti.Trace = trace;
                ti.OtherRef = docid;
                ti.NextDocId = "";
                ti.Status = TransactionStatus.Approved;
                ti.TransDate = transdate;
                ti.ValueDate = transdate;
                ti.Verified = true;
                ti.Verified_User = user_id;
                ti.UserCreate = user_id;
                dt.CreateOneTranday(ti);
                D_Account da = new D_Account();
                Account_Info ai;
                D_TrandayDetail dtd = new D_TrandayDetail();
                foreach (TrandayDetail_Info tdi in ti.TrandayDetails)
                { 
                    tdi.CR_Amount *= -1;
                    tdi.DB_Amount *= -1;
                    tdi.DocID = ti.DocID;
                    dt.AddCommand(dtd.CreateOneTrandayDetail(tdi));

                    ai = da.GetOneAccount(tdi.Account_ID);
                    // ghi có tài khoản.
                    ai.y_Credit += tdi.CR_Amount;
                    ai.q_Credit += tdi.CR_Amount;
                    ai.m_Credit += tdi.CR_Amount;
                    ai.w_Credit += tdi.CR_Amount;
                    ai.d_Credit += tdi.CR_Amount;
                    // ghi nợ tài khoản.
                    ai.y_Debit += tdi.DB_Amount;
                    ai.q_Debit += tdi.DB_Amount;
                    ai.m_Debit += tdi.DB_Amount;
                    ai.w_Debit += tdi.DB_Amount;
                    ai.d_Debit += tdi.DB_Amount;
                    dt.AddCommand(da.EditOneAccount(ai));
                }
                if (dt.Execute())
                { 
                    // nếu thực hiện thành công
                    if (logger.IsDebugEnabled)
                        logger.Debug(string.Format("Done create new merchant transaction: {0}",ti.DocID));
                    msg.ResponseCode = "00";  // Approved
                    return msg;
                }
                else
                {
                    if (logger.IsErrorEnabled)
                        logger.Error(string.Format("Fails create new one merchant transaction: {0}", ti.DocID));
                    msg.ResponseCode = "06";  // Error
                    return msg;
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                msg.ResponseCode = "06";  // Error
                return msg;
            }
        }
        /// <summary>
        /// Hàm check messages iso8583
        /// </summary>
        /// <returns>
        /// Trả về kết quả thực hiện
        /// </returns>
        public ResponseMessage NetworkMessages()
        {
            // trả về kết quả thành công
            ResponseMessage msg = new ResponseMessage();
            msg.ResponseCode = "00";    // Approved
            msg.LocalDate = DateTime.Now.ToString("MMdd");
            msg.LocalTime = DateTime.Now.ToString("hhmmss");

            return msg;
        }
    }
}
