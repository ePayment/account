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
    public partial class frmUserResetPassword : Form
    {
        public frmUserResetPassword()
        {
            InitializeComponent();
        }

        private void sbtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void sbtnOK_Click(object sender, EventArgs e)
        {
            if (txt_NewPass.Text.CompareTo(txt_ConfirmPass.Text) != 0)
            {
                MessageBox.Show("Mật khẩu kiểm tra không đúng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (Account.UIProviders.UIUser.ResetPassword(frmUserProfileList.oSelectedUser.User_ID, txt_NewPass.Text) == 0)
            {
                MessageBox.Show("Cài đặt lại mật khẩu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show(Account.UIProviders.UIUser.ValidationMessage, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void frmUserResetPassword_Load(object sender, EventArgs e)
        {
            txt_NewPass.Text = string.Empty;
            txt_ConfirmPass.Text = string.Empty;
            txt_NewPass.Focus();
        }

        
    }
}
