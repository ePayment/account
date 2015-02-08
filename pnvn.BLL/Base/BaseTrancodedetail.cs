using System;
using System.Collections.Generic;
using System.Text;

using Account.Common.Entities;
using Account.Data.SqlServer;

namespace Account.Business.Base
{
    public partial class BaseTranCodeDetail:BaseError
    {
        protected D_TranCodeDetail _dalTranCodeDetail;
        public BaseTranCodeDetail()
        { _dalTranCodeDetail = new D_TranCodeDetail(); }
        protected int Insert(TranCodeDetail_Info obj)
        {
            if (obj == null)
                throw new Exception("Invalid data input");
            _dalTranCodeDetail.CreateOneTranCodeDetail(obj);
            if (_dalTranCodeDetail.Execute())
                return _dalTranCodeDetail.LastRecordsEffected;
            else
                throw _dalTranCodeDetail.GetException;
        }
        protected int Update(TranCodeDetail_Info obj)
        {
            if (obj == null)
                throw new Exception("Invalid data input");
            _dalTranCodeDetail.EditOneTranCodeDetail(obj);
            if (_dalTranCodeDetail.Execute())
                return _dalTranCodeDetail.LastRecordsEffected;
            else
                throw _dalTranCodeDetail.GetException;
        }
        protected int Delete(TranCodeDetail_Info obj)
        {
            if (obj == null)
                throw new Exception("Invalid data input");
            _dalTranCodeDetail.RemoveOneTranCodeDetail(obj.ID);
            if (_dalTranCodeDetail.Execute())
                return _dalTranCodeDetail.LastRecordsEffected;
            else
                throw _dalTranCodeDetail.GetException;
        }
        protected int Delete(string code)
        {
            if (string.IsNullOrEmpty(code))
                throw new Exception("Invalid data input");
            _dalTranCodeDetail.RemoveOneTranCodeDetailByCode(code);
            if (_dalTranCodeDetail.Execute())
                return _dalTranCodeDetail.LastRecordsEffected;
            else
                throw _dalTranCodeDetail.GetException;
        }
        protected TranCodeDetail_Info GetTranCodeDetailByID(decimal id)
        { return _dalTranCodeDetail.GetOneTranCodeDetail(id); }
        protected List<TranCodeDetail_Info> GetAllTranCodeDetail()
        { return _dalTranCodeDetail.GetAllTranCodeDetail(); }
    }
}
