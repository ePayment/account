using System;
using System.Collections.Generic;
using System.Text;

using Account.Common.Entities;
using Account.Data.SqlServer;

namespace Account.Business.Base
{
    public partial class BaseWorkingDays:BaseError
    {
        protected D_WorkingDay _dalWork;
        public BaseWorkingDays()
        { _dalWork = new D_WorkingDay(); }
        protected WorkingDay_Info GetWorkingDayByDate(DateTime trandate)
        { return _dalWork.GetOneWorkingDay(trandate); }
        protected List<WorkingDay_Info> GetALLWorkingDays()
        { return _dalWork.GetAllWorkingDay(); }
        protected WorkingDay_Info ToDay()
        {return _dalWork.GetCurrentDay(); }
    }
}
