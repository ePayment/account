using System;
using System.Collections.Generic;
using System.Text;

using Account.Common.Entities;
using Account.Business;

namespace Account.UIProviders
{
    public static partial class UISector
    {
        static Sector dalSec = new Sector();
        static StringBuilder bstr = new StringBuilder();

        public static Sector_Info GetSectorByID(string id)
        {
            return dalSec.GetSectorByID(id);
        }
        public static List<Sector_Info> GetAll()
        {
            return dalSec.GetAllSector();
        }
        public static int Insert(Sector_Info obj)
        {
            if (Validation(obj))
            {
                return dalSec.Insert(obj.ID, obj.Name);
            }
            else
                throw new Exception(dalSec.Error_Message);
        }
        public static int Update(Sector_Info obj)
        {
            if (Validation(obj))
            {
                return dalSec.Update(obj.ID,obj.Name);
            }
            else
                throw new Exception(dalSec.Error_Message);
        }
        public static int Delete(string id)
        {
            if (!string.IsNullOrEmpty(id))
                return dalSec.Delete(id);
            else
                throw new Exception(dalSec.Error_Message);
        }
        private static bool Validation(Sector_Info obj)
        {
            // reset temp string
            bstr = new StringBuilder("");
            if (obj == null)
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
