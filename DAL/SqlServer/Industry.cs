using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Account.Common.Entities;

namespace Account.Data.SqlServer
{

    public class D_Industry : SqlServerHelper
    {
        public SqlCommand CreateOneIndustry(Industry_Info objIndustryInfo)
        {
            SqlCommand command = new SqlCommand("insert into Industry (ID, Name) Values (@ID, @Name)");
            command.CommandType = CommandType.Text;
            command.Parameters.Add("@ID", SqlDbType.NVarChar, 5).Value = objIndustryInfo.ID;
            command.Parameters.Add("@Name", SqlDbType.NVarChar, 135).Value = objIndustryInfo.Name;
            this.AddCommand(command);
            return command;
        }
        public SqlCommand EditOneIndustry(Industry_Info objIndustryInfo)
        {
            SqlCommand command = new SqlCommand("Update Industry Set  Name= @Name  Where ID= @ID");
            command.CommandType = CommandType.Text;
            command.Parameters.Add("@ID", SqlDbType.NVarChar, 5).Value = objIndustryInfo.ID;
            command.Parameters.Add("@Name", SqlDbType.NVarChar, 135).Value = objIndustryInfo.Name;
            this.AddCommand(command);
            return command;
        }
        public SqlCommand RemoveOneIndustry(string id)
        {
            SqlCommand command = new SqlCommand("Delete Industry where ID = @ID ");
            command.CommandType = CommandType.Text;
            command.Parameters.Add("@ID", SqlDbType.NVarChar, 5).Value = id;
            this.AddCommand(command);
            return command;
        }
        public List<Industry_Info> GetAllIndustry()
        {
            SqlConnection objconn = new SqlConnection(GetConnectionString());
            SqlCommand command = new SqlCommand("Select * from Industry", objconn);
            command.CommandType = CommandType.Text;
            try
            {
                objconn.Open();
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(ds);
                List<Industry_Info> list = new List<Industry_Info>();
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
        public Industry_Info GetOneIndustry(string id)
        {
            SqlConnection objconn = new SqlConnection(GetConnectionString());
            SqlCommand command = new SqlCommand("Select * from Industry Where ID = @ID", objconn);
            command.CommandType = CommandType.Text;
            command.Parameters.Add("@ID", SqlDbType.NVarChar, 5).Value = id;
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
        private Industry_Info GenerateObj(DataRow row)
        {
            if (row == null)
                throw new Exception("Invalid Datarow");
            Industry_Info inInfo = new Industry_Info();
            if (row["ID"] != DBNull.Value)
                inInfo.ID = Convert.ToString(row["ID"]);
            if (row["Name"] != DBNull.Value)
                inInfo.Name = Convert.ToString(row["Name"]);
            return inInfo;
        }
    }
}