using System;
using System.Collections.Generic;
using System.Text;

namespace Account.Common.Entities
{
    public partial class Sector_Info
    {
        private string _id;
        private string _name;
        public Sector_Info()
        {
        }
        public Sector_Info(string id, string name)
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