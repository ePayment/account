using System;
using System.Collections.Generic;
using System.Text;

using Account.Common.Entities;
using Account.Data.SqlServer;

namespace Account.Business.Base
{
    public partial class BaseTrancode:BaseError
    {
        protected D_TranCode _dalTrancode;
        public BaseTrancode()
        { _dalTrancode = new D_TranCode();
        }
        protected int Insert(Trancode_Info obj)
        {
            if (obj == null)
                throw new Exception("Invalid data input");
            _dalTrancode.CreateOneTranCode(obj);
            if (_dalTrancode.Execute())
                return _dalTrancode.LastRecordsEffected;
            else
                throw _dalTrancode.GetException;
        }
        protected int Update(Trancode_Info obj)
        {
            if (obj == null)
                throw new Exception("Invalid data input");
            _dalTrancode.EditOneTranCode(obj);
            if (_dalTrancode.Execute())
                return _dalTrancode.LastRecordsEffected;
            else
                throw _dalTrancode.GetException;
        }
        protected int Delete(Trancode_Info obj)
        {
            if (obj == null)
                throw new Exception("Invalid data input");
            _dalTrancode.RemoveOneTranCode(obj.Code);
            if (_dalTrancode.Execute())
                return _dalTrancode.LastRecordsEffected;
            else
                throw _dalTrancode.GetException;
        }
        protected Trancode_Info GetTrancodeByID(string code)
        { return _dalTrancode.GetOneTranCode(code); }
        protected List<Trancode_Info> GetAllTrancode()
        { return _dalTrancode.GetAllTranCode(); }
    }
}
