using Account.Common.Entities;
using log4net.Repository.Hierarchy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Account.Data.Mongo
{
    public class D_Account
    {
        public D_Account()
        {
            ePayment.DataProvider.MongoHelper.MongoDatabase = "epayment";
            ePayment.DataProvider.MongoHelper.MongoServer = "mongodb://127.0.0.1:27017";
        }
        public void CreateOneAccount(Account_Info objAccountInfo)
        {
            try { 
                dynamic acc_info = new ePayment.DataProvider.DynamicObj();

                acc_info.Account_ID = objAccountInfo.Account_ID;
                ePayment.DataProvider.MongoHelper.Save("Account",acc_info);
            }
            catch (Exception ex)
            {
                //ePayment.DataProvider.MongoHelper.
                //Logger.Error(ex);
                throw ex;
            }
        }
    }
}
