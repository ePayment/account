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
    public partial class frmAccountRoleList : Form
    {
        private static frmAccountRoleList m_CurrentInstance = null;
        public static frmAccountRoleList CurrentInstance
        {
            get
            {
                if (m_CurrentInstance == null)
                {
                    m_CurrentInstance = new frmAccountRoleList();
                }
                else if (m_CurrentInstance.IsDisposed)
                {
                    m_CurrentInstance = new frmAccountRoleList();
                }
                return m_CurrentInstance;
            }
        }
        DataTable dtTemp = new DataTable();
        public static List<Account.Common.Entities.AccountRoles_Info> lstAccountRolesInfo = new List<Account.Common.Entities.AccountRoles_Info>();
        public static Account.Common.Entities.AccountRoles_Info oSelectedAccountRole = null;

        public frmAccountRoleList()
        {
            InitializeComponent();
            m_CurrentInstance = this;
        }

        private void frmAccountRoleList_Load(object sender, EventArgs e)
        {
            Create_DataSource_Table();
            lstAccountRolesInfo = Account.UIProviders.UIAccount_Roles.GetAll();
            SetDataSource();
        }

        private void frmAccountRoleList_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) sbtnExit.PerformClick();
            else if (e.KeyCode == Keys.Enter) sbtnDetail.PerformClick();
        }

        private void sbtnDetail_Click(object sender, EventArgs e)
        {
            if (gridView1.FocusedRowHandle < 0) return;
            int ID = Convert.ToInt32(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gcolID).ToString());
            oSelectedAccountRole = Find_AccountRoles(ID);
            frmAccountRole ofrm = new frmAccountRole();
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
            dtTemp.Columns.Add("ID");            
            dtTemp.Columns.Add("Name");
            dtTemp.Columns.Add("Account_ID");
            dtTemp.Columns.Add("Type");
            dtTemp.Columns.Add("Operator");
            dtTemp.Columns.Add("Value");
            dtTemp.Columns.Add("Seq");
            dtTemp.Columns.Add("Active");
            dtTemp.Columns.Add("Active_Date");

            gcolID.FieldName = "ID";
            gcolName.FieldName = "Name";
            gcolAccountID.FieldName = "Account_ID";
            gcolType.FieldName = "Type";
            gcolOperator.FieldName = "Operator";
            gcolValue.FieldName = "Value";
            gcolSeq.FieldName = "Seq";
            gcolActive.FieldName = "Active";            
            gcolActiveDate.FieldName = "Active_Date";            
        }

        private void SetDataSource()
        {
            if (lstAccountRolesInfo.Count == 0)
            {
                dtTemp.Rows.Clear();
                return;
            }
            dtTemp.Rows.Clear();
            for (int i = 0; i < lstAccountRolesInfo.Count; i++)
            {
                DataRow oRow = dtTemp.NewRow();
                oRow["ID"] = lstAccountRolesInfo[i].ID;
                oRow["Name"] = lstAccountRolesInfo[i].Name;
                oRow["Account_ID"] = lstAccountRolesInfo[i].Account_ID;
                oRow["Type"] = lstAccountRolesInfo[i].Type.ToString();
                oRow["Operator"] = lstAccountRolesInfo[i].Operator.ToString();
                oRow["Value"] = lstAccountRolesInfo[i].Value;
                oRow["Seq"] = lstAccountRolesInfo[i].Seq;
                oRow["Active"] = lstAccountRolesInfo[i].Active;
                oRow["Active_Date"] = lstAccountRolesInfo[i].Active_Date;
                dtTemp.Rows.Add(oRow);
            }

            grdCtrlAccountRole.DataSource = null;
            grdCtrlAccountRole.DataSource = dtTemp;
        }

        private Account.Common.Entities.AccountRoles_Info Find_AccountRoles(int ID)
        {
            for (int i = 0; i < lstAccountRolesInfo.Count; i++)
            {
                if (lstAccountRolesInfo[i].ID == ID) return lstAccountRolesInfo[i];
            }
            return null;
        }
    }
}
