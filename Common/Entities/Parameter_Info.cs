using System;
using System.Text;

namespace Account.Common.Entities
{
    public partial class Parameter_Info
    {
        string _paramName;
        string _paramValue;
        string _paramDescript;

        public Parameter_Info()
        { }
        public Parameter_Info(string paramName, string paramValue, string paramDescript)
        {
            this.Name = paramName;
            this.Value = paramValue;
            this.Descript = paramDescript;
        }
        public string Name
        {
            get { return _paramName; }
            set {
                if (string.IsNullOrEmpty(value))
                    throw new Exception("Parameter name does not null or empty");
                _paramName = value; }
        }
        public string Value
        {
            get { return _paramValue; }
            set { _paramValue = value; }
        }
        public string Descript
        {
            get { return _paramDescript; }
            set { _paramDescript = value; }
        }
    }
}