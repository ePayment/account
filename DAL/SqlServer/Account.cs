using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Account.Common.Entities;
using Account.Common.Utilities;

namespace Account.Data.SqlServer
{
    /// <summary>
    /// class DAL for Account table
    /// </summary>
    public partial class D_Account : SqlServerHelper
    {
        /// <summary>
        /// tạo tài khoản mới
        /// </summary>
        /// <param name="objAccountInfo"></param>
        /// <returns></returns>
        public SqlCommand CreateOneAccount(Account_Info objAccountInfo)
        {
            try
            {
                SqlCommand command = new SqlCommand(
                    "INSERT INTO Account("
                    + "Account_ID, "
                    + "Name, "
                    + "Ref, "
                    + "b_Credit, "
                    + "y_Credit, "
                    + "y_Debit, "
                    + "q_Credit, "
                    + "q_Debit, "
                    + "m_Credit, "
                    + "m_Debit, "
                    + "w_Credit, "
                    + "w_Debit, "
                    + "d_Credit, "
                    + "d_Debit, "
                    + "CreditDebit, "
                    + "Ccy, "
                    + "Amount_Blocked, "
                    + "Account_GL, "
                    + "Branch_ID, "
                    + "Customer_ID, "
                    + "Categories, "
                    + "ApprovedTime, "
                    + "Approved, "
                    + "Locked, "
                    + "UNC_Rpt, "
                    + "Open_Date, "
                    + "Last_Date, "
                    + "UserCreate "
                    + ")"
                    + "VALUES ("
                    + "@Account_ID, "
                    + "@Name, "
                    + "@Ref, "
                    + "@b_Credit, "
                    + "@y_Credit, "
                    + "@y_Debit, "
                    + "@q_Credit, "
                    + "@q_Debit, "
                    + "@m_Credit, "
                    + "@m_Debit, "
                    + "@w_Credit, "
                    + "@w_Debit, "
                    + "@d_Credit, "
                    + "@d_Debit, "
                    + "@CreditDebit, "
                    + "@Ccy, "
                    + "@Amount_Blocked, "
                    + "@Account_GL, "
                    + "@Branch_ID, "
                    + "@Customer_ID, "
                    + "@Categories, "
                    + "@ApprovedTime, "
                    + "@Approved, "
                    + "@Locked, "
                    + "@UNC_Rpt, "
                    + "@Open_Date, "
                    + "@Last_Date, "
                    + "@UserCreate "
                    + ")");
                command.CommandType = CommandType.Text;
                command.Parameters.Add("@Account_ID", SqlDbType.NVarChar, 25).Value = objAccountInfo.Account_ID;
                command.Parameters.Add("@Name", SqlDbType.NVarChar, 135).Value = objAccountInfo.Name;
                if (!string.IsNullOrEmpty(objAccountInfo.Reference))
                    command.Parameters.Add("@Ref", SqlDbType.NVarChar, 25).Value = objAccountInfo.Reference;
                else
                    command.Parameters.Add("@Ref", SqlDbType.NVarChar, 25).Value = DBNull.Value;
                command.Parameters.Add("@b_Credit", SqlDbType.Decimal).Value = objAccountInfo.b_Credit;
                command.Parameters.Add("@y_Credit", SqlDbType.Decimal).Value = objAccountInfo.y_Credit;
                command.Parameters.Add("@y_Debit", SqlDbType.Decimal).Value = objAccountInfo.y_Debit;
                command.Parameters.Add("@q_Credit", SqlDbType.Decimal).Value = objAccountInfo.q_Credit;
                command.Parameters.Add("@q_Debit", SqlDbType.Decimal).Value = objAccountInfo.q_Debit;
                command.Parameters.Add("@m_Credit", SqlDbType.Decimal).Value = objAccountInfo.m_Credit;
                command.Parameters.Add("@m_Debit", SqlDbType.Decimal).Value = objAccountInfo.m_Debit;
                command.Parameters.Add("@w_Credit", SqlDbType.Decimal).Value = objAccountInfo.w_Credit;
                command.Parameters.Add("@w_Debit", SqlDbType.Decimal).Value = objAccountInfo.w_Debit;
                command.Parameters.Add("@d_Credit", SqlDbType.Decimal).Value = objAccountInfo.d_Credit;
                command.Parameters.Add("@d_Debit", SqlDbType.Decimal).Value = objAccountInfo.d_Debit;
                command.Parameters.Add("@CreditDebit", SqlDbType.NVarChar, 10).Value = objAccountInfo.CreditDebit;
                command.Parameters.Add("@Ccy", SqlDbType.NVarChar, 25).Value = objAccountInfo.Ccy;
                command.Parameters.Add("@Account_GL", SqlDbType.NVarChar, 25).Value = objAccountInfo.Account_GL;
                command.Parameters.Add("@Branch_ID", SqlDbType.NVarChar, 25).Value = objAccountInfo.Branch_ID;
                command.Parameters.Add("@Customer_ID", SqlDbType.NVarChar, 25).Value = objAccountInfo.Customer_ID;
                command.Parameters.Add("@Categories", SqlDbType.NVarChar, 25).Value = objAccountInfo.Categories;
                command.Parameters.Add("@Amount_Blocked", SqlDbType.Decimal).Value = objAccountInfo.Amount_Blocked;
                if (objAccountInfo.ApprovedTime != new DateTime(0))
                    command.Parameters.Add("@ApprovedTime", SqlDbType.DateTime).Value = objAccountInfo.ApprovedTime;
                else
                    command.Parameters.Add("@ApprovedTime", SqlDbType.DateTime).Value = DBNull.Value;

                command.Parameters.Add("@Approved", SqlDbType.Bit).Value = objAccountInfo.Approved;
                command.Parameters.Add("@Locked", SqlDbType.Bit).Value = objAccountInfo.Locked;

                if (objAccountInfo.UNC_Rpt != null)
                    command.Parameters.Add("@UNC_Rpt", SqlDbType.NVarChar, 50).Value = objAccountInfo.UNC_Rpt;
                else
                    command.Parameters.Add("@UNC_Rpt", SqlDbType.NVarChar, 50).Value = DBNull.Value;
                command.Parameters.Add("@Open_Date", SqlDbType.DateTime).Value = DateTime.Now;
                command.Parameters.Add("@Last_Date", SqlDbType.DateTime).Value = DateTime.Now;
                command.Parameters.Add("@UserCreate", SqlDbType.NVarChar, 25).Value = objAccountInfo.UserCreate;
                this.AddCommand(command);
                return command;
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                throw ex; 
            }
            
        }
        /// <summary>
        /// sửa đổi thông tin tài khoản
        /// </summary>
        /// <param name="objAccountInfo"></param>
        /// <returns></returns>
        public SqlCommand EditOneAccount(Account_Info objAccountInfo)
        {
            return EditOneAccount(objAccountInfo, false);
        }
        /// <summary>
        /// Hàm cập nhật thông tin tài khoản 
        /// </summary>
        /// <param name="objAccountInfo">thông tin tài khoản chi tiết</param>
        /// <param name="forceUpdate">= true cập nhật không cần checksume
        /// =false kiểm tra điều kiện toàn vẹn dữ liệu checksume</param>
        /// <returns>SqlCommand</returns>
        public SqlCommand EditOneAccount(Account_Info objAccountInfo, bool forceUpdate)
        {
            try
            {
                SqlCommand command = new SqlCommand("AccountUpdate");
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@Account_ID", SqlDbType.NVarChar, 25).Value = objAccountInfo.Account_ID;
                command.Parameters.Add("@Name", SqlDbType.NVarChar, 135).Value = objAccountInfo.Name;
                if (!string.IsNullOrEmpty(objAccountInfo.Reference))
                    command.Parameters.Add("@Ref", SqlDbType.NVarChar, 25).Value = objAccountInfo.Reference;
                else
                    command.Parameters.Add("@Ref", SqlDbType.NVarChar, 25).Value = DBNull.Value;
                command.Parameters.Add("@b_Credit", SqlDbType.Decimal).Value = objAccountInfo.b_Credit;
                command.Parameters.Add("@y_Credit", SqlDbType.Decimal).Value = objAccountInfo.y_Credit;
                command.Parameters.Add("@y_Debit", SqlDbType.Decimal).Value = objAccountInfo.y_Debit;
                command.Parameters.Add("@q_Credit", SqlDbType.Decimal).Value = objAccountInfo.q_Credit;
                command.Parameters.Add("@q_Debit", SqlDbType.Decimal).Value = objAccountInfo.q_Debit;
                command.Parameters.Add("@m_Credit", SqlDbType.Decimal).Value = objAccountInfo.m_Credit;
                command.Parameters.Add("@m_Debit", SqlDbType.Decimal).Value = objAccountInfo.m_Debit;
                command.Parameters.Add("@w_Credit", SqlDbType.Decimal).Value = objAccountInfo.w_Credit;
                command.Parameters.Add("@w_Debit", SqlDbType.Decimal).Value = objAccountInfo.w_Debit;
                command.Parameters.Add("@d_Credit", SqlDbType.Decimal).Value = objAccountInfo.d_Credit;
                command.Parameters.Add("@d_Debit", SqlDbType.Decimal).Value = objAccountInfo.d_Debit;
                command.Parameters.Add("@CreditDebit", SqlDbType.NVarChar, 10).Value = objAccountInfo.CreditDebit;
                command.Parameters.Add("@Ccy", SqlDbType.NVarChar, 3).Value = objAccountInfo.Ccy;
                command.Parameters.Add("@Account_GL", SqlDbType.NVarChar, 25).Value = objAccountInfo.Account_GL;
                command.Parameters.Add("@Branch_ID", SqlDbType.NVarChar, 25).Value = objAccountInfo.Branch_ID;
                command.Parameters.Add("@Customer_ID", SqlDbType.NVarChar, 25).Value = objAccountInfo.Customer_ID;
                command.Parameters.Add("@Categories", SqlDbType.NVarChar, 25).Value = objAccountInfo.Categories;
                command.Parameters.Add("@Amount_Blocked", SqlDbType.Decimal).Value = objAccountInfo.Amount_Blocked;
                if (objAccountInfo.ApprovedTime != new DateTime(0))
                    command.Parameters.Add("@ApprovedTime", SqlDbType.DateTime).Value = objAccountInfo.ApprovedTime;
                else
                    command.Parameters.Add("@ApprovedTime", SqlDbType.DateTime).Value = DBNull.Value;

                command.Parameters.Add("@Approved", SqlDbType.Bit).Value = objAccountInfo.Approved;
                command.Parameters.Add("@Locked", SqlDbType.Bit).Value = objAccountInfo.Locked;

                if (objAccountInfo.UNC_Rpt != null)
                    command.Parameters.Add("@UNC_Rpt", SqlDbType.NVarChar, 50).Value = objAccountInfo.UNC_Rpt;
                else
                    command.Parameters.Add("@UNC_Rpt", SqlDbType.NVarChar, 50).Value = DBNull.Value;
                if (objAccountInfo.Closed == true)
                {
                    command.Parameters.Add("@Closed", SqlDbType.Bit).Value = objAccountInfo.Closed;
                    command.Parameters.Add("@Closed_date", SqlDbType.DateTime).Value = objAccountInfo.Closed_date;
                }
                else
                {
                    command.Parameters.Add("@Closed", SqlDbType.Bit).Value = objAccountInfo.Closed;
                    command.Parameters.Add("@Closed_date", SqlDbType.DateTime).Value = DBNull.Value;
                }
                command.Parameters.Add("@Open_Date", SqlDbType.DateTime).Value = objAccountInfo.Open_Date;
                command.Parameters.Add("@Last_Date", SqlDbType.DateTime).Value = DateTime.Now;
                command.Parameters.Add("@UserCreate", SqlDbType.NVarChar, 25).Value = objAccountInfo.UserCreate;
                command.Parameters.Add("@CheckSumValue", SqlDbType.NVarChar,4000).Value = objAccountInfo.CheckSumValue;
                command.Parameters.Add("@force_update", SqlDbType.Bit).Value = forceUpdate;
                this.AddCommand(command);
                return command;
            }
            catch (Exception ex)
            { Logger.Error(ex); throw ex; }
        }
        /// <summary>
        /// xóa một hồ sơ tài khoản
        /// </summary>
        /// <param name="accountId"></param>
        /// <returns></returns>
        public SqlCommand RemoveOneAccount(string accountId)
        {
            try
            {
                SqlCommand command = new SqlCommand("Delete Account where Account_ID = @Account_ID");
                command.CommandType = CommandType.Text;
                command.Parameters.Add("@Account_ID", SqlDbType.NVarChar, 25).Value = accountId;
                this.AddCommand(command);
                return command;
            }
            catch (Exception ex)
            { Logger.Error(ex); throw ex; }
        }
        /// <summary>
        /// lấy thông tin chi tiết toàn bộ danh sách tài khoản
        /// </summary>
        /// <returns></returns>
        public List<Account_Info> GetAllAccount()
        {
            SqlConnection objconn = new SqlConnection(GetConnectionString());
            try
            {
                objconn.Open();
                SqlCommand command = new SqlCommand("GetAllAccount", objconn);
                command.CommandType = CommandType.StoredProcedure;
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(ds);
                if (ds.Tables[0].Rows.Count == 0)
                    return null;
                List<Account_Info> list = new List<Account_Info>();
                foreach (DataRow row in ds.Tables[0].Rows)
                { list.Add(GenerateObject(row)); }
                return list;
            }
            catch (System.Exception ex)
            {
                Logger.Error(ex);
                throw ex;
            }
            finally
            { objconn.Close(); }
        }
        /// <summary>
        /// lấy thông tin chi tiết của một tài khoản
        /// </summary>
        /// <param name="accountId"></param>
        /// <returns></returns>
        public Account_Info GetOneAccount(string accountId)
        {
            SqlConnection objconn = new SqlConnection(GetConnectionString());
            SqlCommand command = new SqlCommand("GetAccountByID",objconn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@accountId", SqlDbType.NVarChar, 25).Value = accountId;
            
            try
            {
                objconn.Open();
                SqlDataReader ord = command.ExecuteReader();
                if (ord.HasRows)
                {
                    DataTable dt = new DataTable();
                    dt.Load(ord);
                    return GenerateObject(dt.Rows[0]);
                }
                else
                    return null;
            }
            catch (System.Exception ex)
            {
                if (Logger.IsErrorEnabled) Logger.Error(ex);
                return null;
            }
            finally
            { objconn.Close(); }
        }
        /// <summary>
        /// lấy thông tin chi tiết một tài khoản theo các tham số duy nhất
        /// </summary>
        /// <param name="branchId">mã chi nhánh của tài khoản </param>
        /// <param name="categories">mã loại sản phẩm của tài khoản </param>
        /// <param name="custId">mã khách hàng của tài khoản</param>
        /// <returns>thông tin chi tiết tài khoản</returns>
        public  Account_Info GetOneAccount(string branchId, string categories, string custId)
        {
            SqlConnection objconn = new SqlConnection(GetConnectionString());
            SqlCommand command = new SqlCommand("GetAccountBy_Branch_Cat_Cust", objconn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Branch_ID", SqlDbType.NVarChar, 25).Value = branchId;
            command.Parameters.Add("@Categories", SqlDbType.NVarChar, 25).Value = categories;
            command.Parameters.Add("@CustomerId", SqlDbType.NVarChar, 25).Value = custId;
            try
            {
                objconn.Open();
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(ds);
                if (ds.Tables[0].Rows.Count == 0 || ds.Tables[0].Rows.Count>1)
                    return null;
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
        /// lấy danh sách chi tiết nhóm tài khoản 
        /// theo tiền tố các ký tự đầu
        /// </summary>
        /// <param name="prefixAc"></param>
        /// <returns></returns>
        public List<Account_Info> GetListAccountLike(string prefixAc)
        {
            SqlConnection objconn = new SqlConnection(GetConnectionString());
            SqlCommand command = new SqlCommand("GetListAccountByGroup", objconn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Clear();
            command.Parameters.Add("@preAc", SqlDbType.NVarChar, 25).Value = prefixAc;
            try
            {
                objconn.Open();
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(ds);
                List<Account_Info> list = new List<Account_Info>();
                foreach (DataRow row in ds.Tables[0].Rows)
                { list.Add(GenerateObject(row)); }
                return list;
            }
            catch (System.Exception ex)
            {
                Logger.Error(ex);
                throw ex;
            }
            finally
            { objconn.Close(); }
        }
        /// <summary>
        /// lấy danh sách chi tiết nhóm tài khoản 
        /// theo tiền tố các ký tự đầu
        /// và mã sản phẩm
        /// </summary>
        /// <param name="prefixAc"></param>
        /// <param name="categories"></param>
        /// <returns></returns>
        public  List<Account_Info> GetListAccountLike(string prefixAc, string categories)
        {
            SqlConnection objconn = new SqlConnection(GetConnectionString());
            SqlCommand command = new SqlCommand("GetListAccountByGroupAndCat", objconn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Clear();
            command.Parameters.Add("@preAc", SqlDbType.NVarChar, 25).Value = prefixAc;
            command.Parameters.Add("@Categories", SqlDbType.NVarChar, 25).Value = categories;
            try
            {
                objconn.Open();
                SqlDataAdapter da = new SqlDataAdapter(command);
                DataSet ds = new DataSet();
                da.Fill(ds);
                List<Account_Info> list = new List<Account_Info>();
                foreach (DataRow row in ds.Tables[0].Rows)
                { list.Add(GenerateObject(row)); }
                return list;
            }
            catch (System.Exception ex)
            {
                Logger.Error(ex);
                throw ex;
            }
            finally
            { objconn.Close(); }
        }
        /// <summary>
        ///  Lấy danh sách tài khoản khách hàng đã được mở
        /// </summary>
        /// <param name="custId">Mã khách hàng</param>
        /// <returns>Danh sách tài khoản chi tiết của khách hàng</returns>
        public List<Account_Info> GetListAccountByCustId(string custId)
        {
            SqlConnection objconn = new SqlConnection(GetConnectionString());
            SqlCommand command = new SqlCommand("GetListAccountByCustomerID", objconn);
            command.Parameters.Clear();
            command.Parameters.Add("@customerId", SqlDbType.NVarChar, 25).Value = custId;
            command.CommandType = CommandType.StoredProcedure;
            try
            {
                objconn.Open();
                SqlDataAdapter da = new SqlDataAdapter(command);
                DataSet ds = new DataSet();
                da.Fill(ds);
                List<Account_Info> list = new List<Account_Info>();
                foreach (DataRow row in ds.Tables[0].Rows)
                { list.Add(GenerateObject(row)); }
                return list;
            }
            catch (System.Exception ex)
            {
                Logger.Error(ex);
                throw;
            }
            finally
            { objconn.Close(); }
        }
        /// <summary>
        /// lấy danh sách chi tiết nhóm tài khoản 
        /// theo tiền tố các ký tự đầu
        /// và mã sản phẩm của một khách hàng
        /// </summary>
        /// <param name="prefixAc">chuỗi ký tự đầu của mã tài khoản</param>
        /// <param name="categories">mã sản phẩm</param>
        /// <param name="custId">mã khách hàng</param>
        /// <returns>Danh sách tài khoản chi tiết</returns>
        public  List<Account_Info> GetListAccountLike(string prefixAc, string categories, string custId)
        {
            SqlConnection objconn = new SqlConnection(GetConnectionString());
            SqlCommand command = new SqlCommand("GetListAccountByGroupAndCatAndCust", objconn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Clear();
            command.Parameters.Add("@preAc", SqlDbType.NVarChar, 25).Value = prefixAc;
            command.Parameters.Add("@Categories", SqlDbType.NVarChar, 25).Value = categories;
            command.Parameters.Add("@Customer_ID", SqlDbType.NVarChar, 25).Value = custId;
            try
            {
                objconn.Open();
                SqlDataAdapter da = new SqlDataAdapter(command);
                DataSet ds = new DataSet();
                da.Fill(ds);
                List<Account_Info> list = new List<Account_Info>();
                foreach (DataRow row in ds.Tables[0].Rows)
                { list.Add(GenerateObject(row)); }
                return list;
            }
            catch (System.Exception ex)
            {
                Logger.Error(ex);
                throw;
            }
            finally { objconn.Close(); }
        }
        /// <summary>
        /// gán đối đượng Account_info
        /// </summary>
        /// <param name="row"></param>
        /// <returns>thông tin tài khoản chi tiết</returns>
        private static Account_Info GenerateObject(DataRow row)
        {
            if (row == null)
                throw new Exception("Data row does not null or empty");
            Account_Info objAccountInfo = new Account_Info();
            if (row["Account_ID"] != DBNull.Value)
                objAccountInfo.Account_ID = Convert.ToString(row["Account_ID"]);
            if (row["Name"] != DBNull.Value)
                objAccountInfo.Name = Convert.ToString(row["Name"]);
            if (row["Ref"] != DBNull.Value)
                objAccountInfo.Reference = Convert.ToString(row["Ref"]);
            if (row["b_Credit"] != DBNull.Value)
                objAccountInfo.b_Credit = Convert.ToDecimal(row["b_Credit"]);
            if (row["y_Credit"] != DBNull.Value)
                objAccountInfo.y_Credit = Convert.ToDecimal(row["y_Credit"]);
            if (row["y_Debit"] != DBNull.Value)
                objAccountInfo.y_Debit = Convert.ToDecimal(row["y_Debit"]);
            if (row["q_Credit"] != DBNull.Value)
                objAccountInfo.q_Credit = Convert.ToDecimal(row["q_Credit"]);
            if (row["q_Debit"] != DBNull.Value)
                objAccountInfo.q_Debit = Convert.ToDecimal(row["q_Debit"]);
            if (row["m_Credit"] != DBNull.Value)
                objAccountInfo.m_Credit = Convert.ToDecimal(row["m_Credit"]);
            if (row["m_Debit"] != DBNull.Value)
                objAccountInfo.m_Debit = Convert.ToDecimal(row["m_Debit"]);
            if (row["w_Credit"] != DBNull.Value)
                objAccountInfo.w_Credit = Convert.ToDecimal(row["w_Credit"]);
            if (row["w_Debit"] != DBNull.Value)
                objAccountInfo.w_Debit = Convert.ToDecimal(row["w_Debit"]);
            if (row["d_Credit"] != DBNull.Value)
                objAccountInfo.d_Credit = Convert.ToDecimal(row["d_Credit"]);
            if (row["d_Debit"] != DBNull.Value)
                objAccountInfo.d_Debit = Convert.ToDecimal(row["d_Debit"]);
            if (row["CreditDebit"] != DBNull.Value)
                objAccountInfo.CreditDebit =
                    (AccountType) Enum.Parse(typeof (AccountType), row["CreditDebit"].ToString());
            if (row["Ccy"] != DBNull.Value)
                objAccountInfo.Ccy = Convert.ToString(row["Ccy"]);
            if (row["Account_GL"] != DBNull.Value)
                objAccountInfo.Account_GL = Convert.ToString(row["Account_GL"]);
            if (row["Branch_ID"] != DBNull.Value)
                objAccountInfo.Branch_ID = Convert.ToString(row["Branch_ID"]);
            if (row["Customer_ID"] != DBNull.Value)
                objAccountInfo.Customer_ID = Convert.ToString(row["Customer_ID"]);
            if (row["Categories"] != DBNull.Value)
                objAccountInfo.Categories = Convert.ToString(row["Categories"]);
            if (row["Amount_Blocked"] != DBNull.Value)
                objAccountInfo.Amount_Blocked = Convert.ToDecimal(row["Amount_Blocked"]);
            if (row["ApprovedTime"] != DBNull.Value)
                objAccountInfo.ApprovedTime = Convert.ToDateTime(row["ApprovedTime"]);
            if (row["Approved"] != DBNull.Value)
                objAccountInfo.Approved = Convert.ToBoolean(row["Approved"]);
            if (row["Locked"] != DBNull.Value)
                objAccountInfo.Locked = Convert.ToBoolean(row["Locked"]);
            if (row["UNC_Rpt"] != DBNull.Value)
                objAccountInfo.UNC_Rpt = Convert.ToString(row["UNC_Rpt"]);
            if (row["Closed"] != DBNull.Value)
                objAccountInfo.Closed = Convert.ToBoolean(row["Closed"]);
            if (row["Closed_date"] != DBNull.Value)
                objAccountInfo.Closed_date = Convert.ToDateTime(row["Closed_date"]);
            if (row["Open_Date"] != DBNull.Value)
                objAccountInfo.Open_Date = Convert.ToDateTime(row["Open_Date"]);
            if (row["Last_Date"] != DBNull.Value)
                objAccountInfo.Last_Date = Convert.ToDateTime(row["Last_Date"]);
            if (row["UserCreate"] != DBNull.Value)
                objAccountInfo.UserCreate = Convert.ToString(row["UserCreate"]);
            if (row["IS_CHECKSUM"] != DBNull.Value)
                objAccountInfo.CheckSumValue = Convert.ToString(row["IS_CHECKSUM"]);

            return objAccountInfo;
        }
        /// <summary>
        /// sinh mã tài khoản mới
        /// </summary>
        /// <param name="branchId">mã chi nhánh</param>
        /// <param name="categories">mã sản phẩm</param>
        /// <param name="custId">mã khách hàng</param>
        /// <returns>mã tài khoản</returns>
        public string GenerateNewAccountId(string branchId, string categories)
        {
            // cấu trúc tài khoản
            SqlConnection objconn = new SqlConnection(GetConnectionString());
            SqlCommand command = new SqlCommand("GenerateAccountID", objconn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Branch_ID", SqlDbType.NVarChar, 25).Value = branchId;
            command.Parameters.Add("@Categories", SqlDbType.NVarChar, 25).Value = categories;

            try
            {
                objconn.Open();
                SqlDataReader ord = command.ExecuteReader();
                if (ord.HasRows)
                {
                    ord.Read();
                    return ord[0].ToString();
                }
                else
                    return String.Empty;
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                throw;
            }
            finally { objconn.Close(); }
        }
    }
}