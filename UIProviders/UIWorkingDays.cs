using System;
using System.Collections.Generic;
using System.Text;
using Account.Common.Entities;
using Account.Business;

namespace Account.UIProviders
{
    public static partial class UIWorkingDays
    {
        static WorkingDay dalWorking = new WorkingDay();
        public static WorkingDay_Info GetWorkingDayByDate(DateTime date)
        {
            return dalWorking.GetWorkingDayByDate(date);
        }
        public static WorkingDay_Info GetToday()
        {
            return dalWorking.ToDay();
        }
        public static List<WorkingDay_Info> GetAll()
        {
            return dalWorking.GetAllWorkingDays();
        }
    }
}
