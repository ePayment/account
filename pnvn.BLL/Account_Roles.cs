using System;
using System.Collections.Generic;
using System.Text;

using Account.Business.Base;
using Account.Common.Entities;

namespace Account.Business
{
    public partial class Account_Roles:BaseAccountRoles
    {
        public new int Insert(AccountRoles_Info acRoleInfo)
        {
            if (acRoleInfo == null)
            {
                SetError(98, "Invalid data input");
                return Error_Number;
            }
            if (string.IsNullOrEmpty(acRoleInfo.Account_ID))
            {
                SetError(98, "Account_ID is null or empty");
                return Error_Number;
            }
            if (string.IsNullOrEmpty(acRoleInfo.Name))
            {
                SetError(98, "Name is null or empty");
                return Error_Number;
            }
            if (Convert.ToInt32(acRoleInfo.Seq)==0)
            {
                SetError(98, "Seq is null or empty");
                return Error_Number;
            }
            if (string.IsNullOrEmpty(acRoleInfo.Operator.ToString()))
            {
                SetError(98, "Operater is null or empty");
                return Error_Number;
            }
            if (string.IsNullOrEmpty(acRoleInfo.Type.ToString()))
            {
                SetError(98, "Type is null or empty");
                return Error_Number;
            }
            if ((acRoleInfo.Active==true)&&(acRoleInfo.Active_Date==DateTime.MinValue))
            {
                SetError(98, "Active Date is null or empty");
                return Error_Number;
            }
            if (acRoleInfo.CreateDate==DateTime.MinValue)
            {
                SetError(98, "CreateDate is null or empty");
                return Error_Number;
            }
            if (acRoleInfo.Last_Update==DateTime.MinValue)
            {
                SetError(98, "Last_Update is null or empty");
                return Error_Number;
            }
            if ( string.IsNullOrEmpty(acRoleInfo.UserCreated))
            {
                SetError(98, "UserCreated is null or empty");
                return Error_Number;
            }
            if (base.Insert(acRoleInfo)!=0)
                SetError(0,String.Empty);
            else
                SetError(99,_dalAcRoles.GetException.Message);

            return Error_Number;
        }
        public new int Update(AccountRoles_Info acRoleInfo)
        {
            if (acRoleInfo == null)
            {
                SetError(98, "Invalid data input");
                return Error_Number;
            }
            if (string.IsNullOrEmpty(acRoleInfo.Account_ID))
            {
                SetError(98, "Account_ID is null or empty");
                return Error_Number;
            }
            if (string.IsNullOrEmpty(acRoleInfo.Name))
            {
                SetError(98, "Name is null or empty");
                return Error_Number;
            }
            if (Convert.ToInt32(acRoleInfo.Seq) == 0)
            {
                SetError(98, "Seq is null or empty");
                return Error_Number;
            }
            if (string.IsNullOrEmpty(acRoleInfo.Operator.ToString()))
            {
                SetError(98, "Operater is null or empty");
                return Error_Number;
            }
            if (string.IsNullOrEmpty(acRoleInfo.Type.ToString()))
            {
                SetError(98, "Type is null or empty");
                return Error_Number;
            }
            if ((acRoleInfo.Active == true) && (acRoleInfo.Active_Date == DateTime.MinValue))
            {
                SetError(98, "Active Date is null or empty");
                return Error_Number;
            }
            if (acRoleInfo.CreateDate == DateTime.MinValue)
            {
                SetError(98, "CreateDate is null or empty");
                return Error_Number;
            }
            if (acRoleInfo.Last_Update == DateTime.MinValue)
            {
                SetError(98, "Last_Update is null or empty");
                return Error_Number;
            }
            if (string.IsNullOrEmpty(acRoleInfo.UserCreated))
            {
                SetError(98, "UserCreated is null or empty");
                return Error_Number;
            }
            var oldAcRoleInfo = _dalAcRoles.GetOne(acRoleInfo.ID);
            if (oldAcRoleInfo == null)
            {
                SetError(99, string.Format("Account role {0} not find",acRoleInfo.ID));
                return Error_Number;
            }
            if (base.Update(acRoleInfo) != 0)
                SetError(0, String.Empty);
            else
                SetError(99, _dalAcRoles.GetException.Message);

            return Error_Number;
        }
        public int Delete(string acRoleId)
        {
            if (string.IsNullOrEmpty(acRoleId))
            {
                SetError(98, "Invalid acRoleId");
                return Error_Number;
            }
            var acRoleInfo = _dalAcRoles.GetOne((decimal)Decimal.Parse(acRoleId));
            if (acRoleInfo == null)
            {
                SetError(98, "Account role not find");
                return Error_Number;
            }
            if (acRoleInfo.Active == true)
            {
                SetError(99, "Account role is actived");
                return Error_Number;
            }
            if (base.Delete(acRoleInfo) != 0)
                SetError(0, String.Empty);
            else
                SetError(99, _dalAcRoles.GetException.Message);
            return Error_Number;
        }
        public int Active(string acRoleId)
        {
            if (string.IsNullOrEmpty(acRoleId))
            {
                SetError(98, "Invalid acRoleId");
                return Error_Number;
            }
            var acRoleInfo = _dalAcRoles.GetOne((decimal)Decimal.Parse(acRoleId));
            if (acRoleInfo == null)
            {
                SetError(98, "Account role not find");
                return Error_Number;
            }
            if (acRoleInfo.Active == true)
            {
                SetError(99, "Account role is actived");
                return Error_Number;
            }
            if (base.Active(acRoleInfo) != 0)
                SetError(0, String.Empty);
            else
                SetError(99, _dalAcRoles.GetException.Message);
            return Error_Number;
        }
        public new AccountRoles_Info GetAccountRoleByID(string acRoleId)
        {
            return base.GetAccountRoleByID(acRoleId);
        }
        public new List<AccountRoles_Info> GetSomething(string accountId)
        { return base.GetSomething(accountId); }
        public new List<AccountRoles_Info> GetAllAccountRoles()
        { return base.GetAllAccountRoles(); }
        
    }
}
