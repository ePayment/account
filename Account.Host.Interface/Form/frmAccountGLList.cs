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
    public partial class frmAccountGLList : Form
    {

        private static frmAccountGLList m_CurrentInstance = null;
        public static frmAccountGLList CurrentInstance
        {
            get
            {
                if (m_CurrentInstance == null)
                {
                    m_CurrentInstance = new frmAccountGLList();
                }
                else if (m_CurrentInstance.IsDisposed)
                {
                    m_CurrentInstance = new frmAccountGLList();
                }
                return m_CurrentInstance;
            }
        }
        DataTable dtTemp = new DataTable();
        public static List<Account.Common.Entities.Account_GL_Info> lstAccountGL = new List<Account.Common.Entities.Account_GL_Info>();
        public static Account.Common.Entities.Account_GL_Info oSelectedAccountGl = null;

        public frmAccountGLList()
        {
            InitializeComponent();
            m_CurrentInstance = this;
        }

        private void sbtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void sbtnDetail_Click(object sender, EventArgs e)
        {
            if (gridView1.FocusedRowHandle < 0) return;
            else
            {
                string Account_ID = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gcolAccountID).ToString();
                for (int i = 0; i < lstAccountGL.Count; i++)
                {

                    if (lstAccountGL[i].Account_ID == Account_ID)
                    {
                        oSelectedAccountGl = lstAccountGL[i];
                        frmAccountGL ofrm = new frmAccountGL();
                        ofrm.ShowDialog();
                        break;
                    }
                }
            }
        }

           

        private void frmAccountGLList_Load(object sender, EventArgs e)
        {
            Program.GetAll_Branch();
            Create_DataSource_Table();
            lstAccountGL = Account.UIProviders.UIAccount_GL.GetAll();
            SetDataSource();
        }


        private void Create_DataSource_Table()
        {
            dtTemp = new DataTable();
            dtTemp.Columns.Add("Account_ID");
            dtTemp.Columns.Add("Name");
            dtTemp.Columns.Add("Branch_ID");
            dtTemp.Columns.Add("Branch_Name");

            gcolAccountID.FieldName = "Account_ID";            
            gcolName.FieldName = "Name";
            gcolBranchID.FieldName = "Branch_ID";
            gcolBranchName.FieldName = "Branch_Name";           
        }

        private void SetDataSource()
        {
            if (lstAccountGL.Count == 0)
            {
                dtTemp.Rows.Clear();
                return;
            }
            dtTemp.Rows.Clear();
            Account.Common.Entities.Branches_Info oBranch = new Account.Common.Entities.Branches_Info();

            for (int i = 0; i < lstAccountGL.Count; i++)
            {
                DataRow oRow = dtTemp.NewRow();
                oRow["Account_ID"] = lstAccountGL[i].Account_ID;
                oRow["Name"] = lstAccountGL[i].Name;
                oBranch = Program.FindBranch(lstAccountGL[i].Branch_ID);
                oRow["Branch_ID"] = oBranch.ID;
                oRow["Branch_Name"] = oBranch.Name;               
                dtTemp.Rows.Add(oRow);
            }
            grdCtrlAccountGL.DataSource = null;
            grdCtrlAccountGL.DataSource = dtTemp;
        }

        private void frmAccountGLList_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) sbtnExit.PerformClick();
            else if (e.KeyCode == Keys.Alt)
            {
                if (e.KeyCode == Keys.C) sbtnDetail.PerformClick();
            }
        }

      
    }
}
