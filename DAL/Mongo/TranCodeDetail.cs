using Account.Common.Entities;
using log4net.Repository.Hierarchy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Dynamic;
using MongoDB.Driver;

namespace Account.Data.Mongo
{
    public class D_TranCodeDetail
    {
        public D_TranCodeDetail()
        {
            ePayment.DataProvider.MongoHelper.MongoDatabase = "epayment";
            ePayment.DataProvider.MongoHelper.MongoServer = "mongodb://127.0.0.1:27017";
        }
        public bool CreateOneTranCodeDetail(TranCodeDetail_Info objTranCodeDetailInfo)
        {
            try
            {
                dynamic trancodeDetail_info = new ePayment.DataProvider.DynamicObj();
                trancodeDetail_info.SEQ = objTranCodeDetailInfo.SEQ;
                trancodeDetail_info.Code = objTranCodeDetailInfo.Code;
                trancodeDetail_info.Account_ID = objTranCodeDetailInfo.Account_ID;
                trancodeDetail_info.CreditDebit = objTranCodeDetailInfo.CreditDebit;
                trancodeDetail_info.NumType = objTranCodeDetailInfo.NumberType;
                trancodeDetail_info.NumValue = objTranCodeDetailInfo.NumberValue;
                trancodeDetail_info.IsAccountCust = objTranCodeDetailInfo.Is_Account_Cust;
                trancodeDetail_info.Master = objTranCodeDetailInfo.Master;
                return ePayment.DataProvider.MongoHelper.Save("TranCodeDetail", trancodeDetail_info);

            }
            catch (Exception ex)
            { 
                //Logger.Error(ex); throw ex; 
                return false;
            }
        }

        public bool EditOneTranCodeDetail(TranCodeDetail_Info objTranCodeDetailInfo)
        {
            try
            {
                dynamic trancodeDetail_info = new ePayment.DataProvider.DynamicObj();
                trancodeDetail_info.SEQ = objTranCodeDetailInfo.SEQ;
                trancodeDetail_info.Code = objTranCodeDetailInfo.Code;
                trancodeDetail_info.Account_ID = objTranCodeDetailInfo.Account_ID;
                trancodeDetail_info.CreditDebit = objTranCodeDetailInfo.CreditDebit;
                trancodeDetail_info.NumType = objTranCodeDetailInfo.NumberType;
                trancodeDetail_info.NumValue = objTranCodeDetailInfo.NumberValue;
                trancodeDetail_info.IsAccountCust = objTranCodeDetailInfo.Is_Account_Cust;
                trancodeDetail_info.Master = objTranCodeDetailInfo.Master;
                return ePayment.DataProvider.MongoHelper.Save("TranCodeDetail", trancodeDetail_info);

            }
            catch (Exception ex)
            {
                //Logger.Error(ex); throw ex; 
                return false;
            }
        }

        public bool RemoveOneTranCodeDetail(dynamic _id)
        {
            try
            {               
                return ePayment.DataProvider.MongoHelper.Delete("TranCodeDetail", _id);

            }
            catch (Exception ex)
            {
                //Logger.Error(ex); throw ex; 
                return false;
            }
        }

        public bool RemoveOneTranCodeDetailByCode(dynamic _id)
        {
            try
            {
                return ePayment.DataProvider.MongoHelper.Delete("TranCodeDetail", _id);

            }
            catch (Exception ex)
            {
                //Logger.Error(ex); throw ex; 
                return false;
            }
        }

        public ePayment.DataProvider.DynamicObj[] GetAllTranCodeDetail()
        {
            try
            {
                IMongoQuery query;
                return ePayment.DataProvider.MongoHelper.List("TranCodeDetail", query);

            }
            catch (Exception ex)
            {
                //Logger.Error(ex); throw ex; 
                return null;
            }
        }

        public ePayment.DataProvider.DynamicObj GetOneTranCodeDetail()
        {
            try
            {
                IMongoQuery query;
                return ePayment.DataProvider.MongoHelper.Get("TranCodeDetail", query);

            }
            catch (Exception ex)
            {
                //Logger.Error(ex); throw ex; 
                return null;
            }
        }

        public ePayment.DataProvider.DynamicObj GetTranCodeDetailByCode(string trancode)
        {
            try
            {
                IMongoQuery query;
                return ePayment.DataProvider.MongoHelper.Get("TranCodeDetail", query);

            }
            catch (Exception ex)
            {
                //Logger.Error(ex); throw ex; 
                return null;
            }
        }
    
    }
}
