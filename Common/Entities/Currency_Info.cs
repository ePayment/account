using System;
using System.Collections.Generic;
using System.Text;

namespace Account.Common.Entities
{
    public class Currency_Info
    {
        protected string _Code;
        protected string _Name;
        protected int _numbercode;

        public Currency_Info()
        {
        }
        public Currency_Info(string Code, string Name,int numcode)
        {
            this.Code = Code;
            this.Name = Name;
            this.NumberCode = numcode;
        }
        public string Code
        {
            get { return _Code; }
            set {
                if (string.IsNullOrEmpty(value))
                    throw new Exception("Currency code does not null or empty");
                _Code = value; }
        }
        public string Name
        {
            get { return _Name; }
            set {
                if (string.IsNullOrEmpty(value))
                    throw new Exception("Currency name does not null or empty");
                _Name = value; }
        }
        public int NumberCode
        {
            get { return _numbercode; }
            set {
                if (value == 0)
                    throw new Exception("Currency number iso code does not null or empty");
                _numbercode = value;
            }
        }
    }
}