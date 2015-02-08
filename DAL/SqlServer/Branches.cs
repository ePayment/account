using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Account.Common.Entities;

namespace Account.Data.SqlServer
{
    public partial class D_Branches : SqlServerHelper
    {
        public SqlCommand CreateOneBranches(Branches_Info objBranches_Info)
        {
            SqlCommand command = new SqlCommand("INSERT INTO Branches(ID, Name) VALUES (@ID, @Name)");
            command.CommandType = CommandType.Text;
            command.Parameters.Add("@ID", SqlDbType.NVarChar, 25).Value = objBranches_Info.ID;
            command.Parameters.Add("@Name", SqlDbType.NVarChar, 135).Value = objBranches_Info.Name;
            this.AddCommand(command);
            return command;
        }
        //**********************************************************************************       
        public SqlCommand EditOneBranches(Branches_Info objBranches_Info)
        {
            SqlCommand command = new SqlCommand("Update Branches Set Name= @Name Where ID= @ID");
            command.CommandType = CommandType.Text;
            command.Parameters.Add("@ID", SqlDbType.NVarChar, 25).Value = objBranches_Info.ID;
            command.Parameters.Add("@Name", SqlDbType.NVarChar, 135).Value = objBranches_Info.Name;
            this.AddCommand(command);
            return command;
        }
        //******************************************************************************       
        public SqlCommand RemoveOneBranches(string ID)
        {
            SqlCommand command = new SqlCommand("Delete Branches where ID = @ID");
            command.CommandType = CommandType.Text;
            command.Parameters.Add("@ID", SqlDbType.NVarChar, 25).Value = ID;
            this.AddCommand(command);
            return command;

        }
        //******************************************************************************       
        public List<Branches_Info> GetAllBranches()
        {
            DataSet ds = new DataSet();
            SqlConnection objconn = new SqlConnection(GetConnectionString());
            SqlCommand command = new SqlCommand("SELECT ID, Name FROM Branches", objconn);
            command.CommandType = CommandType.Text;
            try
            {
                objconn.Open();
                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(ds);
                List<Branches_Info> list = new List<Branches_Info>();
                foreach (DataRow row in ds.Tables[0].Rows)
                    list.Add(GenerateObj(row));
                return list;
            }
            catch (System.Exception ex)
            {
                if (Logger.IsErrorEnabled)
                    Logger.Error(ex);
                return null;
            }
            finally
            {
                objconn.Close();
            }
        }
        //******************************************************************************       
        public Branches_Info GetOneBranches(string ID)
        {
            DataSet ds = new DataSet();
            SqlConnection objconn = new SqlConnection(GetConnectionString());
            SqlCommand command = new SqlCommand("Select * from Branches where ID = @ID", objconn);
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
            {
                objconn.Close();
            }
        }

        private Branches_Info GenerateObj(DataRow ordBranches)
        {
            if (ordBranches == null)
                throw new Exception("");
            Branches_Info objBranches_Info = new Branches_Info();
            if (ordBranches["ID"] != DBNull.Value)
            {
                objBranches_Info.ID = Convert.ToString(ordBranches["ID"]);
            }
            if (ordBranches["Name"] != DBNull.Value)
            {
                objBranches_Info.Name = Convert.ToString(ordBranches["Name"]);
            }
            return objBranches_Info;
        }
    }
}