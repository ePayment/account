using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Account.Common.Entities;
using Account.Common.Utilities;

namespace Account.Data.SqlServer
{
    public partial class D_TranCodeDetailFull:SqlServerHelper
    {
        public TranCodeDetailFull_Info GetOneTranCodeFullById(decimal id)
        {
            DataSet ds = new DataSet();
            SqlConnection objconn = new SqlConnection(GetConnectionString());
            SqlCommand command = new SqlCommand("Select * from Trancodedetailfull Where ID = @ID", objconn);
            command.CommandType = CommandType.Text;
            command.Parameters.Clear();
            command.Parameters.Add("@ID", SqlDbType.Decimal).Value = id;
            try
            {
                objconn.Open();
                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(ds);
                return GenerateObj(ds.Tables[0].Rows[0]);
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
        public List<TranCodeDetailFull_Info> GetOneTranCodeFullByCode(string code)
        {
            DataSet ds = new DataSet();
            SqlConnection objconn = new SqlConnection(GetConnectionString());
            SqlCommand command = new SqlCommand("Select * from Trancodedetailfull Where Code = @Code", objconn);
            command.CommandType = CommandType.Text;
            command.Parameters.Clear();
            command.Parameters.Add("@Code", SqlDbType.NVarChar, 5).Value = code;
            try
            {
                objconn.Open();
                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(ds);
                List<TranCodeDetailFull_Info> list = new List<TranCodeDetailFull_Info>();
                foreach (DataRow row in ds.Tables[0].Rows)
                    list.Add(GenerateObj(row));
                return list;
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
        private TranCodeDetailFull_Info GenerateObj(DataRow row)
        {
            if (row == null)
                throw new Exception("Data object is null or empty");
            TranCodeDetailFull_Info objTranCodeDetailInfo = new TranCodeDetailFull_Info();
            if (row["Code"] != DBNull.Value)
            {
                objTranCodeDetailInfo.Code = Convert.ToString(row["Code"]);
            }

            if (row["Name"] != DBNull.Value)
            {
                objTranCodeDetailInfo.Name = Convert.ToString(row["Name"]);
            }
            if (row["Status"] != DBNull.Value)
            {
                objTranCodeDetailInfo.Status = Convert.ToBoolean(row["Status"]);
            }
            if (row["DirecobjTranCodeDetailInfoon"] != DBNull.Value)
            {
                objTranCodeDetailInfo.Categories = Convert.ToString(row["Categories"]);
            }
            if (row["NextCode"] != DBNull.Value)
            {
                objTranCodeDetailInfo.NextCode = Convert.ToString(row["NextCode"]);
            }
            if (row["CostCode"] != DBNull.Value)
            {
                objTranCodeDetailInfo.CostCode = Convert.ToString(row["CostCode"]);
            }
            if (row["Descript"] != DBNull.Value)
            {
                objTranCodeDetailInfo.Descript = Convert.ToString(row["Descript"]);
            }
            if (row["CodeType"] != DBNull.Value)
            {
                objTranCodeDetailInfo.CodeType = Convert.ToString(row["CodeType"]);
            }
            if (row["Report"] != DBNull.Value)
            {
                objTranCodeDetailInfo.Report = Convert.ToBoolean(row["Report"]);
            }
            if (row["Display"] != DBNull.Value)
            {
                objTranCodeDetailInfo.Display = Convert.ToBoolean(row["Display"]);
            }
            if (row["Formula"] != DBNull.Value)
            {
                objTranCodeDetailInfo.Formula = Convert.ToString(row["Fomular"]);
            }
            if (row["RefNum"] != DBNull.Value)
            {
                objTranCodeDetailInfo.RefNum = Convert.ToString(row["RefNum"]);
            }
            if (row["CheckOn"] != DBNull.Value)
            {
                objTranCodeDetailInfo.CheckOn = Convert.ToBoolean(row["CheckOn"]);
            }
            if (row["DateCreated"] != DBNull.Value)
            {
                objTranCodeDetailInfo.DateCreated = Convert.ToDateTime(row["DateCreated"]);
            }
            if (row["UserCreate"] != DBNull.Value)
            {
                objTranCodeDetailInfo.UserCreate = Convert.ToString(row["UserCreate"]);
            }
            if (row["Branch_ID"] != DBNull.Value)
            {
                objTranCodeDetailInfo.Branch_ID = Convert.ToString(row["Branch_ID"]);
            }
            if (row["id"] != DBNull.Value)
            {
                objTranCodeDetailInfo.ID = Convert.ToDecimal(row["id"]);
            }
            if (row["Account_ID"] != DBNull.Value)
            {
                objTranCodeDetailInfo.Account_ID = Convert.ToString(row["Account_ID"]);
            }
            if (row["CreditDebit"] != DBNull.Value)
            {
                objTranCodeDetailInfo.CreditDebit = Convert.ToString(row["CreditDebit"]);
            }
            if (row["NumType"] != DBNull.Value)
            {
                objTranCodeDetailInfo.NumberType = (NumberType)Enum.Parse(typeof(NumberType), row["NumType"].ToString());
            }
            if (row["NumValue"] != DBNull.Value)
            {
                objTranCodeDetailInfo.NumberValue = Convert.ToSingle(row["NumValue"]);
            }
            if (row["SEQ"] != DBNull.Value)
            {
                objTranCodeDetailInfo.SEQ = Convert.ToInt32(row["SEQ"]);
            }
            if (row["IsAccountCust"] != DBNull.Value)
            {
                objTranCodeDetailInfo.Is_Account_Cust = Convert.ToBoolean(row["IsAccountCust"]);
            }
            if (row["Master"] != DBNull.Value)
            {
                objTranCodeDetailInfo.Master = Convert.ToBoolean(row["Master"]);
            }
            return objTranCodeDetailInfo;
        }
    }
}