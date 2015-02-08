using System;
using System.Collections.Generic;
using System.Text;

using Account.Common.Entities;
using Account.Data.SqlServer;

namespace Account.Business.Base
{
    public partial class BaseIndustry:BaseError
    {
        protected D_Industry _dalIn;
        public BaseIndustry()
        { _dalIn = new D_Industry(); }
        protected int Insert(Industry_Info obj)
        {
            if (obj == null)
                throw new Exception("Invalid data input");
            _dalIn.CreateOneIndustry(obj);
            if (_dalIn.Execute())
                return _dalIn.LastRecordsEffected;
            else
                throw _dalIn.GetException;
        }
        protected int Update(Industry_Info obj)
        {
            if (obj == null)
                throw new Exception("Invalid data input");
            _dalIn.EditOneIndustry(obj);
            if (_dalIn.Execute())
                return _dalIn.LastRecordsEffected;
            else
                throw _dalIn.GetException;
        }
        protected int Delete(Industry_Info obj)
        {
            if (obj == null)
                throw new Exception("Invalid data input");
            _dalIn.RemoveOneIndustry(obj.ID);
            if (_dalIn.Execute())
                return _dalIn.LastRecordsEffected;
            else
                throw _dalIn.GetException;
        }
        protected Industry_Info GetIndustryByID(string id)
        {
            return _dalIn.GetOneIndustry(id);
        }
        protected List<Industry_Info> GetAllIndustry()
        { return _dalIn.GetAllIndustry(); }
    }
}
