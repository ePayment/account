using System;
using System.Collections.Generic;
using System.Text;

using Account.Common.Entities;
using Account.Business.Base;
using Account.Business;

using log4net;

namespace Account.Business
{
    public class ChannelAccount:Account
    {
        private Account_Info _acc;
        
        private xml_response _res;
        private ILog logger;
        private Channel_Info _channel;

        public ChannelAccount(Channel_Info channel)
        {
            _channel = channel;
            logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        }
        /// <summary>
        /// Get one Account detail
        /// </summary>
        /// <param name="accountId"></param>
        /// <returns>Account_Info</returns>
        public new xml_response GetAccountById(string accountId)
        {
            try
            {
                _res = new xml_response();
                _res.function_name = this.ToString() + string.Format(".GetAccountById({0})", accountId);
                if (logger.IsDebugEnabled)
                    logger.Debug(string.Format("Start function: {0}", _res.function_name));
                Account_Info ai = base.GetAccountById(accountId);
                if (ai == null)
                {
                    // không tìm thấy thông tin tài khoản.
                    _res.SetError("11", string.Format("Account: {0} not found", accountId));
                    if (logger.IsErrorEnabled)
                        logger.Error(string.Format("{0}\t{1}", _res.error_code, _res.error_msg));
                }
                else
                {
                    _res.Accounts = ai.RenderXML();
                }
            }
            catch(Exception ex)
            {
                if (logger.IsErrorEnabled)
                    logger.Error(ex);
                throw;
            }
            return _res;
        }
        /// <summary>
        /// Tạo mới tài khoản
        /// </summary>
        /// <param name="custName">tên khách hàng</param>
        /// <param name="custAdd">địa chỉ khách hàng</param>
        /// <param name="custCert">số chứng minh thư hoặc hỗ chiếu (duy nhất không được trùng với khách hàng đã có)</param>
        /// <returns>thông tin tài khoản chi tiết được tạo mới 
        /// hoặc thông tin tài khoản đã được mở trước đó</returns>
        public xml_response Insert(string custId)
        {
            return Insert(_channel.Categories, custId);
        }
        /// <summary>
        /// Mở tài khoản theo Categories và mã khách hàng
        /// </summary>
        /// <param name="categories">Mã sản phẩm</param>
        /// <param name="custId">Mã khách hàng</param>
        /// <returns>chuỗi ký tự thông tin tài khoản chi tiết được mở theo định dạng
        /// xml hoặc chuối ký tự lỗi định dạng xml</returns>
        public xml_response Insert(string categories, string custId)
        {
            try
            {
                _res = new xml_response();
                _res.function_name = this.ToString() + string.Format(".Insert({0},{1})", categories, custId);
                Customer bcust = new Customer();
                Customer_Info custInfo = bcust.GetCustomerByID(custId);
                if (custInfo == null)
                {
                    _res.SetError("01", "Customer can not find");
                    if (logger.IsErrorEnabled)
                        logger.Error(string.Format("{0}\t{1}", _res.error_code, _res.error_msg));
                    return _res;
                }
                else
                {
                    if (custInfo.Active == false)
                    {
                        _res.SetError("03", "Customers have not been approved");
                        if (logger.IsErrorEnabled)
                            logger.Error(string.Format("{0}\t{1}", _res.error_code, _res.error_msg));
                        return _res;
                    }
                }
                Categories dalCat = new Categories();
                Categories_Info catInfo = dalCat.GetCategoriesByID(categories);
                if (catInfo == null)
                {
                    _res.SetError("98", string.Format("Categories Id {0} can not find", categories));
                    if (logger.IsErrorEnabled)
                        logger.Error(string.Format("{0}\t{1}", _res.error_code, _res.error_msg));
                    return _res;
                }

                Account_Info acInfo = GetAccountBy(_channel.Branch, categories, custId);
                if (acInfo == null)
                {
                    // Khởi tạo thông tin mở tài khoản.
                    acInfo = new Account_Info();
                    acInfo.Name = custInfo.Name; // tên tài khoản.
                    acInfo.Customer_ID = custInfo.ID; // Mã khách hàng.
                    acInfo.Branch_ID = _channel.Branch;
                    acInfo.Categories = categories;
                    acInfo.Ccy = _channel.Currency_Code;
                    acInfo.Account_GL = catInfo.Account_GL.Account_ID;
                    acInfo.CreditDebit = catInfo.Account_GL.CreditDebit;
                    acInfo.Approved = true;
                    acInfo.ApprovedTime = DateTime.Now;
                    acInfo.UserCreate = _channel.UserLogin;
                    acInfo.Account_ID = GenerateNewAccountId(acInfo.Branch_ID, acInfo.Categories);
                    acInfo.Open_Date = DateTime.Now;
                    acInfo.Last_Date = DateTime.Now;
                    // thực hiện mở tài khoản.
                    if (Insert(acInfo) == 0)
                        _res.Accounts = acInfo.RenderXML();
                    else
                    {
                        // Lấy nội dung lỗi
                        _res.SetError("99", dalAc.GetException.Message);
                        if (logger.IsErrorEnabled)
                            logger.Error(string.Format("{0}\t{1}", _res.error_code, _res.error_msg));
                        return _res;
                    }
                }
                else
                {
                    // tài khoản đã được mở
                    _res.SetError("12", "Account opened");
                    if (logger.IsErrorEnabled)
                        logger.Error(string.Format("{0}\t{1}", _res.error_code, _res.error_msg));
                }
            }
            catch (Exception ex)
            {
                _res.SetError("99", ex.Message);
                if (logger.IsErrorEnabled)
                    logger.Error(string.Format("{0}\t{1}", _res.error_code, _res.error_msg));
            }
            return _res;
        }
        /// <summary>
        /// Hàm khóa một phần hay toàn bộ số dư tài khoản
        /// </summary>
        /// <param name="accountId"></param>
        /// <param name="amnt"></param>
        /// <returns></returns>
        public new xml_response Block(string accountId, decimal amnt)
        {
            try
            {
                _res = new xml_response();
                _res.function_name = this.ToString() + string.Format(".Block({0}, {1})", accountId, amnt);
                if (logger.IsDebugEnabled)
                    logger.Debug(string.Format("Start function: {0}", _res.function_name));
                //D_Account da = new D_Account();
                Account da = new Account();
                Account_Info ai = da.GetAccountByID(accountId);
                if (ai == null)
                {
                    _res.SetError("11", string.Format("Account {0} can not find", accountId));
                    if (logger.IsErrorEnabled)
                        logger.Error(string.Format("{0}\t{1}", _res.error_code, _res.error_msg));
                    return _res;
                }
                if (ai.BalanceAvaiable > amnt)
                {
                    _res.SetError("14", "Account balance is not enough");
                    if (logger.IsErrorEnabled)
                        logger.Error(string.Format("{0}\t{1}", _res.error_code, _res.error_msg));
                    return _res;
                }

                // thực hiện khóa số dư
                if (base.Block(ai, amnt) == 0)
                {
                    // Khóa không thành công
                    _res.SetError("99", base.Error_Message);
                    if (logger.IsErrorEnabled)
                        logger.Error(string.Format("{0}\t{1}", _res.error_code, _res.error_msg));
                }
            }catch(Exception ex)
            {
                if (logger.IsErrorEnabled)
                    logger.Error(ex);
                throw;
            }
            return _res;
        }
        /// <summary>
        /// hàm bỏ khóa số dư tài khoản
        /// </summary>
        /// <param name="accountId"></param>
        /// <param name="amnt"></param>
        /// <returns></returns>
        public new xml_response UnBlock(string accountId, decimal amnt)
        {
            try
            {
                _res = new xml_response();
                _res.function_name = this.ToString() + string.Format(".UnBlock({0}, {1})", accountId, amnt);
                if (logger.IsDebugEnabled)
                    logger.Debug(string.Format("Start function: {0}", _res.function_name));
                //D_Account da = new D_Account();
                Account da = new Account();
                Account_Info ai = da.GetAccountByID(accountId);
                if (ai == null)
                {
                    _res.SetError("11", string.Format("Account {0} can not find", accountId));
                    if (logger.IsErrorEnabled)
                        logger.Error(string.Format("{0}\t{1}", _res.error_code, _res.error_msg));
                    return _res;
                }
                if (ai.BalanceAvaiable < amnt)
                {
                    _res.SetError("14", "Account balance is not enough");
                    if (logger.IsErrorEnabled)
                        logger.Error(string.Format("{0}\t{1}", _res.error_code, _res.error_msg));
                    return _res;
                }

                // Thực hiện bỏ khóa số dư
                if (base.UnBlock(ai, amnt) == 0)
                {
                    // mở khóa số dư không thành công
                    _res.SetError("99", base.Error_Message);
                    if (logger.IsErrorEnabled)
                        logger.Error(string.Format("{0}\t{1}", _res.error_code, _res.error_msg));
                }
            }
            catch(Exception ex)
            {
                if(logger.IsErrorEnabled)
                    logger.Error(ex);
                throw;
            }
            return _res;
        }
        /// <summary>
        /// Hàm đóng tài khoản.
        /// </summary>
        /// <param name="accountId">Mã tài khoản</param>
        /// <returns></returns>
        public new xml_response Close(string accountId)
        {
            try
            {
                _res = new xml_response();
                _res.function_name = this.ToString() + string.Format(".Close({0})", accountId);
                if (logger.IsDebugEnabled)
                    logger.Debug(string.Format("Start function: {0}", _res.function_name));

                //var da = new D_Account();
                var da = new Account();
                _acc = da.GetAccountByID(accountId);
                if (_acc == null)
                {
                    // tài khoản không tìm thấy
                    _res.SetError("11", string.Format("Account_ID: {0} can not find", accountId));
                    if (logger.IsErrorEnabled)
                        logger.Error(string.Format("{0}\t{1}", _res.error_code, _res.error_msg));
                    return _res;
                }
                else
                {
                    if (_acc.Balance != 0)
                    {
                        // tài khoản vẫn còn số dư
                        _res.SetError("19",
                                      string.Format("Account_ID: {0} not allowed to close while still balance",
                                                    accountId));
                        if (logger.IsErrorEnabled)
                            logger.Error(string.Format("{0}\t{1}", _res.error_code, _res.error_msg));
                        return _res;
                    }
                    if (!_acc.Approved )
                    {
                        // tài khoản chưa được duyệt
                        _res.SetError("13", string.Format("Account_ID: {0} has not been approved", accountId));
                        if (logger.IsErrorEnabled)
                            logger.Error(string.Format("{0}\t{1}", _res.error_code, _res.error_msg));
                        return _res;
                    }
                    if (_acc.Closed)
                    {
                        // tài khoản đã được đóng
                        _res.SetError("21", string.Format("Account_ID: {0} closed", accountId));
                        if (logger.IsErrorEnabled)
                            logger.Error(string.Format("{0}\t{1}", _res.error_code, _res.error_msg));
                        return _res;
                    }
                }

                // thực hiện đóng tài khoản.
                if (Close(_acc) == 0)
                {
                    // đóng tài khoản không thành công
                    _res.SetError("99", base.Error_Message);
                    if (logger.IsErrorEnabled)
                        logger.Error(string.Format("{0}\t{1}", _res.error_code, _res.error_msg));
                }
            }
            catch (Exception ex)
            {
                if (logger.IsErrorEnabled)
                    logger.Error(ex);
                throw;
            }
            return _res;
        }
    }
}
