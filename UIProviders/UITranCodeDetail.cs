using System;
using System.Collections.Generic;
using System.Text;
using Account.Common.Entities;
using Account.Business;

namespace Account.UIProviders
{
    public static partial class UITranCodeDetail
    {
        static TranCodeDetail dal_trancode_detail = new TranCodeDetail();
        public static TranCodeDetail_Info GetParameterByID(string id)
            {
                return dal_trancode_detail.GetTranCodeDetailByID((decimal)Decimal.Parse(id));
            }
        public static List<TranCodeDetail_Info> GetAll()
        { return dal_trancode_detail.GetAllTranCodeDetail(); }
        public static int Insert(TranCodeDetail_Info obj)
        {
            if (obj != null)
            {
                return dal_trancode_detail.Insert(obj);
            }
            else
                throw new Exception(dal_trancode_detail.Error_Message);
        }
        public static int Update(TranCodeDetail_Info obj)
        {
            if (obj != null)
            {
                return dal_trancode_detail.Update(obj);
            }
            else
                throw new Exception(dal_trancode_detail.Error_Message);
        }
        public static int DeleteByID(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                return dal_trancode_detail.Delete((decimal)Decimal.Parse(id));
            }
            else
                throw new Exception(dal_trancode_detail.Error_Message);
        }
    }
}
