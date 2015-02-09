using System;
using System.Collections.Generic;
using System.Text;

using Account.Common.Entities;
//using Account.Data.SqlServer;
using Account.Data.Mongo;
using ePayment.DataProvider;

namespace Account.Business.Base
{
    public partial class BaseChannels:BaseError
    {
        protected D_Channels _dalChannel;
        public BaseChannels()
        { _dalChannel = new D_Channels(); }
        public int Insert(DynamicObj obj)
        {
            if (obj == null)
            {
                SetError(98, "Invalid data input");
                return Error_Number;
            }
            _dalChannel.CreateOneChannels(obj);
            return 1;
        }
        public int Update(DynamicObj obj)
        {
            if (obj == null)
            {
                SetError(98, "Invalid data input");
                return Error_Number;
            }
            _dalChannel.EditOneChannels(obj);
            return 1;
            //if (_dalChannel.Execute())
            //    return _dalChannel.LastRecordsEffected;
            //else
            //    throw _dalChannel.GetException;
        }
        protected int Delete(dynamic obj)
        {
            if (obj == null)
            {
                SetError(98, "Invalid data input");
                return Error_Number;
            }
            _dalChannel.RemoveOneChannels(obj.Name);
            return 1;
        }
        protected dynamic GetChannelByName(string name)
        { return _dalChannel.GetOneChannels(name); }
        protected ePayment.DataProvider.DynamicObj[] GetAllChannel()
        { return _dalChannel.GetAllChannels(); }

    }
}
