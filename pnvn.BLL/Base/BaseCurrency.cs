using System;
using System.Collections.Generic;
using System.Text;

using Account.Common.Entities;
using Account.Data.SqlServer;

namespace Account.Business.Base
{
    public partial class BaseCurrency:BaseError
    {
        protected D_Currency _dalCcy;
        public BaseCurrency()
        { _dalCcy = new D_Currency(); }
        protected int Insert(Currency_Info obj)
        {
            if (obj == null)
                throw new Exception("Invalid data input");
            _dalCcy.CreateOneCurrency(obj);
            if (_dalCcy.Execute())
                return _dalCcy.LastRecordsEffected;
            throw _dalCcy.GetException;
        }
        protected int Update(Currency_Info obj)
        {
            if (obj == null)
                throw new Exception("Invalid data input");
            _dalCcy.EditOneCurrency(obj);
            if (_dalCcy.Execute())
                return _dalCcy.LastRecordsEffected;
            throw _dalCcy.GetException;
        }
        protected int Delete(Currency_Info obj)
        {
            if (obj == null)
                throw new Exception("Invalid data input");
            _dalCcy.RemoveOneCurrency(obj.Code);
            if (_dalCcy.Execute())
                return _dalCcy.LastRecordsEffected;
            throw _dalCcy.GetException;
        }
        protected Currency_Info GetCurrencyById(string code)
        { return _dalCcy.GetOneCurrency(code); }
        protected List<Currency_Info> GetAllCurrency()
        { return _dalCcy.GetAllCurrency(); }
    }
}
