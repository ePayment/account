using System;
using System.Collections.Generic;
using System.Text;

using Account.Common.Entities;
using Account.Data.SqlServer;

namespace Account.Business.Base
{
    public partial class BaseUser:BaseError
    {
        protected D_User dalUser;
        public BaseUser()
        { dalUser = new D_User(); }
        protected int Insert(User_Info obj)
        {
            if (obj == null)
                throw new Exception("Object is null");
            dalUser.CreateOneUser(obj);
            if (dalUser.Execute())
                return dalUser.LastRecordsEffected;
            else
                throw dalUser.GetException;
        }
        protected int Update(User_Info obj)
        {
            if (obj == null)
                throw new Exception("Object is null");
            dalUser.EditOneUser(obj);
            if (dalUser.Execute())
                return dalUser.LastRecordsEffected;
            else
                throw dalUser.GetException;
        }
        protected int Delete(User_Info obj)
        {
            if (obj == null)
                throw new Exception("Object is null");
            dalUser.RemoveOneUser(obj.User_ID);
            if (dalUser.Execute())
                return dalUser.LastRecordsEffected;
            else
                throw dalUser.GetException;
        }
        protected User_Info GetUserByID(string uid)
        { return dalUser.GetOneUser(uid); }
        protected List<User_Info> GetAllUser()
        { return dalUser.GetAllUser(); }
    }
}
