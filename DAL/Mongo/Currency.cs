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
    public class D_Currency
    {
        public D_Currency()
        {
            ePayment.DataProvider.MongoHelper.MongoDatabase = "epayment";
            ePayment.DataProvider.MongoHelper.MongoServer = "mongodb://127.0.0.1:27017";
        }

        public bool CreateOneCurrency(Currency_Info objCurrencyInfo)
        {
            try
            {
                dynamic currency_info = new ePayment.DataProvider.DynamicObj();
                currency_info.Code = objCurrencyInfo.Code;
                currency_info.Name = objCurrencyInfo.Name;
                currency_info.NumberCode = objCurrencyInfo.NumberCode;
                return ePayment.DataProvider.MongoHelper.Save("Currency", currency_info);
            }
            catch (Exception ex)
            {
                //Logger.Error(ex); throw ex; 
                return false;
            }
        }

        public bool EditOneCurrency(Currency_Info objCurrencyInfo)
        {
            try
            {
                dynamic currency_info = new ePayment.DataProvider.DynamicObj();
                currency_info.Code = objCurrencyInfo.Code;
                currency_info.Name = objCurrencyInfo.Name;
                currency_info.NumberCode = objCurrencyInfo.NumberCode;
                return ePayment.DataProvider.MongoHelper.Save("Currency", currency_info);
            }
            catch (Exception ex)
            {
                //Logger.Error(ex); throw ex; 
                return false;
            }
        }

        public bool RemoveOneCurrency(string id)
        {
            try
            {
                return ePayment.DataProvider.MongoHelper.Delete("Currency", id);

            }
            catch (Exception ex)
            {
                //Logger.Error(ex); throw ex; 
                return false;
            }
        }

        public ePayment.DataProvider.DynamicObj GetOneCurrency(string code)
        {
            try
            {
                IMongoQuery query;
                return ePayment.DataProvider.MongoHelper.Get("Currency", query);

            }
            catch (Exception ex)
            {
                //Logger.Error(ex); throw ex; 
                return null;
            }
        }

        public ePayment.DataProvider.DynamicObj[] GetAllCurrency()
        {
            try
            {
                IMongoQuery query;
                return ePayment.DataProvider.MongoHelper.List("Currency", query);

            }
            catch (Exception ex)
            {
                //Logger.Error(ex); throw ex; 
                return null;
            }
        }

    }
}
