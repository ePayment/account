using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Account.Common.Entities;

namespace Account.Data.SqlServer
{
    public partial class D_User:SqlServerHelper
    {
        public SqlCommand CreateOneUser(User_Info objuser)
        {
            SqlCommand command = new SqlCommand(@"Insert Into User_Profile(User_ID, FullName, Password, Branch_ID, IsAdministrator)
                                                    Values(@User_ID, @FullName, @Password, @Branch_ID, @IsAdministrator)");
            command.CommandType = CommandType.Text;
            command.Parameters.Clear();
            command.Parameters.Add("@User_ID", SqlDbType.NVarChar, 25).Value = objuser.User_ID;
            command.Parameters.Add("@FullName", SqlDbType.NVarChar, 135).Value = objuser.FullName;
            command.Parameters.Add("@Password", SqlDbType.NVarChar, 250).Value = objuser.Password;
            command.Parameters.Add("@Branch_ID", SqlDbType.NVarChar, 25).Value = objuser.Branch_ID;
            command.Parameters.Add("@IsAdministrator", SqlDbType.Bit).Value = objuser.IsAdministrator;
            this.AddCommand(command);
            return command;
        }
        public SqlCommand EditOneUser(User_Info objuser)
        {
            SqlCommand command = new SqlCommand("Update User_Profile Set "+
                                                "User_ID= @User_ID, "+
                                                "FullName= @FullName, "+
                                                "Password= @Password, "+
                                                "Branch_ID= @Branch_ID, "+
                                                "IsAdministrator= @IsAdministrator, " +
                                                "LastLogin = @LastTimelogin,"+
                                                "LastLogout = @LastTimeLogout "+
                                                "Where User_ID = @User_ID");
            command.CommandType = CommandType.Text;
            command.Parameters.Clear();
            command.Parameters.Add("@User_ID", SqlDbType.NVarChar, 25).Value = objuser.User_ID;
            command.Parameters.Add("@FullName", SqlDbType.NVarChar, 135).Value = objuser.FullName;
            command.Parameters.Add("@Password", SqlDbType.NVarChar, 250).Value = objuser.Password;
            command.Parameters.Add("@Branch_ID", SqlDbType.NVarChar, 25).Value = objuser.Branch_ID;
            command.Parameters.Add("@IsAdministrator", SqlDbType.Bit).Value = objuser.IsAdministrator;
            if (objuser.LastLogin == DateTime.MinValue) 
                command.Parameters.Add("@LastTimeLogin",SqlDbType.DateTime).Value = DBNull.Value;
            else
                command.Parameters.Add("@LastTimeLogin",SqlDbType.DateTime).Value = objuser.LastLogin;
            if (objuser.LastLogout == DateTime.MinValue) 
                command.Parameters.Add("@LastTimeLogout",SqlDbType.DateTime).Value = DBNull.Value;
            else
                command.Parameters.Add("@LastTimeLogout",SqlDbType.DateTime).Value = objuser.LastLogout;
            this.AddCommand(command);
            return command;
        }
        public SqlCommand RemoveOneUser(string uid)
        {
            SqlCommand command = new SqlCommand("Delete User_Profile where User_ID = @User_ID");
            command.CommandType = CommandType.Text;
            command.Parameters.Clear();
            command.Parameters.Add("@User_ID", SqlDbType.NVarChar, 25).Value = uid;
            this.AddCommand(command);
            return command;
        }
        public List<User_Info> GetAllUser()
        {
            
            SqlConnection objconn = new SqlConnection(GetConnectionString());
            SqlCommand command = new SqlCommand("Select * from User_Profile", objconn);
            command.CommandType = CommandType.Text;
            try
            {
                objconn.Open();
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(ds);
                List<User_Info> list = new List<User_Info>();
                foreach (DataRow row in ds.Tables[0].Rows)
                    list.Add(GenerateObj(row));
                return list;
            }
            catch (SqlException ex)
            {
                if (Logger.IsErrorEnabled) Logger.Error(ex);
                throw ex;
            }
            finally
            {
                objconn.Close();
            }
        }
        public User_Info GetOneUser(string uid)
        {
            
            SqlConnection objconn = new SqlConnection(GetConnectionString());
            SqlCommand command = new SqlCommand("Select * From User_Profile Where User_ID = @User_ID", objconn);
            command.CommandType = CommandType.Text;
            command.Parameters.Add("@User_ID", SqlDbType.NVarChar, 25).Value = uid;
            try
            {
                objconn.Open();
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                    return GenerateObj(ds.Tables[0].Rows[0]);
                else
                    return null;
            }
            catch (SqlException ex)
            {
                if (Logger.IsErrorEnabled) Logger.Error(ex);
                throw ex;
            }
            finally
            {
                objconn.Close();
            }
        }
        private User_Info GenerateObj(DataRow ordUser_Profile)
        {
            if (ordUser_Profile == null)
                throw new Exception("Invalid Data row");

            User_Info objUser_Profile_Info = new User_Info();
            if (ordUser_Profile["User_ID"] != DBNull.Value)
            {
                objUser_Profile_Info.User_ID = Convert.ToString(ordUser_Profile["User_ID"]);
            }
            if (ordUser_Profile["FullName"] != DBNull.Value)
            {
                objUser_Profile_Info.FullName = Convert.ToString(ordUser_Profile["FullName"]);
            }
            if (ordUser_Profile["Password"] != DBNull.Value)
            {
                objUser_Profile_Info.Password = Convert.ToString(ordUser_Profile["Password"]);
            }
            if (ordUser_Profile["Branch_ID"] != DBNull.Value)
            {
                objUser_Profile_Info.Branch_ID = Convert.ToString(ordUser_Profile["Branch_ID"]);
            }
            //if (ordUser_Profile["IsAdministrator"] != DBNull.Value)
            //{
            //    objUser_Profile_Info.IsAdministrator = Convert.ToBoolean(ordUser_Profile["IsAdministrator"]);
            //}
            if (ordUser_Profile["LastLogin"] != DBNull.Value)
            {
                objUser_Profile_Info.LastLogin = Convert.ToDateTime(ordUser_Profile["LastLogin"]);
            }
            if (ordUser_Profile["LastLogout"] != DBNull.Value)
            {
                objUser_Profile_Info.LastLogout = Convert.ToDateTime(ordUser_Profile["LastLogout"]);
            }
            return objUser_Profile_Info;
        }
    }
}