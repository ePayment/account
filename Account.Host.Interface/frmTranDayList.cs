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
    public partial class frmTranDayList : Form
    {

        private static frmTranDayList m_CurrentInstance = null;
        public static frmTranDayList CurrentInstance
        {
            get
            {
                if (m_CurrentInstance == null)
                {
                    m_CurrentInstance = new frmTranDayList();
                }
                else if (m_CurrentInstance.IsDisposed)
                {
                    m_CurrentInstance = new frmTranDayList();
                }
                return m_CurrentInstance;
            }
        }

        public static List<Account.Common.Entities.Tranday_Info> lstTranDayInfo = new List<Account.Common.Entities.Tranday_Info>();
        public static Account.Common.Entities.Tranday_Info oSelectedTranDayInfo = null;
        DataTable dtTemp = new DataTable();


        public frmTranDayList()
        {
            InitializeComponent();
            m_CurrentInstance = this;
        }

        private void sbtnDetail_Click(object sender, EventArgs e)
        {

        }

        private void sbtnExit_Click(object sender, EventArgs e)
        {

        }

        private void frmTranDayList_Load(object sender, EventArgs e)
        {
            Create_DataSource_Table();
            //lstTranDayInfo = Account.UIProviders.UITranday.GetAll();
            SetDataSource();

        }

        private void frmTranDayList_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) sbtnExit.PerformClick();
            else if (e.KeyCode == Keys.Alt)
            {
                if (e.KeyCode == Keys.C) sbtnDetail.PerformClick();
            }
        }


        private void Create_DataSource_Table()
        {
            dtTemp = new DataTable();
            dtTemp.Columns.Add("DocID");
            dtTemp.Columns.Add("Trace");
            dtTemp.Columns.Add("TransDate");            
            dtTemp.Columns.Add("Branch_ID");
            dtTemp.Columns.Add("Branch_Name");
            dtTemp.Columns.Add("Status");
            dtTemp.Columns.Add("AllowReverse");
            dtTemp.Columns.Add("Verified");
            dtTemp.Columns.Add("Verified_User");

            dtTemp.Columns["Verified"].DataType = System.Type.GetType("System.Boolean");
            dtTemp.Columns["AllowReverse"].DataType = System.Type.GetType("System.Boolean");

            gcolDocID.FieldName = "DocID";
            gcolTraceNum.FieldName = "Trace";
            gcolTransDate.FieldName = "TransDate";
            gcolBranchID.FieldName = "Branch_ID";
            gcolBranchName.FieldName = "Branch_Name";
            gcolStatus.FieldName = "Status";
            gcolAllowReverse.FieldName = "AllowReverse";            
            gcolVerified.FieldName = "Verified";           
            gcolVerified_User.FieldName = "Verified_User";
        }

        private void SetDataSource()
        {
            if (lstTranDayInfo.Count == 0)
            {
                dtTemp.Rows.Clear();
                return;
            }
            dtTemp.Rows.Clear();
            Account.Common.Entities.Branches_Info oBranch = new Account.Common.Entities.Branches_Info();
            for (int i = 0; i < lstTranDayInfo.Count; i++)
            {
                DataRow oRow = dtTemp.NewRow();
                oRow["DocID"] = lstTranDayInfo[i].DocID;
                oRow["Trace"] = lstTranDayInfo[i].Trace;
                oRow["TransDate"] = lstTranDayInfo[i].TransDate;
                oBranch = Program.FindBranch(lstTranDayInfo[i].Branch_ID);
                oRow["Branch_ID"] = oBranch.ID;
                oRow["Branch_Name"] = oBranch.Name;
                oRow["Status"] = lstTranDayInfo[i].Status;
                oRow["AllowReverse"] = lstTranDayInfo[i].AllowReverse;
                oRow["Verified"] = lstTranDayInfo[i].Verified;
                oRow["Verified_User"] = lstTranDayInfo[i].Verified_User;
                dtTemp.Rows.Add(oRow);
            }
            grdCtrlTransDay.DataSource = null;
            grdCtrlTransDay.DataSource = dtTemp;
        }
    }
}
