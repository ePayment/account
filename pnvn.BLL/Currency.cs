using System;
using System.Collections.Generic;
using System.Text;

using Account.Business.Base;
using Account.Common.Entities;

namespace Account.Business
{
    public partial class Currency:BaseCurrency
    {
        public int Insert(string code, string name, int numbercode)
        {
            if (string.IsNullOrEmpty(code))
            {
                SetError(98, "Invalid currency code");
                return Error_Number;
            }
            if (string.IsNullOrEmpty(name))
            {
                SetError(98, "Invalid currency name");
                return Error_Number;
            }
            if (numbercode == 0)
            {
                SetError(98, "Invalid currency number code");
                return Error_Number;
            }
            Currency_Info ccyInfo = new Currency_Info();
            ccyInfo.Code = code;
            ccyInfo.Name = name;
            ccyInfo.NumberCode = numbercode;
            if (base.Insert(ccyInfo) != 0)
                SetError(0, String.Empty);
            else
                SetError(99, Error_Message);
            return Error_Number;
        }
        public int Update(string code, string name, int numbercode)
        {
            if (string.IsNullOrEmpty(code))
            {
                SetError(98, "Invalid currency code");
                return Error_Number;
            }
            if (string.IsNullOrEmpty(name))
            {
                SetError(98, "Invalid currency name");
                return Error_Number;
            }
            if (numbercode == 0)
            {
                SetError(98, "Invalid currency number code");
                return Error_Number;
            }
            Currency_Info ccyInfo = base.GetCurrencyById(code);
            if (ccyInfo == null)
            {
                SetError(99, "Currency not find");
                return Error_Number;
            }
            ccyInfo.Name = name;
            ccyInfo.NumberCode = numbercode;
            if (base.Update(ccyInfo) != 0)
                SetError(0, String.Empty);
            else
                SetError(99, Error_Message);
            return Error_Number;
        }
        public int Delete(string code)
        {
            if (string.IsNullOrEmpty(code))
            {
                SetError(98, "Invalid currency code");
                return Error_Number;
            }
            Currency_Info ccyInfo = base.GetCurrencyById(code);
            if (ccyInfo == null)
            {
                SetError(99, "Currency not find");
                return Error_Number;
            }
            if (base.Delete(ccyInfo) != 0)
                SetError(0, String.Empty);
            else
                SetError(99, Error_Message);
            return Error_Number;
        }
        public Currency_Info GetCurrencyByID(string code)
        { return base.GetCurrencyById(code); }
        public new List<Currency_Info> GetAllCurrency()
        { return base.GetAllCurrency(); }

    }
}
