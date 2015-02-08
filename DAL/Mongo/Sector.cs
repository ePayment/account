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
    public class D_Sector
    {
        public D_Sector()
        {
            ePayment.DataProvider.MongoHelper.MongoDatabase = "epayment";
            ePayment.DataProvider.MongoHelper.MongoServer = "mongodb://127.0.0.1:27017";
        }

        public bool CreateOneSector(Sector_Info objSectorInfo)
        {
            try
            {
                dynamic sector_info = new ePayment.DataProvider.DynamicObj();
                sector_info.ID = objSectorInfo.ID;
                sector_info.Name = objSectorInfo.Name;              
                return ePayment.DataProvider.MongoHelper.Save("Sector", sector_info);
            }
            catch (Exception ex)
            {
                //Logger.Error(ex); throw ex; 
                return false;
            }
        }

        public bool EditOneSector(Sector_Info objSectorInfo)
        {
            try
            {
                dynamic sector_info = new ePayment.DataProvider.DynamicObj();
                sector_info.ID = objSectorInfo.ID;
                sector_info.Name = objSectorInfo.Name;              
                return ePayment.DataProvider.MongoHelper.Save("Sector", sector_info);
            }  
            catch (Exception ex)
            {
                //Logger.Error(ex); throw ex; 
                return false;
            }
        }

        public bool RemoveOneSector(string id)
        {
            try
            {
                return ePayment.DataProvider.MongoHelper.Delete("Sector", id);

            }
            catch (Exception ex)
            {
                //Logger.Error(ex); throw ex; 
                return false;
            }
        }

        public ePayment.DataProvider.DynamicObj GetOneSector(string id)
        {
            try
            {
                IMongoQuery query;
                return ePayment.DataProvider.MongoHelper.Get("Sector", query);

            }
            catch (Exception ex)
            {
                //Logger.Error(ex); throw ex; 
                return null;
            }
        }

        public ePayment.DataProvider.DynamicObj[] GetAllSector()
        {
            try
            {
                IMongoQuery query;
                return ePayment.DataProvider.MongoHelper.List("Sector", query);

            }
            catch (Exception ex)
            {
                //Logger.Error(ex); throw ex; 
                return null;
            }
        }

    }
}
