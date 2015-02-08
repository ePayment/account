using System;
using System.Collections.Generic;
using System.Text;
using Account.Common.Entities;
using Account.Business.Base;
using log4net;

namespace Account.Business
{
    public class ChannelCustomer:BaseCustomer
    {
        private xml_response _res;
        private Channel_Info _channel;
        protected ILog Logger;

        public ChannelCustomer(Channel_Info channel):base()
        {
            _channel = channel;
            Logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        }
        public xml_response Insert(string custName, string custAdd, string custCert)
        {
            try
            {
                _res = new xml_response();
                _res.function_name = this.ToString() +
                                     string.Format(".Insert({0},{1},{2})", custName, custAdd, custCert);
                if (string.IsNullOrEmpty(custName))
                {
                    _res.SetError("98", "Customer name is null or empty");
                    if (Logger.IsDebugEnabled)
                        Logger.Debug(string.Format("{0}\t{1}", _res.error_code, _res.error_msg));
                    return _res;
                }
                if (string.IsNullOrEmpty(custAdd))
                {
                    _res.SetError("98", "Customer address is null or empty");
                    if (Logger.IsDebugEnabled)
                        Logger.Debug(string.Format("{0}\t{1}", _res.error_code, _res.error_msg));
                    return _res;
                }
                if (string.IsNullOrEmpty(custCert))
                {
                    _res.SetError("98", "Customer identity card is null or empty");
                    if (Logger.IsDebugEnabled)
                        Logger.Debug(string.Format("{0}\t{1}", _res.error_code, _res.error_msg));
                    return _res;
                }
                if (base.GetCustomerByCert(custCert) != null)
                {
                    _res.SetError("02", "Customer by identity card:" + custCert + " opened");
                    if (Logger.IsDebugEnabled)
                        Logger.Debug(string.Format("{0}\t{1}", _res.error_code, _res.error_msg));
                    return _res;
                }
                if (base.Insert(_channel.Branch,_channel.UserLogin, custName, custAdd, custCert) == 0)
                {
                    _res.SetError("99", GetException.Message);
                    if (Logger.IsDebugEnabled)
                        Logger.Debug(string.Format("{0}\t{1}", _res.error_code, _res.error_msg));
                }
                _res.Customers = base.GetCustomerByCert(custCert).RenderXML();
            }
            catch(Exception ex)
            {
                if (Logger.IsErrorEnabled)
                    Logger.Error(ex);
                throw;
            }
            return _res;
        }
        public new xml_response GetCustomerById(string custId)
        {
            try
            {
                _res = new xml_response();
                _res.function_name = this.ToString() + string.Format(".GetCustomerById({0})", custId);
                if (Logger.IsDebugEnabled)
                    Logger.Debug(string.Format("Start function: {0}", _res.function_name));
                Customer_Info custInfo = base.GetCustomerById(custId);
                if (custInfo==null)
                {
                    _res.SetError("01", string.Format("Customer: {0} not found", custId));
                    if (Logger.IsErrorEnabled)
                        Logger.Error(string.Format("{0}\t{1}", _res.error_code, _res.error_msg));
                }
                else
                {
                    custInfo.Balance = base.Balance(custId);    // lấy số dư theo khách hàng
                    _res.Customers = custInfo.RenderXML();
                }
            }
            catch (Exception ex)
            {
                if (Logger.IsErrorEnabled)
                    Logger.Error(ex);
                throw;
            }
            return _res;
        }
        public new xml_response GetCustomerByCert(string custCert)
        {
            try
            {
                _res = new xml_response();
                _res.function_name = this.ToString() + string.Format(".GetCustomerByCert({0})", custCert);
                if (Logger.IsDebugEnabled)
                    Logger.Debug(string.Format("Start function: {0}", _res.function_name));
                Customer_Info custInfo = base.GetCustomerByCert(custCert);
                if (custInfo == null)
                {
                    _res.SetError("01", string.Format("Customer: {0} not found", custCert));
                    if (Logger.IsErrorEnabled)
                        Logger.Error(string.Format("{0}\t{1}", _res.error_code, _res.error_msg));
                }
                else
                {
                    custInfo.Balance = base.Balance(custInfo.ID);   // lấy số dư theo khách hàng
                    _res.Customers = custInfo.RenderXML();
                }
            }
            catch (Exception ex)
            {
                if (Logger.IsErrorEnabled)
                    Logger.Error(ex);
                throw;
            }
            return _res;
        }
    }
}
