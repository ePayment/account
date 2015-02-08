using System;
using System.Collections.Generic;
using System.Text;
using Account.Common.Entities;
using Account.Business;

namespace Account.UIProviders
{
    public static partial class UIUser
    {
        static User dalUser = new User();
        public static User_Info GetUserByID(string id)
        {
            return dalUser.GetUserByID(id);
        }
        public static List<User_Info> GetAll()
        {
            return dalUser.GetAllUser();
        }
        public static int Insert(User_Info obj)
        {
            if (obj != null)
            {
                return dalUser.Insert(obj);
            }
            else
                throw new Exception(dalUser.Error_Message);
        }
        public static int Update(User_Info obj)
        {
            if (obj != null)
            {
                return dalUser.Update(obj);
            }
            else
                throw new Exception(dalUser.Error_Message);
        }
        public static int Delete(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                return dalUser.Delete(id);
            }
            else
                throw new Exception(dalUser.Error_Message);
        }
        public static int ChangePassword(string uid, string oldPass, string newPass)
        {
            return dalUser.ChangePassword(uid, oldPass, newPass);
        }
        public static int ResetPassword(string uid, string newPass)
        { return dalUser.ResetPassword(uid, newPass); }
        public static int Login(string uid, string pass)
        {
            return dalUser.Login(uid, pass);
        }
        public static int Logout(string uid)
        { return dalUser.Logout(uid); }
        public static string ValidationMessage
        { get { return dalUser.Error_Message; } }
    }
}
