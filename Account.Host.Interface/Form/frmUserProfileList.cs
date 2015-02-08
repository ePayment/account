using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Account.Host.Interface
{
    public partial class frmUserProfileList : Form
    {
        private static frmUserProfileList m_CurrentInstance = null;
        public static frmUserProfileList CurrentInstance
        {
            get
            {
                if (m_CurrentInstance == null)
                {
                    m_CurrentInstance = new frmUserProfileList();
                }
                else if (m_CurrentInstance.IsDisposed)
                {
                    m_CurrentInstance = new frmUserProfileList();
                }
                return m_CurrentInstance;
            }
        }
        DataTable dtTemp = new DataTable();
        public static List<Account.Common.Entities.User_Info> lstUserInfo = new List<Account.Common.Entities.User_Info>();
        public static Account.Common.Entities.User_Info oSelectedUser = null;

        public frmUserProfileList()
        {
            InitializeComponent();
            m_CurrentInstance = this;
        }

        private void frmUserProfileList_Load(object sender, EventArgs e)
        {
            Program.GetAll_Branch();
            lstUserInfo = Account.UIProviders.UIUser.GetAll();
            Create_DataSource_Table();
            SetDataSource();
        }

        private void frmUserProfileList_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) sbtnExit.PerformClick();
            else if (e.KeyCode == Keys.Enter) sbtnDetail.PerformClick();
        }

        private void sbtnDetail_Click(object sender, EventArgs e)
        {
            oSelectedUser = Find_User(gridView1.GetFocusedRowCellValue(gcolUserID).ToString());
            if (oSelectedUser == null) return;
            frmUserProfile ofrm = new frmUserProfile();
            ofrm.ShowDialog();
            SetDataSource();
        }

        private void sbtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Create_DataSource_Table()
        {
            dtTemp = new DataTable();
            dtTemp.Columns.Add("User_ID");
            dtTemp.Columns.Add("FullName");
            dtTemp.Columns.Add("Password");
            dtTemp.Columns.Add("BranchID");
            dtTemp.Columns.Add("BranchName");
            dtTemp.Columns.Add("LastLogin");
            dtTemp.Columns.Add("LastLogout");

            dtTemp.Columns["LastLogin"].DataType = System.Type.GetType("System.DateTime");
            dtTemp.Columns["LastLogout"].DataType = System.Type.GetType("System.DateTime");


            gcolUserID.FieldName = "User_ID";
            gcolFullName.FieldName = "FullName";
            gcolBranchID.FieldName = "BranchID";
            gcolBranchName.FieldName = "BranchName";
            gcolLastLogin.FieldName = "LastLogin";
            gcolLastLogout.FieldName = "LastLogout";
        }

        private void SetDataSource()
        {
            if (lstUserInfo.Count == 0)
            {
                dtTemp.Rows.Clear();
                return;
            }
            dtTemp.Rows.Clear();
            Account.Common.Entities.Branches_Info oBranch = null;
            for (int i = 0; i < lstUserInfo.Count; i++)
            {
                DataRow oRow = dtTemp.NewRow();
                oRow["User_ID"] = lstUserInfo[i].User_ID;
                oRow["FullName"] = lstUserInfo[i].FullName;
                oRow["Password"] = lstUserInfo[i].Password;
                oBranch = Program.FindBranch(lstUserInfo[i].Branch_ID);
                oRow["BranchID"] = oBranch.ID;
                oRow["BranchName"] = oBranch.Name;
                oRow["LastLogin"] = lstUserInfo[i].LastLogin;
                oRow["LastLogout"] = lstUserInfo[i].LastLogout;

                dtTemp.Rows.Add(oRow);
            }

            grdCtrlAccountGL.DataSource = null;
            grdCtrlAccountGL.DataSource = dtTemp;
        }

        private Account.Common.Entities.User_Info Find_User(string UserID)
        {
            for (int i = 0; i < lstUserInfo.Count; i++)
            {
                if (lstUserInfo[i].User_ID == UserID) return lstUserInfo[i];
            }
            return null;
        }

        private void sbtnResetPass_Click(object sender, EventArgs e)
        {
            oSelectedUser = Find_User(gridView1.GetFocusedRowCellValue(gcolUserID).ToString());
            if (oSelectedUser == null) return;
            if (Program.CurrentUser.IsAdministrator == false)
            {
                MessageBox.Show("Bạn không được quyền sử dụng chức năng này", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                frmUserResetPassword ofrm = new frmUserResetPassword();
                ofrm.ShowDialog();
            }
        }
    }
}
