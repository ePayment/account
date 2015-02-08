using System;
using System.Collections.Generic;
using System.Text;
using Account.Common.Utilities;

namespace Account.Common.Entities
{
    public class Account_GL_Info
    {
        private string _branchId;
        private string _accountId;
        private string _name;
        private AccountType _CreditDebit;
        private string _Ccy;
        public Account_GL_Info()
        {
        }
        public Account_GL_Info(string branchId, string accountId, string name,
                               AccountType _CreditDebit, string _Ccy)
        {
            this.Branch_ID = branchId;
            this.Account_ID = accountId;
            this.Name = name;
            this.CreditDebit = _CreditDebit;
            this.Ccy = _Ccy;
        }
        public string Branch_ID
        {
            get { return _branchId; }
            set { _branchId = value; }
        }
        public string Account_ID
        {
            get { return _accountId; }
            set { _accountId = value; }
        }
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public AccountType CreditDebit
        {
            get { return _CreditDebit; }
            set { _CreditDebit = value; }
        }
        public string Ccy
        {
            get { return _Ccy; }
            set { _Ccy = value; }
        }
    }
}