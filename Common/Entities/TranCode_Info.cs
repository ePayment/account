using System;
using System.Collections.Generic;
using System.Text;
using Account.Common.Utilities;

namespace Account.Common.Entities
{
    public class Trancode_Info
    {
        string _code = "";
        string _name = "";
        bool _status = true;
        string _categories = "";
        string _nextcode = "";
        string _costcode = "";
        string _descript = "";
        CodeType _codetype;
        bool _allowReverse;
        bool _report = false;
        bool _display = false;
        string _formula = "";
        string _refnum = "";
        bool _checkon = false;
        DateTime _datecreate = DateTime.Now;
        string _usercreate = "";
        string _branch = "";

        public string Code
        { get { return _code; } 
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new Exception("Code is null or empty");
                _code = value;
            } 
        }
        public string Name
        { get { return _name; } 
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
        public CodeType CodeType
        { get { return _codetype; } set { _codetype = value; } }
        public bool AllowReverse
        { get { return _allowReverse; } set { _allowReverse = value; } }
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
        public Trancode_Info()
        { }
        public Trancode_Info(string code, string name, bool status, string categories, 
                             string nextcode, string costcode, string descript, CodeType codetype, 
                             bool display, string fomular, string refnum, bool checkon, DateTime datecreate, 
                             string usercreate, string branch, bool report, bool allowReverse)
        {
            this.Code = code;
            this.Name = name;
            this.Status = status;
            this.Categories = categories;
            this.NextCode = nextcode;
            this.CostCode = costcode;
            this.Descript = descript;
            this.CodeType = codetype;
            this.AllowReverse = allowReverse;
            this.Report = report;
            this.Display = display;
            this.Formula = fomular;
            this.RefNum = refnum;
            this.CheckOn = checkon;
            this.DateCreated = datecreate;
            this.UserCreate = usercreate;
            this.Branch_ID = branch;
        }
    }
}