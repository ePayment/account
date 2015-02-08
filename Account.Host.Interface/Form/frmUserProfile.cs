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
    public partial class frmUserProfile : Form
    {
        Account.Common.Entities.User_Info oUserInfo = null;
        Account.Common.Entities.Branches_Info oSelectedBranch = null;

        public frmUserProfile()
        {
            InitializeComponent();
        }

        private void frmUserProfile_Load(object sender, EventArgs e)
        {
            Program.eButton = Program.Button.None;
            Program.GetAll_Branch();
            lookUEdit_BranchID.Properties.Columns[0].FieldName = "ID";
            lookUEdit_BranchID.Properties.Columns[1].FieldName = "Name";
            lookUEdit_BranchID.Properties.ValueMember = "ID";
            lookUEdit_BranchID.Properties.DisplayMember = "ID";
            lookUEdit_BranchID.Properties.DataSource = Program.lstBranch;
            if (lookUEdit_BranchID.ItemIndex < 0) lookUEdit_BranchID.EditValue = string.Empty;

            Detail_UserProfile(frmUserProfileList.oSelectedUser);
            Enable(false);
        }

        private void frmUserProfile_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.N) sbtnNew.PerformClick();
            else if (e.Control &&  e.KeyCode == Keys.E) sbtnEdit.PerformClick();
            else if (e.Control &&  e.KeyCode == Keys.S) sbtnOK.PerformClick();
            else if (e.KeyCode == Keys.Escape) sbtnExit.PerformClick();
        }

        private void sbtnNew_Click(object sender, EventArgs e)
        {
            Program.eButton = Program.Button.New;
            Clear();
            oUserInfo = new Account.Common.Entities.User_Info();
            Enable(true);
            txt_User_ID.Focus();
        }

        private void sbtnEdit_Click(object sender, EventArgs e)
        {
            oUserInfo = frmUserProfileList.oSelectedUser;
            if (oUserInfo.User_ID == Program.CurrentUser.User_ID)
            {
                MessageBox.Show("Bạn không được chỉnh sửa thông tin này", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Program.eButton = Program.Button.Edit;
            Enable(true);
            txt_User_ID.Focus();
            txt_Password.Enabled = false;
        }

        private void sbtnOK_Click(object sender, EventArgs e)
        {
            if (CheckValue() == false) return;
            Save_UserProfile();
        }

        private void sbtnExit_Click(object sender, EventArgs e)
        {
            Program.eButton = Program.Button.None;
            this.Close();
        }

        private void lookUEdit_BranchID_EditValueChanged(object sender, EventArgs e)
        {

            if (lookUEdit_BranchID.ItemIndex < 0)
            {
                lookUEdit_BranchID.EditValue = string.Empty;
                return;
            }
            oSelectedBranch = Program.lstBranch[lookUEdit_BranchID.ItemIndex];
            txt_BranchName.Text = oSelectedBranch.Name;
        }
        private bool CheckValue()
        {
            if (txt_FullName.Text.Trim() == string.Empty)
                return DialogMess("Bạn chưa nhập tên đầy đủ của khách hàng!", MessageBoxIcon.Stop, txt_FullName);

            if (txt_Password.Text.Trim() == string.Empty)
                return DialogMess("Bạn chưa nhập mật khẩu!", MessageBoxIcon.Stop, txt_Password);                      
            if (oSelectedBranch == null)
                return DialogMess("Bạn chưa chọn chi nhánh!", MessageBoxIcon.Stop, lookUEdit_BranchID);            

            return true;
        }
        private void Detail_UserProfile(Account.Common.Entities.User_Info oCurUserProfile)
        {
            txt_User_ID.Text = oCurUserProfile.User_ID;
            txt_FullName.Text = oCurUserProfile.FullName;
            txt_Password.Text = oCurUserProfile.Password;          
            oSelectedBranch = Program.FindBranch(oCurUserProfile.Branch_ID);
            if (oSelectedBranch != null)
            {
                lookUEdit_BranchID.EditValue = oSelectedBranch.ID;
                txt_BranchName.Text = oSelectedBranch.Name;
            }
            chk_IsAdmin.EditValue = oCurUserProfile.IsAdministrator;
            dtLastLogin.EditValue = oCurUserProfile.LastLogin;
            dtLastLogout.EditValue = oCurUserProfile.LastLogout;
        }

        private void Save_UserProfile()
        {
            if (oUserInfo == null) return;
            
            oUserInfo.User_ID = txt_User_ID.Text.Trim();
            oUserInfo.FullName = txt_FullName.Text.Trim();
            oUserInfo.Password = txt_Password.Text.Trim();
            oUserInfo.Branch_ID = oSelectedBranch.ID;
            oUserInfo.IsAdministrator =Convert.ToBoolean(chk_IsAdmin.EditValue);

            if (Program.eButton == Program.Button.New) Insert_UserProfile();
            else if (Program.eButton == Program.Button.Edit) Update_UserProfile(); 
        }

        private void Insert_UserProfile()
        {
            if (Account.UIProviders.UIUser.Insert(oUserInfo) == 0)
            {
                MessageBox.Show("Thêm mới thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                frmUserProfileList.lstUserInfo.Insert(frmUserProfileList.lstUserInfo.Count, oUserInfo);
                Enable(false);
                Program.eButton = Program.Button.None;
            }
            else
            {
                MessageBox.Show(Account.UIProviders.UIUser.ValidationMessage, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Enable(true);
            }
        }
        private void Update_UserProfile()
        {
            if (Account.UIProviders.UIUser.Update(oUserInfo) == 0)
            {
                MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                int index = frmUserProfileList.lstUserInfo.IndexOf(frmUserProfileList.oSelectedUser);
                frmUserProfileList.lstUserInfo.RemoveAt(index);
                frmUserProfileList.lstUserInfo.Insert(index, oUserInfo);
                Enable(false);
                Program.eButton = Program.Button.None;
            }
            else
            {
                MessageBox.Show(Account.UIProviders.UIUser.ValidationMessage, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Enable(true);
            }
        }

        private void Clear()
        {
            txt_User_ID.Text = string.Empty;
            txt_FullName.Text = string.Empty;
            txt_Password.Text = string.Empty;
            txt_TID.Text = string.Empty; 
            lookUEdit_BranchID.EditValue = string.Empty; oSelectedBranch = null;
            txt_BranchName.Text = string.Empty;
            chk_IsAdmin.EditValue = string.Empty;
            dtLastLogin.EditValue = null;
            dtLastLogout.EditValue = null;        
          
        }

        private void Enable(bool value)
        {

            txt_User_ID.Enabled = value;
            txt_FullName.Enabled = value;
            txt_Password.Enabled = value;
            txt_TID.Enabled = false;
            lookUEdit_BranchID.Enabled = value;
            txt_BranchName.Enabled = false;
            chk_IsAdmin.Enabled = value;
            dtLastLogin.Enabled = false;
            dtLastLogout.Enabled = false;       

         
        }


        public bool DialogMess(string strMessage, MessageBoxIcon msgIcon, Control ctrl)
        {
            MessageBox.Show(strMessage, "Thông báo", MessageBoxButtons.OK, msgIcon);
            ctrl.Focus();
            return false;
        }

      
    }
}
