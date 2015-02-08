using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Account.Common.Entities;

using log4net;

namespace Account.Data.SqlServer
{
    public partial class D_EndOfDay:SqlServerHelper
    {
        ILog logger;
        public D_EndOfDay()
        { logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType); }
        public List<CheckBalanceInfo> GetResultCheckBalance()
        {
            SqlConnection objconn = new SqlConnection(GetConnectionString());
            SqlCommand command = new SqlCommand("Select * from CheckAccountBalance()", objconn);
            command.CommandType = CommandType.Text;
            try
            {
                objconn.Open();
                IAsyncResult itfAsynch;
                itfAsynch = command.BeginExecuteReader();
                while (!itfAsynch.IsCompleted)
                {
                    // Waiting
                    System.Threading.Thread.Sleep(1000);
                }
                SqlDataReader ord = command.EndExecuteReader(itfAsynch);
                if (ord.HasRows)
                {
                    DataTable dt = new DataTable();
                    dt.Load(ord);
                    List<CheckBalanceInfo> list = new List<CheckBalanceInfo>();
                    foreach (DataRow row in dt.Rows)
                        list.Add(GenerateObj(row));
                    return list;
                }
                else
                { return null; }
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
        public bool RunEOD()
        {
            SqlConnection objConn = new SqlConnection(GetConnectionString());
            SqlCommand command = new SqlCommand("RunEOD", objConn);
            command.CommandType = CommandType.StoredProcedure;
            try
            {
                objConn.Open();
                IAsyncResult itfAsynch;
                itfAsynch = command.BeginExecuteNonQuery();
                while (!itfAsynch.IsCompleted)
                {
                    // Waiting
                    System.Threading.Thread.Sleep(1000);
                }
                command.EndExecuteNonQuery(itfAsynch);
                return true;
            }
            catch (SqlException ex)
                {
                    if (logger.IsErrorEnabled)
                        logger.Error(ex);
                    throw ex;
                }
            finally
            {
                objConn.Close();
            }
        }
        private CheckBalanceInfo GenerateObj(DataRow obj)
        {
            CheckBalanceInfo objCheck = new CheckBalanceInfo();
            if (obj == null)
                throw new Exception("Data row is null");
            if (obj["Account_ID"] != DBNull.Value)
                objCheck.AccountId = Convert.ToString(obj["Account_ID"]);
            if (obj["Name"] != DBNull.Value)
                objCheck.AccountName = Convert.ToString(obj["Name"]);
            if (obj["d_debit"] != DBNull.Value)
                objCheck.AccountDebit = Convert.ToDecimal(obj["d_debit"]);
            if (obj["d_credit"] != DBNull.Value)
                objCheck.AccountCredit = Convert.ToDecimal(obj["d_credit"]);
            if (obj["DB"] != DBNull.Value)
                objCheck.TranDebit = Convert.ToDecimal(obj["DB"]);
            if (obj["CR"] != DBNull.Value)
                objCheck.TranCredit = Convert.ToDecimal(obj["CR"]);
            return objCheck;
        }
    }
}