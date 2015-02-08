using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Account.Common.Entities;
using Account.Common.Utilities;

namespace Account.Data.SqlServer
{
    public partial class D_TranCodeDetail : SqlServerHelper
    {
        public SqlCommand CreateOneTranCodeDetail(TranCodeDetail_Info objTranCodeDetailInfo)
        {
            try
            {
                SqlCommand command = new SqlCommand(@"INSERT INTO TranCodeDetail(
                                                                SEQ, 
                                                                Code, 
                                                                Account_ID, 
                                                                CreditDebit, 
                                                                NumType, 
                                                                NumValue, 
                                                                IsAccountCust, 
                                                                Master
                                                                )
                                                        VALUES (
                                                                @SEQ, 
                                                                @Code, 
                                                                @Account_ID, 
                                                                @CreditDebit, 
                                                                @NumType, 
                                                                @NumValue, 
                                                                @IsAccountCust, 
                                                                @Master)");
                command.CommandType = CommandType.Text;
                command.Parameters.Add(new SqlParameter(@"SEQ", objTranCodeDetailInfo.SEQ));
                command.Parameters.Add(new SqlParameter(@"Code", objTranCodeDetailInfo.Code));
                command.Parameters.Add(new SqlParameter(@"Account_ID", objTranCodeDetailInfo.Account_ID));
                command.Parameters.Add(new SqlParameter(@"CreditDebit", objTranCodeDetailInfo.CreditDebit.ToString()));
                command.Parameters.Add(new SqlParameter(@"NumType", objTranCodeDetailInfo.NumberType));
                command.Parameters.Add(new SqlParameter(@"NumValue", objTranCodeDetailInfo.NumberValue));
                command.Parameters.Add(new SqlParameter(@"IsAccountCust", objTranCodeDetailInfo.Is_Account_Cust));
                command.Parameters.Add(new SqlParameter(@"Master", objTranCodeDetailInfo.Master));
                this.AddCommand(command);
                return command;
            }
            catch (Exception ex)
            { Logger.Error(ex); throw ex; }
        }
        public SqlCommand EditOneTranCodeDetail(TranCodeDetail_Info objTranCodeDetailInfo)
        {
            try
            {
                SqlCommand command = new SqlCommand(@"UPDATE TranCodeDetail SET 
                                                                SEQ = @SEQ, 
                                                                Code = @Code, 
                                                                Account_ID = @Account_ID, 
                                                                CreditDebit = @CreditDebit, 
                                                                NumType = @NumType, 
                                                                NumValue = @NumValue, 
                                                                IsAccountCust = @IsAccountCust, 
                                                                Master = @Master 
                                                                WHERE ID = @ID ");
                command.CommandType = CommandType.Text;
                command.Parameters.Add(new SqlParameter(@"ID", objTranCodeDetailInfo.ID));
                command.Parameters.Add(new SqlParameter(@"SEQ", objTranCodeDetailInfo.SEQ));
                command.Parameters.Add(new SqlParameter(@"Code", objTranCodeDetailInfo.Code));
                command.Parameters.Add(new SqlParameter(@"Account_ID", objTranCodeDetailInfo.Account_ID));
                command.Parameters.Add(new SqlParameter(@"CreditDebit", objTranCodeDetailInfo.CreditDebit.ToString()));
                command.Parameters.Add(new SqlParameter(@"NumType", objTranCodeDetailInfo.NumberType));
                command.Parameters.Add(new SqlParameter(@"NumValue", objTranCodeDetailInfo.NumberValue));
                command.Parameters.Add(new SqlParameter(@"IsAccountCust", objTranCodeDetailInfo.Is_Account_Cust));
                command.Parameters.Add(new SqlParameter(@"Master", objTranCodeDetailInfo.Master));
                this.AddCommand(command);
                return command;
            }
            catch (Exception ex)
            { Logger.Error(ex); throw ex; }
        }
        public SqlCommand RemoveOneTranCodeDetail(decimal id)
        {
            try
            {
                SqlCommand command = new SqlCommand("Delete TranCodeDetail where ID = @ID ");
                command.CommandType = CommandType.Text;
                command.Parameters.Add(new SqlParameter(@"ID", id));
                this.AddCommand(command);
                return command;
            }
            catch (Exception ex)
            { Logger.Error(ex); throw ex; }
        }
        public SqlCommand RemoveOneTranCodeDetailByCode(string tranCode)
        {
            try
            {
                SqlCommand command = new SqlCommand("Delete TranCodeDetail where Code = @Code ");
                command.CommandType = CommandType.Text;
                command.Parameters.Clear();
                command.Parameters.Add(new SqlParameter("@Code", SqlDbType.NVarChar, 5)).Value = tranCode;
                this.AddCommand(command);
                return command;
            }
            catch (Exception ex)
            { Logger.Error(ex); throw ex; }
        }
        public List<TranCodeDetail_Info> GetAllTranCodeDetail()
        {
            DataSet ds = new DataSet();
            SqlConnection objconn = new SqlConnection(GetConnectionString());
            SqlCommand command = new SqlCommand("Select * from TranCodeDetail ", objconn);
            command.CommandType = CommandType.Text;
            try
            {
                objconn.Open();
                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(ds);
                List<TranCodeDetail_Info> list = new List<TranCodeDetail_Info>();
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    list.Add(GenerateObject(row));
                }
                return list;
            }
            catch (System.Exception ex)
            {
                Logger.Error(ex);
                return null;
            }
            finally
            {
                objconn.Close();
            }
        }
        public TranCodeDetail_Info GetOneTranCodeDetail(decimal id)
        {
            DataSet ds = new DataSet();
            SqlConnection objconn = new SqlConnection(GetConnectionString());
            SqlCommand command = new SqlCommand("Select * from TranCodeDetail where ID = @ID", objconn);
            command.CommandType = CommandType.Text;
            command.Parameters.Add("@ID", SqlDbType.Decimal).Value = id;
            try
            {
                objconn.Open();
                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(ds);
                return GenerateObject(ds.Tables[0].Rows[0]);
            }
            catch (System.Exception ex)
            {
                Logger.Error(ex);
                return null;
            }
            finally
            {
                objconn.Close();
            }
        }
        public List<TranCodeDetail_Info> GetTranCodeDetailByCode(string tranCode)
        {
            DataSet ds = new DataSet();
            SqlConnection objconn = new SqlConnection(GetConnectionString());
            SqlCommand command = new SqlCommand("Select * from TranCodeDetail where Code = @Code Order By Master DESC, Seq ASC", objconn);
            command.CommandType = CommandType.Text;
            command.Parameters.Add(new SqlParameter("@Code", SqlDbType.NVarChar, 5)).Value = tranCode;
            try
            {
                objconn.Open();
                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(ds);
                List<TranCodeDetail_Info> list = new List<TranCodeDetail_Info>();
                foreach (DataRow row in ds.Tables[0].Rows)
                { list.Add(GenerateObject(row)); }
                return list;
            }
            catch (System.Exception ex)
            {
                Logger.Error(ex);
                return null;
            }
            finally
            {
                objconn.Close();
            }
        }
        private TranCodeDetail_Info GenerateObject(DataRow row)
        {
            if (row == null)
                throw new Exception("Data row not set");
            TranCodeDetail_Info tci = new TranCodeDetail_Info();

            if (row["id"] != DBNull.Value)
            {
                tci.ID = Convert.ToDecimal(row["id"]);
            }
            if (row["Code"] != DBNull.Value)
            {
                tci.Code = Convert.ToString(row["Code"]);
            }
            if (row["Account_ID"] != DBNull.Value)
            {
                tci.Account_ID = Convert.ToString(row["Account_ID"]);
            }
            if (row["CreditDebit"] != DBNull.Value)
            {
                tci.CreditDebit = (CreditDebit)Enum.Parse(typeof(CreditDebit), row["CreditDebit"].ToString());
            }
            if (row["NumType"] != DBNull.Value)
            {
                tci.NumberType = (NumberType)Enum.Parse(typeof(NumberType), row["NumType"].ToString());
            }
            if (row["NumValue"] != DBNull.Value)
            {
                tci.NumberValue = Convert.ToSingle(row["NumValue"]);
            }
            if (row["SEQ"] != DBNull.Value)
            {
                tci.SEQ = Convert.ToInt32(row["SEQ"]);
            }
            if (row["IsAccountCust"] != DBNull.Value)
            {
                tci.Is_Account_Cust = Convert.ToBoolean(row["IsAccountCust"]);
            }
            if (row["Master"] != DBNull.Value)
            {
                tci.Master = Convert.ToBoolean(row["Master"]);
            }
            return tci;
        }
    }
}