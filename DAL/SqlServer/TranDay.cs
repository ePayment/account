using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Account.Common.Entities;
using Account.Common.Utilities;

namespace Account.Data.SqlServer
{
    public partial class D_Tranday : SqlServerHelper
    {
        /// <summary>
        /// Hàm tạo mới một chứng từ trong ngày
        /// </summary>
        /// <param name="objTrandayInfo">thông tin chi tiết chứng từ</param>
        /// <returns>câu lệnh ghi nhận vào DB</returns>
        public SqlCommand CreateOneTranday(Tranday_Info objTrandayInfo)
        {
            try
            {
                SqlCommand command = new SqlCommand("INSERT INTO Tranday("
                                                    + "DocID, "
                                                    + "TraceNum, "
                                                    + "TransDate, "
                                                    + "Branch_ID, "
                                                    + "Descript, "
                                                    + "Trans_code, "
                                                    + "Next_DocID, "
                                                    + "Status, "
                                                    + "AllowReverse, "
                                                    + "OtherRef, "
                                                    + "ValueDate, "
                                                    + "Verified, "
                                                    + "Verified_User, "
                                                    + "CreatedDate, "
                                                    + "Last_Date, "
                                                    + "UserCreate "
                                                    + ")"
                                                    + "VALUES ("
                                                    + "@DocID, "
                                                    + "@TraceNum, "
                                                    + "@TransDate, "
                                                    + "@Branch_ID, "
                                                    + "@Descript, "
                                                    + "@Trans_code, "
                                                    + "@Next_DocID, "
                                                    + "@Status, "
                                                    + "@AllowReverse, "
                                                    + "@OtherRef, "
                                                    + "@ValueDate, "
                                                    + "@Verified, "
                                                    + "@Verified_User, "
                                                    + "@CreatedDate, "
                                                    + "@Last_Date, "
                                                    + "@UserCreate "
                                                    + ")");
                command.CommandType = CommandType.Text;
                command.Parameters.Add("@DocID", SqlDbType.NVarChar, 25).Value = objTrandayInfo.DocID;
                if (string.IsNullOrEmpty(objTrandayInfo.Trace))
                { command.Parameters.Add("@TraceNum", SqlDbType.NVarChar, 25).Value = DBNull.Value; }
                else
                { command.Parameters.Add("@TraceNum", SqlDbType.NVarChar, 25).Value = objTrandayInfo.Trace; }
                command.Parameters.Add("@TransDate", SqlDbType.DateTime).Value = objTrandayInfo.TransDate;
                command.Parameters.Add("@Branch_ID", SqlDbType.NVarChar, 4).Value = objTrandayInfo.Branch_ID;
                command.Parameters.Add("@Descript", SqlDbType.NVarChar, 270).Value = objTrandayInfo.Descript;
                command.Parameters.Add("@Trans_code", SqlDbType.NVarChar, 5).Value = objTrandayInfo.TranCode;
                if (!string.IsNullOrEmpty(objTrandayInfo.NextDocId))
                    command.Parameters.Add("@Next_DocID", SqlDbType.NVarChar, 25).Value = objTrandayInfo.NextDocId;
                else
                    command.Parameters.Add("@Next_DocID", SqlDbType.NVarChar, 25).Value = DBNull.Value;
                command.Parameters.Add("@Status", SqlDbType.NVarChar, 50).Value = objTrandayInfo.Status;
                command.Parameters.Add("@AllowReverse", SqlDbType.Bit).Value = objTrandayInfo.AllowReverse;
                if (string.IsNullOrEmpty(objTrandayInfo.OtherRef))
                { command.Parameters.Add("@OtherRef", SqlDbType.NVarChar, 50).Value = DBNull.Value; }
                else
                { command.Parameters.Add("@OtherRef", SqlDbType.NVarChar, 50).Value = objTrandayInfo.OtherRef; }
                command.Parameters.Add("@ValueDate", SqlDbType.DateTime).Value = objTrandayInfo.ValueDate;
                command.Parameters.Add("@Verified", SqlDbType.Bit).Value = objTrandayInfo.Verified;
                if (objTrandayInfo.Verified == false)
                { command.Parameters.Add("@Verified_User", SqlDbType.NVarChar, 25).Value = DBNull.Value; }
                else
                { command.Parameters.Add("@Verified_User", SqlDbType.NVarChar, 25).Value = objTrandayInfo.Verified_User; }
                command.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = objTrandayInfo.CreatedDate;
                command.Parameters.Add("@Last_Date", SqlDbType.DateTime).Value = objTrandayInfo.Last_Update;
                command.Parameters.Add("@UserCreate", SqlDbType.NVarChar, 25).Value = objTrandayInfo.UserCreate;
                this.AddCommand(command);
                return command;
            }
            catch (Exception ex)
            { Logger.Error(ex); throw ex; }
        }
        /// <summary>
        /// Hàm sửa một chứng từ
        /// </summary>
        /// <param name="objTrandayInfo">thông tin chi tiết chứng từ</param>
        /// <returns>câu lệnh cập nhật vào DB</returns>
        public SqlCommand EditOneTranday(Tranday_Info objTrandayInfo)
        {
            try
            {
                SqlCommand command = new SqlCommand("UPDATE Tranday SET "
                                                    + "TraceNum = @TraceNum, "
                                                    + "TransDate = @TransDate, "
                                                    + "Branch_ID = @Branch_ID, "
                                                    + "Descript = @Descript, "
                                                    + "Trans_code = @Trans_code, "
                                                    + "Next_DocID = @Next_DocID, "
                                                    + "Status = @Status, "
                                                    + "AllowReverse = @AllowReverse, "
                                                    + "OtherRef = @OtherRef, "
                                                    + "ValueDate = @ValueDate, "
                                                    + "Verified = @Verified, "
                                                    + "Verified_User = @Verified_User, "
                                                    + "CreatedDate = @CreatedDate, "
                                                    + "Last_Date = @Last_Date, "
                                                    + "UserCreate = @UserCreate "
                                                    + "WHERE DocID= @DocID");
                command.CommandType = CommandType.Text;
                command.Parameters.Add("@DocID", SqlDbType.NVarChar, 25).Value = objTrandayInfo.DocID;
                if (string.IsNullOrEmpty(objTrandayInfo.Trace))
                { command.Parameters.Add("@TraceNum", SqlDbType.NVarChar, 25).Value = DBNull.Value; }
                else
                { command.Parameters.Add("@TraceNum", SqlDbType.NVarChar, 25).Value = objTrandayInfo.Trace; }
                command.Parameters.Add("@TransDate", SqlDbType.DateTime).Value = objTrandayInfo.TransDate;
                command.Parameters.Add("@Branch_ID", SqlDbType.NVarChar, 4).Value = objTrandayInfo.Branch_ID;
                command.Parameters.Add("@Descript", SqlDbType.NVarChar, 270).Value = objTrandayInfo.Descript;
                command.Parameters.Add("@Trans_code", SqlDbType.NVarChar, 5).Value = objTrandayInfo.TranCode;
                if (!string.IsNullOrEmpty(objTrandayInfo.NextDocId))
                    command.Parameters.Add("@Next_DocID", SqlDbType.NVarChar, 25).Value = objTrandayInfo.NextDocId;
                else
                    command.Parameters.Add("@Next_DocID", SqlDbType.NVarChar, 25).Value = DBNull.Value;
                command.Parameters.Add("@Status", SqlDbType.NVarChar, 50).Value = objTrandayInfo.Status;
                command.Parameters.Add("@AllowReverse", SqlDbType.Bit).Value = objTrandayInfo.AllowReverse;
                if (string.IsNullOrEmpty(objTrandayInfo.OtherRef))
                { command.Parameters.Add("@OtherRef", SqlDbType.NVarChar, 50).Value = DBNull.Value; }
                else
                { command.Parameters.Add("@OtherRef", SqlDbType.NVarChar, 50).Value = objTrandayInfo.OtherRef; }
                command.Parameters.Add("@ValueDate", SqlDbType.DateTime).Value = objTrandayInfo.ValueDate;
                command.Parameters.Add("@Verified", SqlDbType.Bit).Value = objTrandayInfo.Verified;
                if (objTrandayInfo.Verified == false)
                { command.Parameters.Add("@Verified_User", SqlDbType.NVarChar, 25).Value = DBNull.Value; }
                else
                { command.Parameters.Add("@Verified_User", SqlDbType.NVarChar, 25).Value = objTrandayInfo.Verified_User; }
                command.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = objTrandayInfo.CreatedDate;
                command.Parameters.Add("@Last_Date", SqlDbType.DateTime).Value = objTrandayInfo.Last_Update;
                command.Parameters.Add("@UserCreate", SqlDbType.NVarChar, 25).Value = objTrandayInfo.UserCreate;
                this.AddCommand(command);
                return command;
            }
            catch (Exception ex)
            { Logger.Error(ex); throw ex;  }
        }
        /// <summary>
        /// hàm xóa một chứng từ
        /// </summary>
        /// <param name="docId">Mã số chứng từ</param>
        /// <returns>câu lệnh del bản ghi trong DB</returns>
        public SqlCommand RemoveOneTranday(string docId)
        {
            try
            {
                SqlCommand command = new SqlCommand("Delete Tranday where DocID = @DocID");
                command.CommandType = CommandType.Text;
                command.Parameters.Add(new SqlParameter(@"DocID", docId));
                this.AddCommand(command);
                return command;
            }
            catch (Exception ex)
            { Logger.Error(ex); throw ex; }
        }
        /// <summary>
        /// Hàm lấy thông tin chi tiết của một chứng từ
        /// </summary>
        /// <param name="docId">Mã số chứng từ</param>
        /// <returns>Thông tin chi tiết của chứng từ</returns>
        public Tranday_Info GetOneTranday(string docId)
        {
            SqlConnection objconn = new SqlConnection(GetConnectionString());
            SqlCommand command = new SqlCommand("Select * from Tranday Where DocID = @DocID", objconn);
            command.CommandType = CommandType.Text;
            command.Parameters.Clear();
            command.Parameters.Add("@DocID",SqlDbType.NVarChar,25).Value = docId;
            try
            {
                objconn.Open();
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(ds);
                if (ds.Tables[0].Rows.Count == 1)
                {
                    Tranday_Info ti = new Tranday_Info();
                    ti = GenerateObject(ds.Tables[0].Rows[0]);
                    D_TrandayDetail dtd = new D_TrandayDetail();
                    ti.TrandayDetails = dtd.GetOneTrandayDetail(docId);
                    return ti;
                }
                else
                    return null;
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
        /// Hàm kiểm tra số chứng từ này đã có hay chưa
        /// điều kiện tìm kiếm theo một trong hai biến hoặc cả hai biến
        /// với giá trị chống cả hai biến hàm không đúng
        /// </summary>
        /// <param name="docid">mã số chứng từ do hệ thống tự sinh theo định dạng tại file cấu hình</param>
        /// <param name="trace">mã số chứng từ duy nhất theo ngày khóa sổ</param>
        /// <returns>
        /// trả về giá trị true nếu đã có
        /// và false nếu không có.
        /// </returns>
        public bool IsExists(string docid, string trace)
        {
            if (string.IsNullOrEmpty(docid) && string.IsNullOrEmpty(trace))
                throw new Exception("Invalid parameter value");

            SqlConnection objconn = new SqlConnection(GetConnectionString());
            SqlCommand command=new SqlCommand();
            command.CommandType = CommandType.Text;
            if (!string.IsNullOrEmpty(docid))
            {
                command = new SqlCommand("Select Count(*) from Tranday where DocID = @DocID", objconn);
                command.Parameters.Clear();
                command.Parameters.Add(new SqlParameter(@"DocID", docid));
            }

            if (!string.IsNullOrEmpty(trace))
            {
                command = new SqlCommand("Select Count(*) from Tranday where TraceNum = @TraceNum", objconn);
                command.Parameters.Clear();
                command.Parameters.Add(new SqlParameter(@"TraceNum", trace));
            }
            if (string.IsNullOrEmpty(docid)==false && string.IsNullOrEmpty(trace)==false)
            {
                command = new SqlCommand("Select Count(*) from Tranday where DocID = @DocID And TraceNum = @TraceNum", objconn);
                command.Parameters.Clear();
                command.Parameters.Add(new SqlParameter(@"DocID", docid));
                command.Parameters.Add(new SqlParameter(@"TraceNum", trace));
            }
            try
            {
                objconn.Open();
                SqlDataReader ord = command.ExecuteReader();
                if (ord != null)
                    ord.Read();
                if (Convert.ToInt16(ord[0]) == 0)
                { return false; }
                else
                { return true; }
            }
            catch (System.Exception ex)
            {
                Logger.Error(ex);
                return false;
            }
            finally
            {
                objconn.Close();
            }
        }
        /// <summary>
        /// Hàm dán thông tin từ bản ghi vào lớp đối tượng
        /// </summary>
        /// <param name="row">dòng dữ liệu trên bảng</param>
        /// <returns>thông ti n chi tiết chứng từ</returns>
        private Tranday_Info GenerateObject(DataRow row)
        {
            if (row == null)
                throw new Exception("Data row does not null or empty");

            Tranday_Info objTranday_Info = new Tranday_Info();

            if (row["DocID"] != DBNull.Value)
            {
                objTranday_Info.DocID = Convert.ToString(row["DocID"]);
            }
            if (row["TraceNum"] != DBNull.Value)
            {
                objTranday_Info.Trace = Convert.ToString(row["TraceNum"]);
            }
            if (row["TransDate"] != DBNull.Value)
            {
                objTranday_Info.TransDate = Convert.ToDateTime(row["TransDate"]);
            }
            if (row["Branch_ID"] != DBNull.Value)
            {
                objTranday_Info.Branch_ID = Convert.ToString(row["Branch_ID"]);
            }
            if (row["Descript"] != DBNull.Value)
            {
                objTranday_Info.Descript = Convert.ToString(row["Descript"]);
            }
            if (row["Trans_code"] != DBNull.Value)
            {
                objTranday_Info.TranCode = Convert.ToString(row["Trans_code"]);
            }
            if (row["Next_DocID"] != DBNull.Value)
            {
                objTranday_Info.NextDocId = Convert.ToString(row["Next_DocID"]);
            }
            if (row["Status"] != DBNull.Value)
            {
                objTranday_Info.Status = (TransactionStatus)Enum.Parse(typeof(TransactionStatus), row["Status"].ToString());
            }
            if (row["OtherRef"] != DBNull.Value)
            {
                objTranday_Info.OtherRef = Convert.ToString(row["OtherRef"]);
            }
            if (row["ValueDate"] != DBNull.Value)
            {
                objTranday_Info.ValueDate = Convert.ToDateTime(row["ValueDate"]);
            }
            if (row["Verified"] != DBNull.Value)
            {
                objTranday_Info.Verified = Convert.ToBoolean(row["Verified"]);
            }
            if (row["Verified_User"] != DBNull.Value)
            {
                objTranday_Info.Verified_User = Convert.ToString(row["Verified_User"]);
            }
            if (row["UserCreate"] != DBNull.Value)
            {
                objTranday_Info.UserCreate = Convert.ToString(row["UserCreate"]);
            }
            if (row["AllowReverse"] != DBNull.Value)
            {
                objTranday_Info.AllowReverse = Convert.ToBoolean(row["AllowReverse"]);
            }
            if (row["CreatedDate"] != DBNull.Value)
            {
                objTranday_Info.CreatedDate = Convert.ToDateTime(row["CreatedDate"]);
            }
            if (row["Last_Date"] != DBNull.Value)
            {
                objTranday_Info.Last_Update = Convert.ToDateTime(row["Last_Date"]);
            }
            return objTranday_Info;
        }
        /// <summary>
        /// Hàm lấy danh sách giao dịch trong ngày theo số lượng tự chọn
        /// tham số, nếu giá trị tham số là zero thì hàm sẽ lấy tất cả các giao dịch
        /// phát sinh trong ngày.
        /// </summary>
        /// <param name="many">số giao dịch cần lấy</param>
        /// <returns>danh sách giao dịch chi tiết cần lấy</returns>
        public List<Tranday_Info> GetManyTranday(string account_id, int many)
        {
            string cmdstr = "";
            if (many == 0)
            {
                // Lấy tất cả các giao dịch
                cmdstr = string.Format("Select a.* from Tranday a,(Select * from Trandaydetail Where PATINDEX(@Account_ID, Account_ID)>0) b Where a.DocID = b.DocID Order By a.CreatedDate DESC");
            }
            else
            {
                cmdstr = string.Format("Select top {0} a.* from Tranday a,(Select DocID from Trandaydetail Where PATINDEX(@Account_ID, Account_ID)>0) b Where a.DocID = b.DocID Order By a.CreatedDate DESC", many);
            }
            // Lấy theo số lượng giao dịch đã định
            DataSet ds = new DataSet();
            SqlConnection objconn = new SqlConnection(GetConnectionString());
            SqlCommand command = new SqlCommand(cmdstr, objconn);
            command.Parameters.Clear();
            command.Parameters.Add("@Account_ID", SqlDbType.NVarChar, 25).Value = account_id;
            command.CommandType = CommandType.Text;
            try
            {
                objconn.Open();
                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(ds);
                Tranday_Info ti;
                D_TrandayDetail dtd = new D_TrandayDetail();
                List<Tranday_Info> list = new List<Tranday_Info>();
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    ti = GenerateObject(row);
                    ti.TrandayDetails = dtd.GetOneTrandayDetail(ti.DocID);
                    list.Add(ti);
                }
                return list;
            }
            catch (SqlException ex)
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
        /// Hàm lấy giao dịch khóa sổ theo tham số từ ngày, đến ngày
        /// </summary>
        /// <param name="dfrom">từ ngày</param>
        /// <param name="dto">đến ngày</param>
        /// <returns>Danh sách chi tiết giao dịch</returns>
        public List<Tranday_Info> GetManyTranALL(string account_id, DateTime dfrom, DateTime dto)
        {
            DataSet ds = new DataSet();
            SqlConnection objconn = new SqlConnection(GetConnectionString());
            SqlCommand command = new SqlCommand("Select a.* From TranAll() a,(Select DocID from TranAllDetail() Where PATINDEX(@Account_ID, Account_ID)>0) b Where a.DocID = b.DocID And (a.Transdate >= @DateFrom And a.Transdate <= @DateTo)", objconn);
            command.CommandType = CommandType.Text;
            command.Parameters.Add("@Account_ID", SqlDbType.NVarChar,25).Value = account_id;
            command.Parameters.Add("@DateFrom",SqlDbType.DateTime).Value=dfrom;
            command.Parameters.Add("@DateTo", SqlDbType.DateTime).Value = dto;
            try
            {
                objconn.Open();
                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(ds);
                Tranday_Info ti;
                D_TrandayDetail dtd = new D_TrandayDetail();
                List<Tranday_Info> list = new List<Tranday_Info>();
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    ti = GenerateObject(row);
                    ti.TrandayDetails = dtd.GetOneTranYearDetail(ti.DocID);
                    list.Add(ti);
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
//        public List<Tranday_Info> GetCondictionTranday(TrandayFull_Info obj)
//        {
//            DataSet ds = new DataSet();
//            SqlConnection objconn = new SqlConnection(GetConnectionString());
//            SqlCommand command = new SqlCommand(@"Select a.* From TranAll() a,
//            (Select DocID from TranAllDetail() Where Account_ID = @Account_ID) b 
//            Where a.DocID = b.DocID And (a.Transdate >= @DateFrom And a.Transdate <= @DateTo)", objconn);
//            command.CommandType = CommandType.Text;
//            command.Parameters.Add(new SqlParameter("@Account_ID", SqlDbType.NVarChar, 25).Value = account_id);
//            command.Parameters.Add(new SqlParameter("@DateFrom", SqlDbType.DateTime).Value = dfrom);
//            command.Parameters.Add(new SqlParameter("@DateTo", SqlDbType.DateTime).Value = dto);
//            try
//            {
//                objconn.Open();
//                SqlDataAdapter da = new SqlDataAdapter(command);
//                da.Fill(ds);
//                Tranday_Info ti;
//                D_TrandayDetail dtd = new D_TrandayDetail();
//                List<Tranday_Info> list = new List<Tranday_Info>();
//                foreach (DataRow row in ds.Tables[0].Rows)
//                {
//                    ti = GenerateObject(row);
//                    ti.TrandayDetails = dtd.GetOneTranYearDetail(ti.DocID);
//                    list.Add(ti);
//                }
//                return list;
//            }
//            catch (System.Exception ex)
//            {
//                Logger.Error(ex);
//                return null;
//            }
//            finally
//            {
//                objconn.Close();
//            }
//        }
        //public long GetCondictionTranday_Auth(TrandayFull_Info obj)
        //{ }
        //private string SqlCondictionTranday(TrandayFull_Info obj)
        //{
        //    string select_str = string.Empty;
        //    string from_str = string.Empty;
        //    string where_detail_str = string.Empty;
        //    string where_str = string.Empty;
        //    string order_by = string.Empty;
        //    if (!string.IsNullOrEmpty(obj.DocID)) 
        //        switch (string.IsNullOrEmpty(where_detail_str)) 
        //        {
        //            case true:
        //                where_detail_str += "PATINDEX("+obj.DocID+",a.DocID)>0";
        //                break;
        //            case false:
        //                where_detail_str += "AND PATINDEX(" + obj.DocID + ",a.DocID)>0";
        //                break;
        //        }
        //    if (!string.IsNullOrEmpty(obj.Descript))
        //        switch (string.IsNullOrEmpty(where_detail_str))
        //        {
        //            case true:
        //                where_detail_str += "PATINDEX(" + obj.Descript + ",a.Descript)>0";
        //                break;
        //            case false:
        //                where_detail_str += "AND PATINDEX(" + obj.Descript + ",a.Descript)>0";
        //                break;
        //        }

        //    if (!string.IsNullOrEmpty(obj.OtherRef))
        //        switch (string.IsNullOrEmpty(where_detail_str))
        //        {
        //            case true:
        //                where_detail_str += "PATINDEX(" + obj.OtherRef + ",a.OtherRef)>0";
        //                break;
        //            case false:
        //                where_detail_str += "AND PATINDEX(" + obj.OtherRef + ",a.OtherRef)>0";
        //                break;
        //        }
        //    if (!string.IsNullOrEmpty(obj.TransDate))
        //        switch (string.IsNullOrEmpty(where_detail_str))
        //        {
        //            case true:
        //                where_detail_str += "PATINDEX(" + obj.OtherRef + ",a.OtherRef)>0";
        //                break;
        //            case false:
        //                where_detail_str += "AND PATINDEX(" + obj.OtherRef + ",a.OtherRef)>0";
        //                break;
        //        }

        //    where_str = "";

        //    select_str = "Select a.* ";
        //    from_str = "From TranAll() a, (Select DocID from TranAllDetail() "+ where_detail_str +") b ";
        //    order_by = "Order By a.DocID ASC";
        //}
    }
}