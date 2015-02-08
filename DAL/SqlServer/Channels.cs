using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Account.Common.Entities;

namespace Account.Data.SqlServer
{
    public partial class D_Channels:SqlServerHelper
    {
        public SqlCommand CreateOneChannel(Channel_Info objChannels_Info)
        {
            try
            {
                SqlCommand command = new SqlCommand(@"INSERT INTO Channels
                                        ([Name]
                                        ,[Descript]
                                        ,[Service_port]
                                        ,[Iso_port]
                                        ,[Listener_host]
                                        ,[Currency_Code]
                                        ,[Categories]
                                        ,[Branch_ID]
                                        ,[User_ID]
                                        ,[Trancode_AddFund]                                        
                                        ,[Trancode_Retail]
                                        ,[Trancode_Fund_Transfer]
                                        ,[Security]
                                        ,[Private_Key]
                                        ,[CreateDated]
                                        ,[Last_Date]
                                        ,[UserCreate])
                                        VALUES (@Name,
                                         @Descript,
                                         @Service_port,
                                         @Iso_port,
                                         @Listener_host,
                                         @Currency_code,
                                         @Categories,
                                         @Branch_ID,
                                         @User_ID,
                                         @Trancode_AddFund,
                                         @Trancode_Retail,
                                         @Trancode_Fund_Transfer,
                                         @Security,
                                         @Private_Key,
                                         @CreateDated,
                                         @Last_Date,
                                         @UserCreate)");
                command.CommandType = System.Data.CommandType.Text;
                command.Parameters.Clear();
                command.Parameters.Add("@Name", SqlDbType.NVarChar, 50).Value = objChannels_Info.Name;
                command.Parameters.Add("@Descript", SqlDbType.NVarChar, 250).Value = objChannels_Info.Descript;
                command.Parameters.Add("@Service_port", SqlDbType.Int).Value = objChannels_Info.Service_Port;
                command.Parameters.Add("@Iso_port", SqlDbType.Int).Value = objChannels_Info.ISO_Port;
                command.Parameters.Add("@Listener_host", SqlDbType.NVarChar, 50).Value = objChannels_Info.Listener_Host;
                command.Parameters.Add("@Currency_Code", SqlDbType.NVarChar, 3).Value = objChannels_Info.Currency_Code;
                command.Parameters.Add("@Categories", SqlDbType.NVarChar, 25).Value = objChannels_Info.Categories;
                command.Parameters.Add("@Branch_ID", SqlDbType.NVarChar, 25).Value = objChannels_Info.Branch;
                command.Parameters.Add("@User_ID", SqlDbType.NVarChar, 25).Value = objChannels_Info.UserLogin;
                command.Parameters.Add("@Trancode_Addfund", SqlDbType.NVarChar, 5).Value = objChannels_Info.AddFund_Trancode;
                command.Parameters.Add("@Trancode_Retail", SqlDbType.NVarChar, 5).Value = objChannels_Info.Retail_Trancode;
                command.Parameters.Add("@Trancode_Fund_Transfer", SqlDbType.NVarChar, 5).Value = objChannels_Info.FundTranfer_Trancode;
                command.Parameters.Add("@Security", SqlDbType.Bit).Value = objChannels_Info.Security;
                command.Parameters.Add("@Private_Key", SqlDbType.NVarChar, 4000).Value = objChannels_Info.Key;
                command.Parameters.Add("@CreateDated", SqlDbType.DateTime).Value = objChannels_Info.Create_Date;
                command.Parameters.Add("@Last_Date", SqlDbType.DateTime).Value = objChannels_Info.Last_Date;
                command.Parameters.Add("@UserCreate", SqlDbType.NVarChar, 25).Value = objChannels_Info.User_Create;
                AddCommand(command);
                return command;
            }
            catch (Exception ex)
            { throw ex; }
        }
        public SqlCommand EditOneChannel(Channel_Info objChannels_Info)
        {
            SqlCommand command = new SqlCommand(@"UPDATE [Channels]
                                                SET [Descript] = @Descript
                                                ,[Service_port] = @Service_port
                                                ,[Iso_port] = @Iso_port
                                                ,[Listener_host] = @Listener_host
                                                ,[Currency_Code] = @Currency_Code
                                                ,[Categories] = @Categories
                                                ,[Branch_ID] = @Branch_ID
                                                ,[User_ID] = @User_ID
                                                ,[Trancode_Retail] = @Trancode_Retail
                                                ,[Trancode_AddFund] = @Trancode_AddFund
                                                ,[Trancode_Fund_Transfer] = @Trancode_Fund_Transfer
                                                ,[Security] = @Security
                                                ,[Private_Key] = @Private_Key
                                                ,[CreateDated] = @CreateDated
                                                ,[Last_Date] = @Last_Date
                                                ,[UserCreate] = @UserCreate 
                                                WHERE [Name] = @Name");
            command.CommandType = CommandType.Text;
            command.Parameters.Clear();
            command.Parameters.Add("@Name", SqlDbType.NVarChar, 50).Value = objChannels_Info.Name;
            command.Parameters.Add("@Descript", SqlDbType.NVarChar, 250).Value = objChannels_Info.Descript;
            command.Parameters.Add("@Service_port", SqlDbType.Int).Value = objChannels_Info.Service_Port;
            command.Parameters.Add("@Iso_port", SqlDbType.Int).Value = objChannels_Info.ISO_Port;
            command.Parameters.Add("@Listener_host", SqlDbType.NVarChar, 50).Value = objChannels_Info.Listener_Host;
            command.Parameters.Add("@Currency_Code", SqlDbType.NVarChar, 3).Value = objChannels_Info.Currency_Code;
            command.Parameters.Add("@Categories", SqlDbType.NVarChar, 25).Value = objChannels_Info.Categories;
            command.Parameters.Add("@Branch_ID", SqlDbType.NVarChar, 25).Value = objChannels_Info.Branch;
            command.Parameters.Add("@User_ID", SqlDbType.NVarChar, 25).Value = objChannels_Info.UserLogin;
            command.Parameters.Add("@Trancode_Addfund", SqlDbType.NVarChar, 5).Value = objChannels_Info.AddFund_Trancode;
            command.Parameters.Add("@Trancode_Retail", SqlDbType.NVarChar, 5).Value = objChannels_Info.Retail_Trancode;
            command.Parameters.Add("@Trancode_Fund_Transfer", SqlDbType.NVarChar, 5).Value = objChannels_Info.FundTranfer_Trancode;
            command.Parameters.Add("@Security", SqlDbType.Bit).Value = objChannels_Info.Security;
            command.Parameters.Add("@Private_Key", SqlDbType.NText).Value = objChannels_Info.Key;
            command.Parameters.Add("@CreateDated", SqlDbType.DateTime).Value = objChannels_Info.Create_Date;
            command.Parameters.Add("@Last_Date", SqlDbType.DateTime).Value = objChannels_Info.Last_Date;
            command.Parameters.Add("@UserCreate", SqlDbType.NVarChar, 25).Value = objChannels_Info.User_Create;
            AddCommand(command);
            return command;
        }
        public SqlCommand RemoveOneChannel(string channel_name)
        {
            SqlCommand command = new SqlCommand("Delete From Channels WHERE [Name] = @Name");
            command.CommandType = CommandType.Text;
            command.Parameters.Clear();
            command.Parameters.Add("@Name", SqlDbType.NVarChar, 50).Value = channel_name;
            AddCommand(command);
            return command;
        }
        public Channel_Info GetOneChannel(string channel_name)
        {
            DataSet ds = new DataSet();
            SqlConnection objconn = new SqlConnection(GetConnectionString());
            SqlCommand command = new SqlCommand("Select * from Channels Where Name = @Name", objconn);
            command.CommandType = CommandType.Text;
            command.Parameters.Clear();
            command.Parameters.Add("@Name", SqlDbType.NVarChar, 50).Value = channel_name;
            try
            {
                objconn.Open();
                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(ds);
                return GenerateObj(ds.Tables[0].Rows[0]);
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
        public List<Channel_Info> GetAllChannels()
        {
            DataSet ds = new DataSet();
            SqlConnection objconn = new SqlConnection(GetConnectionString());
            SqlCommand command = new SqlCommand("Select * from Channels", objconn);
            command.CommandType = CommandType.Text;
            try
            {
                objconn.Open();
                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(ds);
                List<Channel_Info> list = new List<Channel_Info>();
                foreach (DataRow row in ds.Tables[0].Rows)
                    list.Add(GenerateObj(row));
                return list;
            }
            catch (SqlException ex)
            {
                Logger.Error(ex);
                throw;
            }
            finally
            {
                objconn.Close();
            }
        }
        private Channel_Info GenerateObj(DataRow row)
        {
            if (row == null)
                throw new Exception("Data row is empty or null");
            Channel_Info channel = new Channel_Info();
            if (row["ID"] != DBNull.Value)
                channel.ID = Convert.ToInt32(row["ID"]);
            if (row["Name"] != DBNull.Value)
                channel.Name = Convert.ToString(row["Name"]);
            if (row["Descript"] != DBNull.Value)
                channel.Descript = Convert.ToString(row["Descript"]);
            if (row["Service_Port"] != DBNull.Value)
                channel.Service_Port = Convert.ToInt32(row["Service_Port"]);
            if (row["Iso_Port"] != DBNull.Value)
                channel.ISO_Port = Convert.ToInt32(row["Iso_Port"]);
            if (row["Listener_Host"] != DBNull.Value)
                channel.Listener_Host = Convert.ToString(row["Listener_Host"]);
            if (row["Categories"] != DBNull.Value)
                channel.Categories = Convert.ToString(row["Categories"]);
            if (row["Currency_Code"] != DBNull.Value)
                channel.Currency_Code = Convert.ToString(row["Currency_Code"]);
            if (row["User_ID"] != DBNull.Value)
                channel.UserLogin = Convert.ToString(row["User_ID"]);
            if (row["Branch_ID"] != DBNull.Value)
                channel.Branch = Convert.ToString(row["Branch_ID"]);
            if (row["Trancode_AddFund"] != DBNull.Value)
                channel.AddFund_Trancode = Convert.ToString(row["Trancode_AddFund"]);
            if (row["Trancode_Retail"] != DBNull.Value)
                channel.Retail_Trancode = Convert.ToString(row["Trancode_Retail"]);
            if (row["Trancode_Fund_Transfer"] != DBNull.Value)
                channel.FundTranfer_Trancode = Convert.ToString(row["Trancode_Fund_Transfer"]);
            if (row["CreateDated"] != DBNull.Value)
                channel.Create_Date = Convert.ToDateTime(row["CreateDated"]);
            if (row["Last_Date"] != DBNull.Value)
                channel.Last_Date = Convert.ToDateTime(row["Last_Date"]);
            if (row["UserCreate"] != DBNull.Value)
                channel.User_Create = Convert.ToString(row["UserCreate"]);
            if (row["Security"] != DBNull.Value)
                channel.Security = Convert.ToBoolean(row["Security"]);
            if (row["Private_Key"] != DBNull.Value)
                channel.Key = Convert.ToString(row["Private_Key"]);

            return channel;
        }
    }
}