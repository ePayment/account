using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Account.Host.Interface
{
    public partial class frmAccountOpen : Form
    {
        private static ErrorProvider m_Err_Provider;
        private static frmAccountOpen m_CurrentInstance = null;
        public static frmAccountOpen CurrentInstance
        {
            get
            {
                if (m_CurrentInstance == null)
                    m_CurrentInstance = new frmAccountOpen();
                else if (m_CurrentInstance.IsDisposed)
                    m_CurrentInstance = new frmAccountOpen();
                return m_CurrentInstance;
            }
        }
        public frmAccountOpen()
        {
            InitializeComponent();
        }

        private void sbtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void sbtnOK_Click(object sender, EventArgs e)
        {
            if (CheckValidData())
            {
                Account.Common.Entities.Account_Info acInfo = new Account.Common.Entities.Account_Info();
                acInfo.Account_ID = Account.UIProviders.UIAccount.GenerateId(lookUEdit_Branch.Text, lookUEdit_Categories.Text, txt_CustomerId.Text);
                if (!string.IsNullOrEmpty(txt_Ref.Text))
                    acInfo.Reference = txt_Ref.Text;
                acInfo.Name = txt_Name.Text;
                acInfo.Branch_ID = lookUEdit_Branch.Text;
                acInfo.Categories = lookUEdit_Categories.Text;
                acInfo.Customer_ID = txt_CustomerId.Text;
                acInfo.CreditDebit = (Account.Common.Utilities.AccountType)Enum.Parse(typeof(Account.Common.Utilities.AccountType), txt_CreditDebit.Text);
                acInfo.Ccy = txt_Ccy.Text;
                acInfo.Account_GL = txt_AccountGL.Text;
                acInfo.Approved = false;
                acInfo.Closed = false;
                acInfo.Locked = false;
                acInfo.Open_Date = DateTime.Now;
                acInfo.Last_Date = DateTime.Now;
                acInfo.UserCreate = Program.CurrentUser.User_ID;
                if (Account.UIProviders.UIAccount.Insert(acInfo) != 0)
                {
                    MessageBox.Show(Account.UIProviders.UIAccount.ValidationMessage, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    MessageBox.Show("Mở tài khoản: " + acInfo.Account_ID +" thành công\nBước tiếp theo bạn cần duyệt tài khoản", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                    this.Dispose();
                }
            }
            else
            { return; }
        }

        private bool CheckValidData()
        {
            m_Err_Provider=new ErrorProvider();
            m_Err_Provider.BlinkStyle=ErrorBlinkStyle.BlinkIfDifferentError;
            m_Err_Provider.BlinkRate = 1;
            m_Err_Provider.SetIconAlignment(lookUEdit_Branch, ErrorIconAlignment.MiddleLeft);
            m_Err_Provider.SetIconAlignment(txt_CustomerId, ErrorIconAlignment.MiddleLeft);
            m_Err_Provider.SetIconAlignment(txt_Name, ErrorIconAlignment.MiddleLeft);
            m_Err_Provider.SetIconAlignment(lookUEdit_Categories, ErrorIconAlignment.MiddleLeft);
            m_Err_Provider.SetIconAlignment(txt_AccountGL, ErrorIconAlignment.MiddleLeft);
            m_Err_Provider.SetIconAlignment(txt_CreditDebit, ErrorIconAlignment.MiddleLeft);
            m_Err_Provider.SetIconAlignment(txt_Ccy, ErrorIconAlignment.MiddleLeft);
            
            m_Err_Provider.SetError(lookUEdit_Branch, string.Empty);
            m_Err_Provider.SetError(txt_CustomerId, string.Empty);
            m_Err_Provider.SetError(lookUEdit_Categories, string.Empty);
            m_Err_Provider.SetError(txt_Name, string.Empty);
            m_Err_Provider.SetError(txt_AccountGL, string.Empty);
            m_Err_Provider.SetError(txt_CreditDebit, string.Empty);
            m_Err_Provider.SetError(txt_Ccy, string.Empty);

            bool valid = true;
            if (lookUEdit_Branch.ItemIndex < 0) 
            {valid = false;m_Err_Provider.SetError(lookUEdit_Branch,"Sai mã chi nhánh");}
            if (string.IsNullOrEmpty(txt_CustomerId.Text)) 
            {valid=false; m_Err_Provider.SetError(txt_CustomerId,"Sai mã khách hàng");}
            if (string.IsNullOrEmpty(txt_Name.Text)) 
            {valid = false; m_Err_Provider.SetError(txt_Name,"Tên tài khoản chưa nhập");}
            if (lookUEdit_Categories.ItemIndex < 0) 
            {valid = false; m_Err_Provider.SetError(lookUEdit_Categories,"Loại tài khoản chưa có");}
            if (string.IsNullOrEmpty(txt_AccountGL.Text)) 
            {valid = false;m_Err_Provider.SetError(txt_AccountGL,"Sai tài khoản tổng hợp");}
            if (string.IsNullOrEmpty(txt_CreditDebit.Text)) 
            {valid = false;m_Err_Provider.SetError(txt_CreditDebit,"Sai tính chất tài khoản");}
            if (string.IsNullOrEmpty(txt_Ccy.Text)) 
            {valid = false;m_Err_Provider.SetError(txt_Ccy,"Sai loại tiền tài khoản");}

            return valid;
        }

        private void frmAccountOpen_Load(object sender, EventArgs e)
        {
            Program.GetAll_Branch();
            lookUEdit_Branch.Properties.Columns[0].FieldName = "ID";
            lookUEdit_Branch.Properties.Columns[1].FieldName = "Name";
            lookUEdit_Branch.Properties.ValueMember = "ID";
            lookUEdit_Branch.Properties.DisplayMember = "ID";
            lookUEdit_Branch.Properties.DataSource = Program.lstBranch;
            if (lookUEdit_Branch.ItemIndex < 0) lookUEdit_Branch.EditValue = string.Empty;
            Program.GetAll_Categories();
            lookUEdit_Categories.Properties.Columns[0].FieldName = "ID";
            lookUEdit_Categories.Properties.Columns[1].FieldName = "Name";
            lookUEdit_Categories.Properties.ValueMember = "ID";
            lookUEdit_Categories.Properties.DisplayMember = "ID";
            lookUEdit_Categories.Properties.DataSource = Program.lstCategories;
            if (lookUEdit_Categories.ItemIndex < 0) lookUEdit_Categories.EditValue = string.Empty;

        }
        private void frmAccountOpen_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.S) sbtnOK.PerformClick();
            else if (e.KeyCode == Keys.Escape) sbtnCancel.PerformClick();
        }

        private void txt_CustomerId_LostFocus(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_CustomerId.Text))
                return;
            else
            {
                Account.Common.Entities.Customer_Info custInfo = Program.FindCustomer(txt_CustomerId.Text);
                if (custInfo == null)
                {
                    MessageBox.Show("Không tìm thấy mã khách hàng này", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txt_CustomerId.Text = string.Empty;
                    txt_CustomerId.Focus();
                    
                    txt_Name.Text = string.Empty;
                    return;
                }
                else
                { txt_Name.Text = custInfo.Name; }
            }
        }

        private void lookUEdit_Categories_EditValueChanged(object sender, EventArgs e)
        {
            if (lookUEdit_Categories.ItemIndex < 0)
            {
                lookUEdit_Categories.EditValue = string.Empty;
                return;
            }
            Account.Common.Entities.Categories_Info oSelectedCate = Program.lstCategories[lookUEdit_Categories.ItemIndex];
            txt_AccountGL.Text = oSelectedCate.Account_GL.Account_ID;
            txt_Ccy.Text = oSelectedCate.Account_GL.Ccy;
            txt_CreditDebit.Text = oSelectedCate.Account_GL.CreditDebit.ToString();

        }

    }
}
