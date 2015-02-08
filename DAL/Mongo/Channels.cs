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
    public class D_Channels
    {
        public D_Channels()
        {
            ePayment.DataProvider.MongoHelper.MongoDatabase = "epayment";
            ePayment.DataProvider.MongoHelper.MongoServer = "mongodb://127.0.0.1:27017";
        }

        public bool CreateOneChannels(Channel_Info objChannelsInfo)
        {
            try
            {
                dynamic channel_Info = new ePayment.DataProvider.DynamicObj();                
                channel_Info.Name = objChannelsInfo.Name;
                channel_Info.Descript = objChannelsInfo.Descript;
                channel_Info.Service_port = objChannelsInfo.Service_Port;
                channel_Info.Iso_port = objChannelsInfo.ISO_Port;
                channel_Info.Listener_host = objChannelsInfo.Listener_Host;
                channel_Info.Currency_Code = objChannelsInfo.Currency_Code;
                channel_Info.Categories = objChannelsInfo.Categories;
                channel_Info.Branch_ID = objChannelsInfo.Branch;
                channel_Info.User_ID = objChannelsInfo.UserLogin;
                channel_Info.Trancode_AddFund = objChannelsInfo.AddFund_Trancode;
                channel_Info.Trancode_Retail = objChannelsInfo.Retail_Trancode;
                channel_Info.Trancode_Fund_Transfer = objChannelsInfo.FundTranfer_Trancode;
                channel_Info.Security = objChannelsInfo.Security;
                channel_Info.Private_Key = objChannelsInfo.Key;
                channel_Info.CreateDated = objChannelsInfo.Create_Date;
                channel_Info.Last_Date = objChannelsInfo.Last_Date;
                channel_Info.UserCreate = objChannelsInfo.User_Create;
              
                return ePayment.DataProvider.MongoHelper.Save("Channels", channel_Info);
            }
            catch (Exception ex)
            {
                //Logger.Error(ex); throw ex; 
                return false;
            }
        }

        public bool EditOneChannels(Channel_Info objChannelsInfo)
        {
            try
            {
                dynamic channel_Info = new ePayment.DataProvider.DynamicObj();
                channel_Info.Name = objChannelsInfo.Name;
                channel_Info.Descript = objChannelsInfo.Descript;
                channel_Info.Service_port = objChannelsInfo.Service_Port;
                channel_Info.Iso_port = objChannelsInfo.ISO_Port;
                channel_Info.Listener_host = objChannelsInfo.Listener_Host;
                channel_Info.Currency_Code = objChannelsInfo.Currency_Code;
                channel_Info.Categories = objChannelsInfo.Categories;
                channel_Info.Branch_ID = objChannelsInfo.Branch;
                channel_Info.User_ID = objChannelsInfo.UserLogin;
                channel_Info.Trancode_AddFund = objChannelsInfo.AddFund_Trancode;
                channel_Info.Trancode_Retail = objChannelsInfo.Retail_Trancode;
                channel_Info.Trancode_Fund_Transfer = objChannelsInfo.FundTranfer_Trancode;
                channel_Info.Security = objChannelsInfo.Security;
                channel_Info.Private_Key = objChannelsInfo.Key;
                channel_Info.CreateDated = objChannelsInfo.Create_Date;
                channel_Info.Last_Date = objChannelsInfo.Last_Date;
                channel_Info.UserCreate = objChannelsInfo.User_Create;
                return ePayment.DataProvider.MongoHelper.Save("Channels", channel_Info);
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
                IMongoQuery query;
                return ePayment.DataProvider.MongoHelper.Get("Channels", query);

            }
            catch (Exception ex)
            {
                //Logger.Error(ex); throw ex; 
                return null;
            }
        }

        public ePayment.DataProvider.DynamicObj[] GetAllChannels()
        {
            try
            {
                
                IMongoQuery query;             
                return ePayment.DataProvider.MongoHelper.List("Channels", query);

            }
            catch (Exception ex)
            {
                //Logger.Error(ex); throw ex; 
                return null;
            }
        }

    }
}
