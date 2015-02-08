using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Account.Common.Entities;

namespace Account.Data.SqlServer
{
    public partial class D_TrandayDetail : SqlServerHelper
    {
        public SqlCommand CreateOneTrandayDetail(TrandayDetail_Info objTrandayDetailInfo)
        {
            try
            {
                SqlCommand command = new SqlCommand(
                    @"INSERT INTO [TrandayDetail]
                                       ([DocID]
                                       ,[Account_ID]
                                       ,[DB_Amount]
                                       ,[CR_Amount]
                                       ,[SEQ]
                                       ,[Ccy]
                                       ,[BalanceAvaiable])
                                 VALUES
                                       (@DocID
                                       ,@Account_ID
                                       ,@DB_Amount
                                       ,@CR_Amount
                                       ,@SEQ
                                       ,@Ccy
                                       ,@BalanceAvaiable)");
                command.CommandType = CommandType.Text;
                command.Parameters.Add("@DocID", SqlDbType.NVarChar, 50).Value = objTrandayDetailInfo.DocID;
                command.Parameters.Add("@Account_ID", SqlDbType.NVarChar, 50).Value = objTrandayDetailInfo.Account_ID;
                command.Parameters.Add("@DB_Amount", SqlDbType.Decimal).Value = objTrandayDetailInfo.DB_Amount;
                command.Parameters.Add("@CR_Amount", SqlDbType.Decimal).Value = objTrandayDetailInfo.CR_Amount;
                command.Parameters.Add("@SEQ", SqlDbType.Int).Value = objTrandayDetailInfo.SEQ;
                command.Parameters.Add("@Ccy", SqlDbType.NVarChar, 6).Value = objTrandayDetailInfo.Ccy;
                command.Parameters.Add("@BalanceAvaiable", SqlDbType.Decimal).Value = objTrandayDetailInfo.BalanceAvaiable;
                this.AddCommand(command);
                return command;
            }
            catch (Exception ex)
            { Logger.Error(ex); throw ex; }
        }
        //**********************************************************************************       
        public SqlCommand EditOneTrandayDetail(TrandayDetail_Info objTrandayDetailInfo)
        {
            try
            {
                SqlCommand command = new SqlCommand(
                    @"UPDATE [TrandayDetail]
                               SET [Account_ID] = @Account_ID
                                  ,[DB_Amount] = @DB_Amount
                                  ,[CR_Amount] = @CR_Amount
                                  ,[SEQ] = @SEQ
                                  ,[Ccy] = @Ccy
                                  ,[BalanceAvaiable] = @BalanceAvaiable
                             WHERE [ID] = @ID");
                command.CommandType = CommandType.Text;
                command.Parameters.Add("@ID", SqlDbType.Decimal).Value = objTrandayDetailInfo.ID;
                command.Parameters.Add("@DocID", SqlDbType.NVarChar, 50).Value = objTrandayDetailInfo.DocID;
                command.Parameters.Add("@Account_ID", SqlDbType.NVarChar, 50).Value = objTrandayDetailInfo.Account_ID;
                command.Parameters.Add("@DB_Amount", SqlDbType.Decimal).Value = objTrandayDetailInfo.DB_Amount;
                command.Parameters.Add("@CR_Amount", SqlDbType.Decimal).Value = objTrandayDetailInfo.CR_Amount;
                command.Parameters.Add("@SEQ", SqlDbType.Int).Value = objTrandayDetailInfo.SEQ;
                command.Parameters.Add("@Ccy", SqlDbType.NVarChar, 6).Value = objTrandayDetailInfo.Ccy;
                command.Parameters.Add("@BalanceAvaiable", SqlDbType.Decimal).Value = objTrandayDetailInfo.BalanceAvaiable;
                this.AddCommand(command);
                return command;
            }
            catch (Exception ex)
            { Logger.Error(ex); throw ex; }
        }
        //******************************************************************************       
        public SqlCommand RemoveOneTrandayDetail(string docId)
        {
            try
            {
                SqlCommand command = new SqlCommand("Delete TrandayDetail where DocID = @DocID");
                command.CommandType = CommandType.Text;
                command.Parameters.Add("@DocID", SqlDbType.NVarChar, 25).Value = docId;
                this.AddCommand(command);
                return command;
            }
            catch (Exception ex)
            { Logger.Error(ex); throw ex; }
        }
        //******************************************************************************       
        public List<TrandayDetail_Info> GetAllTrandayDetail()
        {
            DataSet ds = new DataSet();
            SqlConnection objconn = new SqlConnection(GetConnectionString());
            SqlCommand command = new SqlCommand("Select * From TrandayDetail", objconn);
            command.CommandType = CommandType.Text;
            try
            {
                objconn.Open();
                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(ds);
                List<TrandayDetail_Info> list = new List<TrandayDetail_Info>();
                foreach (DataRow row in ds.Tables[0].Rows)
                    list.Add(GenerateObject(row));
                return list;
            }
            catch (System.Exception ex)
            {
                Logger.Error(ex); throw ex;
            }
            finally
            {
                objconn.Close();
            }
        }
        //******************************************************************************       
        public TrandayDetail_Info GetOneTrandayDetail(decimal id)
        {
            DataSet ds = new DataSet();
            TrandayDetail_Info objTrandayDetail_Info = new TrandayDetail_Info();
            SqlConnection objconn = new SqlConnection(GetConnectionString());
            SqlCommand command = new SqlCommand("Select * From TrandayDetail Where ID = @ID", objconn);
            command.CommandType = CommandType.Text;
            command.Parameters.Add("@ID", SqlDbType.Decimal).Value = objTrandayDetail_Info.ID;
            
            try
            {
                objconn.Open();
                SqlDataAdapter da = new SqlDataAdapter (command);
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
        /// <summary>
        /// hàm lấy giao dịch chi tiết vào mảng
        /// </summary>
        /// <param name="docid"></param>
        /// <returns>
        /// giá trị trả về danh sách
        /// kiểu TrandayDetail_Info
        /// </returns>
        public List<TrandayDetail_Info> GetOneTrandayDetail(string docid)
        {
            DataSet ds = new DataSet();
            TrandayDetail_Info objTrandayDetail_Info = new TrandayDetail_Info();
            SqlConnection objconn = new SqlConnection(GetConnectionString());
            SqlCommand command = new SqlCommand("Select * From TrandayDetail Where DocID = @docid Order By DB_Amount ASC, CR_Amount ASC", objconn);
            command.CommandType = CommandType.Text;
            command.Parameters.Add("@docid", SqlDbType.NVarChar,25).Value = docid;

            try
            {
                objconn.Open();
                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(ds);
                List<TrandayDetail_Info> list = new List<TrandayDetail_Info>();
                foreach (DataRow row in ds.Tables[0].Rows)
                    list.Add(GenerateObject(row));
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
        /// <summary>
        /// Hàm lấy giao dịch chi tiết đã khóa sổ
        /// </summary>
        /// <param name="docid">số chứng từ</param>
        /// <returns>thông tin chứng từ chi tiết</returns>
        public List<TrandayDetail_Info> GetOneTranYearDetail(string docid)
        {
            DataSet ds = new DataSet();
            TrandayDetail_Info objTrandayDetail_Info = new TrandayDetail_Info();
            SqlConnection objconn = new SqlConnection(GetConnectionString());
            SqlCommand command = new SqlCommand("Select * From TranYearDetail Where DocID = @docid Order By DB_Amount ASC, CR_Amount ASC", objconn);
            command.CommandType = CommandType.Text;
            command.Parameters.Add("@docid", SqlDbType.NVarChar, 50).Value = docid;

            try
            {
                objconn.Open();
                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(ds);
                List<TrandayDetail_Info> list = new List<TrandayDetail_Info>();
                foreach (DataRow row in ds.Tables[0].Rows)
                    list.Add(GenerateObject(row));
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
        /// <summary
        /// hàm chuyển giá trị datarow về dạng cấu trúc Trandaydetail_Info
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        private TrandayDetail_Info GenerateObject(DataRow row)
        {
            if (row == null)
                throw new Exception("Trandaydetail object does not exists");
            
            TrandayDetail_Info tdi = new TrandayDetail_Info();
            if (row["ID"] != DBNull.Value)
            {
                tdi.ID = Convert.ToDecimal(row["ID"]);
            }
            if (row["DocID"] != DBNull.Value)
            {
                tdi.DocID = Convert.ToString(row["DocID"]);
            }
            if (row["Account_ID"] != DBNull.Value)
            {
                tdi.Account_ID = Convert.ToString(row["Account_ID"]);
            }
            if (row["db_Amount"] != DBNull.Value)
            {
                tdi.DB_Amount = Convert.ToDecimal(row["db_Amount"]);
            }
            if (row["Cr_Amount"] != DBNull.Value)
            {
                tdi.CR_Amount = Convert.ToDecimal(row["Cr_Amount"]);
            }
            if (row["SEQ"] != DBNull.Value)
            {
                tdi.SEQ = Convert.ToInt16(row["SEQ"]);
            }
            if (row["Ccy"] != DBNull.Value)
            {
                tdi.Ccy = Convert.ToString(row["Ccy"]);
            }
            if (row["BalanceAvaiable"] != DBNull.Value)
            {
                tdi.BalanceAvaiable = Convert.ToDecimal(row["BalanceAvaiable"]);
            }
            return tdi;
        }
    }
}