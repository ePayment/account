using System;
using System.Collections.Generic;
using System.Text;

using Account.Common.Entities;
using Account.Business.Base;

namespace Account.Business
{
    public class WorkingDay:BaseWorkingDays
    {
        public new WorkingDay_Info GetWorkingDayByDate(DateTime trandate)
        {
            return base.GetWorkingDayByDate(trandate);
        }
        public List<WorkingDay_Info> GetAllWorkingDays()
        { return base.GetALLWorkingDays(); }
        public new WorkingDay_Info ToDay()
        { return base.ToDay(); }
    }
    
}
    

