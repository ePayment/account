using System;
using System.Collections.Generic;
using System.Text;

namespace Account.Common.Entities
{
    public class Industry_Info
    {
        private string _id;
        private string _name;
        public Industry_Info()
        {
        }
        public Industry_Info(string id, string name)
        {
            this.ID = id;
            this.Name = name;
        }
        public string ID
        {
            get { return _id; }
            set { _id = value; }
        }
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
    }
}