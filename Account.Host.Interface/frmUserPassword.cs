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
    public partial class frmUserPassword : Form
    {
        public frmUserPassword()
        {
            InitializeComponent();
        }

       
        private void frmUserPassword_Load(object sender, EventArgs e)
        {
            txt_OldPass.Text = string.Empty;
            txt_NewPass.Text = string.Empty;
            txt_ConfirmPass.Text = string.Empty;

            txt_OldPass.Focus();
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
            if (Account.UIProviders.UIUser.ChangePassword(Program.CurrentUser.User_ID, txt_OldPass.Text, txt_NewPass.Text) == 0)
            {
                MessageBox.Show("Đổi mật khẩu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show(Account.UIProviders.UIUser.ValidationMessage, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
    }
}
