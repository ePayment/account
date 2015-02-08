using System;
using System.Collections.Generic;
using System.Text;
using Account.Common.Entities;
using Account.Business;

namespace Account.UIProviders
{
    public static partial class UIAccount_Roles
    {
        static Account_Roles dal_ac_roles = new Account_Roles();
        static StringBuilder bstr;

        public static AccountRoles_Info GetAccountRoleById(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                return dal_ac_roles.GetAccountRoleByID(id);
            }
            else
                throw new Exception(dal_ac_roles.Error_Message);
        }
        public static List<AccountRoles_Info> GetAll()
        {
            return dal_ac_roles.GetAllAccountRoles();
        }
        public static int Insert(AccountRoles_Info obj)
        {
            if (obj != null)
            {
                return dal_ac_roles.Insert(obj);
            }
            else
                throw new Exception(dal_ac_roles.Error_Message);
        }
        public static int Update(AccountRoles_Info obj)
        {
            if (obj != null)
            {
                return dal_ac_roles.Update(obj);
            }
            else
                throw new Exception(dal_ac_roles.Error_Message);
        }
        public static int Delete(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                return dal_ac_roles.Delete(id);
            }
            else
                throw new Exception(dal_ac_roles.Error_Message);
        }
        public static string ValidationMessage

        {
            get { return dal_ac_roles.Error_Message; }
        }
    }
}
