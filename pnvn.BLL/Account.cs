using System;
using System.Collections.Generic;
using System.Text;

using Account.Common.Entities;
using Account.Common.Utilities;
using Account.Business.Base;

namespace Account.Business
{
    public partial class Account:BaseAccount
    {
        public string GenerateNewAccountID(string branch, string categories)
        { return base.GenerateNewAccountId(branch,categories); }
        public Account_Info GetAccountByID(string accountId)
        { return dalAc.GetOneAccount(accountId); }
        public List<Account_Info> GetAllAccount()
        { return dalAc.GetAllAccount(); }
        public int Insert_Auth(Account_Info obj)
        {
            SetError(0, String.Empty);
            if (string.IsNullOrEmpty(obj.Account_ID))
            {
                SetError(98, "Invalid Account ID");
                return Error_Number;
            }
            if (string.IsNullOrEmpty(obj.Name))
            {
                SetError(98, "Invalid Account Name");
                return Error_Number;
            }

            Branches dalBranch = new Branches();
            if (dalBranch.GetBranchesByID(obj.Branch_ID) == null)
            {
                SetError(70, "Branch Id not find");
                return Error_Number;
            }
            Categories dalCat = new Categories();
            Categories_Info catInfo = dalCat.GetCategoriesByID(obj.Categories);
            if (catInfo == null)
            {
                SetError(71, "Categories Id not find");
                return Error_Number;
            }
            Customer dalCust = new Customer();
            Customer_Info custInfo = dalCust.GetCustomerByID(obj.Customer_ID);
            if (custInfo == null)
            {
                SetError(1, "Customer not find");
                return Error_Number;
            }
            if (!custInfo.Active)
            {
                SetError(3, "Customer has been not active");
                return Error_Number;
            }
            Account_Info acInfo = base.GetAccountBy(obj.Branch_ID, obj.Categories, obj.Customer_ID);
            if (acInfo != null)
            {
                SetError(12, "Account opened");
                return Error_Number;
            }
            acInfo = base.GetAccountById(obj.Account_ID);
            if (acInfo != null)
            {
                SetError(12, "Account opened");
                return Error_Number;
            }

            return Error_Number;
        }
        public new int Insert(Account_Info obj)
        {

            int result = Insert_Auth(obj);
            if (result != 0) return result;

            obj.Open_Date = DateTime.Now;
            obj.Last_Date = DateTime.Now;
            
            if (base.Insert(obj)!=0)
                 SetError(0,String.Empty);
            else
                SetError(99,dalAc.GetException.Message);
            return Error_Number;
        }
        public int Update_Auth(Account_Info obj)
        {
            SetError(0, String.Empty);
            if (obj == null)
            {
                SetError(98, "Object is null");
                return Error_Number;
            }
            if (string.IsNullOrEmpty(obj.Name))
            {
                SetError(11, "Account name is null or empty");
                return Error_Number;
            }
            Account_Info acInfo = base.GetAccountById(obj.Account_ID);
            if (acInfo == null)
            {
                SetError(11, "Account not find");
                return Error_Number;
            }
            if (acInfo.Approved == true)
            {
                SetError(20, "Account approved");
                return Error_Number;
            }
            if (acInfo.Closed == true) 
            {
                SetError(21, "Account closed");
                return Error_Number;
            }
            if (acInfo.Locked == true)
            {
                SetError(22, "Account locked");
                return Error_Number;
            }
            return Error_Number;
        }
        public new int Update(Account_Info obj)
        {
            int result = Update_Auth(obj);
            if (result != 0) return result;
            obj.Last_Date = DateTime.Now;
            
            if (base.Update(obj)!=0)
                SetError(0, String.Empty);
            else
                SetError(99, dalAc.GetException.Message);
            return Error_Number;
        }
        public int Approved_Auth(string accountId)
        {
            SetError(0, String.Empty);
            Account_Info acInfo = dalAc.GetOneAccount(accountId);
            if (acInfo == null)
            {
                SetError(11, "Account not find");
                return Error_Number;
            }
            if (acInfo.Approved == true)
            {
                SetError(20, "Account approved");
                return Error_Number;
            }
            return Error_Number;
        }
        public int Approved(string accountId)
        {
            int result = Approved_Auth(accountId);
            if (result != 0) return result;
            Account_Info acInfo = dalAc.GetOneAccount(accountId);
            acInfo.Approved = true;
            acInfo.Last_Date = DateTime.Now;
            dalAc.EditOneAccount(acInfo);
            if (dalAc.Execute())
                SetError(0, String.Empty);
            else
                SetError(99, dalAc.GetException.Message);
            return Error_Number;
        }
        public int Delete_Auth(string accountId)
        {
            SetError(0, String.Empty);
            Account_Info acInfo = dalAc.GetOneAccount(accountId);
            if (acInfo == null)
            {
                SetError(11, "Account not find");
                return Error_Number;
            }
            if (acInfo.Approved == true)
            {
                SetError(20, "Account approved");
                return Error_Number;
            }
            return Error_Number;
        }
        public int Delete(string accountId)
        {
            int result = Delete_Auth(accountId);
            if (result != 0) return result;

            if (base.Delete(accountId) != 0)
                SetError(0, String.Empty);
            else
                SetError(99, dalAc.GetException.Message);
            return Error_Number;
        }
        public int Lock_Auth(string accountId)
        {
            SetError(0, String.Empty);
            Account_Info acInfo = dalAc.GetOneAccount(accountId);
            if (acInfo == null)
            {
                SetError(11, "Account not find");
                return Error_Number;
            }
            if (acInfo.Approved == false)
            {
                SetError(13, "Account not approved");
                return Error_Number;
            }
            if (acInfo.Closed == true)
            {
                SetError(21, "Account closed");
                return Error_Number;
            }
            if (acInfo.Locked == true)
            {
                SetError(22, "Account locked");
                return Error_Number;
            }
            return Error_Number;
        }
        public int Lock(string accountId)
        {
            int result = Lock_Auth(accountId);
            if (result != 0) return result;
            Account_Info acInfo = dalAc.GetOneAccount(accountId);
            if (base.Lock(acInfo)!=0)
                SetError(0, String.Empty);
            else
                SetError(99, dalAc.GetException.Message);
            return Error_Number;
        }
        public int UnLock_Auth(string accountId)
        {
            SetError(0, String.Empty);
            Account_Info acInfo = dalAc.GetOneAccount(accountId);
            if (acInfo == null)
            {
                SetError(11, "Account not find");
                return Error_Number;
            }
            if (acInfo.Locked == false)
            {
                SetError(23, "Account not lock");
                return Error_Number;
            }
            return Error_Number;
        }
        public int UnLock(string accountId)
        {
            int result = UnLock_Auth(accountId);
            if (result != 0) return result;
            Account_Info acInfo = dalAc.GetOneAccount(accountId);
            if (base.UnLock(acInfo)!=0)
                SetError(0, String.Empty);
            else
                SetError(99, dalAc.GetException.Message);
            return Error_Number;
        }
        public int Close_Auth(string accountId)
        {
            SetError(0, String.Empty);
            Account_Info acInfo = dalAc.GetOneAccount(accountId);
            if (acInfo == null)
            {
                SetError(11, "Account not find");
                return Error_Number;
            }
            if (acInfo.Approved == false)
            {
                SetError(13, "Account not approved");
                return Error_Number;
            }
            if (acInfo.Closed == true)
            {
                SetError(21, "Account closed");
                return Error_Number;
            }
            if (acInfo.Locked == true)
            {
                SetError(22, "Account locked");
                return Error_Number;
            }
            if (acInfo.Balance != 0)
            {
                SetError(19, "Account not allow closed still balance");
                return Error_Number;
            }
            return Error_Number;
        }
        public int Close(string accountId)
        {
            int result = Close_Auth(accountId);
            if (result != 0) return result;

            Account_Info acInfo = dalAc.GetOneAccount(accountId);
            
            if (base.Close(acInfo)!=0)
                SetError(0, String.Empty);
            else
                SetError(99, dalAc.GetException.Message);
            return Error_Number;
        }
        public int Block_Auth(string accountId, decimal amount)
        {
            SetError(0, String.Empty);
            Account_Info acInfo = dalAc.GetOneAccount(accountId);
            if (acInfo == null)
            {
                SetError(11, "Account not find");
                return Error_Number;
            }
            if (acInfo.Approved == false)
            {
                SetError(13, "Account not approved");
                return Error_Number;
            }
            if (acInfo.Closed == true)
            {
                SetError(21, "Account closed");
                return Error_Number;
            }
            if (acInfo.Locked == true)
            {
                SetError(22, "Account locked");
                return Error_Number;
            }
            if (Math.Abs(acInfo.BalanceAvaiable) < amount)
            {
                SetError(14, "Account balance is not enough");
                return Error_Number;
            }
            return Error_Number;
        }
        public int Block(string accountId, decimal amount)
        {
            int result = Block_Auth(accountId, amount);
            if (result != 0) return result;
            Account_Info acInfo = dalAc.GetOneAccount(accountId);
            if (base.Block(acInfo,amount) != 0)
                SetError(0, String.Empty);
            else
                SetError(99, dalAc.GetException.Message);
            return Error_Number;
        }
        public int UnBlock_Auth(string accountId, decimal amount)
        {
            SetError(0, String.Empty);
            Account_Info acInfo = dalAc.GetOneAccount(accountId);
            if (acInfo == null)
            {
                SetError(11, "Account not find");
                return Error_Number;
            }
            if (acInfo.Approved == false)
            {
                SetError(13, "Account not approved");
                return Error_Number;
            }
            if (acInfo.Closed == true)
            {
                SetError(21, "Account closed");
                return Error_Number;
            }
            if (acInfo.Locked == true)
            {
                SetError(22, "Account locked");
                return Error_Number;
            }
            if (Math.Abs(acInfo.Amount_Blocked) < amount)
            {
                SetError(24, "Amount blocked is not enough");
                return Error_Number;
            }
            return Error_Number;
        }
        public int UnBlock(string accountId, decimal amount)
        {
            int result = UnBlock_Auth(accountId, amount);
            if (result != 0) return result;

            Account_Info acInfo = dalAc.GetOneAccount(accountId);
            if (base.UnBlock(acInfo, amount) != 0)
                SetError(0, String.Empty);
            else
                SetError(99, dalAc.GetException.Message);
            return Error_Number;
        }
    }
}