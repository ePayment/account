using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Account.Common.Entities;
using Account.Common.Utilities;

namespace Account.Data.SqlServer
{
    public partial class D_Categories : SqlServerHelper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="objCategoriesInfo"></param>
        /// <returns></returns>
        public SqlCommand CreateOneCategories(Categories_Info objCategoriesInfo)
        {
            SqlCommand command = new SqlCommand(@"INSERT INTO Categories(
                                                    ID, 
                                                    Name, 
                                                    Account_GL
                                                    ) 
                                                    VALUES (
                                                    @ID, 
                                                    @Name, 
                                                    @Account_GL
                                                    )");
            command.CommandType = CommandType.Text;
            command.Parameters.Add("@ID", SqlDbType.NVarChar, 25).Value = objCategoriesInfo.ID;
            command.Parameters.Add("@Name", SqlDbType.NVarChar, 135).Value = objCategoriesInfo.Name;
            command.Parameters.Add("@Account_GL", SqlDbType.NVarChar, 25).Value = objCategoriesInfo.Account_GL.Account_ID;
            this.AddCommand(command);
            return command;
        }
        /// <summary>
        /// Sửa thông tin sản phẩm chi tiết
        /// </summary>
        /// <param name="objCategoriesInfo">thông tin sản phẩm chi tiết</param>
        /// <returns></returns>
        public SqlCommand EditOneCategories(Categories_Info objCategoriesInfo)
        {
            SqlCommand command = new SqlCommand(@"UPDATE Categories SET 
                                                    Name = @Name, 
                                                    Account_GL = @Account_GL 
                                                    WHERE ID = @ID");
            command.CommandType = CommandType.Text;
            command.Parameters.Add("@ID", SqlDbType.NVarChar, 25).Value = objCategoriesInfo.ID;
            command.Parameters.Add("@Name", SqlDbType.NVarChar, 135).Value = objCategoriesInfo.Name;
            command.Parameters.Add("@Account_GL", SqlDbType.NVarChar, 25).Value = objCategoriesInfo.Account_GL.Account_ID;
            this.AddCommand(command);
            return command;
        }
        /// <summary>
        /// Xóa bảng ghi sản phẩm
        /// </summary>
        /// <param name="id">Mã sản phẩm</param>
        /// <returns></returns>
        public SqlCommand RemoveOneCategories(string id)
        {
            SqlCommand command = new SqlCommand("Delete Categories where ID = @ID");
            command.CommandType = CommandType.Text;
            command.Parameters.Add("@ID", SqlDbType.NVarChar, 50).Value = id;
            this.AddCommand(command);
            return command;

        }
        /// <summary>
        /// Lấy toàn bộ thông tin sản phẩm
        /// </summary>
        /// <returns></returns>
        public List<Categories_Info> GetAllCategories()
        {
            SqlConnection objconn = new SqlConnection(GetConnectionString());
            SqlCommand command = new SqlCommand(@"Select a.*,b.ID AS CatID,b.Name AS CatName from Account_GL a, Categories b
                                                Where a.Account_ID = b.Account_GL
                                                Order By b.ID", objconn);
            command.CommandType = CommandType.Text;
            try
            {
                objconn.Open();
                SqlDataAdapter da = new SqlDataAdapter(command);
                DataSet ds = new DataSet();
                da.Fill(ds);
                List<Categories_Info> list = new List<Categories_Info>();
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    list.Add(GenerateObj(row));
                }
                return list;
            }
            catch (System.Exception ex)
            {
                if (Logger.IsErrorEnabled)
                    Logger.Error(ex);
                return null;
            }
            finally
            { objconn.Close(); }
        }
        /// <summary>
        /// Lấy thông tin sản phẩm chi tiết
        /// </summary>
        /// <param name="ID">Mã sản phẩm</param>
        /// <returns></returns>
        public Categories_Info GetOneCategories(string ID)
        {
            DataSet ds = new DataSet();
            SqlConnection objconn = new SqlConnection(GetConnectionString());
            SqlCommand command = new SqlCommand(@"Select a.*,b.ID AS CatID,b.Name AS CatName from Account_GL a, Categories b
                                                    Where a.Account_ID = b.Account_GL
                                                    AND b.ID = @ID", objconn);
            command.CommandType = CommandType.Text;
            command.Parameters.Add("@ID", SqlDbType.NVarChar, 25).Value = ID;
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
            { objconn.Close(); }
        }
        /// <summary>
        /// lấy mã tài khoản GL gắn với mã dịch vụ
        /// </summary>
        /// <param name="catid">mã sản phẩm</param>
        /// <returns></returns>
        private Categories_Info GenerateObj(DataRow ordCategories)
        {
            if (ordCategories == null)
                throw new Exception("Data row is empty or null");
            Categories_Info objCategoriesInfo = new Categories_Info();
            if (ordCategories["CatID"] != DBNull.Value)
            {
                objCategoriesInfo.ID = Convert.ToString(ordCategories["CatID"]);
            }
            if (ordCategories["CatName"] != DBNull.Value)
            {
                objCategoriesInfo.Name = Convert.ToString(ordCategories["CatName"]);
            }

            Account_GL_Info objAccountGlInfo = new Account_GL_Info();

            if (ordCategories["Branch_ID"] != DBNull.Value)
            {
                objAccountGlInfo.Branch_ID = Convert.ToString(ordCategories["Branch_ID"]);
            }
            if (ordCategories["Account_ID"] != DBNull.Value)
            {
                objAccountGlInfo.Account_ID = Convert.ToString(ordCategories["Account_ID"]);
            }
            if (ordCategories["Name"] != DBNull.Value)
            {
                objAccountGlInfo.Name = Convert.ToString(ordCategories["Name"]);
            }
            if (ordCategories["CreditDebit"] != DBNull.Value)
            {
                objAccountGlInfo.CreditDebit = (AccountType)Enum.Parse(typeof(AccountType), ordCategories["CreditDebit"].ToString());
            }
            if (ordCategories["Ccy"] != DBNull.Value)
            {
                objAccountGlInfo.Ccy = Convert.ToString(ordCategories["Ccy"]);
            }

            objCategoriesInfo.Account_GL = objAccountGlInfo;
            return objCategoriesInfo;
        }
    }
}