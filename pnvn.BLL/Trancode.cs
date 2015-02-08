using System;
using System.Collections.Generic;
using System.Text;

using Account.Business.Base;
using Account.Common.Entities;

namespace Account.Business
{
    public partial class Trancode:BaseTrancode
    {
        public new int Insert(Trancode_Info obj)
        {
            if (obj == null)
            {
                SetError(99, "Invalid data input");
                return Error_Number;
            }
            if (string.IsNullOrEmpty(obj.Code))
            {
                SetError(98, "Trancode code is null or empty");
                return Error_Number;
            }
            if (string.IsNullOrEmpty(obj.Name))
            {
                SetError(98, "Trancode name is null or empty");
                return Error_Number;
            }
            if (string.IsNullOrEmpty(obj.Categories))
            {
                SetError(98, "Trancode categories is null or empty");
                return Error_Number;
            }
            if (string.IsNullOrEmpty(obj.CodeType.ToString()))
            {
                SetError(98, "Trancode type is null or empty");
                return Error_Number;
            }
            if (string.IsNullOrEmpty(obj.UserCreate))
            {
                SetError(98, "Trancode usercreate is null or empty");
                return Error_Number;
            }
            if (obj.DateCreated==DateTime.MinValue)
            {
                SetError(98, "Trancode DateCreated is null or empty");
                return Error_Number;
            }
            if (base.Insert(obj) != 0)
                SetError(0, String.Empty);
            else
                SetError(99, Error_Message);
            return Error_Number;
        }
        public new int Update(Trancode_Info obj)
        {
            if (obj == null)
            {
                SetError(99, "Invalid data input");
                return Error_Number;
            }
            if (string.IsNullOrEmpty(obj.Code))
            {
                SetError(98, "Trancode code is null or empty");
                return Error_Number;
            }
            if (string.IsNullOrEmpty(obj.Name))
            {
                SetError(98, "Trancode name is null or empty");
                return Error_Number;
            }
            if (string.IsNullOrEmpty(obj.Categories))
            {
                SetError(98, "Trancode categories is null or empty");
                return Error_Number;
            }
            if (string.IsNullOrEmpty(obj.CodeType.ToString()))
            {
                SetError(98, "Trancode type is null or empty");
                return Error_Number;
            }
            if (string.IsNullOrEmpty(obj.UserCreate))
            {
                SetError(98, "Trancode usercreate is null or empty");
                return Error_Number;
            }
            if (obj.DateCreated == DateTime.MinValue)
            {
                SetError(98, "Trancode DateCreated is null or empty");
                return Error_Number;
            }
            if (base.GetTrancodeByID(obj.Code) == null)
            {
                SetError(98, "Trancode not find");
                return Error_Number;
            }
            if (base.Update(obj) != 0)
                SetError(0, String.Empty);
            else
                SetError(99, Error_Message);
            return Error_Number;
        }
        public int Delete(string code)
        {
            if (string.IsNullOrEmpty(code))
            {
                SetError(98, "Trancode code is null or empty");
                return Error_Number;
            }
            Trancode_Info obj = base.GetTrancodeByID(code);
            if (obj == null)
            {
                SetError(98, "Trancode not find");
                return Error_Number;
            }
            if (base.Delete(obj) != 0)
                SetError(0, String.Empty);
            else
                SetError(99, Error_Message);
            return Error_Number;
        }
        public new Trancode_Info GetTrancodeByID(string code)
        { return base.GetTrancodeByID(code); }
        public new List<Trancode_Info> GetAllTrancode()
        { return base.GetAllTrancode(); }
    }
}
