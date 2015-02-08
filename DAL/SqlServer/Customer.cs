using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Account.Common.Entities;

namespace Account.Data.SqlServer
{
    public partial class D_Customer : SqlServerHelper
    {
        /// <summary>
        /// Tạo mới hồ sơ khách hàng
        /// </summary>
        /// <param name="objCustomerInfo"></param>
        /// <returns></returns>
        public SqlCommand CreateOneCustomer(Customer_Info objCustomerInfo)
        {
            try
            {
                var command = new SqlCommand();
                command.CommandText =
                    "INSERT INTO Customer("
                    + "ID, "
                    + "Cust_Ref, "
                    + "Name, "
                    + "ShortName, "
                    + "Sector, "
                    + "Industry, "
                    + "VATCode, "
                    + "Address, "
                    + "Address1, "
                    + "Tel, "
                    + "Tel1, "
                    + "Fax, "
                    + "Handphone, "
                    + "Account_ID, "
                    + "Cust_Cert, "
                    + "Cust_Cert_Type, "
                    + "Cust_Cert_Dated, "
                    + "Cust_Cert_By, "
                    + "Cust_Type, "
                    + "FamilyName, "
                    + "Email, "
                    + "Website, "
                    + "ApprovedTime, "
                    + "Approved, "
                    + "Branch_ID, "
                    + "mngStaff, "
                    + "EAddress, "
                    + "EName, "
                    + "DateCreated, "
                    + "UserCreate, "
                    + "Last_Date "
                    + ")"
                    + "VALUES ("
                    + "@ID, "
                    + "@Cust_Ref, "
                    + "@Name, "
                    + "@ShortName, "
                    + "@Sector, "
                    + "@Industry, "
                    + "@VATCode, "
                    + "@Address, "
                    + "@Address1, "
                    + "@Tel, "
                    + "@Tel1, "
                    + "@Fax, "
                    + "@Handphone, "
                    + "@Account_ID, "
                    + "@Cust_Cert, "
                    + "@Cust_Cert_Type, "
                    + "@Cust_Cert_Dated, "
                    + "@Cust_Cert_By, "
                    + "@Cust_Type, "
                    + "@FamilyName, "
                    + "@Email, "
                    + "@Website, "
                    + "@ApprovedTime, "
                    + "@Approved, "
                    + "@Branch_ID, "
                    + "@mngStaff, "
                    + "@EAddress, "
                    + "@EName, "
                    + "@DateCreated, "
                    + "@UserCreate, "
                    + "@Last_Date "
                    + ")";
                command.CommandType = CommandType.Text;
                command.Parameters.Add("@ID", SqlDbType.NVarChar, 25).Value = objCustomerInfo.ID;
                command.Parameters.Add("@Cust_Ref", SqlDbType.NVarChar, 25).Value = objCustomerInfo.Reference;
                command.Parameters.Add("@Name", SqlDbType.NVarChar, 135).Value = objCustomerInfo.Name;
                command.Parameters.Add("@ShortName", SqlDbType.NVarChar, 135).Value = objCustomerInfo.ShortName;
                if (string.IsNullOrEmpty(objCustomerInfo.Sector))
                    command.Parameters.Add("@Sector", SqlDbType.NVarChar, 3).Value = DBNull.Value;
                else
                    command.Parameters.Add("@Sector", SqlDbType.NVarChar, 3).Value = objCustomerInfo.Sector;
                if (string.IsNullOrEmpty(objCustomerInfo.Industry))
                    command.Parameters.Add("@Industry", SqlDbType.NVarChar, 5).Value = DBNull.Value;
                else
                    command.Parameters.Add("@Industry", SqlDbType.NVarChar, 5).Value = objCustomerInfo.Industry;
                command.Parameters.Add("@VATCode", SqlDbType.NVarChar, 20).Value = objCustomerInfo.VATCode;
                command.Parameters.Add("@Address", SqlDbType.NVarChar, 135).Value = objCustomerInfo.Address;
                command.Parameters.Add("@Address1", SqlDbType.NVarChar, 135).Value = objCustomerInfo.Address1;
                command.Parameters.Add("@Tel", SqlDbType.NVarChar, 50).Value = objCustomerInfo.Tel;
                command.Parameters.Add("@Tel1", SqlDbType.NVarChar, 50).Value = objCustomerInfo.Tel1;
                command.Parameters.Add("@Fax", SqlDbType.NVarChar, 50).Value = objCustomerInfo.Fax;
                command.Parameters.Add("@Handphone", SqlDbType.NVarChar, 50).Value = objCustomerInfo.Handphone;
                command.Parameters.Add("@Account_ID", SqlDbType.NVarChar, 25).Value =
                    string.IsNullOrEmpty(objCustomerInfo.Account_ID)
                        ? (object) DBNull.Value
                        : objCustomerInfo.Account_ID;
                command.Parameters.Add("@Cust_Cert", SqlDbType.NVarChar, 255).Value = objCustomerInfo.Cust_Cert;
                command.Parameters.Add("@Cust_Cert_Type", SqlDbType.NVarChar, 35).Value = objCustomerInfo.Cust_Cert_Type;
                if (objCustomerInfo.Cust_Cert_Dated != new DateTime(0))
                    command.Parameters.Add("@Cust_Cert_Dated", SqlDbType.DateTime).Value =
                        objCustomerInfo.Cust_Cert_Dated;
                else
                    command.Parameters.Add("@Cust_Cert_Dated", SqlDbType.DateTime).Value = DBNull.Value;
                command.Parameters.Add("@Cust_Cert_By", SqlDbType.NVarChar, 35).Value = objCustomerInfo.Cust_Cert_By;
                command.Parameters.Add("@Cust_Type", SqlDbType.NVarChar, 25).Value = objCustomerInfo.Cust_Type;
                command.Parameters.Add("@FamilyName", SqlDbType.NVarChar, 25).Value = objCustomerInfo.FamilyName;
                command.Parameters.Add("@Email", SqlDbType.NVarChar, 50).Value = objCustomerInfo.Email;
                command.Parameters.Add("@Website", SqlDbType.NVarChar, 250).Value = objCustomerInfo.Website;
                if (objCustomerInfo.Approved == true)
                    command.Parameters.Add("@ApprovedTime", SqlDbType.DateTime).Value = objCustomerInfo.ApprovedTime;
                else
                    command.Parameters.Add("@ApprovedTime", SqlDbType.DateTime).Value = DBNull.Value;
                command.Parameters.Add("@Approved", SqlDbType.Bit).Value = objCustomerInfo.Approved;
                if (string.IsNullOrEmpty(objCustomerInfo.Branch_ID))
                    command.Parameters.Add("@Branch_ID", SqlDbType.NVarChar, 25).Value = DBNull.Value;
                else
                    command.Parameters.Add("@Branch_ID", SqlDbType.NVarChar, 25).Value = objCustomerInfo.Branch_ID;

                command.Parameters.Add("@mngStaff", SqlDbType.NVarChar, 135).Value = objCustomerInfo.mngStaff;
                command.Parameters.Add("@EAddress", SqlDbType.NVarChar, 135).Value = objCustomerInfo.EAddress;
                command.Parameters.Add("@EName", SqlDbType.NVarChar, 135).Value = objCustomerInfo.EName;
                command.Parameters.Add("@DateCreated", SqlDbType.DateTime).Value = objCustomerInfo.DateCreated;
                command.Parameters.Add("@Last_Date", SqlDbType.DateTime).Value = objCustomerInfo.LastUpdate;
                command.Parameters.Add("@UserCreate", SqlDbType.NVarChar, 25).Value = objCustomerInfo.UserCreate;
                this.AddCommand(command);
                return command;
            }
            catch (Exception ex)
            { Logger.Error(ex); throw; }
        }
        /// <summary>
        /// sửa hồ sơ khách hàng
        /// </summary>
        /// <param name="objCustomerInfo"></param>
        /// <returns></returns>
        public SqlCommand EditOneCustomer(Customer_Info objCustomerInfo)
        {
            try
            {
                SqlCommand command = new SqlCommand(
                    "UPDATE Customer SET "
                    + "Cust_Ref = @Cust_Ref, "
                    + "Name = @Name, "
                    + "ShortName = @ShortName, "
                    + "Sector = @Sector, "
                    + "Industry = @Industry, "
                    + "VATCode = @VATCode, "
                    + "Address = @Address, "
                    + "Address1 = @Address1, "
                    + "Tel = @Tel, "
                    + "Tel1 = @Tel1, "
                    + "Fax = @Fax, "
                    + "Handphone = @Handphone, "
                    + "Account_ID = @Account_ID, "
                    + "Cust_Cert = @Cust_Cert, "
                    + "Cust_Cert_Type = @Cust_Cert_Type, "
                    + "Cust_Cert_Dated = @Cust_Cert_Dated, "
                    + "Cust_Cert_By = @Cust_Cert_By, "
                    + "Cust_Type = @Cust_Type, "
                    + "FamilyName = @FamilyName, "
                    + "Email = @Email, "
                    + "Website = @Website, "
                    + "ApprovedTime = @ApprovedTime, "
                    + "Approved = @Approved, "
                    + "Branch_ID = @Branch_ID, "
                    + "mngStaff = @mngStaff, "
                    + "EAddress = @EAddress, "
                    + "EName = @EName, "
                    + "DateCreated = @DateCreated, "
                    + "UserCreate = @UserCreate, "
                    + "Last_Date = @Last_Date "
                    + "WHERE "
                    + "ID = @ID "
                    );
                command.CommandType = CommandType.Text;
                command.Parameters.Add("@ID", SqlDbType.NVarChar, 25).Value = objCustomerInfo.ID;
                command.Parameters.Add("@Cust_Ref", SqlDbType.NVarChar, 25).Value = objCustomerInfo.Reference;
                command.Parameters.Add("@Name", SqlDbType.NVarChar, 135).Value = objCustomerInfo.Name;
                command.Parameters.Add("@ShortName", SqlDbType.NVarChar, 135).Value = objCustomerInfo.ShortName;
                if (string.IsNullOrEmpty(objCustomerInfo.Sector))
                    command.Parameters.Add("@Sector", SqlDbType.NVarChar, 3).Value = DBNull.Value;
                else
                    command.Parameters.Add("@Sector", SqlDbType.NVarChar, 3).Value = objCustomerInfo.Sector;
                if (string.IsNullOrEmpty(objCustomerInfo.Industry))
                    command.Parameters.Add("@Industry", SqlDbType.NVarChar, 5).Value = DBNull.Value;
                else
                    command.Parameters.Add("@Industry", SqlDbType.NVarChar, 5).Value = objCustomerInfo.Industry;
                command.Parameters.Add("@VATCode", SqlDbType.NVarChar, 20).Value = objCustomerInfo.VATCode;
                command.Parameters.Add("@Address", SqlDbType.NVarChar, 135).Value = objCustomerInfo.Address;
                command.Parameters.Add("@Address1", SqlDbType.NVarChar, 135).Value = objCustomerInfo.Address1;
                command.Parameters.Add("@Tel", SqlDbType.NVarChar, 50).Value = objCustomerInfo.Tel;
                command.Parameters.Add("@Tel1", SqlDbType.NVarChar, 50).Value = objCustomerInfo.Tel1;
                command.Parameters.Add("@Fax", SqlDbType.NVarChar, 50).Value = objCustomerInfo.Fax;
                command.Parameters.Add("@Handphone", SqlDbType.NVarChar, 50).Value = objCustomerInfo.Handphone;
                command.Parameters.Add("@Account_ID", SqlDbType.NVarChar, 25).Value =
                    string.IsNullOrEmpty(objCustomerInfo.Account_ID)
                        ? (object)DBNull.Value
                        : objCustomerInfo.Account_ID;
                command.Parameters.Add("@Cust_Cert", SqlDbType.NVarChar, 255).Value = objCustomerInfo.Cust_Cert;
                command.Parameters.Add("@Cust_Cert_Type", SqlDbType.NVarChar, 35).Value = objCustomerInfo.Cust_Cert_Type;
                if (objCustomerInfo.Cust_Cert_Dated != new DateTime(0))
                    command.Parameters.Add("@Cust_Cert_Dated", SqlDbType.DateTime).Value =
                        objCustomerInfo.Cust_Cert_Dated;
                else
                    command.Parameters.Add("@Cust_Cert_Dated", SqlDbType.DateTime).Value = DBNull.Value;
                command.Parameters.Add("@Cust_Cert_By", SqlDbType.NVarChar, 35).Value = objCustomerInfo.Cust_Cert_By;
                command.Parameters.Add("@Cust_Type", SqlDbType.NVarChar, 25).Value = objCustomerInfo.Cust_Type;
                command.Parameters.Add("@FamilyName", SqlDbType.NVarChar, 25).Value = objCustomerInfo.FamilyName;
                command.Parameters.Add("@Email", SqlDbType.NVarChar, 50).Value = objCustomerInfo.Email;
                command.Parameters.Add("@Website", SqlDbType.NVarChar, 250).Value = objCustomerInfo.Website;
                if (objCustomerInfo.Approved == true)
                    command.Parameters.Add("@ApprovedTime", SqlDbType.DateTime).Value = objCustomerInfo.ApprovedTime;
                else
                    command.Parameters.Add("@ApprovedTime", SqlDbType.DateTime).Value = DBNull.Value;
                command.Parameters.Add("@Approved", SqlDbType.Bit).Value = objCustomerInfo.Approved;
                if (string.IsNullOrEmpty(objCustomerInfo.Branch_ID))
                    command.Parameters.Add("@Branch_ID", SqlDbType.NVarChar, 25).Value = DBNull.Value;
                else
                    command.Parameters.Add("@Branch_ID", SqlDbType.NVarChar, 25).Value = objCustomerInfo.Branch_ID;

                command.Parameters.Add("@mngStaff", SqlDbType.NVarChar, 135).Value = objCustomerInfo.mngStaff;
                command.Parameters.Add("@EAddress", SqlDbType.NVarChar, 135).Value = objCustomerInfo.EAddress;
                command.Parameters.Add("@EName", SqlDbType.NVarChar, 135).Value = objCustomerInfo.EName;
                command.Parameters.Add("@DateCreated", SqlDbType.DateTime).Value = objCustomerInfo.DateCreated;
                command.Parameters.Add("@Last_Date", SqlDbType.DateTime).Value = objCustomerInfo.LastUpdate;
                command.Parameters.Add("@UserCreate", SqlDbType.NVarChar, 25).Value = objCustomerInfo.UserCreate;
                this.AddCommand(command);
                return command;
            }
            catch (Exception ex)
            { Logger.Error(ex); throw; }
        }
        /// <summary>
        /// xóa hồ sơ khách hàng
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public SqlCommand RemoveOneCustomer(string id)
        {
            try
            {
                SqlCommand command = new SqlCommand("Delete Customer where ID = @ID ");
                command.CommandType = CommandType.Text;
                command.Parameters.Add("@ID", SqlDbType.NVarChar, 25).Value = id;
                this.AddCommand(command);
                return command;
            }
            catch (Exception ex)
            { Logger.Error(ex); throw ex; }
        }
        /// <summary>
        /// Lấy toàn bộ danh sách khách hàng
        /// </summary>
        /// <returns></returns>
        public List<Customer_Info> GetAllCustomer()
        {
            DataSet ds = new DataSet();
            SqlConnection objconn = new SqlConnection(GetConnectionString());
            SqlCommand command = new SqlCommand("Select * from Customer", objconn);
            command.CommandType = CommandType.Text;
            try
            {
                objconn.Open();
                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(ds);
                List<Customer_Info> list=new List<Customer_Info>();
                foreach (DataRow row in ds.Tables[0].Rows)
                    list.Add(GenerateObject(row));
                return list;
            }
            catch (System.Exception ex)
            {
                Logger.Error(ex);
                throw;
            }
            finally
            {
                objconn.Close();
            }
        }
        /// <summary>
        /// lấy thông tin chi tiết của một khách hàng
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Customer_Info GetOneCustomer(string id)
        {
            DataSet ds = new DataSet();
            SqlConnection objconn = new SqlConnection(GetConnectionString());
            SqlCommand command = new SqlCommand("Select * from Customer where ID = @ID", objconn);
            command.CommandType = CommandType.Text;
            command.Parameters.Add("@ID", SqlDbType.NVarChar, 25).Value = id;
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
                return null;
            }
            finally
            {
                objconn.Close();
            }
        }
        /// <summary>
        /// lấy mã khách hàng căn cứ theo chứng minh thư
        /// </summary>
        /// <param name="certId"></param>
        /// <returns>
        /// trả về thông tin khách hàng chi tiết
        /// hoặc null nếu không tìm thấy
        /// </returns>
        public Customer_Info GetOneCustomerByCert(string certId)
        {
            DataSet ds =new DataSet();
            SqlConnection objconn = new SqlConnection(GetConnectionString());
            SqlCommand command = new SqlCommand("Select * from Customer where Cust_Cert = @Cust_Cert", objconn);
            command.CommandType = CommandType.Text;
            command.Parameters.Add("@Cust_Cert", SqlDbType.NVarChar, 25).Value = certId;
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
                return null;
            }
            finally
            {
                objconn.Close();
            }
        }
        /// <summary>
        /// Lấy mã khách hàng theo số chứng minh
        /// </summary>
        /// <param name="certId"></param>
        /// <returns>
        /// kết quả trả về là mã khách hàng
        /// hoặc null nếu không tìm thấy
        /// </returns>
        public string GetCustomerIdByCert(string certId)
        {
            SqlConnection objconn = new SqlConnection(GetConnectionString());
            SqlCommand command = new SqlCommand("Select ID From Customer Where Cust_Cert = @Cust_Cert",objconn);
            command.CommandType = CommandType.Text;
            command.Parameters.Clear();
            command.Parameters.Add("@Cust_Cert", SqlDbType.NVarChar, 50).Value = certId;
            try
            {
                objconn.Open();
                SqlDataReader ord = command.ExecuteReader();
                ord.Read();
                if (ord.HasRows)
                { return Convert.ToString(ord[0]); }
                else
                { return null; }
            }
            catch (SqlException ex)
            {
                Logger.Error(ex);
                return null;
            }
            finally
            { objconn.Close(); }
        }
        /// <summary>
        /// Hàm gán đối tượng Customer_Info từ cơ sở dữ liệu
        /// </summary>
        /// <param name="row">Bản ghi hồ sơ khách hàng từ cơ sở dữ liệu</param>
        /// <returns>thông tin chi tiết khách hàng</returns>
        private Customer_Info GenerateObject(DataRow row)
        {
            if (row == null)
                throw new Exception("Data row does not null or empty");
            Customer_Info objCustomer_Info = new Customer_Info();
            if (row["ID"] != DBNull.Value)
            {
                objCustomer_Info.ID = Convert.ToString(row["ID"]);
            }
            if (row["Cust_Ref"] != DBNull.Value)
            {
                objCustomer_Info.Reference = Convert.ToString(row["Cust_Ref"]);
            }
            if (row["Name"] != DBNull.Value)
            {
                objCustomer_Info.Name = Convert.ToString(row["Name"]);
            }
            if (row["ShortName"] != DBNull.Value)
            {
                objCustomer_Info.ShortName = Convert.ToString(row["ShortName"]);
            }
            if (row["Sector"] != DBNull.Value)
            {
                objCustomer_Info.Sector = Convert.ToString(row["Sector"]);
            }
            if (row["Industry"] != DBNull.Value)
            {
                objCustomer_Info.Industry = Convert.ToString(row["Industry"]);
            }
            if (row["VATCode"] != DBNull.Value)
            {
                objCustomer_Info.VATCode = Convert.ToString(row["VATCode"]);
            }
            if (row["Address"] != DBNull.Value)
            {
                objCustomer_Info.Address = Convert.ToString(row["Address"]);
            }
            if (row["Address1"] != DBNull.Value)
            {
                objCustomer_Info.Address1 = Convert.ToString(row["Address1"]);
            }
            if (row["Tel"] != DBNull.Value)
            {
                objCustomer_Info.Tel = Convert.ToString(row["Tel"]);
            }
            if (row["Tel1"] != DBNull.Value)
            {
                objCustomer_Info.Tel1 = Convert.ToString(row["Tel1"]);
            }
            if (row["Fax"] != DBNull.Value)
            {
                objCustomer_Info.Fax = Convert.ToString(row["Fax"]);
            }
            if (row["Handphone"] != DBNull.Value)
            {
                objCustomer_Info.Handphone = Convert.ToString(row["Handphone"]);
            }
            if (row["Account_ID"] != DBNull.Value)
            {
                objCustomer_Info.Account_ID = Convert.ToString(row["Account_ID"]);
            }
            if (row["Cust_Cert"] != DBNull.Value)
            {
                objCustomer_Info.Cust_Cert = Convert.ToString(row["Cust_Cert"]);
            }
            if (row["Cust_Cert_Type"] != DBNull.Value)
            {
                objCustomer_Info.Cust_Cert_Type = Convert.ToString(row["Cust_Cert_Type"]);
            }
            if (row["Cust_Cert_Dated"] != DBNull.Value)
            {
                objCustomer_Info.Cust_Cert_Dated = Convert.ToDateTime(row["Cust_Cert_Dated"]);
            }
            if (row["Cust_Cert_By"] != DBNull.Value)
            {
                objCustomer_Info.Cust_Cert_By = Convert.ToString(row["Cust_Cert_By"]);
            }
            if (row["Cust_Type"] != DBNull.Value)
            {
                objCustomer_Info.Cust_Type = Convert.ToString(row["Cust_Type"]);
            }
            if (row["FamilyName"] != DBNull.Value)
            {
                objCustomer_Info.FamilyName = Convert.ToString(row["FamilyName"]);
            }
            if (row["Email"] != DBNull.Value)
            {
                objCustomer_Info.Email = Convert.ToString(row["Email"]);
            }
            if (row["Website"] != DBNull.Value)
            {
                objCustomer_Info.Website = Convert.ToString(row["Website"]);
            }
            if (row["ApprovedTime"] != DBNull.Value)
            {
                objCustomer_Info.ApprovedTime = Convert.ToDateTime(row["ApprovedTime"]);
            }
            if (row["Approved"] != DBNull.Value)
            {
                objCustomer_Info.Approved = Convert.ToBoolean(row["Approved"]);
            }
            if (row["Branch_ID"] != DBNull.Value)
            {
                objCustomer_Info.Branch_ID = Convert.ToString(row["Branch_ID"]);
            }
            if (row["mngStaff"] != DBNull.Value)
            {
                objCustomer_Info.mngStaff = Convert.ToString(row["mngStaff"]);
            }
            if (row["EAddress"] != DBNull.Value)
            {
                objCustomer_Info.EAddress = Convert.ToString(row["EAddress"]);
            }
            if (row["EName"] != DBNull.Value)
            {
                objCustomer_Info.EName = Convert.ToString(row["EName"]);
            }
            if (row["DateCreated"] != DBNull.Value)
            {
                objCustomer_Info.DateCreated = Convert.ToDateTime(row["DateCreated"]);
            }
            if (row["UserCreate"] != DBNull.Value)
            {
                objCustomer_Info.UserCreate = Convert.ToString(row["UserCreate"]);
            }
            if (row["Last_Date"] != DBNull.Value)
            {
                objCustomer_Info.LastUpdate = Convert.ToDateTime(row["Last_Date"]);
            }
            return objCustomer_Info;
        }
        /// <summary>
        /// Hàm sinh mã khách hàng tự động
        /// </summary>
        /// <returns>mã khách hàng mới</returns>
        public string GenerateNewCustomerId()
        {
            long seq;
            string cust_format;
            DataTableReader rs = GetDataTableReader("Select Value From Parameters WHERE Name = 'customer_id_max_seq'");
            if (rs.HasRows)
            {
                rs.Read();
                seq = Convert.ToInt64(rs[0]);
            }
            else
                throw new Exception("Can not find customer_id_max_seq in Parameters table");
            seq++;
            StringBuilder returnstr = new StringBuilder();
            // ký tự phân cách
            char[] sp = new char[] { '%' };
            rs = GetDataTableReader("Select Value From Parameters WHERE Name = 'customer_id_format'");
            if (rs.HasRows)
            {
                rs.Read();
                cust_format = Convert.ToString(rs[0]);
            }
            else
                throw new Exception("Can not find customer_id_format in Parameters table");

            if (string.IsNullOrEmpty(cust_format))
                return seq.ToString().PadLeft(6, '0');
            foreach (string b in cust_format.Split(sp))
            {
                if (!string.IsNullOrEmpty(b))
                {
                    switch (b.Substring(0, 1).ToLower())
                    {
                        case "#":
                            // thứ tự tăng dần
                            int temp_length = Convert.ToInt32(b.Substring(1));
                            returnstr.Append(seq.ToString().PadLeft(temp_length, '0'));
                            break;
                        case "b":
                            // mã chi nhánh
                            break;
                    }
                }
            }
            // cập nhật số thứ tự tăng khách hàng
            AddCommand("Update Parameters Set Value = '" + seq.ToString() + "' Where Name = 'customer_id_max_seq'");
            Execute();
            return returnstr.ToString();
        }
    }
}