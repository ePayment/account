using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Account.Common.Entities;

namespace Account.Data.SqlServer
{
    public class D_WorkingDay:SqlServerHelper
    {
        public SqlCommand CreateOneWorkingDay(WorkingDay_Info objWorkingDays_Info)
        {
            try
            {
                SqlCommand command = new SqlCommand("Insert Into WorkingDays(TransDate, BeginOfTime, EndOfTime, IsEOD) Values(@TransDate, @BeginOfTime, @EndOfTime, @IsEOD)");
                command.CommandType = CommandType.Text;
                //command.Parameters.Add("@ID", SqlDbType.Decimal).Value = objWorkingDays_Info.ID;
                command.Parameters.Add("@TransDate", SqlDbType.DateTime).Value = objWorkingDays_Info.TransDate;
                command.Parameters.Add("@BeginOfTime", SqlDbType.DateTime).Value = objWorkingDays_Info.BeginOfTime;
                command.Parameters.Add("@EndOfTime", SqlDbType.DateTime).Value = objWorkingDays_Info.EndOfTime;
                command.Parameters.Add("@IsEOD", SqlDbType.Bit).Value = objWorkingDays_Info.IsEOD;
                this.AddCommand(command);
                return command;
            }
            catch (Exception ex)
            { Logger.Error(ex); throw ex; }
        }
        public SqlCommand EditOneWorkingDay(WorkingDay_Info objWorkingDays_Info)
        {
            try
            {
                SqlCommand command = new SqlCommand("Update WorkingDays Set TransDate=@TransDate, "
                                                    + "BeginOfTime=@BeginOfTime, EndOfTime=@EndOfTime, IsEOD=@IsEOD Where TransDate=@TransDate");
                command.CommandType = CommandType.Text;
                //command.Parameters.Add("@ID", SqlDbType.Decimal).Value = objWorkingDays_Info.ID;
                command.Parameters.Add("@TransDate", SqlDbType.DateTime).Value = objWorkingDays_Info.TransDate;
                command.Parameters.Add("@BeginOfTime", SqlDbType.DateTime).Value = objWorkingDays_Info.BeginOfTime;
                command.Parameters.Add("@EndOfTime", SqlDbType.DateTime).Value = objWorkingDays_Info.EndOfTime;
                command.Parameters.Add("@IsEOD", SqlDbType.Bit).Value = objWorkingDays_Info.IsEOD;
                this.AddCommand(command);
                return command;
            }
            catch (Exception ex)
            { Logger.Error(ex); throw ex; }
        }
        public SqlCommand RemoveOneWorkingDay(DateTime transdate)
        {
            try
            {
                SqlCommand command = new SqlCommand("Delete WorkingDays Where TransDate = @TransDate");
                command.CommandType = CommandType.Text;
                command.Parameters.Add("@TransDate", SqlDbType.DateTime).Value = transdate;
                this.AddCommand(command);
                return command;
            }
            catch (Exception ex)
            { Logger.Error(ex); throw ex; }
        }
        /// <summary>
        /// Lấy thông tin ngày làm việc bất kỳ
        /// nếu ngày làm việc mà chưa có thì trả về giá trị null
        /// </summary>
        /// <param name="transdate">
        /// ngày làm việc
        /// </param>
        /// <returns>
        /// thông tin ngày làm việc chi tiết
        /// </returns>
        public WorkingDay_Info GetOneWorkingDay(DateTime transdate)
        {
            SqlConnection objconn = new SqlConnection(GetConnectionString());
            SqlCommand command = new SqlCommand("Select * From WorkingDays Where TransDate = @TransDate", objconn);
            command.CommandType = CommandType.Text;
            command.Parameters.Add("@TransDate", SqlDbType.DateTime).Value = transdate;
            try
            {
                objconn.Open();
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(ds);
                return GenerateObject(ds.Tables[0].Rows[0]);
            }
            catch (Exception ex)
            { Logger.Error(ex); throw ex; }
            finally
            { objconn.Close(); }
        }
        public List<WorkingDay_Info> GetAllWorkingDay()
        {
            SqlConnection objconn = new SqlConnection(GetConnectionString());
            SqlCommand command = new SqlCommand("Select * From WorkingDays Order By TransDate ASC", objconn);
            command.CommandType = CommandType.Text;
            try
            {
                objconn.Open();
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(ds);
                List<WorkingDay_Info> list = new List<WorkingDay_Info>();
                foreach (DataRow row in ds.Tables[0].Rows)
                    list.Add(GenerateObject(row));
                return list;
            }
            catch (Exception ex)
            { Logger.Error(ex); throw ex; }
            finally
            { objconn.Close(); }
        }
        /// <summary>
        /// Lấy ngày thông tin làm việc hiện tại
        /// </summary>
        /// <returns>
        /// thông tin ngày làm việc chi tiết
        /// </returns>
        public WorkingDay_Info GetCurrentDay()
        {
            SqlConnection objconn = new SqlConnection(GetConnectionString());
            SqlCommand command = new SqlCommand("Select * From WorkingDays Where IsEOD = 0", objconn);
            command.CommandType = CommandType.Text;
            try
            {
                objconn.Open();
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(ds);
                return GenerateObject(ds.Tables[0].Rows[0]);
            }
            catch (Exception ex)
            { Logger.Error(ex); throw ex; }
            finally
            { objconn.Close(); }
        }
        private WorkingDay_Info GenerateObject(DataRow row)
        {
            if (row == null)
                throw new Exception("Data row does not null or empty");
            WorkingDay_Info wi = new WorkingDay_Info();
            if (row["TransDate"] != DBNull.Value)
                wi.TransDate = Convert.ToDateTime(row["TransDate"]);
            if (row["BeginOfTime"] != DBNull.Value)
                wi.BeginOfTime = Convert.ToDateTime(row["BeginOfTime"]);
            if (row["EndOfTime"] != DBNull.Value)
                wi.EndOfTime = Convert.ToDateTime(row["EndOfTime"]);
            if (row["IsEOD"] != DBNull.Value)
                wi.IsEOD = Convert.ToBoolean(row["IsEOD"]);
            return wi;
        }
    }
}