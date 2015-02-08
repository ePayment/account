using System;
using System.Collections.Generic;
using System.Text;
using Account.Common.Utilities;

namespace Account.Common.Entities
{
    public class TranCodeDetail_Info
    {
        private decimal _id;
        private string _code;
        private string _accountId;
        private CreditDebit _creditDebit;
        private NumberType _numType;
        private int _seq;
        private bool _isaccountCust;
        private float _numValue;
        private bool _master;

        public TranCodeDetail_Info()
        {
        }
        public TranCodeDetail_Info(decimal id, string code, string accountId, 
                                   CreditDebit creditdebit, NumberType numtype, int seq, 
                                   bool accCust, float numvalue, bool master)
        {
            this.ID = id;
            this.Code = code;
            this.Account_ID = accountId;
            this.CreditDebit = creditdebit;
            this.NumberType = numtype;
            this.SEQ = seq;
            this.Is_Account_Cust = accCust;
            this.Master = master;
            this.NumberValue = numvalue;
        }
        public decimal ID
        {
            get { return _id; }
            set { _id = value; }
        }
        public string Code
        {
            get { return _code; }
            set { _code = value; }
        }
        public string Account_ID
        {
            get { return _accountId; }
            set { _accountId = value; }
        }
        public CreditDebit CreditDebit
        {
            get { return _creditDebit; }
            set { _creditDebit = value; }
        }
        public NumberType NumberType
        {
            get { return _numType; }
            set 
            {
                if (value == NumberType.Percentage)
                    if ((NumberValue > 1) || (NumberValue < 0))
                        throw new Exception("Number value does not larger one or smaller zero");

                _numType = value; 
            }
        }
        public int SEQ
        {
            get { return _seq; }
            set { _seq = value; }
        }
        public bool Is_Account_Cust
        {
            get { return _isaccountCust; }
            set { _isaccountCust = value; }
        }
        public bool Master
        { get { return _master; } set { _master = value; } }
        public float NumberValue
        {
            get { return _numValue; }
            set 
            {
                if (NumberType == NumberType.Percentage)
                    if ((value > 1) || (value<0))
                        throw new Exception("Value does not larger one or smaller zero");
                _numValue = value; 
            }
        }
    }
}