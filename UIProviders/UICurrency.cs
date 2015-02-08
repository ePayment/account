using System;
using System.Collections.Generic;
using System.Text;

using Account.Common.Entities;
using Account.Business;

namespace Account.UIProviders
{
    public static partial class UICurrency
    {
        static Currency dal_ccy = new Currency();
        public static Currency_Info GetCurrencyByID(string id)
        {
            return dal_ccy.GetCurrencyByID(id);
        }
        public static List<Currency_Info> GetAll()
        {
            return dal_ccy.GetAllCurrency();
        }
        public static int Insert(Currency_Info obj)
        {
            if (obj != null)
            {
                return dal_ccy.Insert(obj.Code, obj.Name, obj.NumberCode);
            }
            else
                throw new Exception(dal_ccy.Error_Message);
        }
        public static int Update(Currency_Info obj)
        {
            if (obj != null)
            {
                return dal_ccy.Update(obj.Code, obj.Name, obj.NumberCode);
            }
            else
                throw new Exception(dal_ccy.Error_Message);
        }
        public static int Delete(string code)
        {
            if (!string.IsNullOrEmpty(code))
            {
                return dal_ccy.Delete(code);
            }
            else
                throw new Exception(dal_ccy.Error_Message);
        }
        public static string ValidationMessage
        { get { return dal_ccy.Error_Message; } }
    }
}
