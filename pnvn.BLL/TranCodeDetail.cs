using System;
using System.Collections.Generic;
using System.Text;

using Account.Business.Base;
using Account.Common.Entities;

namespace Account.Business
{
    public partial class TranCodeDetail:BaseTranCodeDetail
    {
        public  new int Insert(TranCodeDetail_Info obj)
        {
            if (obj == null)
            {
                SetError(98, "Object is null");
                return Error_Number;
            }
            if (string.IsNullOrEmpty(obj.Code))
            {
                SetError(98, "Code is null or empty");
                return Error_Number;
            }
            if (string.IsNullOrEmpty(obj.Account_ID))
            {
                SetError(98, "Account_ID is null or empty");
                return Error_Number;
            }
            if (string.IsNullOrEmpty(obj.CreditDebit.ToString()))
            {
                SetError(98, "CreditDebit is null or empty");
                return Error_Number;
            }
            if (string.IsNullOrEmpty(obj.NumberType.ToString()))
            {
                SetError(98, "NumberType is null or empty");
                return Error_Number;
            }
            if(base.Insert(obj)!=0)
                SetError(0,String.Empty);
            else
                SetError(99,Error_Message);
            return Error_Number;
        }
        public new int Update(TranCodeDetail_Info obj)
        {
            if (obj == null)
            {
                SetError(98, "Object is null");
                return Error_Number;
            }
            if (string.IsNullOrEmpty(obj.Code))
            {
                SetError(98, "Code is null or empty");
                return Error_Number;
            }
            if (string.IsNullOrEmpty(obj.Account_ID))
            {
                SetError(98, "Account_ID is null or empty");
                return Error_Number;
            }
            if (string.IsNullOrEmpty(obj.CreditDebit.ToString()))
            {
                SetError(98, "CreditDebit is null or empty");
                return Error_Number;
            }
            if (string.IsNullOrEmpty(obj.NumberType.ToString()))
            {
                SetError(98, "NumberType is null or empty");
                return Error_Number;
            }
            if (base.GetTranCodeDetailByID(obj.ID)==null)
            {
                SetError(99, "TranCOdeDetail not find");
                return Error_Number;
            }
            if(base.Update(obj)!=0)
                SetError(0,String.Empty);
            else
                SetError(99,Error_Message);
            return Error_Number;
        }
        public int Delete(decimal id)
        {
            TranCodeDetail_Info obj = base.GetTranCodeDetailByID(id);
            if (obj == null)
            {
                SetError(99, "TranCodeDetail not find");
                return Error_Number;
            }
            if (base.Delete(obj) != 0)
                SetError(0, String.Empty);
            else
                SetError(99, Error_Message);
            return Error_Number;
        }
        public new TranCodeDetail_Info GetTranCodeDetailByID(decimal id)
        { return base.GetTranCodeDetailByID(id); }
        public new List<TranCodeDetail_Info> GetAllTranCodeDetail()
        { return base.GetAllTranCodeDetail(); }
    }
}
