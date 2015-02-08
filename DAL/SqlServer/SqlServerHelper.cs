using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using System.Configuration;


using log4net;

namespace Account.Data.SqlServer
{
    public partial class SqlServerHelper
    {
        #region "tham so su dung"
        private Queue _sqlqueue;                    // tạo hàng queue xử lý command
        private string _connstr;                    // tham số connection string
        private ILog _logger;                       // log4net
        private int _effectedRecord = 0;            // số bản ghi được cập nhật tại câu lệnh SqlCmd cuối
        private Exception _getEx;
        #endregion

        #region "Properties"
        /// <summary>
        /// thuộc tính trả về số bản ghi được cập nhật thay đổi 
        /// tại câu lệnh Sqlcmd cuối cùng
        /// </summary>
        public int LastRecordsEffected
        {
            get { return _effectedRecord; }
        }
        public ILog Logger
        { get { return _logger; } set { _logger = value; } }
        #endregion

        /// <summary>
        /// hàm thực hiện các lệnh Sql server 
        /// mà không có giá trị trả về (NonQueure)
        /// </summary>
        #region "function common"

        public Exception GetException
        { get { return _getEx; } }
        /// <summary>
        /// sử dụng tính năng Begin transaction và commit transaction
        /// Kết quả trả về giá trị true nếu thực hiện thành công
        /// và trả về giá trị false nếu gặp lỗi
        /// </summary>
        public bool Execute()
        {
            StringBuilder strb;
            SqlConnection objConn = new SqlConnection(_connstr);
            SqlCommand command = objConn.CreateCommand();
            SqlTransaction transaction = null;
            try
                {
                    objConn.Open();
                    transaction = objConn.BeginTransaction();
                    command.Transaction = transaction;
                    if (Logger.IsDebugEnabled)
                        Logger.Debug(string.Format("Begin SqlTransaction"));
                    SqlCommand tempCommand;

                    while (_sqlqueue.Count != 0)
                    {
                        tempCommand = (SqlCommand)_sqlqueue.Dequeue();
                        command.CommandText = tempCommand.CommandText;
                        command.CommandType = tempCommand.CommandType;
                        command.Parameters.Clear();
                        foreach (SqlParameter par in tempCommand.Parameters)
                        { command.Parameters.Add(par.ParameterName,par.SqlDbType,par.Size).Value=par.Value; }
                        if (Logger.IsDebugEnabled)
                        {
                            strb = new StringBuilder(command.CommandText + "\n");
                            foreach (SqlParameter par in command.Parameters)
                            {strb.AppendFormat("{0}={1};", par.ParameterName, par.Value);}
                            Logger.Debug(strb.ToString());
                        }
                        
                        _effectedRecord = command.ExecuteNonQuery();

                        if (Logger.IsDebugEnabled)
                            Logger.Debug(string.Format("{0} records effected", _effectedRecord));
                    }
                    transaction.Commit();
                    if (Logger.IsDebugEnabled)
                        Logger.Debug(string.Format("Commit SqlTransaction"));
                    return true;
                }
            catch (SqlException ex1)
            {
                Logger.Error(ex1);
                Logger.Error(string.Format("Rollback SqlTransaction"));
                _getEx = ex1;
                transaction.Rollback();
                return false;
            }
        finally
        { objConn.Close(); }

        }
        /// <summary>
        /// khởi tạo các tham số kết từ tệp cấu hình
        /// </summary>
        public SqlServerHelper()
        {
            try
            {
                _logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
                _sqlqueue = new Queue();
                //ConfigurationManager.ConnectionStrings["sitesqlserver"].ConnectionString;
                _connstr = System.Configuration.ConfigurationSettings.AppSettings["sitesqlserver"].ToString();
                if (string.IsNullOrEmpty(_connstr))
                    throw new Exception("Can not find connection string for SqlServer");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// lấy tham số kết nối Sql server qua biến
        /// </summary>
        /// <param name="connectionstring"></param>
        public SqlServerHelper(string connectionstring)
        {
            _logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            _sqlqueue = new Queue();
            _connstr = connectionstring;
        }

        /// <summary>
        ///  hàm trả về giá trị chuỗi tham số kết nối SQL;
        /// </summary>
        /// <returns>xâu kết nối</returns>
        protected string GetConnectionString()
        {
            if (!string.IsNullOrEmpty(_connstr))
            { return _connstr; }
            else  { return null; }
        }
        /// <summary>
        /// hàm thêm mới các câu lệnh SqlCommand vào hàng đợi để thực thi
        /// </summary>
        /// <param name="sqlcmd">SqlCommand</param>
        public void AddCommand(SqlCommand sqlcmd)
        {
            _sqlqueue.Enqueue(sqlcmd);
        }
        /// <summary>
        /// hàm thêm mới đối tượng câu lệnh SqlCommand vào hàng đợi để thực thi
        /// </summary>
        /// <param name="sqlcmd">đối tượng object</param>
        public void AddCommand(object sqlcmd)
        {
            _sqlqueue.Enqueue((SqlCommand)sqlcmd);
        }
        /// <summary>
        /// hàm thêm mới chuỗi ký tự T-SQL vào hàng đợi để thực thi
        /// </summary>
        /// <param name="sqlcmd"></param>
        public  void AddCommand(string cmdtxt)
        {
            SqlCommand command = new SqlCommand(cmdtxt);
            _sqlqueue.Enqueue(command);
        }
        /// <summary>
        /// Hàm hủy các lệnh SqlCommand
        /// </summary>
        public void ClearCommand()
        {
            _sqlqueue.Clear();
        }
        #endregion

        #region "Danh sach ham lay DL"
        /// <summary>
        /// Các hàm lấy dữ liệu chỉ đọc từ câu lệnh sql string
        /// </summary>
        /// <param name="cmdstr">chuỗi ký tự lênh SQL</param>
        /// <returns>Trả về DataTable chỉ đọc</returns>
        public DataTableReader GetDataTableReader(string cmdstr)
        {
            if (Logger.IsDebugEnabled)
                Logger.Debug(string.Format("{0}", cmdstr));

            DataSet ds = new DataSet();
            SqlConnection objconn = new SqlConnection(GetConnectionString());
            SqlCommand cmd = new SqlCommand(cmdstr, objconn);
            cmd.CommandType = CommandType.Text;
            try
            {
                objconn.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
            }
            catch (SqlException ex)
            {
                Logger.Error(ex);
                _getEx = ex;
            }
            finally
            {
                objconn.Close();
            }
            // lấy dữ liệu chỉ đọc và chuyển tiếp
            if (ds.Tables.Count != 0)
            { return ds.Tables[0].CreateDataReader(); }
            else
            { return null; }
            
        }
        /// <summary>
        /// Lấy giá trị là DataTable chỉ đọc
        /// </summary>
        /// <param name="cmdstr">chuỗi ký tự câu lệnh SQL</param>
        /// <param name="recordcount">biến số trả về số bản ghi đọc được</param>
        /// <returns></returns>
        public DataTableReader GetDataTableReader(string cmdstr, out int recordcount)
        {
            if (Logger.IsDebugEnabled)
                Logger.Debug(string.Format("{0}", cmdstr));
            recordcount = 0;
            DataSet ds = new DataSet();
            SqlConnection objconn = new SqlConnection(GetConnectionString());

            SqlCommand cmd = new SqlCommand(cmdstr, objconn);
            cmd.CommandType = CommandType.Text;
            try
            {
                objconn.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                recordcount= da.Fill(ds);
            }
            catch (SqlException ex)
            {
                Logger.Error(ex);
                _getEx = ex;
            }
            finally
            {
                objconn.Close();
            }
            // lấy dữ liệu chỉ đọc và chuyển tiếp
            if (ds.Tables.Count != 0)
            { return ds.Tables[0].CreateDataReader(); }
            else
            { return null; }

        }
        /// <summary>
        /// Lấy dữ liệu Table
        /// </summary>
        /// <param name="cmdstr">câu lệnh SQL</param>
        /// <returns>Trả về một hay nhiều Table tùy theo câu lệnh SQL gọi</returns>
        public DataTable GetDataTable(string cmdstr)
        {
            if (Logger.IsDebugEnabled)
                Logger.Debug(string.Format("{0}", cmdstr));
            DataSet ds = new DataSet();
            SqlConnection objconn = new SqlConnection(GetConnectionString());

            SqlCommand cmd = new SqlCommand(cmdstr, objconn);
            cmd.CommandType = CommandType.Text;
            try
            {
                objconn.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
            }
            catch (SqlException ex)
            {
                Logger.Error(ex);
                _getEx = ex;
            }
            finally
            {
                objconn.Close();
            }

            // lấy dữ liệu chỉ đọc và chuyển tiếp
            return ds.Tables[0];
        
        }
        /// <summary>
        /// Lấy dữ liệu DataSet
        /// </summary>
        /// <param name="cmdstr">Câu lệnh SQL</param>
        /// <returns>Trả về DataSet</returns>
        public DataSet GetDataSet(string cmdstr)
        {
            if (Logger.IsDebugEnabled)
                Logger.Debug(string.Format("{0}", cmdstr));
            DataSet ds = new DataSet();
            SqlConnection objconn = new SqlConnection(GetConnectionString());

            SqlCommand cmd = new SqlCommand(cmdstr, objconn);
            cmd.CommandType = CommandType.Text;
            try
            {
                objconn.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
            }
            catch (SqlException ex)
            {
                Logger.Error(ex);
                _getEx = ex;
            }
            finally
            {
                objconn.Close();
            }

            // trả về dữ liệu
            return ds;
        }
        /// <summary>
        /// Kiểm tra dữ liệu bản ghi đã có hay chưa
        /// </summary>
        /// <param name="tblname">Tên bảng cần kiểm tra</param>
        /// <param name="colname">Tên trường (cột) cần kiểm tra</param>
        /// <param name="colvalue">Giá trị của trường cần kiểm tra</param>
        /// <param name="fieldtype">Loại dữ liệu của trường</param>
        /// <param name="fieldlength">Độ dài của loại dữ liệu trường</param>
        /// <returns>Trả về số đếm dữ liệu</returns>
        public int RecordExist(string tblname, string colname, object colvalue, SqlDbType fieldtype, int fieldlength)
        {
            int result = 0;
            SqlConnection objconn = new SqlConnection(GetConnectionString());
            SqlCommand command = new SqlCommand("Select Count(*) from " + tblname +
                                                " Where " + colname + " = @" + colname, objconn);
            command.CommandType = CommandType.Text;
            switch (fieldtype)
            {
                case SqlDbType.NVarChar:
                    command.Parameters.Add("@" + colname, fieldtype, fieldlength).Value = (string)colvalue;
                    break;
                case SqlDbType.VarChar:
                    command.Parameters.Add("@" + colname, fieldtype, fieldlength).Value = (string)colvalue;
                    break;
                case SqlDbType.DateTime:
                    command.Parameters.Add("@" + colname, fieldtype).Value = (DateTime)colvalue;
                    break;
                case SqlDbType.Bit:
                    command.Parameters.Add("@" + colname, fieldtype).Value = (bool)colvalue;
                    break;
                case SqlDbType.Decimal:
                    command.Parameters.Add("@" + colname, fieldtype).Value = (decimal)colvalue;
                    break;
                case SqlDbType.Float:
                    command.Parameters.Add("@" + colname, fieldtype).Value = (float)colvalue;
                    break;
                case SqlDbType.Money:
                    command.Parameters.Add("@" + colname, fieldtype).Value = (double)colvalue;
                    break;
                case SqlDbType.NChar:
                    command.Parameters.Add("@" + colname, fieldtype, fieldlength).Value = (string)colvalue;
                    break;
                case SqlDbType.Char:
                    command.Parameters.Add("@" + colname, fieldtype, fieldlength).Value = (string)colvalue;
                    break;
                case SqlDbType.Text:
                    command.Parameters.Add("@" + colname, fieldtype, fieldlength).Value = (string)colvalue;
                    break;
            }
            
            try
            {
                objconn.Open();
                SqlDataReader ordBranches = command.ExecuteReader(); //OjectRecordDatareader
                ordBranches.Read();
                if (ordBranches.HasRows)
                {
                    if (ordBranches[0] != DBNull.Value)
                    {
                        result = Convert.ToInt32(ordBranches[0]);
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                _getEx = ex;
            }
            finally
            {
                objconn.Close();
            }
            return result;
        }

        #endregion
    }
}