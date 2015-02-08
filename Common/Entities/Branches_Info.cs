using System;
using System.Text;

namespace Account.Common.Entities
{
    public class Branches_Info
    {
        protected string _ID;
        protected string _Name;
        public Branches_Info()
        {
        }
        public Branches_Info(string _ID, string _Name)
        {
            this.ID = _ID;
            this.Name = _Name;
        }
        public string ID
        {
            get { return _ID; }
            set {
                if (string.IsNullOrEmpty(value))
                    throw new Exception("Branch id does not null or empty");
                _ID = value; }
        }
        public string Name
        {
            get { return _Name; }
            set {
                if (string.IsNullOrEmpty(value))
                    throw new Exception("Branch name does not null or empty");
                _Name = value; }
        }
    }
}