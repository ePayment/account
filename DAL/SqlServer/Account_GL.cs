using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Account.Common.Entities;
using Account.Common.Utilities;

namespace Account.Data.SqlServer
{

    public partial class D_Account_GL : SqlServerHelper
    {
        public SqlCommand CreateOneAccount_GL(Account_GL_Info objAccountGlInfo)
        {
            SqlCommand command = new SqlCommand(@"INSERT INTO [Account_GL]
                                                       ([Account_ID]
                                                       ,[Name]
                                                       ,[Branch_ID]
                                                       ,[CreditDebit]
                                                       ,[Ccy])
                                                 VALUES
                                                       (@Account_ID
                                                       ,@Name
                                                       ,@Branch_ID
                                                       ,@CreditDebit
                                                       ,@Ccy)");
            command.CommandType = CommandType.Text;
            command.Parameters.Add("@Account_ID", SqlDbType.NVarChar, 25).Value = objAccountGlInfo.Account_ID;
            command.Parameters.Add("@Name", SqlDbType.NVarChar, 135).Value = objAccountGlInfo.Name;
            command.Parameters.Add("@Branch_ID", SqlDbType.NVarChar, 50).Value = objAccountGlInfo.Branch_ID;
            command.Parameters.Add("@CreditDebit", SqlDbType.NVarChar, 50).Value = objAccountGlInfo.CreditDebit;
            command.Parameters.Add("@Ccy", SqlDbType.NVarChar, 50).Value = objAccountGlInfo.Ccy;
            this.AddCommand(command);
            return command;
        }
        public SqlCommand EditOneAccount_GL(Account_GL_Info objAccountGlInfo)
        {
            SqlCommand command = new SqlCommand(@"UPDATE [Account_GL]
                                               SET [Name] = @Name
                                                  ,[Branch_ID] = @Branch_ID
                                                  ,[CreditDebit] = @CreditDebit
                                                  ,[Ccy] = @Ccy
                                             WHERE [Account_ID] = @Account_ID");
            command.CommandType = CommandType.Text;
            command.Parameters.Add("@Account_ID", SqlDbType.NVarChar, 25).Value = objAccountGlInfo.Account_ID;
            command.Parameters.Add("@Name", SqlDbType.NVarChar, 135).Value = objAccountGlInfo.Name;
            command.Parameters.Add("@Branch_ID", SqlDbType.NVarChar, 50).Value = objAccountGlInfo.Branch_ID;
            command.Parameters.Add("@CreditDebit", SqlDbType.NVarChar, 50).Value = objAccountGlInfo.CreditDebit;
            command.Parameters.Add("@Ccy", SqlDbType.NVarChar, 50).Value = objAccountGlInfo.Ccy;
            this.AddCommand(command);
            return command;
        }
        public SqlCommand RemoveOneAccount_GL(string accountId)
        {
            SqlCommand command = new SqlCommand("Delete Account_GL where Account_ID = @Account_ID");
            command.CommandType = CommandType.Text;
            command.Parameters.Add("@Account_ID", SqlDbType.NVarChar, 25).Value = accountId;
            this.AddCommand(command);
            return command;
        }
        public List<Account_GL_Info> GetAllAccount_GL()
        {
            DataSet ds = new DataSet();
            SqlConnection objconn = new SqlConnection(GetConnectionString());
            SqlCommand command = new SqlCommand("Select * from Account_GL", objconn);
            command.CommandType = CommandType.Text;
            try
            {
                objconn.Open();
                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(ds);
                List<Account_GL_Info> list = new List<Account_GL_Info>();
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
        public Account_GL_Info GetOneAccount_GL(string accountId)
        {
            DataSet ds = new DataSet();
            SqlConnection objconn = new SqlConnection(GetConnectionString());
            SqlCommand command = new SqlCommand("Select * from Account_GL Where Account_ID = @Account_ID", objconn);
            command.CommandType = CommandType.Text;
            command.Parameters.Add("@Account_ID", SqlDbType.NVarChar, 25).Value = accountId;
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
        private Account_GL_Info GenerateObj(DataRow ordAccount_GL)
        {
            if (ordAccount_GL == null)
                throw new Exception("");
            Account_GL_Info objAccountGlInfo = new Account_GL_Info();

            if (ordAccount_GL["Branch_ID"] != DBNull.Value)
            {
                objAccountGlInfo.Branch_ID = Convert.ToString(ordAccount_GL["Branch_ID"]);
            }
            if (ordAccount_GL["Account_ID"] != DBNull.Value)
            {
                objAccountGlInfo.Account_ID = Convert.ToString(ordAccount_GL["Account_ID"]);
            }
            if (ordAccount_GL["Name"] != DBNull.Value)
            {
                objAccountGlInfo.Name = Convert.ToString(ordAccount_GL["Name"]);
            }
            if (ordAccount_GL["CreditDebit"] != DBNull.Value)
            {
                objAccountGlInfo.CreditDebit = (AccountType)Enum.Parse(typeof(AccountType), ordAccount_GL["CreditDebit"].ToString());
            }
            if (ordAccount_GL["Ccy"] != DBNull.Value)
            {
                objAccountGlInfo.Ccy = Convert.ToString(ordAccount_GL["Ccy"]);
            }
            return objAccountGlInfo;
        }
    }
}