using System;
using System.Collections.Generic;
using System.Text;
using Account.Common.Entities;
using Account.Business;

namespace Account.UIProviders
{
    public static partial class UIChannels
    {
        static Channels dal_channels = new Channels();
        public static Channel_Info GetChannelByID(string name)
        {
            return dal_channels.GetChannelsByName(name);
        }
        public static List<Channel_Info> GetAll()
        {
            return dal_channels.GetAllChannels();
        }
        public static int Insert(Channel_Info obj)
        {
            if (obj != null)
            {
                return dal_channels.Insert(obj);
            }
            else
                throw new Exception(dal_channels.Error_Message);
        }
        public static int Update(Channel_Info obj)
        {
            if (obj != null)
            {
                return dal_channels.Update(obj);
            }
            else
                throw new Exception(dal_channels.Error_Message);
        }
        public static int Delete(string name)
        {
            if (!string.IsNullOrEmpty(name))
            {
                return dal_channels.Delete(name);
            }
            else
                throw new Exception(dal_channels.Error_Message);
        }
        public static string ValidationMessage
        { get { return dal_channels.Error_Message; } }
    }
}
