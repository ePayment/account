using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Account.Common.Entities;

namespace Account.Data.SqlServer
{
    public partial class D_Parameters:SqlServerHelper
    {
        public SqlCommand CreateOneParameters(Parameter_Info objParam)
        {
            SqlCommand command = new SqlCommand("Insert Into Parameters(Name, Value, Descript) Values(@Name, @Value, @Descript)");
            command.CommandType = CommandType.Text;
            command.Parameters.Clear();
            command.Parameters.Add("@Name", SqlDbType.NVarChar, 50).Value = objParam.Name;
            command.Parameters.Add("@Value", SqlDbType.NVarChar).Value = objParam.Value;
            command.Parameters.Add("@Descript", SqlDbType.NVarChar).Value = objParam.Descript;
            AddCommand(command);
            return command;
        }
        public SqlCommand EditOneParameters(Parameter_Info objParam)
        {
            SqlCommand command = new SqlCommand("Update Parameters Set Name = @Name, Value = @Value, Descript = @Descript Where Name = @Name");
            command.CommandType = CommandType.Text;
            command.Parameters.Clear();
            command.Parameters.Add("@Name", SqlDbType.NVarChar, 50).Value = objParam.Name;
            command.Parameters.Add("@Value", SqlDbType.NVarChar).Value = objParam.Value;
            command.Parameters.Add("@Descript", SqlDbType.NVarChar).Value = objParam.Descript;
            AddCommand(command);
            return command;
        }
        public SqlCommand RemoveOneParameters(string name)
        {
            SqlCommand command = new SqlCommand("Delete Parameters Where Name = @Name");
            command.CommandType = CommandType.Text;
            command.Parameters.Clear();
            command.Parameters.Add("@Name", SqlDbType.NVarChar, 50).Value = name;
            AddCommand(command);
            return command;
        }
        public Parameter_Info GetOneParameters(string name)
        {
            Parameter_Info obj_param = new Parameter_Info();
            SqlConnection objconn = new SqlConnection(GetConnectionString());
            SqlCommand command = new SqlCommand("Select * From Parameters Where Name = @Name", objconn);
            command.CommandType = CommandType.Text;
            command.Parameters.Clear();
            command.Parameters.Add("@Name", SqlDbType.NVarChar, 25).Value = name;
            try
            {
                objconn.Open();
                SqlDataReader ordParameters = command.ExecuteReader();
                ordParameters.Read();
                if (ordParameters.HasRows)
                {
                    if (ordParameters["Name"] != DBNull.Value)
                    {
                        obj_param.Name = Convert.ToString(ordParameters["Name"]);
                    }
                    if (ordParameters["Value"] != DBNull.Value)
                    {
                        obj_param.Value = Convert.ToString(ordParameters["Value"]);
                    }
                    if (ordParameters["Descript"] != DBNull.Value)
                    {
                        obj_param.Descript = Convert.ToString(ordParameters["Descript"]);
                    }
                }
            }
            catch (SqlException ex)
            {
                if (Logger.IsErrorEnabled) Logger.Error(ex);

            }
            finally 
            {
                objconn.Close();
            }
            return obj_param;
        }
        public List<Parameter_Info> GetAllParameters()
        {
            DataSet ds = new DataSet();
            SqlConnection objconn = new SqlConnection(GetConnectionString());
            SqlCommand command = new SqlCommand("Select * From Parameters", objconn);
            command.CommandType = CommandType.Text;
            try
            {
                objconn.Open();
                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(ds);
                List<Parameter_Info> list = new List<Parameter_Info>();
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    list.Add(GenerateObject(row));
                }
                return list;
            }
            catch (SqlException ex)
            {
                if (Logger.IsErrorEnabled) Logger.Error(ex);
                return null;
            }
            finally
            { objconn.Close(); }
            
        }
        private Parameter_Info GenerateObject(DataRow row)
        {
            if (row == null)
            {
                throw new Exception("DataRow does not null");
            }
            else
            {
                Parameter_Info pi = new Parameter_Info();
                if (row["Name"] != DBNull.Value)
                {
                    pi.Name = Convert.ToString(row["Name"]);
                }
                if (row["Value"] != DBNull.Value)
                {
                    pi.Value = Convert.ToString(row["Value"]);
                }
                if (row["Descript"] != DBNull.Value)
                {
                    pi.Descript = Convert.ToString(row["Descript"]);
                }
                return pi;
            }
        }
    }
}