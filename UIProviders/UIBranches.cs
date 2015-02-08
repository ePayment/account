using System;
using System.Collections.Generic;
using System.Text;
using Account.Common.Entities;
using Account.Business;

namespace Account.UIProviders
{
    public static partial class UIBranches
    {
        static Branches dal_branch = new Branches();

        public static Branches_Info GetBranchesByID(string id)
        {
            return dal_branch.GetBranchesByID(id);
        }
        public static List<Branches_Info> GetAll()
        {
            return dal_branch.GetAllBranches();
        }
        public static int Insert(Branches_Info obj)
        {
            return dal_branch.Insert(obj.ID, obj.Name);
        }
        public static int Update(Branches_Info obj)
        {
            return dal_branch.Update(obj.ID, obj.Name);
        }
        public static int Delete(string id)
        {
            return dal_branch.Delete(id);
        }

        public static string ValidationMessage
        { get { return dal_branch.Error_Message; } }
    }
}
