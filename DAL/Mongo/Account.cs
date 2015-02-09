using Account.Common.Entities;
using log4net.Repository.Hierarchy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Dynamic;

using MongoDB.Driver;
using MongoDB.Driver.Builders;


namespace Account.Data.Mongo
{
    public class D_Account
    {
        public D_Account()
        {
            ePayment.DataProvider.MongoHelper.MongoDatabase = "epayment";
            ePayment.DataProvider.MongoHelper.MongoServer = "mongodb://127.0.0.1:27017";
        }
        public bool CreateOneAccount(Account_Info objAccountInfo)
        {
            try
            {
                dynamic acc_info = new ePayment.DataProvider.DynamicObj();
                acc_info.Account_ID = objAccountInfo.Account_ID;
                acc_info.Name = objAccountInfo.Name;
                acc_info.Ref = objAccountInfo.Reference;
                acc_info.b_Credit = objAccountInfo.b_Credit;
                acc_info.y_Credit = objAccountInfo.y_Credit;
                acc_info.y_Debit = objAccountInfo.y_Debit;
                acc_info.q_Credit = objAccountInfo.q_Credit;
                acc_info.q_Debit = objAccountInfo.q_Debit;
                acc_info.m_Credit = objAccountInfo.m_Credit;
                acc_info.m_Debit = objAccountInfo.m_Debit;
                acc_info.w_Credit = objAccountInfo.w_Credit;
                acc_info.w_Debit = objAccountInfo.w_Debit;
                acc_info.d_Credit = objAccountInfo.d_Credit;
                acc_info.d_Debit = objAccountInfo.d_Debit;
                acc_info.CreditDebit = objAccountInfo.CreditDebit;
                acc_info.Ccy = objAccountInfo.Ccy;
                acc_info.Amount_Blocked = objAccountInfo.Amount_Blocked;
                acc_info.Account_GL = objAccountInfo.Account_GL;
                acc_info.Branch_ID = objAccountInfo.Branch_ID;
                acc_info.Customer_ID = objAccountInfo.Customer_ID;
                acc_info.Categories = objAccountInfo.Categories;
                acc_info.ApprovedTime = objAccountInfo.ApprovedTime;
                acc_info.Approved = objAccountInfo.Approved;
                acc_info.Locked = objAccountInfo.Locked;
                acc_info.UNC_Rpt = objAccountInfo.UNC_Rpt;
                acc_info.Open_Date = objAccountInfo.Open_Date;
                acc_info.Last_Date = objAccountInfo.Last_Date;
                acc_info.UserCreate = objAccountInfo.UserCreate;
                return ePayment.DataProvider.MongoHelper.Save("Account", acc_info);
            }
            catch (Exception ex)
            {
                //ePayment.DataProvider.MongoHelper
                //Logger.Error(ex);
                //throw ex;
                return false;
            }
        }

        public bool EditOneAccount(Account_Info objAccountInfo)
        {
            try
            {
                dynamic acc_info = new ePayment.DataProvider.DynamicObj();
                acc_info.Account_ID = objAccountInfo.Account_ID;
                acc_info.Name = objAccountInfo.Name;
                acc_info.Ref = objAccountInfo.Reference;
                acc_info.b_Credit = objAccountInfo.b_Credit;
                acc_info.y_Credit = objAccountInfo.y_Credit;
                acc_info.y_Debit = objAccountInfo.y_Debit;
                acc_info.q_Credit = objAccountInfo.q_Credit;
                acc_info.q_Debit = objAccountInfo.q_Debit;
                acc_info.m_Credit = objAccountInfo.m_Credit;
                acc_info.m_Debit = objAccountInfo.m_Debit;
                acc_info.w_Credit = objAccountInfo.w_Credit;
                acc_info.w_Debit = objAccountInfo.w_Debit;
                acc_info.d_Credit = objAccountInfo.d_Credit;
                acc_info.d_Debit = objAccountInfo.d_Debit;
                acc_info.CreditDebit = objAccountInfo.CreditDebit;
                acc_info.Ccy = objAccountInfo.Ccy;
                acc_info.Amount_Blocked = objAccountInfo.Amount_Blocked;
                acc_info.Account_GL = objAccountInfo.Account_GL;
                acc_info.Branch_ID = objAccountInfo.Branch_ID;
                acc_info.Customer_ID = objAccountInfo.Customer_ID;
                acc_info.Categories = objAccountInfo.Categories;
                acc_info.ApprovedTime = objAccountInfo.ApprovedTime;
                acc_info.Approved = objAccountInfo.Approved;
                acc_info.Locked = objAccountInfo.Locked;
                acc_info.UNC_Rpt = objAccountInfo.UNC_Rpt;
                acc_info.Open_Date = objAccountInfo.Open_Date;
                acc_info.Last_Date = objAccountInfo.Last_Date;
                acc_info.UserCreate = objAccountInfo.UserCreate;
                return ePayment.DataProvider.MongoHelper.Save("Account", acc_info);
            }
            catch (Exception ex)
            {
                //ePayment.DataProvider.MongoHelper
                //Logger.Error(ex);
                //throw ex;
                return false;
            }
        }

