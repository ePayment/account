using System;
using System.Collections.Generic;
using System.Text;
using Account.Common.Utilities;

namespace Account.Common.Entities
{
    public class TranCodeDetailFull_Info
    {
        string _code = "";
        string _name = "";
        bool _status = true;
        string _categories = "";
        string _nextcode = "";
        string _costcode = "";
        string _descript = "";
        string _codetype = "";
        bool _report = false;
        bool _display = false;
        string _formula = "";
        string _refnum = "";
        bool _checkon = false;
        DateTime _datecreate = DateTime.Now;
        string _usercreate = "";
        string _branch = "";

        private decimal _id;
        private string _accountId;
        private string _creditDebit;
        private NumberType _numType;
        private int _seq;
        private bool _isaccountCust;
        private float _numValue;
        private bool _master;

        public string Code
        {
            get { return _code; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new Exception("Code is null or empty");
                _code = value;
            }
        }
        public string Name
        {
            get { return _name; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new Exception("Name is null or empty");
                _name = value;
            }
        }
        public bool Status
        { get { return _status; } set { _status = value; } }
        public string Categories
        {
            get { return _categories; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new Exception("Categories is null or empty");
                _categories = value;
            }
        }
        public string NextCode
        { get { return _nextcode; } set { _nextcode = value; } }
        public string CostCode
        { get { return _costcode; } set { _costcode = value; } }
        public string Descript
        { get { return _descript; } set { _descript = value; } }
        public string CodeType
        { get { return _codetype; } set { _codetype = value; } }
        public bool Report
        { get { return _report; } set { _report = value; } }
        public bool Display
        { get { return _display; } set { _display = value; } }
        public string Formula
        { get { return _formula; } set { _formula = value; } }
        public string RefNum
        { get { return _refnum; } set { _refnum = value; } }
        public bool CheckOn
        { get { return _checkon; } set { _checkon = value; } }
        public DateTime DateCreated
        { get { return _datecreate; } set { _datecreate = value; } }
        public string UserCreate
        { get { return _usercreate; } set { _usercreate = value; } }
        public string Branch_ID
        { get { return _branch; } set { _branch = value; } }
        public decimal ID
        {
            get { return _id; }
            set { _id = value; }
        }
        public string Account_ID
        {
            get { return _accountId; }
            set { _accountId = value; }
        }
        public string CreditDebit
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
                    if ((value > 1) || (value < 0))
                        throw new Exception("Value does not larger one or smaller zero");
                _numValue = value;
            }
        }
        public TranCodeDetailFull_Info()
        { }
        public TranCodeDetailFull_Info(string code, string name, bool status, string categories,
                                       string nextcode, string costcode, string descript, string codetype,
                                       bool display, string fomular, string refnum, bool checkon, DateTime datecreate,
                                       string usercreate, string branch, bool report, decimal id, string accountId,
                                       string creditdebit, NumberType numtype, int seq,
                                       bool accCust, float numvalue, bool master)
        {
            this.Code = code;
            this.Name = name;
            this.Status = status;
            this.Categories = categories;
            this.NextCode = nextcode;
            this.CostCode = costcode;
            this.Descript = descript;
            this.CodeType = codetype;
            this.Report = report;
            this.Display = display;
            this.Formula = fomular;
            this.RefNum = refnum;
            this.CheckOn = checkon;
            this.DateCreated = datecreate;
            this.UserCreate = usercreate;
            this.Branch_ID = branch;
            this.ID = id;
            this.Account_ID = accountId;
            this.CreditDebit = creditdebit;
            this.NumberType = numtype;
            this.SEQ = seq;
            this.Is_Account_Cust = accCust;
            this.Master = master;
            this.NumberValue = numvalue;
        }
    }
}