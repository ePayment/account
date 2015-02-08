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
    public partial class frmAccountList : Form
    {
        private static frmAccountList m_CurrentInstance = null;
        public static frmAccountList CurrentInstance
        {
            get
            {
                if (m_CurrentInstance == null)
                {
                    m_CurrentInstance = new frmAccountList();
                }
                else if (m_CurrentInstance.IsDisposed)
                {
                    m_CurrentInstance = new frmAccountList();
                }
                return m_CurrentInstance;
            }
        }
        DataTable dtTemp = new DataTable();
        public static List<Account.Common.Entities.Account_Info> lstAccountInfo = new List<Account.Common.Entities.Account_Info>();
        public static Account.Common.Entities.Account_Info oSelectedAccount = null;
        
        public frmAccountList()
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
                string Account_ID = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gcolID).ToString();
                for (int i = 0; i < lstAccountInfo.Count; i++)
                {
                    if (lstAccountInfo[i].Account_ID == Account_ID)
                    {
                        oSelectedAccount = lstAccountInfo[i];
                        frmAccount ofrm = new frmAccount();
                        ofrm.ShowDialog();
                        SetDataSource();
                        break;
                    }
                }
            }

        }

        private void frmAccountList_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) sbtnExit.PerformClick();
            else if (e.KeyCode == Keys.Enter) sbtnDetail.PerformClick();
        }

        private void frmAccountList_Load(object sender, EventArgs e)
        {
            Create_DataSource_Table();
            lstAccountInfo = Account.UIProviders.UIAccount.GetAll();
            SetDataSource();
        }

        private void Create_DataSource_Table()
        {
            dtTemp = new DataTable();
            dtTemp.Columns.Add("Account_ID");
            dtTemp.Columns.Add("Name");
            dtTemp.Columns.Add("Reference");
            dtTemp.Columns.Add("Customer_ID");
            dtTemp.Columns.Add("Categories");
            dtTemp.Columns.Add("BranchID");
            dtTemp.Columns.Add("Approved");
            dtTemp.Columns.Add("Locked");
            dtTemp.Columns.Add("Closed");

            gcolID.FieldName = "Account_ID";
            gcolName.FieldName = "Name";
            gcolRef.FieldName = "Reference";
            gcolCustomer.FieldName = "Customer_ID";
            gcolCategories.FieldName = "Categories";
            gcolBranchID.FieldName = "BranchID";
            gcolApproved.FieldName = "Approved";
            gcolLock.FieldName = "Locked";
            gcolClose.FieldName = "Closed";
        }

        private void SetDataSource()
        {
            if (lstAccountInfo.Count == 0)
            {
                dtTemp.Rows.Clear();
                return;
            }
            dtTemp.Rows.Clear();

            for (int i = 0; i < lstAccountInfo.Count; i++)
            {
                DataRow oRow = dtTemp.NewRow();
                oRow["Account_ID"] = lstAccountInfo[i].Account_ID;
                oRow["Name"] = lstAccountInfo[i].Name;
                oRow["Customer_ID"] = lstAccountInfo[i].Customer_ID;
                oRow["Categories"] = lstAccountInfo[i].Categories;
                oRow["BranchID"] = lstAccountInfo[i].Branch_ID;
                oRow["Approved"] = lstAccountInfo[i].Approved;
                oRow["Locked"] = lstAccountInfo[i].Locked;
                oRow["Closed"] = lstAccountInfo[i].Closed;

                dtTemp.Rows.Add(oRow);
            }
            grdCtrlAccountGL.DataSource = null;
            grdCtrlAccountGL.DataSource = dtTemp;
        }
    }
}
