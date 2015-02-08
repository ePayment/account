using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime;
using System.Runtime.Serialization;
using System.ServiceModel;

using System.Text;
using System.Diagnostics;
using System.Xml;

using log4net;

using Account.Business;
using Account.Common.Entities;

namespace Account.Host
{
    [ServiceContract]
    public interface IAccountService
    {
        [OperationContract]
        string Request(string xmlstring);
        [OperationContract]
        string Echo();
    }
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class AccountService : IAccountService
    {
        private XmlDocument _doc = null;
        private xml_response _resXml = null;
        private xml_request _reqXml = null;
        private ChannelAccount _meA = null;
        private MakeTranday _meT = null;
        private ChannelCustomer _meCust = null;
        ILog logger;
        private Channel_Info _channel;

        public AccountService(Channel_Info channel)
        {
            try
            {
                logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
                _channel = channel;
                Start(channel);
            }
            catch (Exception ex)
            { throw ex; }
        }
        private void Start(Channel_Info channel)
        {
            _meT = new MakeTranday(channel);
            _meA = new ChannelAccount(channel);
            _doc = new XmlDocument();
            _meCust = new ChannelCustomer(channel);
        }
        public string Request(string xmlstring)
        {
            try
            {
                _resXml = new xml_response();
                _resXml.function_name = "Request";
                if (logger.IsDebugEnabled)
                    logger.Debug(string.Format("Request String {0}", xmlstring));
                if (_channel.Security == true)
                { _reqXml = new xml_request(_channel.Key, xmlstring); }
                else
                { _reqXml = new xml_request(xmlstring); }

                // không xác định được chuối ký tự yêu cầu.
                if (_reqXml.ValidData == false)
                { _resXml.SetError("98", "Invalid data input"); }
                else
                {
                    _doc = (_reqXml.doc);

                    //====== DEBUG ======
                    if (logger.IsDebugEnabled)
                        logger.Debug(string.Format("Request String (DECRYPT)\n{0}", _doc.InnerXml));
                    //====== DEBUG ======

                    // kết nối đã được khởi tạo
                    // thực hiện hàm
                    XmlNode node = _doc.SelectSingleNode("//request/function_name");
                    switch (node.InnerText.ToLower())
                    {
                        case "opencustomer":
                            OpenOneCustomer(_doc);
                            break;
                        case "openaccount":
                            OpenOneAccount(_doc);
                            break;
                        case "closeaccount":
                            CloseOneAccount(_doc);
                            break;
                        case "retail":
                            Retail(_doc);
                            break;
                        case "addfund":
                            AddFund(_doc);
                            break;
                        case "reverse":
                            Reverse(_doc);
                            break;
                        case "fundtransfer":
                            FundTransfer(_doc);
                            break;
                        case "customer":
                            Customer(_doc);
                            break;
                        case "account":
                            Account(_doc);
                            break;
                        case "transaction":
                            Transaction(_doc);
                            break;
                        case "user":
                            User(_doc);
                            break;
                        default:
                            // không tìm thấy hàm thực hiện chức năng này
                            _resXml.SetError("97", "Invalid function");
                            //ServiceTest st = new ServiceTest(_doc);
                            //_resXml = st.Response;
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                _resXml.SetError("99", ex.Message);
                _resXml.function_name = this.ToString() + ".Request(string xmlstring)";
                logger.Error(string.Format("{0}", ex.Message));
            }
            // ==========================
            // Trả kế quả về cho client
            // ==========================
            if (_channel.Security == true)
            { return _resXml.response_string(_channel.Key); }
            else
            { return _resXml.response_string(); }
        }
        public string Echo()
        {
            if (logger.IsDebugEnabled)
                logger.Debug(string.Format("Hello done"));
            return "Hello done";
        }
        #region "fund service"
        /// <summary>
        /// hàm mở hồ sơ khách hàng
        /// </summary>
        /// <param name="req">chuỗi ký tự theo định dạng xml</param>
        private void OpenOneCustomer(XmlDocument req)
        {
            string cust_name;
            string cust_cert;
            string cust_add;
            try
            {
                _resXml.function_name = this.ToString() + ".OpenOneCustomer";
                if (req.SelectSingleNode("//request/name") != null && string.IsNullOrEmpty(req.SelectSingleNode("//request/name").InnerText) == false)
                    cust_name = req.SelectSingleNode("//request/name").InnerText;
                else
                {
                    _resXml.SetError("98", "Customer name is null or empty");
                    return;
                }
                if (req.SelectSingleNode("//request/identity_card") != null && string.IsNullOrEmpty(req.SelectSingleNode("//request/identity_card").InnerText) == false)
                    cust_cert = req.SelectSingleNode("//request/identity_card").InnerText;
                else
                {
                    _resXml.SetError("98", "Customer identity card is null or empty");
                    return;
                }
                if (req.SelectSingleNode("//request/address") != null && string.IsNullOrEmpty(req.SelectSingleNode("//request/address").InnerText) == false)
                    cust_add = req.SelectSingleNode("//request/address").InnerText;
                else
                {
                    _resXml.SetError("98", "Customer address is null or empty");
                    return;
                }

                _resXml = _meCust.Insert(cust_name, cust_add, cust_cert);
            }
            catch (Exception ex)
            {
                _resXml.SetError("99", ex.Message);
            }

        }
        /// <summary>
        /// Hàm lấy thông tin khách hàng theo mã khách hàng hoặc số chứng minh thư
        /// </summary>
        /// <param name="req">chuỗi ký tự tham số đầu vào</param>
        private void Customer(XmlDocument req)
        {
            try
            {
                _resXml.function_name = this.ToString() + ".Customer";
                if (req.SelectSingleNode("//request/customer_id") != null && string.IsNullOrEmpty(req.SelectSingleNode("//request/customer_id").InnerText) == false)
                {
                    string custId = req.SelectSingleNode("//request/customer_id").InnerText;
                    _resXml = _meCust.GetCustomerById(custId);
                }
                else if (req.SelectSingleNode("//request/identity_card") != null && string.IsNullOrEmpty(req.SelectSingleNode("//request/identity_card").InnerText) == false)
                {
                    string custCert = req.SelectSingleNode("//request/identity_card").InnerText;
                    _resXml = _meCust.GetCustomerByCert(custCert);
                }
                else
                {
                    _resXml.SetError("98", "Invalid parameters");
                }

            }
            catch (Exception ex)
            {
                _resXml.SetError("99", ex.Message);
            }
        }
        /// <summary>
        /// Hàm mở tài khoản mới
        /// </summary>
        /// <param name="req">chuối ký tự định dạng xml</param>
        private void OpenOneAccount(XmlDocument req)
        {
            string custId;
            string catId;
            try
            {
                _resXml.function_name = this.ToString() + ".OpenOneAccount";
                if (req.SelectSingleNode("//request/customer_id") != null && string.IsNullOrEmpty(req.SelectSingleNode("//request/customer_id").InnerText) == false)
                    custId = req.SelectSingleNode("//request/customer_id").InnerText;
                else
                {
                    _resXml.SetError("98", "Customer id is null or empty");
                    return;
                }
                if (req.SelectSingleNode("//request/categories_id") != null && string.IsNullOrEmpty(req.SelectSingleNode("//request/categories_id").InnerText) == false)
                    catId = req.SelectSingleNode("//request/categories_id").InnerText;
                else
                {
                    _resXml.SetError("98", "Categories id is null or empty");
                    return;
                }
                _resXml = _meA.Insert(catId, custId);
            }
            catch (Exception ex)
            {
                _resXml.SetError("99", ex.Message);
            }
        }
        /// <summary>
        /// Hàm đóng tài khoản.
        /// </summary>
        /// <param name="req"></param>
        private void CloseOneAccount(XmlDocument req)
        {
            try
            {
                _resXml.function_name = this.ToString() + ".CloseOneAccount";
                if (req.SelectSingleNode("//request/account_id") != null &&
                    string.IsNullOrEmpty(req.SelectSingleNode("//request/account_id").InnerText) == false)
                    _resXml = _meA.Close(req.SelectSingleNode("//request/account_id").InnerText);
                else
                    _resXml.SetError("98", "account id is null or empty");
            }
            catch (Exception ex)
            {
                _resXml.SetError("99", ex.Message);
            }
        }
        /// <summary>
        /// Hàm nạp tiền vào tài khoản.
        /// </summary>
        /// <param name="req"></param>
        private void AddFund(XmlDocument req)
        { Retail(req); }
        /// <summary>
        /// Hàm bán hàng.
        /// </summary>
        /// <param name="req"></param>
        private void Retail(XmlDocument req)
        {
            string account_id;
            string trancode;
            decimal amount;
            string desc;
            try
            {
                _resXml.function_name = this.ToString() + ".Retail";
                if (req.SelectSingleNode("//request/account_id") != null &&
                    string.IsNullOrEmpty(req.SelectSingleNode("//request/account_id").InnerText) == false)
                    account_id = req.SelectSingleNode("//request/account_id").InnerText;
                else
                {
                    _resXml.SetError("98", "account_id is null or empty");
                    return;
                }
                if (req.SelectSingleNode("//request/trancode") != null &&
                    string.IsNullOrEmpty(req.SelectSingleNode("//request/trancode").InnerText) == false)
                    trancode = req.SelectSingleNode("//request/trancode").InnerText;
                else
                {
                    _resXml.SetError("98", "trancode is null or empty");
                    return;
                }
                if (req.SelectSingleNode("//request/amount") != null &&
                    string.IsNullOrEmpty(req.SelectSingleNode("//request/amount").InnerText) == false)
                    amount = Convert.ToDecimal(req.SelectSingleNode("//request/amount").InnerText);
                else
                {
                    _resXml.SetError("98", "amount is null or empty");
                    return;
                }
                if (req.SelectSingleNode("//request/descript") != null &&
                    string.IsNullOrEmpty(req.SelectSingleNode("//request/descript").InnerText) == false)
                    desc = req.SelectSingleNode("//request/descript").InnerText;
                else
                {
                    desc = "";
                }
                _resXml = _meT.Retail(trancode, account_id, amount, desc);
            }
            catch (Exception ex)
            {
                _resXml.SetError("99", ex.Message);
            }
        }
        /// <summary>
        /// Hàm tạo bút toán hủy bút toán đã được tạo
        /// </summary>
        /// <param name="req"></param>
        private void Reverse(XmlDocument req)
        {
            string doc_id;
            _resXml = new xml_response();
            try
            {
                _resXml.function_name = this.ToString() + ".Reverse()";
                if (req.SelectSingleNode("//request/doc_id") != null &&
                    string.IsNullOrEmpty(req.SelectSingleNode("//request/doc_id").InnerText) == false)
                {
                    doc_id = req.SelectSingleNode("//request/doc_id").InnerText;
                    _resXml = _meT.Reverse(doc_id);
                }
                else
                    _resXml.SetError("98", "doc_id is null or empty");

            }
            catch (Exception ex)
            {
                _resXml.SetError("99", ex.Message);
            }
        }
        /// <summary>
        /// hàm cung cấp thông tin tài khoản
        /// </summary>
        /// <param name="req"></param>
        private void Account(XmlDocument req)
        {
            string account_id;
            try
            {
                _resXml.function_name = this.ToString() + ".Account";
                if (req.SelectSingleNode("//request/account_id") != null &&
                    string.IsNullOrEmpty(req.SelectSingleNode("//request/account_id").InnerText) == false)
                {
                    account_id = req.SelectSingleNode("//request/account_id").InnerText;
                    _resXml = _meA.GetAccountById(account_id);
                }
                else
                    _resXml.SetError("99", "account_id is null or empty");
            }
            catch (Exception ex)
            {
                _resXml.SetError("99", ex.Message);
            }
        }
        /// <summary>
        /// hàm cung cấp thông tin giao dịch trong ngày
        /// </summary>
        /// <param name="req"></param>
        private void Transaction(XmlDocument req)
        {
            string doc_id;
            try
            {
                _resXml.function_name = _resXml.function_name + ".Transaction";
                if (req.SelectSingleNode("//request/doc_id") != null &&
                    string.IsNullOrEmpty(req.SelectSingleNode("//request/doc_id").InnerText) == false)
                {
                    doc_id = req.SelectSingleNode("//request/doc_id").InnerText;

                    _resXml = _meT.GetOneTransaction(doc_id);
                }
                else
                    _resXml.SetError("99", "doc_id is null or empty");
            }
            catch (Exception ex)
            {
                _resXml.SetError("99", ex.Message);
            }
        }
        /// <summary>
        /// Hàm chuyển khoản
        /// </summary>
        /// <param name="req"></param>
        private void FundTransfer(XmlDocument req)
        {
            string trancode;
            string from_acc;
            string to_acc;
            decimal amnt;
            string desc;
            try
            {
                _resXml.function_name = this.ToString() + ".FundTransfer";
                // lấy tham số
                if (req.SelectSingleNode("//request/trancode") != null &&
                    string.IsNullOrEmpty(req.SelectSingleNode("//request/trancode").InnerText) == false)
                    trancode = req.SelectSingleNode("//request/trancode").InnerText;
                else
                {
                    _resXml.SetError("98", "trancode is null or empty");
                    return;
                }
                if (req.SelectSingleNode("//request/db_account_id") != null &&
                    string.IsNullOrEmpty(req.SelectSingleNode("//request/db_account_id").InnerText) == false)
                    from_acc = req.SelectSingleNode("//request/db_account_id").InnerText;
                else
                {
                    _resXml.SetError("98", "db_account_id is null or empty");
                    return;
                }
                if (req.SelectSingleNode("//request/cr_account_id") != null &&
                    string.IsNullOrEmpty(req.SelectSingleNode("//request/cr_account_id").InnerText) == false)
                    to_acc = req.SelectSingleNode("//request/cr_account_id").InnerText;
                else
                {
                    _resXml.SetError("98", "cr_account_id is null or empty");
                    return;
                }
                if (req.SelectSingleNode("//request/amount") != null &&
                    string.IsNullOrEmpty(req.SelectSingleNode("//request/amount").InnerText) == false)
                    amnt = Convert.ToDecimal(req.SelectSingleNode("//request/amount").InnerText);
                else
                {
                    _resXml.SetError("98", "amount is null or empty");
                    return;
                }
                if (req.SelectSingleNode("//request/descript") != null &&
                    string.IsNullOrEmpty(req.SelectSingleNode("//request/descript").InnerText) == false)
                    desc = req.SelectSingleNode("//request/descript").InnerText;
                else
                    desc = "";
                _resXml = _meT.Fundtransfer(trancode, from_acc, to_acc, amnt, desc);
            }
            catch (Exception ex)
            {
                _resXml.SetError("99", ex.Message);
            }
        }

        private void User(XmlDocument req)
        {
            string userId;
            string fullName;
            string pass;
            string branchId;
            try
            {
                _resXml.function_name = this.ToString() + ".User";

                if (req.SelectSingleNode("//request/userid") != null &&
                    string.IsNullOrEmpty(req.SelectSingleNode("//request/userid").InnerText) == false)
                    userId =req.SelectSingleNode("//request/userid").InnerText;
                else
                {
                    _resXml.SetError("98","UserID is null or empty");
                    return;
                }
                if (req.SelectSingleNode("//request/name") != null &&
                    string.IsNullOrEmpty(req.SelectSingleNode("//request/name").InnerText) == false)
                    fullName = req.SelectSingleNode("//request/name").InnerText;
                else
                {
                    _resXml.SetError("98","User Name is null or empty");
                    return;
                }
                if (req.SelectSingleNode("//request/password") != null &&
                    string.IsNullOrEmpty(req.SelectSingleNode("//request/password").InnerText) == false)
                    pass = req.SelectSingleNode("//request/password").InnerText;
                else
                {
                    _resXml.SetError("98", "User password is null or empty");
                    return;
                }
                if (req.SelectSingleNode("//request/branchid") != null &&
                    string.IsNullOrEmpty(req.SelectSingleNode("//request/branchid").InnerText) == false)
                    branchId = req.SelectSingleNode("//request/branchid").InnerText;
                else
                {
                    _resXml.SetError("98", "User branch is null or empty");
                    return;
                }
                User myU = new User();
                User_Info uInfo = new User_Info();
                uInfo.User_ID = userId;
                uInfo.FullName = fullName;
                uInfo.Branch_ID = branchId;
                uInfo.Password = pass;
                if (myU.Insert(uInfo) == 0)
                { _resXml.SetError("99", myU.Error_Message); }
            }
            catch (Exception ex)
            {

                _resXml.SetError("99", ex.Message);
            }
        }

        #endregion

    }
}
