using System;
using System.Collections.Generic;
using System.Text;

using Account.Common.Entities;
using Account.Business;

namespace Account.UIProviders
{
    public static partial class UIAccount_GL
    {
        static AccountGL dal_ac_gl = new AccountGL();
        static StringBuilder bstr = new StringBuilder();

        public static Account_GL_Info GetAccountGLByID(string id)
        {
            if (!string.IsNullOrEmpty(id))
                return dal_ac_gl.GetAccountGLByID(id);
            else
                throw new Exception(dal_ac_gl.Error_Message);
        }
        public static List<Account_GL_Info> GetAll()
        {
            return dal_ac_gl.GetAllAccountGL();
        }
        public static int Insert(Account_GL_Info obj)
        {
            if (Validation(obj))
            {
                return dal_ac_gl.Insert(obj.Account_ID,obj.Name,obj.Branch_ID,obj.CreditDebit,obj.Ccy);
            }
            else
                throw new Exception(dal_ac_gl.Error_Message);
        }
        public static int Update(Account_GL_Info obj)
        {
            if (Validation(obj))
            {
                return dal_ac_gl.Update(obj.Account_ID,obj.Name,obj.Branch_ID,obj.CreditDebit,obj.Ccy);
            }
            else
                throw new Exception(dal_ac_gl.Error_Message);
        }
        public static int Delete(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                return dal_ac_gl.Delete(id);
            }
            else
                throw new Exception(dal_ac_gl.Error_Message);
        }
        private static bool Validation(Account_GL_Info obj)
        {
            bstr = new StringBuilder();
            if (obj == null)
                bstr.Append("Invalid object\n");
            if (string.IsNullOrEmpty(obj.Account_ID))
                bstr.Append("Account_ID is null or empty\n");
            if (string.IsNullOrEmpty(obj.Name))
                bstr.Append("Name is null or empty\n");
            if (string.IsNullOrEmpty(bstr.ToString()))
                return true;
            else
                return false;
        }
        public static string ValidationMessage
        { get { return bstr.ToString(); } }
    }
}
