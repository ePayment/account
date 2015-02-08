using System;
using System.Collections.Generic;
using System.Text;

using Account.Business.Base;
using Account.Common.Entities;
using Account.Common.Utilities;

namespace Account.Business
{
    public partial class AccountGL:BaseAccountGL
    {
        public int Insert(string accountId, string name, string branch, AccountType creditdebit, string currency)
        {
            if (string.IsNullOrEmpty(accountId))
            {
                SetError (98,"Invalid account Id");
                return Error_Number;
            }
            if (string.IsNullOrEmpty(name))
            {
                SetError(98, "Invalid account name");
                return Error_Number;
            }
            if (string.IsNullOrEmpty(creditdebit.ToString()))
            {
                SetError(98, "Invalid account credit/debit");
                return Error_Number;
            }
            if (string.IsNullOrEmpty(currency))
            {
                SetError(98, "Invalid currency");
                return Error_Number;
            }
            Account_GL_Info acGLInfo = new Account_GL_Info();
            acGLInfo.Account_ID = accountId;
            acGLInfo.Name = name;
            acGLInfo.Branch_ID = branch;
            acGLInfo.Ccy = currency;
            acGLInfo.CreditDebit = creditdebit;
            if (base.Insert(acGLInfo) != 0)
                SetError(0, String.Empty);
            else
                SetError(99, _dalAcGL.GetException.Message);
            return Error_Number;
        }
        public int Update(string accountId, string name, string branch, AccountType creditdebit, string currency)
        {
            if (string.IsNullOrEmpty(accountId))
            {
                SetError(98, "Invalid account Id");
                return Error_Number;
            }
            if (string.IsNullOrEmpty(name))
            {
                SetError(98, "Invalid account name");
                return Error_Number;
            }
            if (string.IsNullOrEmpty(creditdebit.ToString()))
            {
                SetError(98, "Invalid account credit/debit");
                return Error_Number;
            }
            if (string.IsNullOrEmpty(currency))
            {
                SetError(98, "Invalid currency");
                return Error_Number;
            }
            Account_GL_Info acGLInfo = base.GetAccountGLByID(accountId);
            if (acGLInfo == null)
            {
                SetError(99, "Account GL not find");
                return Error_Number;
            }
            acGLInfo.Name = name;
            acGLInfo.Branch_ID = branch;
            acGLInfo.Ccy = currency;
            acGLInfo.CreditDebit = creditdebit;
            if (base.Update(acGLInfo) != 0)
                SetError(0, String.Empty);
            else
                SetError(99, _dalAcGL.GetException.Message);
            return Error_Number;
        }
        public int Delete(string accountId)
        {
            if (string.IsNullOrEmpty(accountId))
            {
                SetError(98, "Invalid account Id");
                return Error_Number;
            }
            Account_GL_Info acGLInfo = base.GetAccountGLByID(accountId);
            if (acGLInfo == null)
            {
                SetError(99, "Account GL not find");
                return Error_Number;
            }
            if (base.Delete(acGLInfo) != 0)
                SetError(0, String.Empty);
            else
                SetError(99, _dalAcGL.GetException.Message);
            return Error_Number;
        }
        public new Account_GL_Info GetAccountGLByID(string accountId)
        { return base.GetAccountGLByID(accountId); }
        public new List<Account_GL_Info> GetAllAccountGL()
        { return base.GetAllAccountGL(); }
    }
}
