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
    public partial class frmTranDayDetail : Form
    {
        DataTable tempDB;

        public frmTranDayDetail()
        {
            InitializeComponent();
        }

        private void frmTranDayDetail_Load(object sender, EventArgs e)
        {
            txt_DocID.Text = frmTranDayList.oSelectedTranDayInfo.DocID;
            txt_TraceNum.Text = frmTranDayList.oSelectedTranDayInfo.Trace;
            txt_TransDate.Text = frmTranDayList.oSelectedTranDayInfo.TransDate.ToString();
            txt_Descript.Text = frmTranDayList.oSelectedTranDayInfo.Descript;
            txt_CreateDate.Text = frmTranDayList.oSelectedTranDayInfo.CreatedDate.ToString();
            txt_Branch.Text = frmTranDayList.oSelectedTranDayInfo.Branch_ID;
            txt_Trancode.Text = frmTranDayList.oSelectedTranDayInfo.TranCode;
            txt_LastDate.Text = frmTranDayList.oSelectedTranDayInfo.Last_Update.ToString();
            txt_NextDocID.Text = frmTranDayList.oSelectedTranDayInfo.NextDocId;
            txt_OtherRef.Text = frmTranDayList.oSelectedTranDayInfo.OtherRef;
            txt_Status.Text = frmTranDayList.oSelectedTranDayInfo.Status.ToString();
            txt_UserCreated.Text = frmTranDayList.oSelectedTranDayInfo.UserCreate;
            txt_ValueDate.Text = frmTranDayList.oSelectedTranDayInfo.ValueDate.ToString();
            txt_Verify.Text = frmTranDayList.oSelectedTranDayInfo.Verified.ToString();
            txt_VerifyUser.Text = frmTranDayList.oSelectedTranDayInfo.Verified_User;
            txt_AllowReverse.Text = frmTranDayList.oSelectedTranDayInfo.AllowReverse.ToString();
            
            Create_DataSource();
            SetDataSource();

            txt_DocID.Properties.ReadOnly = true;
            txt_TraceNum.Properties.ReadOnly = true;
            txt_TransDate.Properties.ReadOnly = true;
            txt_Descript.Properties.ReadOnly = true;
            txt_CreateDate.Properties.ReadOnly = true;
            txt_Branch.Properties.ReadOnly = true;
            txt_Trancode.Properties.ReadOnly = true;
            txt_LastDate.Properties.ReadOnly = true;
            txt_NextDocID.Properties.ReadOnly = true;
            txt_OtherRef.Properties.ReadOnly = true;
            txt_Status.Properties.ReadOnly = true;
            txt_UserCreated.Properties.ReadOnly = true;
            txt_ValueDate.Properties.ReadOnly = true;
            txt_Verify.Properties.ReadOnly = true;
            txt_VerifyUser.Properties.ReadOnly = true;
            txt_AllowReverse.Properties.ReadOnly = true;
        }
        private void frmTranDayDetail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) this.Close();
        }
        private void Create_DataSource()
        {
            tempDB = new DataTable();
            tempDB.Columns.Add("ID");
            tempDB.Columns.Add("Account_ID");
            tempDB.Columns.Add("DB_Amount");
            tempDB.Columns.Add("CR_Amount");
            tempDB.Columns.Add("Seq");
            tempDB.Columns.Add("Ccy");
            tempDB.Columns.Add("BalanceAvaiable");

            gcolID.FieldName = "ID";
            gcolSeq.FieldName = "Seq";
            gcolAccount_ID.FieldName = "Account_ID";
            gcolBalAvai.FieldName = "BalanceAvaiable";
            gcolCcy.FieldName = "Ccy";
            gcolCR_Amount.FieldName = "CR_Amount";
            gcolDB_Amount.FieldName = "DB_Amount";
        }
        private void SetDataSource()
        {
            if (frmTranDayList.oSelectedTranDayInfo.TrandayDetails.Count == 0)
            {
                tempDB.Rows.Clear();
                return;
            }
            tempDB.Rows.Clear();

            for (int i = 0; i < frmTranDayList.oSelectedTranDayInfo.TrandayDetails.Count; i++)
            {
                DataRow oRow = tempDB.NewRow();
                oRow["Account_ID"] = frmTranDayList.oSelectedTranDayInfo.TrandayDetails[i].Account_ID;
                oRow["Seq"] = frmTranDayList.oSelectedTranDayInfo.TrandayDetails[i].SEQ;
                oRow["ID"] = frmTranDayList.oSelectedTranDayInfo.TrandayDetails[i].ID;
                oRow["DB_Amount"] = frmTranDayList.oSelectedTranDayInfo.TrandayDetails[i].DB_Amount;
                oRow["CR_Amount"] = frmTranDayList.oSelectedTranDayInfo.TrandayDetails[i].CR_Amount;
                oRow["Ccy"] = frmTranDayList.oSelectedTranDayInfo.TrandayDetails[i].Ccy;
                oRow["BalanceAvaiable"] = frmTranDayList.oSelectedTranDayInfo.TrandayDetails[i].BalanceAvaiable;

                tempDB.Rows.Add(oRow);
            }
            grid_Trandaydetail.DataSource = null;
            grid_Trandaydetail.DataSource = tempDB;
        }
    }
}
