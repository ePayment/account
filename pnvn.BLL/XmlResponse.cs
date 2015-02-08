using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using Account.Common.Utilities;

namespace Account.Business
{
    public class xml_response : IDisposable
    {
        public string function_name = "";
        public string doc_id = "";
        public string trace = "";
        //public string account_id = "";
        //public string amount = "";
        public string error_code = "";
        public string error_msg = "";
        public string Transactions = "";
        public string Accounts = "";
        public string Customers = "";
        private StringBuilder strB;

        public xml_response()
        {
            function_name = "";
            doc_id = "";
            trace = "";
            //account_id = "";
            //amount = "";
            error_code = "0";
            error_msg = "";
        }

        public string response_string()
        {
            strB = new StringBuilder("");
            if (!String.IsNullOrEmpty(function_name))
            {
                strB.Append("<function_name>");
                strB.Append(function_name);
                strB.Append("</function_name>");
            }
            //if (!String.IsNullOrEmpty(doc_id))
            //{
            //    strB.Append("<doc_id>");
            //    strB.Append(doc_id);
            //    strB.Append("</doc_id>");
            //}
            //if (!String.IsNullOrEmpty(trace))
            //{
            //    strB.Append("<trace>");
            //    strB.Append(trace);
            //    strB.Append("</trace>");
            //}

            if (!String.IsNullOrEmpty(error_code))
            {
                strB.Append("<error_code>");
                strB.Append(error_code);
                strB.Append("</error_code>");
            }
            if (!String.IsNullOrEmpty(error_msg))
            {
                strB.Append("<error_msg>");
                strB.Append(error_msg);
                strB.Append("</error_msg>");
            }
            strB.Append(Customers);
            strB.Append(Accounts);
            strB.Append(Transactions);

            return "<response>" + strB.ToString() + "</response>";
        }
        public string response_string(string key)
        {
            CryptProvider myen = new CryptProvider();
            return myen.Encrypt(key, response_string());
        }
        public void SetError(string code, string msg)
        {
            error_code = code;
            error_msg = msg;
        }
        public void SetError(int code, string msg)
        {
            error_code = code.ToString();
            error_msg = msg;
        }
        public void SetError(int code)
        {
            error_code = code.ToString();
            // Lấy nội dung lỗi từ cơ sở dữ liệu
        }
        public void SetError(int code, string msg, params object[] args)
        {
            error_code = code.ToString();
            error_msg = string.Format(msg, args);
        }
        public void Dispose()
        { }
    }
    public class xml_request : IDisposable
    {
        string source;
        bool _isvalid = false;
        public XmlDocument doc = new XmlDocument();
        public xml_request(string DecryptKey, string string_request)
        {
            try
            {
                _isvalid = false;
                // xâu rỗng đưa vào
                if (String.IsNullOrEmpty(string_request))
                { return; }
                CryptProvider myde = new CryptProvider();
                // giải mã xâu
                source = myde.Decrypt(DecryptKey, string_request);
                // chuyển thành các đối tượng
                doc.LoadXml(source.Trim());
                _isvalid = true;
            }
            catch (Exception ex)
            { throw ex; }
        }
        public xml_request(string string_request)
        {
            try
            {
                _isvalid = false;
                // xâu rỗng đưa vào
                if (String.IsNullOrEmpty(string_request))
                { return; }
                // chuyển thành các đối tượng xml
                doc.LoadXml(string_request);
                _isvalid = true;
            }
            catch (Exception ex)
            { throw ex; }
        }
        public bool ValidData
        { get { return _isvalid; } }
        public void Dispose()
        { doc = null; }
    }

}
