using System;
using System.Collections.Generic;
using System.Text;

namespace Account.Common.Entities
{
    public class User_Info
    {
        string _uid;
        string _pass;
        string _branch;
        string _fullname;
        bool _isAdmin;

        DateTime _lastlogin = new DateTime();
        DateTime _lastlogout = new DateTime();

        public User_Info(){}
        public User_Info(string uid, string pass, string branch, string fullname,
                         bool isAdmin, DateTime login, DateTime logout)
        {
            this.User_ID = uid;
            this.FullName = fullname;
            this.Branch_ID = branch;
            this.Password = pass;
            this.IsAdministrator = isAdmin;
            this.LastLogin = login;
            this.LastLogout = logout;
        }
        public string User_ID
        {
            get { return _uid; }
            set {
                if (string.IsNullOrEmpty(value))
                    throw new Exception("User id does not null or empty");
                _uid = value;
            }
        }
        public string FullName
        {
            get { return _fullname; }
            set {
                if (string.IsNullOrEmpty(value))
                    throw new Exception("User name does not null or empty");
                _fullname = value;
            }
        }
        public string Branch_ID
        {
            get { return _branch; }
            set { _branch = value; }
        }
        public string Password
        {
            get { return _pass; }
            set { _pass = value; }
        }
        public bool IsAdministrator
        {get{return _isAdmin;} set{_isAdmin=value;}}
        public DateTime LastLogin
        {
            get { return _lastlogin; }
            set { _lastlogin = value; }
        }
        public DateTime LastLogout
        {
            get { return _lastlogout; }
            set { _lastlogout = value; }
        }
    }
}