using System;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

using Account.Common.Entities;
using Account.Common.Utilities;

namespace Account.Data.SqlServer
{
    public partial class D_TranCode:SqlServerHelper
    {
        public SqlCommand CreateOneTranCode(Trancode_Info objTrancode_Info)
        {
            try
            {
                SqlCommand command = new SqlCommand("INSERT INTO Trancode("
                                                    + "Code, "
                                                    + "Name, "
                                                    + "Status, "
                                                    + "Categories, "
                                                    + "NextCode, "
                                                    + "CostCode, "
                                                    + "Descript, "
                                                    + "CodeType, "
                                                    + "AllowReverse, "
                                                    + "Report, "
                                                    + "Display, "
                                                    + "formula, "
                                                    + "RefNum, "
                                                    + "CheckOn, "
                                                    + "DateCreated, "
                                                    + "UserCreate, "
                                                    + "Branch_ID "
                                                    + ")"
                                                    + "VALUES ("
                                                    + "@Code, "
                                                    + "@Name, "
                                                    + "@Status, "
                                                    + "@Categories, "
                                                    + "@NextCode, "
                                                    + "@CostCode, "
                                                    + "@Descript, "
                                                    + "@CodeType, "
                                                    + "@AllowReverse, "
                                                    + "@Report, "
                                                    + "@Display, "
                                                    + "@formula, "
                                                    + "@RefNum, "
                                                    + "@CheckOn, "
                                                    + "@DateCreated, "
                                                    + "@UserCreate, "
                                                    + "@Branch_ID "
                                                    + ")");
                command.CommandType = CommandType.Text;
                command.Parameters.Clear();
                command.Parameters.Add("@Code", SqlDbType.NVarChar, 5).Value = objTrancode_Info.Code;
                command.Parameters.Add("@Name", SqlDbType.NVarChar, 135).Value = objTrancode_Info.Name;
                command.Parameters.Add("@Status", SqlDbType.Bit).Value = objTrancode_Info.Status;
                command.Parameters.Add("@Categories", SqlDbType.NVarChar, 45).Value = objTrancode_Info.Categories;
                command.Parameters.Add("@NextCode", SqlDbType.NVarChar, 5).Value = objTrancode_Info.NextCode;
                command.Parameters.Add("@CostCode", SqlDbType.NVarChar, 10).Value = objTrancode_Info.CostCode;
                command.Parameters.Add("@Descript", SqlDbType.NVarChar, 135).Value = objTrancode_Info.Descript;
                command.Parameters.Add("@CodeType", SqlDbType.NVarChar, 25).Value = objTrancode_Info.CodeType.ToString();
                command.Parameters.Add("@AllowReverse", SqlDbType.Bit).Value = objTrancode_Info.AllowReverse;
                command.Parameters.Add("@Report", SqlDbType.Bit).Value = objTrancode_Info.Report;
                command.Parameters.Add("@Display", SqlDbType.Bit).Value = objTrancode_Info.Display;
                command.Parameters.Add("@formula", SqlDbType.NVarChar, 135).Value = objTrancode_Info.Formula;
                command.Parameters.Add("@RefNum", SqlDbType.NVarChar, 4).Value = objTrancode_Info.RefNum;
                command.Parameters.Add("@CheckOn", SqlDbType.Bit).Value = objTrancode_Info.CheckOn;
                command.Parameters.Add("@DateCreated", SqlDbType.DateTime).Value = objTrancode_Info.DateCreated;
                command.Parameters.Add("@UserCreate", SqlDbType.NVarChar, 10).Value = objTrancode_Info.UserCreate;
                if (string.IsNullOrEmpty(objTrancode_Info.Branch_ID))
                    command.Parameters.Add("@Branch_ID", SqlDbType.NVarChar, 25).Value = DBNull.Value;
                else
                    command.Parameters.Add("@Branch_ID", SqlDbType.NVarChar, 25).Value = objTrancode_Info.Branch_ID;
                AddCommand(command);
                return command;
            }
            catch (Exception ex)
            { Logger.Error(ex); throw ex; }
        }
        public SqlCommand EditOneTranCode(Trancode_Info objTrancode_Info)
        {
            try
            {
                SqlCommand command = new SqlCommand(
                    "UPDATE Trancode SET "
                    + "Name = @Name, "
                    + "Status = @Status, "
                    + "Categories = @Categories, "
                    + "NextCode = @NextCode, "
                    + "CostCode = @CostCode, "
                    + "Descript = @Descript, "
                    + "CodeType = @CodeType, "
                    + "AllowReverse = @AllowReverse, "
                    + "Report = @Report, "
                    + "Display = @Display, "
                    + "formula = @formula, "
                    + "RefNum = @RefNum, "
                    + "CheckOn = @CheckOn, "
                    + "DateCreated = @DateCreated, "
                    + "UserCreate = @UserCreate, "
                    + "Branch_ID = @Branch_ID "
                    + "WHERE Code = @Code");
                command.CommandType = CommandType.Text;
                command.Parameters.Clear();
                command.Parameters.Add("@Code", SqlDbType.NVarChar, 5).Value = objTrancode_Info.Code;
                command.Parameters.Add("@Name", SqlDbType.NVarChar, 135).Value = objTrancode_Info.Name;
                command.Parameters.Add("@Status", SqlDbType.Bit).Value = objTrancode_Info.Status;
                command.Parameters.Add("@Categories", SqlDbType.NVarChar, 45).Value = objTrancode_Info.Categories;
                command.Parameters.Add("@NextCode", SqlDbType.NVarChar, 5).Value = objTrancode_Info.NextCode;
                command.Parameters.Add("@CostCode", SqlDbType.NVarChar, 10).Value = objTrancode_Info.CostCode;
                command.Parameters.Add("@Descript", SqlDbType.NVarChar, 135).Value = objTrancode_Info.Descript;
                command.Parameters.Add("@CodeType", SqlDbType.NVarChar, 25).Value = objTrancode_Info.CodeType.ToString();
                command.Parameters.Add("@AllowReverse", SqlDbType.Bit).Value = objTrancode_Info.AllowReverse;
                command.Parameters.Add("@Report", SqlDbType.Bit).Value = objTrancode_Info.Report;
                command.Parameters.Add("@Display", SqlDbType.Bit).Value = objTrancode_Info.Display;
                command.Parameters.Add("@formula", SqlDbType.NVarChar, 135).Value = objTrancode_Info.Formula;
                command.Parameters.Add("@RefNum", SqlDbType.NVarChar, 4).Value = objTrancode_Info.RefNum;
                command.Parameters.Add("@CheckOn", SqlDbType.Bit).Value = objTrancode_Info.CheckOn;
                command.Parameters.Add("@DateCreated", SqlDbType.DateTime).Value = objTrancode_Info.DateCreated;
                command.Parameters.Add("@UserCreate", SqlDbType.NVarChar, 10).Value = objTrancode_Info.UserCreate;
                if(string.IsNullOrEmpty(objTrancode_Info.Branch_ID))
                    command.Parameters.Add("@Branch_ID", SqlDbType.NVarChar, 135).Value = DBNull.Value;
                else
                    command.Parameters.Add("@Branch_ID", SqlDbType.NVarChar, 135).Value = objTrancode_Info.Branch_ID;
                AddCommand(command);
                return command;
            }
            catch (Exception ex)
            { Logger.Error(ex); throw ex; }
        }
        public SqlCommand RemoveOneTranCode(string code)
        {
            try
            {
                SqlCommand command = new SqlCommand("Delete From TranCode Where Code = @Code");
                command.CommandType = CommandType.Text;
                command.Parameters.Clear();
                command.Parameters.Add("@Code", SqlDbType.NVarChar, 5).Value = code;
                AddCommand(command);
                return command;
            }
            catch (Exception ex)
            { Logger.Error(ex); throw ex; }
        }
        public List <Trancode_Info> GetAllTranCode()
        {
            DataSet ds = new DataSet();
            SqlConnection objconn = new SqlConnection(GetConnectionString());
            SqlCommand command = new SqlCommand("Select * from TranCode", objconn);
            command.CommandType = CommandType.Text;
            try
            {
                objconn.Open();
                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(ds);
                List<Trancode_Info> list = new List<Trancode_Info>();
                foreach (DataRow row in ds.Tables[0].Rows)
                { list.Add(GenerateObject(row)); }
                return list;
            }
            catch (SqlException ex)
            { Logger.Error(ex); throw ex; }
            finally
            { objconn.Close(); }
        }
        public Trancode_Info GetOneTranCode(string code)
        {
            DataSet ds = new DataSet();
            SqlConnection objconn = new SqlConnection(GetConnectionString());
            SqlCommand command = new SqlCommand("Select * from TranCode Where Code = @Code", objconn);
            command.CommandType = CommandType.Text;
            command.Parameters.Clear();
            command.Parameters.Add("@Code", SqlDbType.NVarChar, 5).Value = code;
            try
            {
                objconn.Open();
                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(ds);
                if (ds.Tables[0].Rows.Count == 1)
                    return GenerateObject(ds.Tables[0].Rows[0]);
                else
                    return null;
            }
            catch (SqlException ex)
            {
                Logger.Error(ex);
                throw ex;
            }
            finally
            {
                objconn.Close();
            }
            
        }
        public List<TranCodeDetail_Info> GetTranCodeDetailByCode(string code)
        {
            D_TranCodeDetail tdi = new D_TranCodeDetail();
            return tdi.GetTranCodeDetailByCode(code);
        }
        private Trancode_Info GenerateObject(DataRow row)
        {
            if (row == null)
                throw new Exception("Data row not set");
            Trancode_Info ti = new Trancode_Info();
            if (row["Code"] != DBNull.Value)
                ti.Code = Convert.ToString(row["Code"]);
            if (row["Name"] != DBNull.Value)
                ti.Name = Convert.ToString(row["Name"]);
            if (row["Status"] != DBNull.Value)
                ti.Status = Convert.ToBoolean(row["Status"]);
            if (row["Categories"] != DBNull.Value)
                ti.Categories = Convert.ToString(row["Categories"]);
            if (row["NextCode"] != DBNull.Value)
                ti.NextCode = Convert.ToString(row["NextCode"]);
            if (row["CostCode"] != DBNull.Value)
                ti.CostCode = Convert.ToString(row["CostCode"]);
            if (row["Descript"] != DBNull.Value)
                ti.Descript = Convert.ToString(row["Descript"]);
            if (row["CodeType"] != DBNull.Value)
                ti.CodeType = (CodeType)Enum.Parse(typeof(CodeType), row["CodeType"].ToString());
            if (row["AllowReverse"] != DBNull.Value)
                ti.AllowReverse = Convert.ToBoolean(row["AllowReverse"]);
            if (row["Report"] != DBNull.Value)
                ti.Report = Convert.ToBoolean(row["Report"]);
            if (row["Display"] != DBNull.Value)
                ti.Display = Convert.ToBoolean(row["Display"]);
            if (row["Formula"] != DBNull.Value)
                ti.Formula = Convert.ToString(row["Formula"]);
            if (row["RefNum"] != DBNull.Value)
                ti.RefNum = Convert.ToString(row["RefNum"]);
            if (row["CheckOn"] != DBNull.Value)
                ti.CheckOn = Convert.ToBoolean(row["CheckOn"]);
            if (row["DateCreated"] != DBNull.Value)
                ti.DateCreated = Convert.ToDateTime(row["DateCreated"]);
            if (row["UserCreate"] != DBNull.Value)
                ti.UserCreate = Convert.ToString(row["UserCreate"]);
            if (row["Branch_ID"] != DBNull.Value)
                ti.Branch_ID = Convert.ToString(row["Branch_ID"]);
            return ti;
        }
    }
}