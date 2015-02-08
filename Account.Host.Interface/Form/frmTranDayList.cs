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

        public static Account.Common.Entities.Tranday_Info oSelectedTranDayInfo = null;
        DataTable dtTemp = new DataTable();

        public frmTranDayList()
        {
            InitializeComponent();
            m_CurrentInstance = this;
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
            else if (e.KeyCode == Keys.Enter) sbtnDetail.PerformClick();
        }

        private void sbtnDetail_Click(object sender, EventArgs e)
        {
            if (gridView1.FocusedRowHandle < 0) return;
            else
            {
                string DocID = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gcolDocID).ToString();
                for (int i = 0; i < Program.lstTranday.Count; i++)
                {

                    if (Program.lstTranday[i].DocID == DocID)
                    {
                        oSelectedTranDayInfo = Program.lstTranday[i];
                        frmTranDayDetail ofrm = new frmTranDayDetail();
                        ofrm.ShowDialog();
                        break;
                    }
                }
            }
        }

        private void sbtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }      

        private void Create_DataSource_Table()
        {
            dtTemp = new DataTable();
            dtTemp.Columns.Add("DocID");
            dtTemp.Columns.Add("Trace");
            dtTemp.Columns.Add("TransDate");
            //dtTemp.Columns["TransDate"].DataType = System.Type.GetType("System.DateTime");
            dtTemp.Columns.Add("Branch_ID");
            dtTemp.Columns.Add("Status");
            dtTemp.Columns.Add("AllowReverse");
            dtTemp.Columns.Add("Verified");
            dtTemp.Columns.Add("Verified_User");
            dtTemp.Columns.Add("Descript");

            //dtTemp.Columns["Verified"].DataType = System.Type.GetType("System.Boolean");
            //dtTemp.Columns["AllowReverse"].DataType = System.Type.GetType("System.Boolean");

            gcolDocID.FieldName = "DocID";
            gcolTraceNum.FieldName = "Trace";
            gcolTransDate.FieldName = "TransDate";
            gcolBranchID.FieldName = "Branch_ID";
            gcolStatus.FieldName = "Status";
            gcolAllowReverse.FieldName = "AllowReverse";            
            gcolVerified.FieldName = "Verified";           
            gcolVerified_User.FieldName = "Verified_User";
            gcolDescript.FieldName = "Descript";
        }

        private void SetDataSource()
        {
            if (Program.lstTranday.Count == 0)
            {
                dtTemp.Rows.Clear();
                return;
            }
            dtTemp.Rows.Clear();
            for (int i = 0; i < Program.lstTranday.Count; i++)
            {
                DataRow oRow = dtTemp.NewRow();
                oRow["DocID"] = Program.lstTranday[i].DocID;
                oRow["Trace"] = Program.lstTranday[i].Trace;
                oRow["TransDate"] = Program.lstTranday[i].TransDate;
                oRow["Branch_ID"] = Program.lstTranday[i].Branch_ID;
                oRow["Status"] = Program.lstTranday[i].Status;
                oRow["AllowReverse"] = Program.lstTranday[i].AllowReverse;
                oRow["Verified"] = Program.lstTranday[i].Verified;
                oRow["Verified_User"] = Program.lstTranday[i].Verified_User;
                oRow["Descript"] = Program.lstTranday[i].Descript;
                dtTemp.Rows.Add(oRow);
            }
            grdCtrlTransDay.DataSource = null;
            grdCtrlTransDay.DataSource = dtTemp;
        }
    }
}
