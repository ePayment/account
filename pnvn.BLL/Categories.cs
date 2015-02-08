using System;
using System.Collections.Generic;
using System.Text;

using Account.Business.Base;
using Account.Common.Entities;

namespace Account.Business
{
    public partial class Categories:BaseCategories
    {
        public int Insert(string id, string name, string account_GL)
        {
            if (string.IsNullOrEmpty(id))
            {
                SetError(98, "Categories Id is null or empty");
                return Error_Number;
            }
            if (string.IsNullOrEmpty(name))
            {
                SetError(98, "Categories name is null or empty");
                return Error_Number;
            }
            AccountGL dal_AcGL = new AccountGL();
            Account_GL_Info acGLInfo = dal_AcGL.GetAccountGLByID(account_GL);
            if (acGLInfo==null)
            {
                SetError(98, "Account_GL not find");
                return Error_Number;
            }
            
            Categories_Info catInfo = new Categories_Info();
            catInfo.ID = id;
            catInfo.Name = name;
            catInfo.Account_GL = acGLInfo;
            if (base.Insert(catInfo) != 0)
                SetError(0, string.Empty);
            else
                SetError(99, _dalCat.GetException.Message);
            return Error_Number;
        }
        public int Update(string id, string name, string account_GL)
        {
            if (string.IsNullOrEmpty(id))
            {
                SetError(98, "Categories Id is null or empty");
                return Error_Number;
            }
            if (string.IsNullOrEmpty(name))
            {
                SetError(98, "Categories name is null or empty");
                return Error_Number;
            }
            AccountGL dal_AcGL = new AccountGL();
            Account_GL_Info acGLInfo = dal_AcGL.GetAccountGLByID(account_GL);
            if (acGLInfo == null)
            {
                SetError(98, "Account_GL not find");
                return Error_Number;
            }            
            
            Categories_Info catInfo = base.GetCategoriesById(id);
            if (catInfo == null)
            {
                SetError(99, "Categories not find");
                return Error_Number;
            }
            // Set info
            catInfo.Name = name;
            catInfo.Account_GL = acGLInfo;

            if (base.Update(catInfo) != 0)
                SetError(0, string.Empty);
            else
                SetError(99, _dalCat.GetException.Message);
            return Error_Number;
        }
        public int Delete(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                SetError(98, "Categories Id is null or empty");
                return Error_Number;
            }
            Categories_Info catInfo = base.GetCategoriesById(id);
            if (catInfo == null)
            {
                SetError(99, "Categories not find");
                return Error_Number;
            }
            if (base.Delete(catInfo) != 0)
                SetError(0, string.Empty);
            else
                SetError(99, _dalCat.GetException.Message);
            return Error_Number;
        }
        public Categories_Info GetCategoriesByID(string id)
        {
            return base.GetCategoriesById(id);
        }
        public new List<Categories_Info> GetAllCategories()
        { return base.GetAllCategories(); }
    }
}
