using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using Account.Common.Entities;

namespace Account.Data.SqlServer
{
    public class D_Sector : SqlServerHelper
    {
        public SqlCommand CreateOneSector(Sector_Info objSectorInfo)
        {
            SqlCommand command = new SqlCommand("insert into Sector (ID, Name) Values (@ID, @Name)");
            command.CommandType = CommandType.Text;
            command.Parameters.Add("@ID", SqlDbType.NVarChar, 5).Value = objSectorInfo.ID;
            command.Parameters.Add("@Name", SqlDbType.NVarChar, 135).Value = objSectorInfo.Name;
            this.AddCommand(command);
            return command;
        }
        public SqlCommand EditOneSector(Sector_Info objSectorInfo)
        {
            SqlCommand command = new SqlCommand("Update Sector Set  ID= @ID,Name= @Name Where ID= @ID");
            command.CommandType = CommandType.Text;
            command.Parameters.Add("@ID", SqlDbType.NVarChar, 5).Value = objSectorInfo.ID;
            command.Parameters.Add("@Name", SqlDbType.NVarChar, 135).Value = objSectorInfo.Name;
            this.AddCommand(command);
            return command;
        }
        public SqlCommand RemoveOneSector(string id)
        {
            SqlCommand command = new SqlCommand("Delete Sector  where ID = @ID");
            command.CommandType = CommandType.Text;
            command.Parameters.Add("@ID", SqlDbType.NVarChar, 5).Value = id;
            this.AddCommand(command);
            return command;

        }
        public List<Sector_Info> GetAllSector()
        {
            SqlConnection objconn = new SqlConnection(GetConnectionString());
            SqlCommand command = new SqlCommand("Select * from Sector", objconn);
            command.CommandType = CommandType.Text;
            try
            {
                objconn.Open();
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(ds);
                List<Sector_Info> list = new List<Sector_Info>();
                foreach(DataRow row in ds.Tables[0].Rows)
                    list.Add(GenerateObj(row));
                return list;
            }
            catch (SqlException ex)
            {
                if (Logger.IsErrorEnabled) Logger.Error(ex);
                throw;
            }
            finally
            {
                objconn.Close();
            }
        }
        public Sector_Info GetOneSector(string id)
        {
            SqlConnection objconn = new SqlConnection(GetConnectionString());
            SqlCommand command = new SqlCommand("Select * from Sector Where ID = @ID", objconn);
            command.CommandType = CommandType.Text;
            command.Parameters.Add("@ID", SqlDbType.NVarChar, 3).Value = id;
            try
            {
                objconn.Open();
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(ds);
                if (ds.Tables[0].Rows.Count == 1)
                    return GenerateObj(ds.Tables[0].Rows[0]);
                else
                    return null;
            }
            catch (System.Exception ex)
            {
                if (Logger.IsErrorEnabled) Logger.Error(ex);
                throw;
            }
            finally
            {
                objconn.Close();
            }
        }
        private Sector_Info GenerateObj(DataRow row)
        {
            if (row == null)
                throw new Exception("Invalid Datarow");
            Sector_Info objSec = new Sector_Info();
            if (row["ID"] == DBNull.Value)
                objSec.ID = Convert.ToString(row["ID"]);
            if (row["Name"] == DBNull.Value)
                objSec.ID = Convert.ToString(row["Name"]);
            return objSec;
        }
    }
}