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
    public partial class frmTranCodeList : Form
    {

        private static frmTranCodeList m_CurrentInstance = null;
        public static frmTranCodeList CurrentInstance
        {
            get
            {
                if (m_CurrentInstance == null)
                {
                    m_CurrentInstance = new frmTranCodeList();
                }
                else if (m_CurrentInstance.IsDisposed)
                {
                    m_CurrentInstance = new frmTranCodeList();
                }
                return m_CurrentInstance;
            }
        }
        DataTable dtTemp = new DataTable();
        public static List<Account.Common.Entities.Trancode_Info> lstTranCodeInfo = new List<Account.Common.Entities.Trancode_Info>();
        public static Account.Common.Entities.Trancode_Info oSelectedTranCode = null;

        public frmTranCodeList()
        {
            InitializeComponent();
        }

        private void frmTranCodeList_Load(object sender, EventArgs e)
        {
            Program.GetAll_Branch();
            Create_DataSource_Table();
            lstTranCodeInfo = Account.UIProviders.UITranCode.GetAll();
            SetDataSource();
        }

        private void frmTranCodeList_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) sbtnExit.PerformClick();
            else if (e.KeyCode == Keys.Enter) sbtnDetail.PerformClick();
        }

        private void sbtnDetail_Click(object sender, EventArgs e)
        {
            if (gridView1.FocusedRowHandle < 0) return;
            string strCode = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gcolCode).ToString();
            oSelectedTranCode = Find_TranCode(strCode);
            frmTranCode ofrm = new frmTranCode();
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
            dtTemp.Columns.Add("Code");
            dtTemp.Columns.Add("Name");
            dtTemp.Columns.Add("Categories");
            dtTemp.Columns.Add("Status");
            dtTemp.Columns.Add("NextCode");
            dtTemp.Columns.Add("CodeType");            
            dtTemp.Columns.Add("AllowReverse");
            dtTemp.Columns.Add("Descript");

            gcolCode.FieldName = "Code";
            gcolName.FieldName = "Name";
            gcolCategories.FieldName = "Categories";
            gcolStatus.FieldName = "Status";
            gcolNextCode.FieldName = "NextCode";
            gcolCodeType.FieldName = "CodeType";        
            gcolAllowReverse.FieldName = "AllowReverse";
            gcolDescript.FieldName = "Descript";
        }

        public void SetDataSource()
        {
            if (lstTranCodeInfo.Count == 0)
            {
                dtTemp.Rows.Clear();
                return;
            }
            dtTemp.Rows.Clear();
            //Account.Common.Entities.Branches_Info oBranch = null;
            for (int i = 0; i < lstTranCodeInfo.Count; i++)
            {
                DataRow oRow = dtTemp.NewRow();
                oRow["Code"] = lstTranCodeInfo[i].Code;
                oRow["Name"] = lstTranCodeInfo[i].Name;
                oRow["Categories"] = lstTranCodeInfo[i].Categories;
                oRow["Status"] = lstTranCodeInfo[i].Status;
                oRow["NextCode"] = lstTranCodeInfo[i].NextCode;
                oRow["CodeType"] = lstTranCodeInfo[i].CodeType;
                oRow["AllowReverse"] = lstTranCodeInfo[i].AllowReverse;
                oRow["Descript"] = lstTranCodeInfo[i].Descript;
               
                dtTemp.Rows.Add(oRow);
            }

            grdCtrlTranCode.DataSource = null;
            grdCtrlTranCode.DataSource = dtTemp;
            
        }

        private Account.Common.Entities.Branches_Info FindBranch(string strBranchID)
        {
            for (int i = 0; i < Program.lstBranch.Count; i++)
            {
                if (Program.lstBranch[i].ID == strBranchID)
                    return Program.lstBranch[i];
            }
            return new Account.Common.Entities.Branches_Info();
        }

        private Account.Common.Entities.Trancode_Info Find_TranCode(string strCode)
        {
            for (int i = 0; i < lstTranCodeInfo.Count; i++)
            {
                if (lstTranCodeInfo[i].Code == strCode) return lstTranCodeInfo[i];
            }
            return null;
        }

    }
}
