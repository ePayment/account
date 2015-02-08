using System;
using System.Collections.Generic;
using System.Text;

using Account.Common.Entities;
using Account.Data.SqlServer;

namespace Account.Business.Base
{
    public partial class BaseCategories:BaseError
    {
        protected D_Categories _dalCat;
        public BaseCategories()
        {
            _dalCat = new D_Categories();
        }
        protected int Insert(Categories_Info catInfo)
        {
            if (catInfo == null)
                throw new Exception("catInfo is null or empty");
            _dalCat.CreateOneCategories(catInfo);
            if (_dalCat.Execute())
                return _dalCat.LastRecordsEffected;
            throw _dalCat.GetException;
        }
        protected int Update(Categories_Info catInfo)
        {
            if (catInfo == null)
                throw new Exception("catInfo is null or empty");
            _dalCat.EditOneCategories(catInfo);
            if (_dalCat.Execute())
                return _dalCat.LastRecordsEffected;
            throw _dalCat.GetException;
        }
        protected int Delete(Categories_Info catInfo)
        {
            if (string.IsNullOrEmpty(catInfo.ID))
                throw new Exception("catId is null or empty");
            _dalCat.RemoveOneCategories(catInfo.ID);
            if (_dalCat.Execute())
                return _dalCat.LastRecordsEffected;
            throw _dalCat.GetException;
        }
        protected Categories_Info GetCategoriesById(string catId)
        {
            return _dalCat.GetOneCategories(catId);
        }
        protected List<Categories_Info> GetAllCategories()
        { return _dalCat.GetAllCategories(); }
    }
}
