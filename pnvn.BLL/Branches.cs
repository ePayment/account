using System;
using System.Collections.Generic;
using System.Text;

using Account.Common.Entities;
using Account.Business.Base;

namespace Account.Business
{
    public partial class Branches:BaseBranches
    {
        public int Insert(string id, string name)
        {
            if (string.IsNullOrEmpty(id))
            {
                SetError(98, "Invalid id");
                return Error_Number;
            }
            if (string.IsNullOrEmpty(name))
            {
                SetError(98, "Invalid name");
                return Error_Number;
            }
            Branches_Info branchInfo = new Branches_Info();
            branchInfo.ID = id;
            branchInfo.Name = name;
            if (base.Insert(branchInfo) != 0)
                SetError(0, String.Empty);
            else
                SetError(99, _dalBranch.GetException.Message);
            return Error_Number;

        }
        public int Update(string id, string name)
        {
            if (string.IsNullOrEmpty(id))
            {
                SetError(98, "Invalid id");
                return Error_Number;
            }
            if (string.IsNullOrEmpty(name))
            {
                SetError(98, "Invalid name");
                return Error_Number;
            }
            Branches_Info branchInfo = _dalBranch.GetOneBranches(id);
            if (branchInfo == null)
            {
                SetError(98, "Branches not find");
                return Error_Number;
            }

            branchInfo.ID = id;
            branchInfo.Name = name;
            if (base.Update(branchInfo) != 0)
                SetError(0, String.Empty);
            else
                SetError(99, _dalBranch.GetException.Message);
            return Error_Number;

        }
        public int Delete(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                SetError(98, "Invalid id");
                return Error_Number;
            }
            Branches_Info branchInfo = _dalBranch.GetOneBranches(id);
            if (branchInfo == null)
            {
                SetError(98, "Branches not find");
                return Error_Number;
            }

            if (base.Delete(branchInfo) != 0)
                SetError(0, String.Empty);
            else
                SetError(99, _dalBranch.GetException.Message);
            return Error_Number;
        }
        public new Branches_Info GetBranchesByID(string id)
        { return base.GetBranchesByID(id); }
        public new List<Branches_Info> GetAllBranches()
        { return base.GetAllBranches(); }
    }
}
