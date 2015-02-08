using System;
using System.Collections.Generic;
using System.Text;

using Account.Common.Entities;
using Account.Business;

namespace Account.UIProviders
{
    public static partial class UITranCode
    {
        static Trancode dal_trancode = new Trancode();
        public static Trancode_Info GetParameterByID(string code)
        {
            return dal_trancode.GetTrancodeByID(code);
        }
        public static List<Trancode_Info> GetAll()
        { return dal_trancode.GetAllTrancode(); }
        public static int Insert(Trancode_Info obj)
        {
            if (obj != null)
            {
                return dal_trancode.Insert(obj);
            }
            else
                throw new Exception(dal_trancode.Error_Message);
        }
        public static int Update(Trancode_Info obj)
        {
            if (obj != null)
            {
                return dal_trancode.Update(obj);
            }
            else
                throw new Exception(dal_trancode.Error_Message);
        }
        public static int Delete(string code)
        {
            if (!string.IsNullOrEmpty(code))
            {
                return dal_trancode.Delete(code);
            }
            else
                throw new Exception(dal_trancode.Error_Message);
        }
    }
}
