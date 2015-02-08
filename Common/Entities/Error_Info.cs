using System;
using System.Collections.Generic;
using System.Text;

namespace Account.Common.Entities
{
    public class Error_Info
    {
        private int _erCode;
        private string _enMsg;
        private string _vnMsg;
        private string _iso8583;

        public int Code
        { get { return _erCode; } set { _erCode = value; } }
        public string EN_Message
        { get { return _enMsg; } set { _enMsg = value; } }
        public string VN_Message
        { get { return _vnMsg; } set { _vnMsg = value; } }
        public string ISO8583
        { get { return _iso8583; } set { _iso8583 = value; } }
        public Error_Info()
        { }
        public Error_Info(int code, string enMsg, string vnMsg, string iso8583)
        {
            this.Code = code;
            this.EN_Message = enMsg;
            this.VN_Message = vnMsg;
            this.ISO8583 = iso8583;
        }
    }
}