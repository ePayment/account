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
    public partial class frmAccountBlock : Form
    {
        private bool m_Mode;
        /// <summary>
        /// Nếu Mode = true thì khóa số dư 
        /// nếu Mode = false thì bỏ khóa số dư;
        /// </summary>
        public bool Mode
        { get { return m_Mode; } set { m_Mode = value; } }
        private ErrorProvider m_Err;
        public frmAccountBlock()
        {
            InitializeComponent();
        }
        private void frmAccountBlock_Load(object sender, EventArgs e)
        {
            if (Mode == true) this.Text = "Khóa số dư tài khoản";
            else this.Text = "Bỏ khóa số dư tài khoản";
            sbtnOK.Enabled = false;
        }
        private void frmAccountBlock_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.S) sbtnOK.PerformClick();
            else if (e.KeyCode == Keys.Escape) sbtnCancel.PerformClick();
        }

        private void sbtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txt_Account_ID_LostFocus(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_Account_ID.Text))
            { return; }
            else
            {
                Account.Common.Entities.Account_Info acInfo = Account.UIProviders.UIAccount.GetAccountByID(txt_Account_ID.Text);
                if (acInfo == null)
                {
                    MessageBox.Show("Không tìm thấy mã tài khoản này", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txt_Account_ID.Text = string.Empty;
                    sbtnOK.Enabled = false;
                    txt_Account_ID.Focus();
                    return;
                }
                else
                {
                    txt_Name.Text = acInfo.Name;
                    txt_Ccy.Text = acInfo.Ccy;
                    sbtnOK.Enabled = true;
                    return;
                }
            }
        }

        private bool CheckValidData()
        {
            bool result = true;
            decimal amnt;
            m_Err = new ErrorProvider();
            // clear err
            m_Err.SetError(txt_Account_ID, string.Empty);
            m_Err.SetError(txt_Amount, string.Empty);

            if (Decimal.TryParse(txt_Amount.Text, out amnt) == false)
            {
                m_Err.SetError(txt_Amount, "Số tiền nhập không đúng");
                result = false;
            }
            
            int r_auth;
            if (Mode == true) r_auth = Account.UIProviders.UIAccount.Block_Auth(txt_Account_ID.Text, Decimal.Parse(txt_Amount.Text));
            else r_auth = Account.UIProviders.UIAccount.UnBlock_Auth(txt_Account_ID.Text, Decimal.Parse(txt_Amount.Text));
            
            if (r_auth != 0)
            {
                m_Err.SetError(txt_Account_ID, Account.UIProviders.UIAccount.ValidationMessage);
                result = false;
            }
            return result;
        }
        private void sbtnOK_Click(object sender, EventArgs e)
        {
            if (CheckValidData())
            {
                int result;
                if (Mode ==true) result = Account.UIProviders.UIAccount.Block(txt_Account_ID.Text,Convert.ToDecimal(txt_Amount.Text));
                else result = Account.UIProviders.UIAccount.UnBlock(txt_Account_ID.Text, Convert.ToDecimal(txt_Amount.Text));

                if (result != 0)
                {
                    MessageBox.Show(Account.UIProviders.UIAccount.ValidationMessage, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (Mode==true) MessageBox.Show("Khóa số dư thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else MessageBox.Show("Bỏ khóa số dư thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            { return; }
            this.Close();
        }
    }
}
