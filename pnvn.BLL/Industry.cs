using System;
using System.Collections.Generic;
using System.Text;

using Account.Business.Base;
using Account.Common.Entities;

namespace Account.Business
{
    public partial class Industry:BaseIndustry
    {
        public int Insert(string id, string name)
        {
            if (string.IsNullOrEmpty(id))
            {
                SetError(98, "Industry id is null or empty");
                return Error_Number;
            }
            if (string.IsNullOrEmpty(name))
            {
                SetError(98, "Industry name is null or empty");
                return Error_Number;
            }
            Industry_Info obj = new Industry_Info();
            obj.ID = id;
            obj.Name = name;
            if (base.Insert(obj) != 0)
                SetError(0, String.Empty);
            else
                SetError(99, Error_Message);
            return Error_Number;
        }
        public int Update(string id, string name)
        {
            if (string.IsNullOrEmpty(id))
            {
                SetError(98, "Industry id is null or empty");
                return Error_Number;
            }
            if (string.IsNullOrEmpty(name))
            {
                SetError(98, "Industry name is null or empty");
                return Error_Number;
            }
            Industry_Info obj = base.GetIndustryByID(id);
            if (obj == null)
            {
                SetError(99, "Industry not find");
                return Error_Number;
            }
            obj.Name = name;
            if (base.Update(obj) != 0)
                SetError(0, String.Empty);
            else
                SetError(99, Error_Message);
            return Error_Number;
        }
        public int Delete(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                SetError(98, "Industry id is null or empty");
                return Error_Number;
            }
            Industry_Info obj = base.GetIndustryByID(id);
            if (obj == null)
            {
                SetError(99, "Industry not find");
                return Error_Number;
            }
            if (base.Delete(obj) != 0)
                SetError(0, string.Empty);
            else
                SetError(99, Error_Message);
            return Error_Number;
        }
        public new Industry_Info GetIndustryByID(string id)
        { return base.GetIndustryByID(id); }
        public new List<Industry_Info> GetAllIndustry()
        { return base.GetAllIndustry(); }
    }
}
