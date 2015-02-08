using System;
using System.Collections.Generic;
using System.Text;

using Account.Common.Entities;
using Account.Data.SqlServer;

namespace Account.Business.Base
{
    public partial class BaseSector:BaseError
    {
    protected D_Sector _dalSec;
    public BaseSector()
        { _dalSec = new D_Sector(); }
        protected int Insert(Sector_Info obj)
        {
            if (obj == null)
                throw new Exception("Invalid data input");
            _dalSec.CreateOneSector(obj);
            if (_dalSec.Execute())
                return _dalSec.LastRecordsEffected;
            else
                throw _dalSec.GetException;
        }
        protected int Update(Sector_Info obj)
        {
            if (obj == null)
                throw new Exception("Invalid data input");
            _dalSec.EditOneSector(obj);
            if (_dalSec.Execute())
                return _dalSec.LastRecordsEffected;
            else
                throw _dalSec.GetException;
        }
        protected int Delete(Sector_Info obj)
        {
            if (obj == null)
                throw new Exception("Invalid data input");
            _dalSec.RemoveOneSector(obj.ID);
            if (_dalSec.Execute())
                return _dalSec.LastRecordsEffected;
            else
                throw _dalSec.GetException;
        }
        protected Sector_Info GetSectorByID(string id)
        {
            return _dalSec.GetOneSector(id);
        }
        protected List<Sector_Info> GetAllSector()
        { return _dalSec.GetAllSector(); }}
}
