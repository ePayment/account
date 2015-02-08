using System;
using System.Collections.Generic;
using System.Text;

namespace Account.Common.Entities
{
    public class Categories_Info
    {
        private string _id;
        private string _name;
        private Account_GL_Info _accountGl;

        public Categories_Info()
        {}
        public Categories_Info(string catId, string catName, Account_GL_Info acGl)
        {
            this.ID = catId;
            this.Name = catName;
            this.Account_GL = acGl;
        }
        public string ID
        {
            get { return _id; }
            set {
                if (string.IsNullOrEmpty(value))
                    throw new Exception("Categories code does not null or empty");
                _id = value; }
        }
        public string Name
        {
            get { return _name; }
            set {
                if (string.IsNullOrEmpty(value))
                    throw new Exception("Categories name does not null or empty");
                _name = value; }
        }
        public Account_GL_Info Account_GL
        {
            get { return _accountGl; }
            set {
                if (value==null)
                    throw new Exception("Account_GL in Categories does not null or empty");
                _accountGl = value; }
        }
    }
}