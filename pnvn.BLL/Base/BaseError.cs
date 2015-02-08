using System;
using System.Collections.Generic;
using System.Text;

namespace Account.Business.Base
{
    public partial class BaseError
    {
        private int err_num = 0;
        private string err_msg;
        public int Error_Number
        { get { return err_num; } }
        public string Error_Message
        {get{return err_msg;}}
        public BaseError()
        { }
        public void SetError(int error_number, string error_message)
        {
            err_num = error_number;
            err_msg = error_message;
        }
    }
}
