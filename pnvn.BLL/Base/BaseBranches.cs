using System;
using System.Collections.Generic;
using System.Text;

using Account.Common.Entities;
using Account.Data.SqlServer;

namespace Account.Business.Base
{
    public partial class BaseBranches:BaseError
    {
        protected D_Branches _dalBranch;

        public BaseBranches()
        { _dalBranch = new D_Branches(); }
        protected int Insert(Branches_Info obj)
        {
            if (obj == null)
            { throw new Exception("Invalid data input"); }
            _dalBranch.CreateOneBranches(obj);
            if (_dalBranch.Execute())
                return _dalBranch.LastRecordsEffected;
            else
                throw _dalBranch.GetException;
        }
        protected int Update(Branches_Info obj)
        {
            if (obj == null)
            { throw new Exception("Invalid data input"); }
            _dalBranch.EditOneBranches(obj);
            if (_dalBranch.Execute())
                return _dalBranch.LastRecordsEffected;
            else
                throw _dalBranch.GetException;
        }
        protected int Delete(Branches_Info obj)
        {
            if (obj == null)
            { throw new Exception("Invalid data input"); }
            _dalBranch.RemoveOneBranches(obj.ID);
            if (_dalBranch.Execute())
                return _dalBranch.LastRecordsEffected;
            else
                throw _dalBranch.GetException;
        }
        protected Branches_Info GetBranchesByID(string id)
        {
            return _dalBranch.GetOneBranches(id);
        }
        protected List<Branches_Info> GetAllBranches()
        { return _dalBranch.GetAllBranches(); }
    }
}
