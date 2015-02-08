using System;
using System.Collections.Generic;
using System.Text;

using Account.Data.SqlServer;
using Account.Common.Entities;

namespace Account.Business.Base
{
    public partial class BaseEndOfDay:BaseError
    {
        protected D_EndOfDay _dalEOD;
        public BaseEndOfDay()
        { _dalEOD = new D_EndOfDay(); }
        protected List<CheckBalanceInfo> GetResultCheckBalance()
        { return _dalEOD.GetResultCheckBalance(); }
        protected bool Run()
        { 
            return _dalEOD.RunEOD(); 
        }
    }
}