        public bool EditOneAccount(Account_Info objAccountInfo, bool forceUpdate)
        {
            try
            {
                dynamic acc_info = new ePayment.DataProvider.DynamicObj();
                acc_info.Account_ID = objAccountInfo.Account_ID;
                acc_info.Name = objAccountInfo.Name;
                acc_info.Ref = objAccountInfo.Reference;
                acc_info.b_Credit = objAccountInfo.b_Credit;
                acc_info.y_Credit = objAccountInfo.y_Credit;
                acc_info.y_Debit = objAccountInfo.y_Debit;
                acc_info.q_Credit = objAccountInfo.q_Credit;
                acc_info.q_Debit = objAccountInfo.q_Debit;
                acc_info.m_Credit = objAccountInfo.m_Credit;
                acc_info.m_Debit = objAccountInfo.m_Debit;
                acc_info.w_Credit = objAccountInfo.w_Credit;
                acc_info.w_Debit = objAccountInfo.w_Debit;
                acc_info.d_Credit = objAccountInfo.d_Credit;
                acc_info.d_Debit = objAccountInfo.d_Debit;
                acc_info.CreditDebit = objAccountInfo.CreditDebit;
                acc_info.Ccy = objAccountInfo.Ccy;
                acc_info.Amount_Blocked = objAccountInfo.Amount_Blocked;
                acc_info.Account_GL = objAccountInfo.Account_GL;
                acc_info.Branch_ID = objAccountInfo.Branch_ID;
                acc_info.Customer_ID = objAccountInfo.Customer_ID;
                acc_info.Categories = objAccountInfo.Categories;
                acc_info.ApprovedTime = objAccountInfo.ApprovedTime;
                acc_info.Approved = objAccountInfo.Approved;
                acc_info.Locked = objAccountInfo.Locked;
                acc_info.UNC_Rpt = objAccountInfo.UNC_Rpt;
                acc_info.Open_Date = objAccountInfo.Open_Date;
                acc_info.Last_Date = objAccountInfo.Last_Date;
                acc_info.UserCreate = objAccountInfo.UserCreate;
                return ePayment.DataProvider.MongoHelper.Save("Account", acc_info);
            }
            catch (Exception ex)
            {
                //ePayment.DataProvider.MongoHelper
                //Logger.Error(ex);
                //throw ex;
                return false;
            }
        }

        public bool RemoveOneAccount(string id)
        {
            try
            {
                return ePayment.DataProvider.MongoHelper.Delete("Account", id);

            }
            catch (Exception ex)
            {
                //Logger.Error(ex); throw ex; 
                return false;
            }
        }

        public ePayment.DataProvider.DynamicObj GetOneAccount(string accountId)
        {
            try
            {
                IMongoQuery query = Query.EQ("_id", accountId);
                return ePayment.DataProvider.MongoHelper.Get("Account", query);

            }
            catch (Exception ex)
            {
                //Logger.Error(ex); throw ex; 
                return null;
            }
        }

        public ePayment.DataProvider.DynamicObj GetOneAccount(string branchId, string categories, string custId)
        {
            try
            {
                IMongoQuery query = Query.EQ("_id", branchId);
                return ePayment.DataProvider.MongoHelper.Get("Account", query);

            }
            catch (Exception ex)
            {
                //Logger.Error(ex); throw ex; 
                return null;
            }
        }

        public ePayment.DataProvider.DynamicObj[] GetAllAccount()
        {
            try
            {
                IMongoQuery query;
                return ePayment.DataProvider.MongoHelper.List("Account", null);

            }
            catch (Exception ex)
            {
                //Logger.Error(ex); throw ex; 
                return null;
            }
        }

        public ePayment.DataProvider.DynamicObj[] GetListAccountLike(string prefixAc)
        {
            try
            {
                IMongoQuery query;
                return ePayment.DataProvider.MongoHelper.List("Account", null);

            }
            catch (Exception ex)
            {
                //Logger.Error(ex); throw ex; 
                return null;
            }
        }

        public ePayment.DataProvider.DynamicObj[] GetListAccountLike(string prefixAc, string categories)
        {
            try
            {
                IMongoQuery query;
                return ePayment.DataProvider.MongoHelper.List("Account", null);

            }
            catch (Exception ex)
            {
                //Logger.Error(ex); throw ex; 
                return null;
            }
        }

        public ePayment.DataProvider.DynamicObj[] GetListAccountByCustId(string custId)
        {
            try
            {
                IMongoQuery query;
                return ePayment.DataProvider.MongoHelper.List("Account", null);

            }
            catch (Exception ex)
            {
                //Logger.Error(ex); throw ex; 
                return null;
            }
        }

        public ePayment.DataProvider.DynamicObj[] GetListAccountLike(string prefixAc, string categories, string custId)
        {
            try
            {
                
                IMongoQuery query;
                return ePayment.DataProvider.MongoHelper.List("Account", null);

            }
            catch (Exception ex)
            {
                //Logger.Error(ex); throw ex; 
                return null;
            }


        }
    }
}
