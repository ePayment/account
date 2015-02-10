using System;
using System.Collections.Generic;
using System.Text;

using Account.Business;
using Account.Business.Base;
using Account.Common.Entities;

namespace Account.Business
{
    public partial class Customer:BaseCustomer
    {
        public int Insert_Auth(Customer_Info custInfo)
        {
            SetError(0, String.Empty);

            if (custInfo == null)
            {
                SetError(98, "Invalid data input");
                return Error_Number;
            }
            if (string.IsNullOrEmpty(custInfo.ID))
            {
                SetError(98, "Customer Id is null or empty");
                return Error_Number;
            }
            if (string.IsNullOrEmpty(custInfo.Name))
            {
                SetError(98, "Customer name is null or empty");
                return Error_Number;
            }
            if (string.IsNullOrEmpty(custInfo.Cust_Cert))
            {
                SetError(98, "Customer identity card number is null or empty");
                return Error_Number;
            }
            if (string.IsNullOrEmpty(custInfo.UserCreate))
            {
                SetError(98, "User Create is null or empty");
                return Error_Number;
            }
            if (custInfo.Approved == true && custInfo.ApprovedTime < custInfo.DateCreated)
            {
                SetError(98, "Invalid ApprovedTime");
                return Error_Number;
            }
            if (custInfo.DateCreated > custInfo.LastUpdate)
            {
                SetError(98, "Invalid DateCreated");
                return Error_Number;
            }
            // Kiểm tra sự tồn tại của chứng minh nhân dân.
            if (base.GetCustomerByCert(custInfo.Cust_Cert) != null)
            {
                SetError(4, "Identity card number of duplicate");
                return Error_Number;
            }
            return Error_Number;
        }
        public new int Insert(Customer_Info custInfo)
        {
            int result = Insert_Auth(custInfo);
            if (result != 0)
                return result;
            if (base.Insert(custInfo) != 0)
                SetError(0, String.Empty);
            //else
            //    SetError(99, _dalCust.GetException.Message);
            return Error_Number;
        }
        public int Update_Auth(Customer_Info custInfo)
        {
            SetError(0, String.Empty);
            if (custInfo == null)
            {
                SetError(98, "Invalid data input");
                return Error_Number;
            }
            if (string.IsNullOrEmpty(custInfo.ID))
            {
                SetError(98, "Customer Id is null or empty");
                return Error_Number;
            }
            if (string.IsNullOrEmpty(custInfo.Name))
            {
                SetError(98, "Customer name is null or empty");
                return Error_Number;
            }
            if (string.IsNullOrEmpty(custInfo.Cust_Cert))
            {
                SetError(98, "Customer identity card number is null or empty");
                return Error_Number;
            }
            if (string.IsNullOrEmpty(custInfo.UserCreate))
            {
                SetError(98, "UserCreate is null or empty");
                return Error_Number;
            }
            if (custInfo.Approved == true && custInfo.ApprovedTime < custInfo.DateCreated)
            {
                SetError(98, "Invalid ApprovedTime");
                return Error_Number;
            }
            if (custInfo.DateCreated > custInfo.LastUpdate)
            {
                SetError(98, "Invalid DateCreated");
                return Error_Number;
            }

            // Kiểm tra sự tồn tại của chứng minh nhân dân.
            Customer_Info oldCust = base.GetCustomerById(custInfo.ID);
            if (oldCust == null)
            {
                SetError(1, "Customer not find");
                return Error_Number;
            }
            if ((oldCust.Cust_Cert != custInfo.Cust_Cert) && (base.GetCustomerByCert(custInfo.Cust_Cert) != null))
            {
                SetError(4, "Identity card number of duplicate");
                return Error_Number;
            }
            if (oldCust.Approved == true)
            {
                SetError(5, "Customer approved");
                return Error_Number;
            }
            return Error_Number;
        }
        public new int Update(Customer_Info custInfo)
        {
            int result = Update_Auth(custInfo);
            if (result != 0)
                return result;
            if (base.Update(custInfo) != 0)
                SetError(0, String.Empty);
            //else
            //    SetError(99, _dalCust.GetException.Message);
            return Error_Number;
        }
        public int Delete_Auth(string custId)
        {
            SetError(0, String.Empty);
            Customer_Info custInfo = base.GetCustomerById(custId);
            if (custInfo == null)
            {
                SetError(1, "Customer not find");
                return Error_Number;
            }
            if (custInfo.Approved == true)
            {
                SetError(5, "Customer approved");
                return Error_Number;
            }
            return Error_Number;
        }
        public new int Delete(string custId)
        {
            int result = Delete_Auth(custId);
            if (result != 0)
                return result;
            if (base.Delete(custId) != 0)
                SetError(0, String.Empty);
            //else
            //    SetError(99, _dalCust.GetException.Message);
            return Error_Number;
        }
        public Customer_Info GetCustomerByID(string custId)
        {
            return base.GetCustomerById(custId);
        }
        public new Customer_Info GetCustomerByCert(string custCert)
        { 
            return base.GetCustomerByCert(custCert); 
        }
        public new dynamic[] GetAllCustomer()
        { return base.GetAllCustomer(); }
        public int Approved_Auth(string custId)
        {
            SetError(0, String.Empty);
            Customer_Info custInfo = base.GetCustomerById(custId);
            if (custInfo == null)
            {
                SetError(1, "Customer not find");
                return Error_Number;
            }
            if (custInfo.Approved == true)
            {
                SetError(5, "Customer approved");
                return Error_Number;
            }
            return Error_Number;
        }
        public int Approved(string custId)
        {
            int result = Approved_Auth(custId);
            if (result != 0) return result;

            Customer_Info custInfo = base.GetCustomerById(custId);
            custInfo.Approved = true;
            custInfo.ApprovedTime = DateTime.Now;
            custInfo.LastUpdate = DateTime.Now;
            
            if (base.Update(custInfo) != 0)
                SetError(0, String.Empty);
            //else
            //    SetError(99, _dalCust.GetException.Message);
            return Error_Number;
        }
        public new decimal Balance(string custId)
        { return base.Balance(custId); }
        public string GenerateNewCustomerID()
        { return base.GenerateNewCustId(); }

    }
}
