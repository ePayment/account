using System;
using System.Collections.Generic;
using System.Text;

using Account.Business.Base;
using Account.Common.Entities;

namespace Account.Business
{
    public partial class Channels:BaseChannels
    {
        public new int Insert(Channel_Info obj)
        {
            if (obj == null)
            { 
                SetError(98, "Invalid data input");
                return Error_Number;
            }
            if (string.IsNullOrEmpty(obj.Name))
            {
                SetError(98, "Channels name is null or empty");
                return Error_Number;
            }
            if (string.IsNullOrEmpty(obj.Descript))
            {
                SetError(98, "Channels descript is null or empty");
                return Error_Number;
            }
            if ((obj.Service_Port < 0) || (obj.Service_Port > 65535))
            {
                SetError(98, "Channels Service Port invalid \n Must be in range 0 to 65535");
                return Error_Number;
            }
            if ((obj.ISO_Port < 0) || (obj.ISO_Port > 65535))
            {
                SetError(98, "Channels Iso Port invalid \n Must be in range 0 to 65535");
                return Error_Number;
            }
            
            if (string.IsNullOrEmpty(obj.Listener_Host))
            {
                SetError(98, "Channels Listener Host is null or empty");
                return Error_Number;
            }
            if (string.IsNullOrEmpty(obj.Currency_Code))
            {
                SetError(98, "Channels Currency Code is null or empty");
                return Error_Number;
            }
            if (string.IsNullOrEmpty(obj.Categories))
            {
                SetError(98, "Channels categories Code is null or empty");
                return Error_Number;
            }
            if (string.IsNullOrEmpty(obj.Branch))
            {
                SetError(98, "Channels branch Code is null or empty");
                return Error_Number;
            }
            if (string.IsNullOrEmpty(obj.UserLogin))
            {
                SetError(98, "Channels user login is null or empty");
                return Error_Number;
            }
            if (string.IsNullOrEmpty(obj.Retail_Trancode))
            {
                SetError(98, "Channels trancode retail is null or empty");
                return Error_Number;
            }
            if (string.IsNullOrEmpty(obj.FundTranfer_Trancode))
            {
                SetError(98, "Channels trancode fundtransfer is null or empty");
                return Error_Number;
            }
            if (obj.Create_Date == DateTime.MinValue)
            {
                SetError(98, "Channels createdate is null or empty");
                return Error_Number;
            }
            if (obj.Last_Date == DateTime.MinValue)
            {
                SetError(98, "Channels lastUpdate is null or empty");
                return Error_Number;
            }
            if (string.IsNullOrEmpty(obj.User_Create))
            {
                SetError(98, "Channels user create is null or empty");
                return Error_Number;
            }
            if (base.Insert(obj) != 0)
                SetError(0, string.Empty);
            else
                SetError(99, Error_Message);
            return Error_Number;
        }
        public new int Update(Channel_Info obj)
        {
            if (obj == null)
            {
                SetError(98, "Invalid data input");
                return Error_Number;
            }
            if (string.IsNullOrEmpty(obj.Name))
            {
                SetError(98, "Channels name is null or empty");
                return Error_Number;
            }
            if (string.IsNullOrEmpty(obj.Descript))
            {
                SetError(98, "Channels descript is null or empty");
                return Error_Number;
            }
            if ((obj.Service_Port < 0) || (obj.Service_Port > 65535))
            {
                SetError(98, "Channels Service Port invalid \n Must be in range 0 to 65535");
                return Error_Number;
            }
            if ((obj.ISO_Port < 0) || (obj.ISO_Port > 65535))
            {
                SetError(98, "Channels Iso Port invalid \n Must be in range 0 to 65535");
                return Error_Number;
            }
            if (string.IsNullOrEmpty(obj.Listener_Host))
            {
                SetError(98, "Channels Listener Host is null or empty");
                return Error_Number;
            }
            if (string.IsNullOrEmpty(obj.Currency_Code))
            {
                SetError(98, "Channels Currency Code is null or empty");
                return Error_Number;
            }
            if (string.IsNullOrEmpty(obj.Categories))
            {
                SetError(98, "Channels categories Code is null or empty");
                return Error_Number;
            }
            if (string.IsNullOrEmpty(obj.Branch))
            {
                SetError(98, "Channels branch Code is null or empty");
                return Error_Number;
            }
            if (string.IsNullOrEmpty(obj.UserLogin))
            {
                SetError(98, "Channels user login is null or empty");
                return Error_Number;
            }
            if (string.IsNullOrEmpty(obj.Retail_Trancode))
            {
                SetError(98, "Channels trancode retail is null or empty");
                return Error_Number;
            }
            if (string.IsNullOrEmpty(obj.FundTranfer_Trancode))
            {
                SetError(98, "Channels trancode fundtransfer is null or empty");
                return Error_Number;
            }
            if (obj.Create_Date == DateTime.MinValue)
            {
                SetError(98, "Channels createdate is null or empty");
                return Error_Number;
            }
            if (obj.Last_Date == DateTime.MinValue)
            {
                SetError(98, "Channels lastUpdate is null or empty");
                return Error_Number;
            }
            if (string.IsNullOrEmpty(obj.User_Create))
            {
                SetError(98, "Channels user create is null or empty");
                return Error_Number;
            }
            if (base.GetChannelByName(obj.Name) == null)
            {
                SetError(99, "Channels not find");
                return Error_Number;
            }
            if (base.Update(obj) != 0)
                SetError(0, string.Empty);
            else
                SetError(99, Error_Message);
            return Error_Number;
        }
        public int Delete(string channelName)
        {
            if (string.IsNullOrEmpty(channelName))
            {
                SetError(98, "Channel name is null or empty");
                return Error_Number;
            }
            Channel_Info obj = base.GetChannelByName(channelName);
            if (obj == null)
            {
                SetError(98, "Channel not find");
                return Error_Number;
            }
            if (base.Delete(obj) != 0)
                SetError(0, String.Empty);
            else
                SetError(99, Error_Message);
            return Error_Number;
        }
        public Channel_Info GetChannelsByName(string channelName)
        { return base.GetChannelByName(channelName); }
        public List<Channel_Info> GetAllChannels()
        { return base.GetAllChannel(); }
    }
}
