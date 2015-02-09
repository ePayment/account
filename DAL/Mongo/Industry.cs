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
    public class D_Industry
    {
        public D_Industry()
        {
            ePayment.DataProvider.MongoHelper.MongoDatabase = "epayment";
            ePayment.DataProvider.MongoHelper.MongoServer = "mongodb://127.0.0.1:27017";
        }

        public bool CreateOneIndustry(Industry_Info objIndustryInfo)
        {
            try
            {
                dynamic industry_info = new ePayment.DataProvider.DynamicObj();
                industry_info.ID = objIndustryInfo.ID;
                industry_info.Name = objIndustryInfo.Name;
                return ePayment.DataProvider.MongoHelper.Save("Industry", industry_info);

            }
            catch (Exception ex)
            {
                //Logger.Error(ex); throw ex; 
                return false;
            }          
        }

        public bool EditOneIndustry(Industry_Info objIndustryInfo)
        {
            try
            {
                dynamic industry_info = new ePayment.DataProvider.DynamicObj();
                industry_info.ID = objIndustryInfo.ID;
                industry_info.Name = objIndustryInfo.Name;
                return ePayment.DataProvider.MongoHelper.Save("Industry", industry_info);

            }
            catch (Exception ex)
            {
                //Logger.Error(ex); throw ex; 
                return false;
            }
        }

        public bool RemoveOneIndustry(dynamic _id)
        {
            try
            {
                return ePayment.DataProvider.MongoHelper.Delete("Industry", _id);

            }
            catch (Exception ex)
            {
                //Logger.Error(ex); throw ex; 
                return false;
            }
        }

        public ePayment.DataProvider.DynamicObj[] GetAllIndustry()
        {
            try
            {
                return ePayment.DataProvider.MongoHelper.List("Industry", null);

            }
            catch (Exception ex)
            {
                //Logger.Error(ex); throw ex; 
                return null;
            }
        }
        public ePayment.DataProvider.DynamicObj GetOneIndustry(string id)
        {
            try
            {
                IMongoQuery query = Query.EQ("_id", id);
                return ePayment.DataProvider.MongoHelper.Get("Industry", query);

            }
            catch (Exception ex)
            {
                //Logger.Error(ex); throw ex; 
                return null;
            }
        }
    }
}
