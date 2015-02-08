using System;
using System.Collections.Generic;
using System.Text;

using Account.Common.Entities;
using Account.Business;

namespace Account.UIProviders
{
    public static partial class UICustomer
    {
        static Customer dal_cust = new Customer();

        public static Customer_Info GetCustomerByID(string id)
        {
            return dal_cust.GetCustomerByID(id);
        }
        public static List<Customer_Info> GetAll()
        {
            return dal_cust.GetAllCustomer();
        }
        public static int Insert_Auth(Customer_Info obj)
        {
            return dal_cust.Insert_Auth(obj);
        }
        public static int Update_Auth(Customer_Info obj)
        {
            return dal_cust.Update_Auth(obj);
        }
        public static int Delete_Auth(string custId)
        {
            return dal_cust.Delete_Auth(custId);
        }

        public static int Insert(Customer_Info obj)
        {
            return dal_cust.Insert(obj);
        }
        public static int Update(Customer_Info obj)
        {
            return dal_cust.Update(obj);
        }
        public static int Delete(string id)
        {
            return dal_cust.Delete(id);
        }

        public static int Approved_Auth(string custId)
        { return dal_cust.Approved_Auth(custId); }
        public static int Approved(string custId)
        { return dal_cust.Approved(custId); }
        public static string ValidationMessage
        { get { return dal_cust.Error_Message; } }
        public static string GenerateID()
        {
            return dal_cust.GenerateNewCustomerID();
        }
    }
}
