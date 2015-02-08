using System;
using System.Collections.Generic;
using System.Text;

using Account.Common.Entities;
using Account.Data.SqlServer;

namespace Account.Business.Base
{
    public partial class BaseAccountRoles:BaseError
    {
        protected D_AccountRoles _dalAcRoles;
        public BaseAccountRoles()
        { _dalAcRoles = new D_AccountRoles(); }
        protected int Insert(AccountRoles_Info acRoleInfo)
        {
            if (acRoleInfo ==null)
                throw new Exception("acRoleInfo data input is null or empty");
            _dalAcRoles.CreateOne(acRoleInfo);
            if (_dalAcRoles.Execute())
                return _dalAcRoles.LastRecordsEffected;
            else
                throw _dalAcRoles.GetException;
        }
        protected int Update(AccountRoles_Info acRoleInfo)
        { 
            if (acRoleInfo ==null)
                throw new Exception("acRoleInfo data input is null or empty");
            _dalAcRoles.EditOne(acRoleInfo);
            if (_dalAcRoles.Execute())
                return _dalAcRoles.LastRecordsEffected;
            else
                throw _dalAcRoles.GetException;
        }
        protected int Delete(AccountRoles_Info acRoleInfo)
        { 
            if (acRoleInfo ==null)
                throw new Exception("acRoleInfo data input is null or empty");
            _dalAcRoles.RemoveOne(acRoleInfo.ID);
            if (_dalAcRoles.Execute())
                return _dalAcRoles.LastRecordsEffected;
            else
                throw _dalAcRoles.GetException;
        }
        protected int Active(AccountRoles_Info acRoleInfo)
        { 
            if (acRoleInfo ==null)
                throw new Exception("acRoleInfo data input is null or empty");
            
            acRoleInfo.Active=true;
            acRoleInfo.Active_Date=DateTime.Now;
            acRoleInfo.Last_Update=DateTime.Now;

            _dalAcRoles.EditOne(acRoleInfo);
            if (_dalAcRoles.Execute())
                return _dalAcRoles.LastRecordsEffected;
            else
                throw _dalAcRoles.GetException;
        }
        protected AccountRoles_Info GetAccountRoleByID(string acRoleId)
        { return _dalAcRoles.GetOne((decimal)Decimal.Parse(acRoleId)); }
        protected List<AccountRoles_Info> GetSomething(string accountId)
        { return _dalAcRoles.GetSomething(accountId); }
        protected List<AccountRoles_Info> GetAllAccountRoles()
        { return _dalAcRoles.GetAll(); }
    }
}
