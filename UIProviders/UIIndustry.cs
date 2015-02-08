using System;
using System.Collections.Generic;
using System.Text;

using Account.Common.Entities;
using Account.Business;

namespace Account.UIProviders
{
    public static partial class UIIndustry
    {
        static Industry dalIn = new Industry();
        static StringBuilder bstr = new StringBuilder();
        public static Industry_Info GetIndustryByID(string id)
        {
            return dalIn.GetIndustryByID(id);
        }
        public static List<Industry_Info> GetAll()
        { return dalIn.GetAllIndustry(); }
        public static int Insert(Industry_Info obj)
        {
            if (Validation(obj))
            {
                return dalIn.Insert(obj.ID, obj.Name);
            }
            else
                throw new Exception(dalIn.Error_Message);
        }
        public static int Update(Industry_Info obj)
        {            
            if (Validation(obj))
            {
                return dalIn.Update(obj.ID, obj.Name);
            }
            else
                throw new Exception(dalIn.Error_Message);
        }
        public static int Delete(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                return dalIn.Delete(id);
            }
            else
                throw new Exception(dalIn.Error_Message);
        }
        private static bool Validation(Industry_Info obj)
        {
            bstr = new StringBuilder("");

            if (obj==null)
                bstr.Append("Invalid object\n");
            if (string.IsNullOrEmpty(obj.ID))
                bstr.Append("ID is null or empty\n");
            if (string.IsNullOrEmpty(obj.Name))
                bstr.Append("Name is null or empty\n");
            if (string.IsNullOrEmpty(bstr.ToString()))
                return true;
            else
                return false;
        }
        public static string ValidationMessage
        { get { return bstr.ToString(); } }
    }
}
