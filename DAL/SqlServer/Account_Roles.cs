using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Account.Common.Entities;
using Account.Common.Utilities;

namespace Account.Data.SqlServer
{
    public partial class D_AccountRoles : SqlServerHelper
    {
        public SqlCommand CreateOne(AccountRoles_Info objAccountRolesInfo)
        {
            SqlCommand command = new SqlCommand("INSERT INTO Account_Roles("
                                                + "Name, "
                                                + "Account_ID, "
                                                + "Type, "
                                                + "Operator, "
                                                + "Value, "
                                                + "Seq, "
                                                + "Active, "
                                                + "Active_Date, "
                                                + "CreateDate, "
                                                + "Last_Update, "
                                                + "UserCreated "
                                                + ")"
                                                + "VALUES ("
                                                + "@Name, "
                                                + "@Account_ID, "
                                                + "@Type, "
                                                + "@Operator, "
                                                + "@Value, "
                                                + "@Seq, "
                                                + "@Active, "
                                                + "@Active_Date, "
                                                + "@CreateDate, "
                                                + "@Last_Update, "
                                                + "@UserCreated "
                                                + ")");
            command.CommandType = CommandType.Text;
            command.Parameters.Clear();
            command.Parameters.Add("@Name", SqlDbType.NVarChar, 150).Value = objAccountRolesInfo.Name;
            command.Parameters.Add("@Type", SqlDbType.NVarChar,50).Value = objAccountRolesInfo.Type;
            command.Parameters.Add("@Account_ID", SqlDbType.NVarChar, 50).Value = objAccountRolesInfo.Account_ID;
            command.Parameters.Add("@Value", SqlDbType.Decimal).Value = objAccountRolesInfo.Value;
            command.Parameters.Add("@Seq", SqlDbType.Int).Value = objAccountRolesInfo.Seq;
            command.Parameters.Add("@Operator", SqlDbType.NVarChar,50).Value = objAccountRolesInfo.Operator;
            command.Parameters.Add("@Active", SqlDbType.Bit).Value = objAccountRolesInfo.Active;
            if (objAccountRolesInfo.Active)
                command.Parameters.Add("@Active_Date", SqlDbType.DateTime).Value = objAccountRolesInfo.Active_Date;
            else
                command.Parameters.Add("@Active_Date", SqlDbType.DateTime).Value = DBNull.Value;
            command.Parameters.Add("@CreateDate", SqlDbType.DateTime).Value = objAccountRolesInfo.Active_Date;
            command.Parameters.Add("@Last_Update", SqlDbType.DateTime).Value = objAccountRolesInfo.Active_Date;
            command.Parameters.Add("@UserCreated", SqlDbType.NVarChar,25).Value = objAccountRolesInfo.Active_Date;
            this.AddCommand(command);
            return command;
        }
        public SqlCommand EditOne(AccountRoles_Info objAccountRolesInfo)
        {
            SqlCommand command = new SqlCommand("UPDATE Account_Roles SET "
                                                + "Name = @Name, "
                                                + "Account_ID = @Account_ID, "
                                                + "Type = @Type, "
                                                + "Operator = @Operator, "
                                                + "Value = @Value, "
                                                + "Seq = @Seq, "
                                                + "Active = @Active, "
                                                + "Active_Date = @Active_Date, "
                                                + "CreateDate = @CreateDate, "
                                                + "Last_Update = @Last_Update, "
                                                + "UserCreated = @UserCreated "
                                                + "WHERE ID = @ID");
            command.CommandType = CommandType.Text;
            command.Parameters.Clear();
            command.Parameters.Add("@ID", SqlDbType.Decimal).Value = objAccountRolesInfo.ID;
            command.Parameters.Add("@Name", SqlDbType.NVarChar, 150).Value = objAccountRolesInfo.Name;
            command.Parameters.Add("@Type", SqlDbType.NVarChar,50).Value = objAccountRolesInfo.Type;
            command.Parameters.Add("@Account_ID", SqlDbType.NVarChar, 50).Value = objAccountRolesInfo.Account_ID;
            command.Parameters.Add("@Value", SqlDbType.Decimal).Value = objAccountRolesInfo.Value;
            command.Parameters.Add("@Seq", SqlDbType.Int).Value = objAccountRolesInfo.Seq;
            command.Parameters.Add("@Operator", SqlDbType.NVarChar,50).Value = objAccountRolesInfo.Operator;
            command.Parameters.Add("@Active", SqlDbType.Bit).Value = objAccountRolesInfo.Active;
            if (objAccountRolesInfo.Active)
                command.Parameters.Add("@Active_Date", SqlDbType.DateTime).Value = objAccountRolesInfo.Active_Date;
            else
                command.Parameters.Add("@Active_Date", SqlDbType.DateTime).Value = DBNull.Value;
            command.Parameters.Add("@CreateDate", SqlDbType.DateTime).Value = objAccountRolesInfo.CreateDate;
            command.Parameters.Add("@Last_Update", SqlDbType.DateTime).Value = objAccountRolesInfo.Last_Update;
            command.Parameters.Add("@UserCreated", SqlDbType.NVarChar,25).Value = objAccountRolesInfo.UserCreated;
            this.AddCommand(command);
            return command;
        }
        public SqlCommand RemoveOne(decimal id)
        {
            SqlCommand command = new SqlCommand("Delete Account_Roles WHERE ID = @ID");
            command.CommandType = CommandType.Text;
            command.Parameters.Clear();
            command.Parameters.Add("@ID", SqlDbType.Decimal).Value = id;
            AddCommand(command);
            return command;
        }
        public AccountRoles_Info GetOne(decimal id)
        {
            DataSet ds=new DataSet();
            SqlConnection objconn = new SqlConnection(GetConnectionString());
            SqlCommand command = new SqlCommand("SELECT * FROM Account_Roles WHERE ID = @ID", objconn);
            command.CommandType = CommandType.Text;
            command.Parameters.Clear();
            command.Parameters.Add("@ID", SqlDbType.Decimal).Value = id;
            try
            {
                objconn.Open();
                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(ds);
                if (ds.Tables[0].Rows[0] == null)
                    return null;
                return GenerateObject(ds.Tables[0].Rows[0]);
            }
            catch (SqlException ex)
            { if (Logger.IsErrorEnabled) Logger.Error(ex); return null; }
            catch (Exception ex)
            { if (Logger.IsErrorEnabled) Logger.Error(ex); return null; }
            finally
            { objconn.Close(); }
        }
        public List<AccountRoles_Info> GetSomething(string accountId)
        {
            DataSet ds = new DataSet();
            SqlConnection objconn = new SqlConnection(GetConnectionString());
            SqlCommand command = new SqlCommand(@"Select * From AccountRolesActive(@Account_ID) 
                                                Order By Seq ASC", objconn);
            command.Parameters.Clear();
            command.Parameters.Add("@Account_ID", SqlDbType.NVarChar, 25).Value = accountId;
            command.CommandType = CommandType.Text;
            try
            {
                objconn.Open();
                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(ds);
                List<AccountRoles_Info> list = new List<AccountRoles_Info>();
                foreach (DataRow row in ds.Tables[0].Rows)
                { list.Add(GenerateObject(row)); }
                return list;
            }
            catch (SqlException ex)
            {
                if (Logger.IsErrorEnabled) Logger.Error(ex);
                return null;
            }
            catch (Exception ex)
            {
                if (Logger.IsErrorEnabled) Logger.Error(ex);
                return null;
            }
            finally
            { objconn.Close(); }
        }
        public List<AccountRoles_Info> GetAll()
        {
            DataSet ds = new DataSet();
            SqlConnection objconn = new SqlConnection(GetConnectionString());
            SqlCommand command = new SqlCommand("Select * from Account_Roles Order By Seq", objconn);
            command.CommandType = CommandType.Text;
            try
            {
                objconn.Open();
                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(ds);
                List<AccountRoles_Info> list = new List<AccountRoles_Info>();
                foreach (DataRow row in ds.Tables[0].Rows)
                { list.Add(GenerateObject(row)); }
                return list;
            }
            catch (SqlException ex)
            {
                if (Logger.IsErrorEnabled) Logger.Error(ex);
                return null;
            }
            catch (Exception ex)
            { if (Logger.IsErrorEnabled) Logger.Error(ex); return null; }
            finally
            { objconn.Close(); }
        }
        private AccountRoles_Info GenerateObject(DataRow row)
        {
            AccountRoles_Info objAccountRolesInfo = new AccountRoles_Info();
            if (row == null)
                throw new Exception("DataRow not be empty");
            if (row["ID"] != DBNull.Value)
            { objAccountRolesInfo.ID = Convert.ToInt32(row["ID"]); }
            if (row["Name"] != DBNull.Value)
            { objAccountRolesInfo.Name = Convert.ToString(row["Name"]); }
            if (row["Account_ID"] != DBNull.Value)
            { objAccountRolesInfo.Account_ID = Convert.ToString(row["Account_ID"]); }
            if (row["Type"] != DBNull.Value)
            { objAccountRolesInfo.Type = (AccountRoleType)Enum.Parse(typeof(AccountRoleType), row["Type"].ToString()); }
            if (row["Operator"] != DBNull.Value)
            { objAccountRolesInfo.Operator = (OperatorType)Enum.Parse(typeof(OperatorType), row["Operator"].ToString()); }
            if (row["Value"] != DBNull.Value)
            { objAccountRolesInfo.Value = Convert.ToDecimal(row["Value"]); }
            if (row["Seq"] != DBNull.Value)
            { objAccountRolesInfo.Seq = Convert.ToInt32(row["Seq"]); }
            if (row["Active"] != DBNull.Value)
            { objAccountRolesInfo.Active = Convert.ToBoolean(row["Active"]); }
            if (row["Active_Date"] != DBNull.Value)
            { objAccountRolesInfo.Active_Date = Convert.ToDateTime(row["Active_Date"]); }
            if (row["CreateDate"] != DBNull.Value)
            { objAccountRolesInfo.CreateDate = Convert.ToDateTime(row["CreateDate"]); }
            if (row["Last_Update"] != DBNull.Value)
            { objAccountRolesInfo.Last_Update = Convert.ToDateTime(row["Last_Update"]); }
            if (row["UserCreated"] != DBNull.Value)
            { objAccountRolesInfo.UserCreated = Convert.ToString(row["UserCreated"]); }
            return objAccountRolesInfo;
        }
    }
}