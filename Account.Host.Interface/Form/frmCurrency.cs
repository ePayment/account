using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Account.Host.Interface
{
    public partial class frmCurrency : Form
    {
        static Account.Common.Entities.Currency_Info oSelectedCcy = null;
        static Account.Common.Entities.Currency_Info oCurrency = null;
        public frmCurrency()
        {
            InitializeComponent();
        }
        private void frmCurrency_Load(object sender, EventArgs e)
        {
            Program.eButton = Program.Button.None;
            oSelectedCcy = frmCurrencyList.oSelectedCcy;
            txt_Code.Text = oSelectedCcy.Code;
            txt_Name.Text = oSelectedCcy.Name;
            txt_ISOCode.Text = oSelectedCcy.NumberCode.ToString();
            txt_Code.Enabled = false;
            txt_Name.Enabled = false;
            txt_ISOCode.Enabled = false;

        }
        private void frmCurrency_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.N) sbtnNew.PerformClick();
            else if (e.Control && e.KeyCode == Keys.E) sbtnEdit.PerformClick();
            else if (e.Control && e.KeyCode == Keys.D) sbtnDel.PerformClick();
            else if (e.Control && e.KeyCode == Keys.S) sbtnOK.PerformClick();
            else if (e.KeyCode == Keys.Escape) sbtnExit.PerformClick();
        }

        private void sbtnNew_Click(object sender, EventArgs e)
        {
            Program.eButton = Program.Button.New;
            txt_Code.Text = string.Empty;
            txt_Code.Enabled = true;
            txt_Name.Text = string.Empty;
            txt_Name.Enabled = true;
            txt_ISOCode.Text = string.Empty;
            txt_ISOCode.Enabled = true;
            txt_Code.Focus();

        }

        private void sbtnEdit_Click(object sender, EventArgs e)
        {
            Program.eButton = Program.Button.Edit;
            txt_Code.Text = oSelectedCcy.Code;
            txt_Name.Text = oSelectedCcy.Name;
            txt_ISOCode.Text = oSelectedCcy.NumberCode.ToString();
            txt_Code.Enabled = false;
            txt_Name.Enabled = true;
            txt_ISOCode.Enabled = true;
            txt_Name.Focus();
        }

        private void sbtnDel_Click(object sender, EventArgs e)
        {
            Program.eButton = Program.Button.Del;
            if (MessageBox.Show("Có chắn chắn xóa loại tiền này không?","Thông báo",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
            {
                if (Account.UIProviders.UICurrency.Delete(txt_Code.Text) == 0)
                {
                    MessageBox.Show("Xóa loại tiền tệ thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frmCurrencyList.lstCurrencyInfo.Remove(oSelectedCcy);
                    this.Close();
                }
                else
                {
                    MessageBox.Show(Account.UIProviders.UICurrency.ValidationMessage, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

        }

        private void sbtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void sbtnOK_Click(object sender, EventArgs e)
        {

            if(Program.eButton == Program.Button.New)
                oCurrency = new Account.Common.Entities.Currency_Info();
            else if (Program.eButton == Program.Button.Edit)
                oCurrency = oSelectedCcy;
            oCurrency.Code = txt_Code.Text;
            oCurrency.Name = txt_Name.Text;
            oCurrency.NumberCode = Convert.ToInt32(txt_ISOCode.Text);

            int result=-1;
            if (Program.eButton == Program.Button.New)
                result = Account.UIProviders.UICurrency.Insert(oCurrency);
            else if (Program.eButton == Program.Button.Edit)
                result = Account.UIProviders.UICurrency.Update(oCurrency);
            if (result == 0)
            {
                MessageBox.Show("Cập nhật thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txt_Code.Enabled = false;
                txt_Name.Enabled = false;
                txt_ISOCode.Enabled = false;
                if (Program.eButton == Program.Button.New)
                    frmCurrencyList.lstCurrencyInfo.Add(oCurrency);
                else if (Program.eButton == Program.Button.Edit)
                {
                    frmCurrencyList.lstCurrencyInfo.Remove(oSelectedCcy);
                    frmCurrencyList.lstCurrencyInfo.Insert(frmCurrencyList.lstCurrencyInfo.Count, oCurrency);
                }
            }
            else
            {
                MessageBox.Show(Account.UIProviders.UICurrency.ValidationMessage, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        
    }
}
