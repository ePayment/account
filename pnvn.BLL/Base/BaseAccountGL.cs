using System;
using System.Collections.Generic;
using System.Text;

using Account.Common.Entities;
using Account.Data.SqlServer;

namespace Account.Business.Base
{
    public partial class BaseAccountGL:BaseError
    {
        protected D_Account_GL _dalAcGL;
        public BaseAccountGL()
        { _dalAcGL = new D_Account_GL(); }
        protected int Insert(Account_GL_Info obj)
        {
            if (obj == null)
                throw new Exception("Invalid data input");
            _dalAcGL.CreateOneAccount_GL(obj);
            if (_dalAcGL.Execute())
                return _dalAcGL.LastRecordsEffected;
            else
                throw _dalAcGL.GetException;
        }
        protected int Update(Account_GL_Info obj)
        {
            if (obj == null)
                throw new Exception("Invalid data input");
            _dalAcGL.EditOneAccount_GL(obj);
            if (_dalAcGL.Execute())
                return _dalAcGL.LastRecordsEffected;
            else
                throw _dalAcGL.GetException;
        }
        protected int Delete(Account_GL_Info obj)
        {
            if (obj == null)
                throw new Exception("Invalid data input");
            _dalAcGL.RemoveOneAccount_GL(obj.Account_ID);
            if (_dalAcGL.Execute())
                return _dalAcGL.LastRecordsEffected;
            else
                throw _dalAcGL.GetException;
        }
        protected Account_GL_Info GetAccountGLByID(string accountId)
        { return _dalAcGL.GetOneAccount_GL(accountId); }
        protected List<Account_GL_Info> GetAllAccountGL()
        { return _dalAcGL.GetAllAccount_GL(); }
    }
}
