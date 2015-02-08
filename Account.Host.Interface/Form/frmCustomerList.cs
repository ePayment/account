using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Account.Host.Interface
{
    public partial class frmCustomerList : Form
    {

        private static frmCustomerList m_CurrentInstance = null;
        public static frmCustomerList CurrentInstance
        {
            get
            {
                if (m_CurrentInstance == null)
                {
                    m_CurrentInstance = new frmCustomerList();
                }
                else if (m_CurrentInstance.IsDisposed)
                {
                    m_CurrentInstance = new frmCustomerList();
                }
                return m_CurrentInstance;
            }
        }

        public static List<Account.Common.Entities.Customer_Info> lstCustomerInfo = new List<Account.Common.Entities.Customer_Info>();
        public static Account.Common.Entities.Customer_Info oSelectedCustomerInfo = null;
        DataTable dtTemp = new DataTable();
        public frmCustomerList()
        {
            InitializeComponent();
            m_CurrentInstance = this;
        }

        private void frmCustomerList_Load(object sender, EventArgs e)
        {
            //Program.GetAll_Branch();
            Create_DataSource_Table();
            lstCustomerInfo=  Account.UIProviders.UICustomer.GetAll();
            SetDataSource();
        }     

        private void frmCustomerList_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) sbtnExit.PerformClick();
            else if (e.KeyCode == Keys.Enter) sbtnDetail.PerformClick();
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
                string ID = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gcolID).ToString();
                for (int i = 0; i < lstCustomerInfo.Count; i++)
                {
                    if (lstCustomerInfo[i].ID == ID)
                    {
                        oSelectedCustomerInfo = lstCustomerInfo[i];
                        frmCustomer ofrm = new frmCustomer();                        
                        ofrm.ShowDialog();
                        SetDataSource();
                        break;
                    }
                }
            }
        }

        private void Create_DataSource_Table()
        {
            dtTemp = new DataTable();
            dtTemp.Columns.Add("ID");
            dtTemp.Columns.Add("Cust_Ref");
            dtTemp.Columns.Add("Name");
            dtTemp.Columns.Add("VATCode");
            dtTemp.Columns.Add("Cust_Cert");                        
            dtTemp.Columns.Add("Branch_ID");
            dtTemp.Columns.Add("Branch_Name");            

            gcolID.FieldName = "ID";
            gcolCusRef.FieldName = "Cust_Ref";            
            gcolName.FieldName = "Name";
            gcolVATCode.FieldName = "VATCode";
            gcolCustCert.FieldName = "Cust_Cert";
            gcolBranchID.FieldName = "Branch_ID";
            gcolBranchName.FieldName = "Branch_Name";
            
        }

        private void SetDataSource()
        {
            if (lstCustomerInfo.Count == 0)
            {
                dtTemp.Rows.Clear();
                return;
            }
            dtTemp.Rows.Clear();
            Account.Common.Entities.Branches_Info oBranch = new Account.Common.Entities.Branches_Info();
            for (int i = 0; i < lstCustomerInfo.Count; i++)
            {
                DataRow oRow = dtTemp.NewRow();
                oRow["ID"] = lstCustomerInfo[i].ID;
                oRow["Cust_Ref"] = lstCustomerInfo[i].Reference;
                oRow["Name"] = lstCustomerInfo[i].Name;
                oRow["VATCode"] = lstCustomerInfo[i].VATCode;
                oRow["Cust_Cert"] = lstCustomerInfo[i].Cust_Cert;   
                oBranch = Program.FindBranch(lstCustomerInfo[i].Branch_ID);
                oRow["Branch_ID"] = oBranch.ID;
                oRow["Branch_Name"] = oBranch.Name;                
                dtTemp.Rows.Add(oRow);
            }
            grdCtrlAccountGL.DataSource = null;
            grdCtrlAccountGL.DataSource = dtTemp;
        }

    }
}
