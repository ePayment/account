using Account.Common.Entities;
using log4net.Repository.Hierarchy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Dynamic;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using ePayment.DataProvider;
namespace Account.Data.Mongo
{
    public class D_Channels
    {
        public D_Channels()
        {
            ePayment.DataProvider.MongoHelper.MongoDatabase = "epayment";
            ePayment.DataProvider.MongoHelper.MongoServer = "mongodb://127.0.0.1:27017";
        }

        public bool CreateOneChannels(dynamic objChannelsInfo)
        {
            try
            {       
                return ePayment.DataProvider.MongoHelper.Save("Channels", objChannelsInfo);
            }
            catch (Exception ex)
            {
                //Logger.Error(ex); throw ex; 
                return false;
            }
        }

        public bool EditOneChannels(dynamic objChannelsInfo)
        {
            try
            {
                return ePayment.DataProvider.MongoHelper.Save("Channels", objChannelsInfo);
            }
            catch (Exception ex)
            {
                //Logger.Error(ex); throw ex; 
                return false;
            }
        }

        public bool RemoveOneChannels(string id)
        {
            try
            {
                return ePayment.DataProvider.MongoHelper.Delete("Channels", id);

            }
            catch (Exception ex)
            {
                //Logger.Error(ex); throw ex; 
                return false;
            }
        }

        public ePayment.DataProvider.DynamicObj GetOneChannels(string id)
        {
            try
            {
                IMongoQuery query = Query.EQ("_id",id);
                return ePayment.DataProvider.MongoHelper.Get("Channels", query);

            }
            catch (Exception ex)
            {
                //Logger.Error(ex); throw ex; 
                return null;
            }
        }

        public DynamicObj[] GetAllChannels()
        {
            DynamicObj[] list = new DynamicObj[] { };
            try
            {     
                return ePayment.DataProvider.MongoHelper.List("Channels", null);
                //foreach (dynamic c in _list)
                //{
                //    list.Add(
                //        new Channel_Info{ ID = c.id, Name = c.name, Service_Port = c.service_port, ISO_Port = c.ISO_Port, Listener_Host = c.Listener_Host,
                //            Currency_Code = c.Currency
                //        }
                //        )
                //}
            }
            catch (Exception ex)
            {
                //Logger.Error(ex); throw ex; 
            }
            return list;
        }

    }
}
