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
    public partial class frmAccountRole : Form
    {
        Account.Common.Entities.AccountRoles_Info oAccountRoleInfo = null;
        public static Account.Common.Utilities.AccountRoleType[] arrRoleType = (Account.Common.Utilities.AccountRoleType[])Enum.GetValues(typeof(Account.Common.Utilities.AccountRoleType));
        public static Account.Common.Utilities.OperatorType[] arrOperatorType = (Account.Common.Utilities.OperatorType[])Enum.GetValues(typeof(Account.Common.Utilities.OperatorType));

        public frmAccountRole()
        {
            InitializeComponent(); 
            cbo_Active.Items.Insert(0, true);
            cbo_Active.Items.Insert(1, false);
            cbo_Operator.DataSource = arrOperatorType ;
            cbo_RoleType.DataSource = arrRoleType; 
        }

        private void frmAccountRole_Load(object sender, EventArgs e)
        {
            Program.eButton = Program.Button.None;         
            Detail_AccountRole(frmAccountRoleList.oSelectedAccountRole);
            Enable(false);
        }

        private void frmAccountRole_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.N) sbtnNew.PerformClick();
            else if (e.Control && e.KeyCode == Keys.E) sbtnEdit.PerformClick();
            else if (e.Control && e.KeyCode == Keys.S) sbtnOK.PerformClick();
            else if (e.Control && e.KeyCode == Keys.D) sbtnDel.PerformClick();
            else if (e.KeyCode == Keys.Escape) sbtnExit.PerformClick();       
        }

        private void sbtnNew_Click(object sender, EventArgs e)
        {
            Program.eButton = Program.Button.New;
            Clear();
            Enable(true);
            oAccountRoleInfo = new Account.Common.Entities.AccountRoles_Info();
            txt_UserCreate.Text = Program.CurrentUser.User_ID;
            dtLastUpdate.DateTime = DateTime.Now;
            dtCreateDate.DateTime = DateTime.Now;
            txt_Name.Focus();
        }

        private void sbtnEdit_Click(object sender, EventArgs e)
        {
            Program.eButton = Program.Button.Edit;
            oAccountRoleInfo = frmAccountRoleList.oSelectedAccountRole;
            Enable(true);
            txt_Name.Focus();
        }

        private void sbtnDel_Click(object sender, EventArgs e)
        {
            Program.eButton = Program.Button.Del;
            oAccountRoleInfo = frmAccountRoleList.oSelectedAccountRole;
            Delete_AccountRole();
            this.Close();
        }

        private void sbtnOK_Click(object sender, EventArgs e)
        {
            Save_AccountRole();
        }

        private void sbtnExit_Click(object sender, EventArgs e)
        {
            Program.eButton = Program.Button.None;
            this.Close();
        }

        private void Detail_AccountRole(Account.Common.Entities.AccountRoles_Info oCurAccountRole)
        {
            txt_Name.Text = oCurAccountRole.Name;
            txt_Account_ID.Text = oCurAccountRole.Account_ID;
            for(int i =0; i< arrRoleType.Length; i++)
            {
                if (arrRoleType[i] == oCurAccountRole.Type)
                {
                    cbo_RoleType.SelectedIndex = i;
                    break;
                }
           }

            for (int i = 0; i < arrOperatorType.Length; i++)
            {
                if (arrOperatorType[i] == oCurAccountRole.Operator)
                {
                    cbo_Operator.SelectedIndex = i;
                    break;
                }
            }

            txt_Value.EditValue = oCurAccountRole.Value;
            txt_Seq.EditValue = oCurAccountRole.Seq;
            if (oCurAccountRole.Active == true) cbo_Active.SelectedIndex = 0;
            else  cbo_Active.SelectedIndex = 1;
            dtActive_Date.EditValue = oCurAccountRole.Active_Date;
            dtCreateDate.EditValue = oCurAccountRole.CreateDate;
            dtLastUpdate.EditValue = oCurAccountRole.Last_Update;
            txt_UserCreate.Text = oCurAccountRole.UserCreated;
           
        }

        private void Save_AccountRole()
        {
            if (oAccountRoleInfo == null) return;

            oAccountRoleInfo.Name = txt_Name.Text;
            oAccountRoleInfo.Account_ID = txt_Account_ID.Text;
            oAccountRoleInfo.Type = arrRoleType[cbo_RoleType.SelectedIndex];
            oAccountRoleInfo.Operator = arrOperatorType[cbo_Operator.SelectedIndex];

            oAccountRoleInfo.Value = Convert.ToDecimal(txt_Value.EditValue);
            oAccountRoleInfo.Seq = Convert.ToInt32(txt_Seq.EditValue);
            if (cbo_Active.SelectedIndex == 0) oAccountRoleInfo.Active = true;
            else oAccountRoleInfo.Active = false;
            oAccountRoleInfo.Active_Date = dtActive_Date.DateTime;
            oAccountRoleInfo.CreateDate = dtCreateDate.DateTime;
            oAccountRoleInfo.Last_Update = dtLastUpdate.DateTime;
            oAccountRoleInfo.UserCreated = Program.CurrentUser.User_ID;

            if (Program.eButton == Program.Button.New) Insert_AccountRole();
            else if (Program.eButton == Program.Button.Edit) Update_AccountRole();            
        }

        private void Insert_AccountRole()
        {
            if (Account.UIProviders.UIAccount_Roles.Insert(oAccountRoleInfo) == 0)
            {
                MessageBox.Show("Thêm mới thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                frmAccountRoleList.lstAccountRolesInfo.Insert(frmAccountRoleList.lstAccountRolesInfo.Count, oAccountRoleInfo);
                Program.eButton = Program.Button.None;
                Enable(false);
            }
            else
            {
                MessageBox.Show(Account.UIProviders.UIAccount_Roles.ValidationMessage, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Enable(true);
            }
        }
        private void Update_AccountRole()
        {
            int index = frmAccountRoleList.lstAccountRolesInfo.IndexOf(frmAccountRoleList.oSelectedAccountRole);
            if (Account.UIProviders.UIAccount_Roles.Update(oAccountRoleInfo) == 0)
            {
                MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                frmAccountRoleList.lstAccountRolesInfo.RemoveAt(index);
                frmAccountRoleList.lstAccountRolesInfo.Insert(index, oAccountRoleInfo);
                Enable(false);
                Program.eButton = Program.Button.None;
            }
            else
            {
                MessageBox.Show(Account.UIProviders.UIAccount_Roles.ValidationMessage, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Enable(true);
            }
        }

        private void Delete_AccountRole()
        {
            DialogResult dlg = MessageBox.Show("Bạn có đồng ý xóa điều kiện định khoản " + oAccountRoleInfo.Name + "?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlg == DialogResult.Yes)
            {

                int index = frmAccountRoleList.lstAccountRolesInfo.IndexOf(frmAccountRoleList.oSelectedAccountRole);
                if (Account.UIProviders.UIAccount_Roles.Delete(oAccountRoleInfo.ID.ToString()) == 0)
                {
                    MessageBox.Show("Xóa điều kiện định khoản thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frmAccountRoleList.lstAccountRolesInfo.RemoveAt(index);                    
                    Enable(false);
                    Program.eButton = Program.Button.None;
                }
                else
                {
                    MessageBox.Show(Account.UIProviders.UIAccount_Roles.ValidationMessage, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Enable(true);
                }
            }
            else
            {
                Program.eButton = Program.Button.None;
                Enable(false);
            }
        }

        private void Clear()
        {
            txt_Name.Text = string.Empty;
            txt_Account_ID.Text = string.Empty;
            cbo_RoleType.SelectedIndex = -1;
            cbo_Operator.SelectedIndex = -1;
            txt_Value.EditValue = string.Empty;
            txt_Seq.EditValue = string.Empty;
            cbo_Active.SelectedIndex = -1;

            dtActive_Date.EditValue = null;
            dtCreateDate.EditValue = null;
            dtLastUpdate.EditValue = null;
        }

        private void Enable(bool value)
        {
            txt_Name.Enabled = value;
            txt_Account_ID.Enabled = value;
            cbo_RoleType.Enabled = value;
            cbo_Operator.Enabled = value;
            txt_Value.Enabled = value;
            txt_Seq.Enabled = value;
            cbo_Active.Enabled = value;
            dtActive_Date.Enabled = false;
            dtCreateDate.Enabled = false;
            dtLastUpdate.Enabled = false;
            txt_UserCreate.Enabled = false;
        }


        public bool DialogMess(string strMessage, MessageBoxIcon msgIcon, Control ctrl)
        {
            MessageBox.Show(strMessage, "Thông báo", MessageBoxButtons.OK, msgIcon);
            ctrl.Focus();
            return false;
        }
        private bool CheckValue()
        {
            if (txt_Name.Text.Trim() == string.Empty)
                return DialogMess("Bạn chưa nhập tên tài khoản!", MessageBoxIcon.Stop, txt_Name);
            if (txt_Account_ID.Text.Trim() == string.Empty)
                return DialogMess("Bạn chưa nhập nhóm tài khoản theo tiền tố của mã tài khoản chi tiết!", MessageBoxIcon.Stop, txt_Account_ID);
            if (cbo_RoleType.SelectedIndex < 0)
                return DialogMess("Bạn chưa chọn loại luật tài khoản!", MessageBoxIcon.Stop, cbo_RoleType);
            if (cbo_Operator.SelectedIndex<0)
                return DialogMess("Bạn chưa chọn toán tử!", MessageBoxIcon.Stop, cbo_Operator);
            if (txt_Value.Text.Trim() == string.Empty)
                return DialogMess("Bạn chưa nhập giá trị của luật!", MessageBoxIcon.Stop, cbo_Operator);
            if (cbo_Active.SelectedIndex < 0)
                return DialogMess("Bạn chưa chọn trạng thái kích hoạt của luật!", MessageBoxIcon.Stop, cbo_Active);
            if (dtActive_Date.EditValue == null || dtActive_Date.Text == string.Empty)
                return DialogMess("Bạn chưa chọn ngày kích hoạt luật!", MessageBoxIcon.Stop, dtActive_Date);
            if (dtCreateDate.EditValue == null || dtCreateDate.Text == string.Empty)
                return DialogMess("Bạn chưa chọn ngày tạo luật!", MessageBoxIcon.Stop, dtCreateDate);
            if (dtLastUpdate.EditValue == null || dtLastUpdate.Text == string.Empty)
                return DialogMess("Bạn chưa chọn ngày cập nhật lần cuối!", MessageBoxIcon.Stop, dtLastUpdate);            
            if (dtLastUpdate.DateTime < dtCreateDate.DateTime)
                return DialogMess("Ngày cập nhật cuối chưa hợp lệ!", MessageBoxIcon.Stop, dtLastUpdate);
            return true;
        }

        private void cbo_Active_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbo_Active.SelectedIndex == 0) dtActive_Date.DateTime = DateTime.Now;
            else dtActive_Date.EditValue = null;
        }

       
    }
}
