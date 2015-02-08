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
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
            m_CurrentInstance = this;           
        }
        private string m_Conn = string.Empty;   


        protected static frmLogin m_CurrentInstance = null;
        public static frmLogin CurrentInstance
        {
            get
            {
                if ((m_CurrentInstance == null) || (m_CurrentInstance.IsDisposed == true))
                {
                    m_CurrentInstance = new frmLogin();
                }
                return m_CurrentInstance;
            }
        }

        private void sbtnOK_Click(object sender, EventArgs e)
        {
            Login();
        }

        private void sbtnESC_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Login()
        {
            if (Account.UIProviders.UIUser.Login(txt_UserName.Text,txt_Password.Text) != 0)
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu chưa đúng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_UserName.Focus();
                return;
            }
            else
            {
                Program.CurrentUser = Account.UIProviders.UIUser.GetUserByID(txt_UserName.Text.Trim());
                Program.CurrentUser.IsAdministrator = true;
                Program.ToDay = Account.UIProviders.UIWorkingDays.GetToday();
                Program.Branch = Account.UIProviders.UIBranches.GetBranchesByID(Program.CurrentUser.Branch_ID);
                Program.Currency =Account.UIProviders.UICurrency.GetCurrencyByID(Account.UIProviders.UIParameters.GetParameterByID("currency_code").Value);
                this.Close();
            }
        }

        private void frmLogin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) sbtnOK.PerformClick();
            else if (e.KeyCode == Keys.Escape) sbtnESC.PerformClick();
        }

        private void tableLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
