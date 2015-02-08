using System;
using System.Collections.Generic;
using System.Text;
using Account.Common.Entities;
using Account.Business;

namespace Account.UIProviders
{
    public static partial class UICategories
    {
        static Categories dal_cat = new Categories();
        
        public static Categories_Info GetCategoriesByID(string id)
        {
                return dal_cat.GetCategoriesByID(id);
        }
        public static List<Categories_Info> GetAll()
        {
            return dal_cat.GetAllCategories();
        }
        public static int Insert(Categories_Info obj)
        {
            if (obj != null)
            {
                return dal_cat.Insert(obj.ID, obj.Name, obj.Account_GL.Account_ID);
            }
            else
                throw new Exception(dal_cat.Error_Message);
        }
        public static int Update(Categories_Info obj)
        {
            if (obj != null)
            {
                return dal_cat.Update(obj.ID, obj.Name, obj.Account_GL.Account_ID);
            }
            else
                throw new Exception(dal_cat.Error_Message);
        }
        public static int Delete(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                return dal_cat.Delete(id);
            }
            else
                throw new Exception(dal_cat.Error_Message);
        }

        public static string ValidationMessage
        { get { return dal_cat.Error_Message; } }
    }
}
