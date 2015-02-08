using System;
using System.Collections.Generic;
using System.Text;
using Account.Common.Entities;
using Account.Business;

namespace Account.UIProviders
{
    public static partial class UITranday
    {
        static Tranday dal_tranday = new Tranday();
        public static Tranday_Info GetTrandayByID(string id)
        {
            return dal_tranday.GetTrandayByID(id);
        }
        public static string GenerateNewID()
        { return dal_tranday.GenerateNewDocID(); }
        public static List<Tranday_Info> GetTransactionByAccount(string accountId, DateTime dateFrom, DateTime dateTo)
        { return dal_tranday.GetTransactionByAccount(accountId, dateFrom, dateTo); }
    }
}
