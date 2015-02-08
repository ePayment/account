using System;
using System.Collections.Generic;
using System.Text;

using Account.Common.Entities;
using Account.Business;

namespace Account.UIProviders
{
    public static partial class UIEndOfDay
    {
        private static EndOfDay _dalEod =new EndOfDay();
        public static List<CheckBalanceInfo> GetResultCheckBalance()
        {
            return _dalEod.CheckAccountBalance();
        }
        public static bool RunEOD()
        { return _dalEod.Run(); }
    }
}
