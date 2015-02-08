using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Account.Common.Entities;

namespace Account.Data.SqlServer
{
    public partial class D_Currency : SqlServerHelper
    {
        public SqlCommand CreateOneCurrency(Currency_Info objCurrency_Info)
        {
            SqlCommand command = new SqlCommand("insert into Currency(Code, Name, NumberCode) Values(@Code, @Name, @NumberCode)");
            command.CommandType = CommandType.Text;
            command.Parameters.Add("@Code", SqlDbType.NVarChar, 3).Value = objCurrency_Info.Code;
            command.Parameters.Add("@Name", SqlDbType.NVarChar, 45).Value = objCurrency_Info.Name;
            command.Parameters.Add("@NumberCode", SqlDbType.Int).Value = objCurrency_Info.NumberCode;
            this.AddCommand(command);
            return command;
        }
        //**********************************************************************************       
        public SqlCommand EditOneCurrency(Currency_Info objCurrency_Info)
        {
            SqlCommand command = new SqlCommand("Update Currency Set Code= @Code,Name= @Name, NumberCode = @NumberCode Where Code= @Code");
            command.CommandType = CommandType.Text;
            command.Parameters.Add("@Code", SqlDbType.NVarChar, 3).Value = objCurrency_Info.Code;
            command.Parameters.Add("@Name", SqlDbType.NVarChar, 45).Value = objCurrency_Info.Name;
            command.Parameters.Add("@NumberCode", SqlDbType.Int).Value = objCurrency_Info.NumberCode;
            this.AddCommand(command);
            return command;
        }
        //******************************************************************************       
        public SqlCommand RemoveOneCurrency(string Code)
        {
            SqlCommand command = new SqlCommand("Delete Currency where Code = @Code ");
            command.CommandType = CommandType.Text;
            command.Parameters.Add("@Code", SqlDbType.NVarChar, 3).Value = Code;
            this.AddCommand(command);
            return command;    

        }
        //******************************************************************************       
        public List<Currency_Info> GetAllCurrency()
        {
            DataSet ds = new DataSet();
            SqlConnection objconn = new SqlConnection(GetConnectionString());
            SqlCommand command = new SqlCommand("Select * From Currency", objconn);
            command.CommandType = CommandType.Text;
            try
            {
                objconn.Open();
                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(ds);
                List<Currency_Info> list=new List<Currency_Info>();
                foreach (DataRow row in ds.Tables[0].Rows)
                    list.Add(GenerateObj(row));
                return list;
            }
            catch (System.Exception ex)
            {
                if (Logger.IsErrorEnabled) Logger.Error(ex);
                return null;
            }
            finally
            {
                objconn.Close();
            }
        }
        //******************************************************************************       
        public Currency_Info GetOneCurrency(string Code)
        {
            DataSet ds = new DataSet();
            SqlConnection objconn = new SqlConnection(GetConnectionString());
            SqlCommand command = new SqlCommand("Select * From Currency Where Code = @Code", objconn);
            command.CommandType = CommandType.Text;
            command.Parameters.Add("@Code", SqlDbType.NVarChar, 3).Value = Code;

            try
            {
                objconn.Open();
                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(ds);
                return GenerateObj(ds.Tables[0].Rows[0]);
            }
            catch (System.Exception ex)
            {
                if (Logger.IsErrorEnabled) Logger.Error(ex);
                return null;
            }
            finally
            {
                objconn.Close();
            }
        }

        private Currency_Info GenerateObj(DataRow ordCurrency)
        {
            if (ordCurrency == null)
                throw new Exception("Invalid data row");
            Currency_Info objCurrency_Info = new Currency_Info();
            if (ordCurrency["Code"] != DBNull.Value)
            {
                objCurrency_Info.Code = Convert.ToString(ordCurrency["Code"]);
            }
            if (ordCurrency["Name"] != DBNull.Value)
            {
                objCurrency_Info.Name = Convert.ToString(ordCurrency["Name"]);
            }
            if (ordCurrency["NumberCode"] != DBNull.Value)
            {
                objCurrency_Info.NumberCode = Convert.ToInt32(ordCurrency["NumberCode"]);
            }
            return objCurrency_Info;
        }
    }
}