using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Account.Common.Entities;

namespace Account.Data.SqlServer
{
    public partial class D_Error:SqlServerHelper
    {
        private Error_Info GenerateObject(DataRow row)
        {
            Error_Info ei = new Error_Info();
            if (row == null)
                throw new Exception("obj invalid");
            if (row["Code"] != DBNull.Value)
                ei.Code = Convert.ToInt32(row["Code"]);
            if (row["EN"] != DBNull.Value)
                ei.EN_Message = Convert.ToString(row["EN"]);
            if (row["VN"] != DBNull.Value)
                ei.VN_Message = Convert.ToString(row["VN"]);
            if (row["ISO8583"] != DBNull.Value)
                ei.ISO8583 = Convert.ToString(row["ISO8583"]);
            return ei;
        }
        public List<Error_Info> GetAllErrors()
        {
            DataSet ds = new DataSet();
            SqlConnection objconn = new SqlConnection(GetConnectionString());

            SqlCommand command = new SqlCommand("Select * From Error_Detail", objconn);
            command.CommandType = CommandType.Text;
            try
            {
                objconn.Open();
                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(ds);
                if (ds.Tables[0].Rows.Count == 0)
                    return null;
                List<Error_Info> list = new List<Error_Info>();
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
            {
                objconn.Close();
            }
        }
        public Error_Info GetOneError(int code)
        {
            {
                DataSet ds = new DataSet();
                SqlConnection objconn = new SqlConnection(GetConnectionString());

                SqlCommand command = new SqlCommand("Select * From Error_Detail Where Code = @Code", objconn);
                command.CommandType = CommandType.Text;
                command.Parameters.Clear();
                command.Parameters.Add("@Code", SqlDbType.Int).Value = code;
                try
                {
                    objconn.Open();
                    SqlDataAdapter da = new SqlDataAdapter(command);
                    da.Fill(ds);
                    if (ds.Tables[0].Rows.Count == 0)
                        return null;
                    return GenerateObject(ds.Tables[0].Rows[0]);
                }
                catch (System.Exception ex)
                {
                    Logger.Error(ex);
                    throw ex;
                }
                finally
                {
                    objconn.Close();
                }
            }
        }
    }
}