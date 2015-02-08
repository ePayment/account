using System;
using System.Collections.Generic;
using System.Text;

using Account.Business.Base;
using Account.Common.Entities;

namespace Account.Business
{
    public partial class Tranday:BaseTranday
    {
        public Tranday_Info GetTrandayByID(string docId)
        { return base.GetTrandayById(docId); }
        public List<Tranday_Info> GetTransactionByAccount(string accountId,DateTime dateFrom,DateTime dateTo)
        {
            if (string.IsNullOrEmpty(accountId))
                throw new Exception("Account Id is null or empty");
            if (dateFrom == DateTime.MinValue)
                throw new Exception("Invalid date from");
            if (dateTo == DateTime.MinValue)
                throw new Exception("Invalid date to");
            if (dateFrom > dateTo)
                throw new Exception("invalid date from > date to");
            List<Tranday_Info> list;
            if ((dateFrom == dateTo) && (dateTo == BaseParameters.ToDay().TransDate))
            {
                // ngày giao dịch hiện tại
                list = base.GetTrandayByAccount(accountId);
            }
            else
            {
                list = base.GetTranAllByAccount(accountId, dateFrom, dateTo);
            }
            return list;
        }
        public string GenerateNewDocID()
        { return base.GenerateDocId(); }
    }
}
