using System;
using System.Collections.Generic;
using System.Text;

using Account.Common.Entities;
using Account.Business;

namespace Account.UIProviders
{
    public static partial class UIAccount
    {
        static Account.Business.Account dal_ac = new Account.Business.Account();
        public static Account_Info GetAccountByID(string id)
        {
            return dal_ac.GetAccountByID(id);
        }
        public static List<Account_Info> GetAll()
        {
            return dal_ac.GetAllAccount();
        }
        public static int Insert_Auth(Account_Info obj)
        { return dal_ac.Insert_Auth(obj); }
        public static int Insert(Account_Info obj)
        {
            return dal_ac.Insert(obj);
        }
        public static int Update_Auth(Account_Info obj)
        { return dal_ac.Update_Auth(obj); }
        public static int Update(Account_Info obj)
        {
            return dal_ac.Update(obj);
        }
        public static int Delete_Auth(string accountId)
        { return dal_ac.Delete_Auth(accountId); }
        public static int Delete(string accountId)
        {
            return dal_ac.Delete(accountId);
        }
        public static int Approved_Auth(string accountId)
        { return dal_ac.Approved_Auth(accountId); }
        public static int Approved(string accountId)
        { return dal_ac.Approved(accountId); }
        public static int Lock_Auth(string accountId)
        { return dal_ac.Lock_Auth(accountId); }
        public static int Lock(string accountId)
        { return dal_ac.Lock(accountId); }
        public static int UnLock_Auth(string accountId)
        { return dal_ac.UnLock_Auth(accountId); }
        public static int UnLock(string accountId)
        { return dal_ac.UnLock(accountId); }
        public static int Close_Auth(string accountId)
        { return dal_ac.Close_Auth(accountId); }
        public static int Close(string accountId)
        { return dal_ac.Close(accountId); }
        public static int Block_Auth(string accountId, decimal amount)
        { return dal_ac.Block_Auth(accountId, amount); }
        public static int Block(string accountId, decimal amount)
        { return dal_ac.Block(accountId, amount); }
        public static int UnBlock_Auth(string accountId, decimal amount)
        { return dal_ac.UnBlock_Auth(accountId, amount); }
        public static int UnBlock(string accountId, decimal amount)
        { return dal_ac.UnBlock(accountId, amount); }
        public static string ValidationMessage
        { get { return dal_ac.Error_Message; } }
        public static string GenerateId(string branchId, string categoriesId, string customerId)
        {
            return dal_ac.GenerateNewAccountID(branchId, categoriesId);
        }
    }
}
