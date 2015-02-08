using System;
using System.Collections.Generic;
using System.Text;
using Account.Common.Entities;
using Account.Business;

namespace Account.UIProviders
{
    public static partial class UIParameters
    {
        static Parameters dal_para = new Parameters();
        public static Parameter_Info GetParameterByID(string name)
        {
            return dal_para.GetParameterByName(name);
        }
        public static List<Parameter_Info> GetAll()
        { return dal_para.GetAllParameters(); }
        public static int Update(Parameter_Info obj)
        {
            if (obj != null)
                return dal_para.Update(obj.Name, obj.Value, obj.Descript);
            else
                throw new Exception(dal_para.Error_Message);
        }
    }
}
