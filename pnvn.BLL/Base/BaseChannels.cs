using System;
using System.Collections.Generic;
using System.Text;

using Account.Common.Entities;
using Account.Data.SqlServer;

namespace Account.Business.Base
{
    public partial class BaseChannels:BaseError
    {
        protected D_Channels _dalChannel;
        public BaseChannels()
        { _dalChannel = new D_Channels(); }
        protected int Insert(Channel_Info obj)
        {
            if (obj == null)
            {
                SetError(98, "Invalid data input");
                return Error_Number;
            }
            _dalChannel.CreateOneChannel(obj);
            if (_dalChannel.Execute())
                return _dalChannel.LastRecordsEffected;
            else
                throw _dalChannel.GetException;
        }
        protected int Update(Channel_Info obj)
        {
            if (obj == null)
            {
                SetError(98, "Invalid data input");
                return Error_Number;
            }
            _dalChannel.EditOneChannel(obj);
            if (_dalChannel.Execute())
                return _dalChannel.LastRecordsEffected;
            else
                throw _dalChannel.GetException;
        }
        protected int Delete(Channel_Info obj)
        {
            if (obj == null)
            {
                SetError(98, "Invalid data input");
                return Error_Number;
            }
            _dalChannel.RemoveOneChannel(obj.Name);
            if (_dalChannel.Execute())
                return _dalChannel.LastRecordsEffected;
            else
                throw _dalChannel.GetException;
        }
        protected Channel_Info GetChannelByName(string name)
        { return _dalChannel.GetOneChannel(name); }
        protected List<Channel_Info> GetAllChannel()
        { return _dalChannel.GetAllChannels(); }

    }
}
