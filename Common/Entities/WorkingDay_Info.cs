using System;
using System.Collections.Generic;
using System.Text;

namespace Account.Common.Entities
{
    public class WorkingDay_Info
    {
        DateTime transdate;
        DateTime beginoftime;
        DateTime endoftime;
        bool iseod;
        public WorkingDay_Info()
        { }
        public WorkingDay_Info(DateTime _transdate, DateTime _beginoftime
                               , DateTime _endoftime, bool _iseod)
        {
            this.TransDate = _transdate;
            this.beginoftime = _beginoftime;
            this.endoftime = _endoftime;
            this.IsEOD = _iseod;
        }
        public DateTime TransDate
        { get { return transdate; } set { transdate = value; } }
        public DateTime BeginOfTime
        { get { return beginoftime; } set { beginoftime = value; } }
        public DateTime EndOfTime
        { get { return endoftime; } set { endoftime = value; } }
        public bool IsEOD
        { get { return iseod; } set { iseod = value; } }
    }
}