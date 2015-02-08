using System;
using System.Collections.Generic;
using System.Text;

using Account.Business.Base;
using Account.Common.Entities;
using Account.Common.Utilities;

namespace Account.Business
{
    public partial class User:BaseUser
    {
        private CryptProvider myCrypt;
        public User()
        { myCrypt = new CryptProvider(); }
        public new int Insert(User_Info obj)
        {
            if (obj == null)
            {
                SetError(98, "Object is null");
                return Error_Number;
            }
            if (string.IsNullOrEmpty(obj.Branch_ID))
            {
                SetError(98, "Branch is null or empty");
                return Error_Number;
            }
            if (string.IsNullOrEmpty(obj.FullName))
            {
                SetError(98, "FullName is null or empty");
                return Error_Number;
            }
            if (string.IsNullOrEmpty(obj.Password))
            {
                SetError(98, "Password is null or empty");
                return Error_Number;
            }
            obj.Password = myCrypt.Encrypt(obj.Password);
            if (base.Insert(obj) != 0)
                SetError(0, String.Empty);
            else
                SetError(99, dalUser.GetException.Message);
            return Error_Number;
        }
        public new int Update(User_Info obj)
        {
            if (obj == null)
            {
                SetError(98, "Object is null");
                return Error_Number;
            }
            if (string.IsNullOrEmpty(obj.Branch_ID))
            {
                SetError(98, "Branch is null or empty");
                return Error_Number;
            }
            if (string.IsNullOrEmpty(obj.FullName))
            {
                SetError(98, "FullName is null or empty");
                return Error_Number;
            }
            if (string.IsNullOrEmpty(obj.Password))
            {
                SetError(98, "Password is null or empty");
                return Error_Number;
            }
            User_Info oldUser = base.GetUserByID(obj.User_ID);
            if (oldUser == null)
            {
                SetError(98, "User not find");
                return Error_Number;
            }
            obj.Password = oldUser.Password;

            if (base.Update(obj) != 0)
                SetError(0, String.Empty);
            else
                SetError(99, dalUser.GetException.Message);
            return Error_Number;
        }
        public int Delete(string uid)
        {
            if (string.IsNullOrEmpty(uid))
            {
                SetError(98, "User Id is null or empty");
                return Error_Number;
            }
            User_Info obj = base.GetUserByID(uid);
            if (obj == null)
            {
                SetError(98, "User not find");
                return Error_Number;
            }
            if (base.Delete(obj) != 0)
                SetError(0, String.Empty);
            else
                SetError(99, dalUser.GetException.Message);
            return Error_Number;
        }
        public new User_Info GetUserByID(string uid)
        { return base.GetUserByID(uid); }
        public new List<User_Info> GetAllUser()
        { return base.GetAllUser(); }
        public int ChangePassword(string uid,string oldPass, string newPass)
        {
            if (string.IsNullOrEmpty(uid))
            {
                SetError(98, "User_ID is null or empty");
                return Error_Number;
            }
            if (string.IsNullOrEmpty(oldPass))
            {
                SetError(98, "Old password is null or empty");
                return Error_Number;
            }
            if (string.IsNullOrEmpty(newPass))
            {
                SetError(98, "New password is null or empty");
                return Error_Number;
            }
            User_Info obj = base.GetUserByID(uid);
            if (obj == null)
            {
                SetError(98, "User not find");
                return Error_Number;
            }
            if (oldPass.CompareTo(newPass)==0)
            {
                SetError(99, "Password the same value!");
                return Error_Number;
            }
            obj.Password = myCrypt.Encrypt(newPass);
            if (base.Update(obj) != 0)
                SetError(0, String.Empty);
            else
                SetError(99, dalUser.GetException.Message);
            return Error_Number;
        }
        public int ResetPassword(string uid, string newPass)
        {
            if (string.IsNullOrEmpty(newPass))
            {
                SetError(98, "New password is null or empty");
                return Error_Number;
            }
            User_Info obj = base.GetUserByID(uid);
            if (obj == null)
            {
                SetError(98, "User not find");
                return Error_Number;
            }
            obj.Password = myCrypt.Encrypt(newPass);
            if (base.Update(obj) != 0)
                SetError(0, String.Empty);
            else
                SetError(99, dalUser.GetException.Message);
            return Error_Number;
        }
        public int Login(string uid, string pass)
        {
            if (string.IsNullOrEmpty(uid))
            {
                SetError(98, "User is null or empty");
                return Error_Number;
            }
            if (string.IsNullOrEmpty(pass))
            {
                SetError(98, "Password is null or empty");
                return Error_Number;
            }
            User_Info uInfo = base.GetUserByID(uid);
            if (uInfo == null)
            {
                SetError(98, "User ID not find");
                return Error_Number;
            }
            //if (pass.CompareTo(myCrypt.Decrypt(uInfo.Password))!=0)
            //{
            //    SetError(98, "Invalid password");
            //    return Error_Number;
            //}
            // Cập nhật thời gian login
            //uInfo.LastLogin = DateTime.Now;
            //if (base.Update(uInfo)!=0)
                SetError(0, String.Empty);
            //else
            //    SetError(99, dalUser.GetException.Message);
            return Error_Number;
        }
        public int Logout(string uid)
        {
            User_Info uInfo = base.GetUserByID(uid);
            if (uInfo == null)
            {
                SetError(98, "User ID not find");
                return Error_Number;
            }
            // Cập nhật thời gian logout
            uInfo.LastLogout = DateTime.Now;
            if (base.Update(uInfo) != 0)
                SetError(0, String.Empty);
            else
                SetError(99, dalUser.GetException.Message);
            return Error_Number;
        }
    }
}
