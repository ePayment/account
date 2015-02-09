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
    public class D_Parameter
    {
        public D_Parameter()
        {
            ePayment.DataProvider.MongoHelper.MongoDatabase = "epayment";
            ePayment.DataProvider.MongoHelper.MongoServer = "mongodb://127.0.0.1:27017";
        }

        public bool CreateOneParameters(Parameter_Info objParam)
        {
            try
            {
                dynamic parameter_info = new ePayment.DataProvider.DynamicObj();
                parameter_info.Name = objParam.Name;
                parameter_info.Value = objParam.Value;
                parameter_info.Descript = objParam.Descript;
                return ePayment.DataProvider.MongoHelper.Save("Parameters", parameter_info);
            }
            catch (Exception ex)
            {
                //Logger.Error(ex); throw ex; 
                return false;
            }
        }

        public bool EditOneParameters(Parameter_Info objParam)
        {
            try
            {
                dynamic parameter_info = new ePayment.DataProvider.DynamicObj();
                parameter_info.Name = objParam.Name;
                parameter_info.Value = objParam.Value;
                parameter_info.Descript = objParam.Descript;
                return ePayment.DataProvider.MongoHelper.Save("Parameters", parameter_info);

            }
            catch (Exception ex)
            {
                //Logger.Error(ex); throw ex; 
                return false;
            }
        }

        public bool RemoveOneParameters(string name)
        {
            try
            {
                return ePayment.DataProvider.MongoHelper.Delete("Parameters", name);

            }
            catch (Exception ex)
            {
                //Logger.Error(ex); throw ex; 
                return false;
            }
        }

        public ePayment.DataProvider.DynamicObj GetOneParameters(string id)
        {
            try
            {
                IMongoQuery query = Query.EQ("_id", id);
                return ePayment.DataProvider.MongoHelper.Get("Parameters", query);

            }
            catch (Exception ex)
            {
                //Logger.Error(ex); throw ex; 
                return null;
            }
        }

        public ePayment.DataProvider.DynamicObj[] GetAllParameters()
        {
            try
            {
                return ePayment.DataProvider.MongoHelper.List("Parameters", null);

            }
            catch (Exception ex)
            {
                //Logger.Error(ex); throw ex; 
                return null;
            }
        }
       
    }
}
