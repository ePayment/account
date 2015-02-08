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
    public class D_Categories
    {
        public D_Categories()
        {
            ePayment.DataProvider.MongoHelper.MongoDatabase = "epayment";
            ePayment.DataProvider.MongoHelper.MongoServer = "mongodb://127.0.0.1:27017";
        }

        public bool CreateOneCategories(Categories_Info objCategoriesInfo)
        {
            try
            {
                dynamic categories_info = new ePayment.DataProvider.DynamicObj();
                categories_info.ID = objCategoriesInfo.ID;
                categories_info.Name = objCategoriesInfo.Name;
                categories_info.Account_GL = objCategoriesInfo.Account_GL;
                return ePayment.DataProvider.MongoHelper.Save("Categories", categories_info);
            }
            catch (Exception ex)
            {
                //Logger.Error(ex); throw ex; 
                return false;
            }
        }

        public bool EditOneCategories(Categories_Info objCategoriesInfo)
        {
            try
            {
                dynamic categories_info = new ePayment.DataProvider.DynamicObj();
                categories_info.ID = objCategoriesInfo.ID;
                categories_info.Name = objCategoriesInfo.Name;
                categories_info.Account_GL = objCategoriesInfo.Account_GL;
                return ePayment.DataProvider.MongoHelper.Save("Categories", categories_info);
            }
            catch (Exception ex)
            {
                //Logger.Error(ex); throw ex; 
                return false;
            }
        }

        public bool RemoveOneCategories(string id)
        {
            try
            {
                return ePayment.DataProvider.MongoHelper.Delete("Categories", id);

            }
            catch (Exception ex)
            {
                //Logger.Error(ex); throw ex; 
                return false;
            }
        }

        public ePayment.DataProvider.DynamicObj GetOneCategories(string id)
        {
            try
            {
                IMongoQuery query;
                return ePayment.DataProvider.MongoHelper.Get("Categories", query);

            }
            catch (Exception ex)
            {
                //Logger.Error(ex); throw ex; 
                return null;
            }
        }

        public ePayment.DataProvider.DynamicObj[] GetAllCategories()
        {
            try
            {
                IMongoQuery query;
                return ePayment.DataProvider.MongoHelper.List("Categories", query);

            }
            catch (Exception ex)
            {
                //Logger.Error(ex); throw ex; 
                return null;
            }
        }

    }
}
