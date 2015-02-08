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
    public partial class frmTransactionFilter : Form
    {
        public frmTransactionFilter()
        {
            InitializeComponent();
        }
        private void frmTransactionFilter_Load(object sender, EventArgs e)
        {
            dt_DateFrom.DateTime = Program.ToDay.TransDate;
            dt_DateTo.DateTime = Program.ToDay.TransDate;
            sbtnOK.Enabled = false;
        }
        private void frmTransactionFilter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) sbtnOK.PerformClick();
            else if (e.KeyCode == Keys.Escape) sbtnExit.PerformClick();
        }

        private void sbtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void sbtnOK_Click(object sender, EventArgs e)
        {
            Program.lstTranday = Account.UIProviders.UITranday.GetTransactionByAccount(txt_AccountID.Text, dt_DateFrom.DateTime, dt_DateTo.DateTime);
            if (Program.lstTranday !=null)
            {
                if (frmTranDayList.CurrentInstance != null)
                {
                    frmTranDayList.CurrentInstance.Close();
                    frmTranDayList.CurrentInstance.Dispose();
                }
                frmTranDayList ofrm = frmTranDayList.CurrentInstance;
                ofrm.MdiParent = Program.m_frmMain;
                ofrm.Show();
                ofrm.WindowState = FormWindowState.Maximized;
                this.Close();
            }
            else
            {
                MessageBox.Show("Không tìm thấy giao dịch nào","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
        }

        private void txt_AccountID_EditValueChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_AccountID.Text))
                sbtnOK.Enabled=false;
            else
                sbtnOK.Enabled=true;
        }
        
    }
}
