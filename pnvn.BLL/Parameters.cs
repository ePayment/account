using System;
using System.Collections.Generic;
using System.Text;

using Account.Business.Base;
using Account.Common.Entities;

namespace Account.Business
{
    public partial class Parameters:BaseParameters
    {
        public int Update(string para_name, string para_value, string para_descript)
        {
            if (string.IsNullOrEmpty(para_name))
            {
                SetError(98,"Parameters name is null or empty");
                return Error_Number;
            }
            if (BaseParameters.Edit(para_name, para_value, para_descript))
                SetError(0,String.Empty);
            else
                SetError(99,Error_Message);
            return Error_Number;
        }
        public Parameter_Info GetParameterByName(string paraName)
        {
            return BaseParameters.Search(paraName);
        }
        public List<Parameter_Info> GetAllParameters()
        { return BaseParameters.Parameters; }
    }
}
