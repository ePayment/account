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
    public partial class frmTranCode : Form
    {
        public frmTranCode()
        {
            InitializeComponent();
        }
        Account.Common.Entities.Trancode_Info oTranCodeInfo = null;
        Account.Common.Entities.Branches_Info oSelectedBranch = null;
        Account.Common.Utilities.CodeType[] arrCodeType = (Account.Common.Utilities.CodeType[])Enum.GetValues(typeof(Account.Common.Utilities.CodeType));
        private void frmTranCode_Load(object sender, EventArgs e)
        {
            cbo_Status.Properties.Items.Add(true);
            cbo_Status.Properties.Items.Add(false);

            cbo_CodeType.Properties.Items.AddRange(arrCodeType);

            Program.GetAll_Branch();            
            lookUEditBranchID.Properties.Columns[0].FieldName = "ID";
            lookUEditBranchID.Properties.Columns[1].FieldName = "Name";
            lookUEditBranchID.Properties.ValueMember = "ID";
            lookUEditBranchID.Properties.DisplayMember = "ID";
            lookUEditBranchID.Properties.DataSource = Program.lstBranch;
            if (lookUEditBranchID.ItemIndex < 0) lookUEditBranchID.EditValue = string.Empty;

            Program.GetAll_Categories();
            lookUpEdit_Categories.Properties.Columns[0].FieldName = "ID";
            lookUpEdit_Categories.Properties.Columns[1].FieldName = "Name";
            lookUpEdit_Categories.Properties.ValueMember = "ID";
            lookUpEdit_Categories.Properties.DisplayMember = "ID";
            lookUpEdit_Categories.Properties.DataSource = Program.lstCategories;
            if (lookUpEdit_Categories.ItemIndex < 0) lookUpEdit_Categories.EditValue = string.Empty;

            Detail_TranCode(frmTranCodeList.oSelectedTranCode);
            ReadOnly(true);
        }

        private void frmTranCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.N) sbtnNew.PerformClick();
            else if (e.Control && e.KeyCode == Keys.E) sbtnEdit.PerformClick();
            else if (e.Control && e.KeyCode == Keys.S) sbtnOK.PerformClick();
            else if (e.Control && e.KeyCode == Keys.D) sbtnDel.PerformClick();
            else if (e.KeyCode == Keys.Escape) sbtnExit.PerformClick();
        }

        private void lookUEditBranchID_EditValueChanged(object sender, EventArgs e)
        {
            if (lookUEditBranchID.ItemIndex < 0)
            {
                lookUEditBranchID.EditValue = string.Empty;
                return;
            }
            oSelectedBranch = Program.lstBranch[lookUEditBranchID.ItemIndex];
            txt_BranchName.Text = oSelectedBranch.Name;

        }

        private void sbtnNew_Click(object sender, EventArgs e)
        {
            Clear();
            oTranCodeInfo = new Account.Common.Entities.Trancode_Info();
            Program.eButton = Program.Button.New;
            ReadOnly(false);
            txt_Code.Focus();
            txt_UserCreate.Text = Program.CurrentUser.User_ID;
            dtDateCreated.DateTime = DateTime.Now;
        }

        private void sbtnEdit_Click(object sender, EventArgs e)
        {
            oTranCodeInfo = frmTranCodeList.oSelectedTranCode;
            Program.eButton = Program.Button.Edit;
            ReadOnly(false);
            txt_Code.Focus();
        }

        private void sbtnDel_Click(object sender, EventArgs e)
        {
            oTranCodeInfo = frmTranCodeList.oSelectedTranCode;
            Delete_TranCode();
        }  

        private void sbtnOK_Click(object sender, EventArgs e)
        {
            if (CheckValue() == false) return;
            Save_TranCode();
        }

        private void sbtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Detail_TranCode(Account.Common.Entities.Trancode_Info oCurTranCode)
        {         
            txt_Code.Text = oCurTranCode.Code;
            txt_Name.Text = oCurTranCode.Name;
            cbo_Status.EditValue = oCurTranCode.Status;
            cbo_CodeType.EditValue = oCurTranCode.CodeType;
            lookUpEdit_Categories.Text = oCurTranCode.Categories;
            oSelectedBranch = Program.FindBranch(oCurTranCode.Branch_ID);
            lookUEditBranchID.EditValue = oSelectedBranch.ID;
            txt_BranchName.Text = oSelectedBranch.Name;
            txt_UserCreate.Text = oCurTranCode.UserCreate;                        
            txt_NextCode.Text = oCurTranCode.NextCode;
            txt_Descript.Text = oCurTranCode.Descript;
            dtDateCreated.DateTime = oCurTranCode.DateCreated;
        }

        private void Save_TranCode()
        {
            if (oTranCodeInfo == null) return;

            oTranCodeInfo.Code = txt_Code.Text;
            oTranCodeInfo.Name = txt_Name.Text.Trim();
            oTranCodeInfo.Categories = lookUpEdit_Categories.Text.Trim();
            oTranCodeInfo.Branch_ID = oSelectedBranch.ID;
            oTranCodeInfo.Status = Convert.ToBoolean(cbo_Status.Text);
            oTranCodeInfo.CodeType = (Account.Common.Utilities.CodeType)Enum.Parse(typeof(Account.Common.Utilities.CodeType), cbo_CodeType.Text);
            oTranCodeInfo.NextCode = txt_NextCode.Text;
            oTranCodeInfo.Descript = txt_Descript.Text;
            oTranCodeInfo.DateCreated = dtDateCreated.DateTime;
            oTranCodeInfo.UserCreate = Program.CurrentUser.User_ID;

            try
            {
                if (Program.eButton == Program.Button.New) Insert_TranCode();
                else if (Program.eButton == Program.Button.Edit) Update_TranCode();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void Insert_TranCode()
        {
            int ID = Account.UIProviders.UITranCode.Insert(oTranCodeInfo);
            if (ID == 0)
            {
                MessageBox.Show("Thêm mới thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                frmTranCodeList.lstTranCodeInfo.Insert(frmTranCodeList.lstTranCodeInfo.Count, oTranCodeInfo);
                ReadOnly(true);
            }
            else
            {
                MessageBox.Show("Thêm mới chưa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void Update_TranCode()
        {
            int index = frmTranCodeList.lstTranCodeInfo.IndexOf(frmTranCodeList.oSelectedTranCode);
            if (Account.UIProviders.UITranCode.Update(oTranCodeInfo) == 0)
            {
                MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                frmTranCodeList.lstTranCodeInfo.RemoveAt(index);
                frmTranCodeList.lstTranCodeInfo.Insert(index, oTranCodeInfo);
                ReadOnly(true);
            }
            else
            {
                MessageBox.Show("Cập nhật chưa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void Delete_TranCode()
        {
            DialogResult dlg = MessageBox.Show("Bạn có thật sự muốn xóa định khoản " + oTranCodeInfo.Name + "?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlg == DialogResult.Yes)
            {
                if (Account.UIProviders.UITranCode.Delete(oTranCodeInfo.Code) == 0)
                {
                    MessageBox.Show("Xóa định khoản thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frmTranCodeList.lstTranCodeInfo.Remove(frmTranCodeList.oSelectedTranCode);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Xóa định khoản chưa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                Program.eButton = Program.Button.None;
                return;
            }
        }

        private void Clear()
        {
            txt_Code.Text = string.Empty;
            txt_Name.Text = string.Empty;
            cbo_CodeType.EditValue = string.Empty;
            cbo_Status.EditValue = string.Empty;
            lookUpEdit_Categories.EditValue = string.Empty;
            lookUEditBranchID.EditValue = string.Empty;
            txt_BranchName.Text = string.Empty;
            txt_UserCreate.Text = string.Empty;
            txt_Descript.Text = string.Empty;
            txt_NextCode.Text = string.Empty;
            dtDateCreated.EditValue = null;
        }

        private void ReadOnly(bool value)
        {
            txt_Code.Properties.ReadOnly = value;
            txt_Name.Properties.ReadOnly = value;
            cbo_Status.Properties.ReadOnly = value;
            cbo_CodeType.Properties.ReadOnly = value;

            lookUpEdit_Categories.Properties.ReadOnly = value;
            lookUEditBranchID.Properties.ReadOnly = value;
            txt_BranchName.Properties.ReadOnly = true;
            txt_UserCreate.Properties.ReadOnly = true;
            txt_NextCode.Properties.ReadOnly = value;
            dtDateCreated.Properties.ReadOnly = true;

            txt_Descript.Properties.ReadOnly = value;
        }

        private bool CheckValue()
        {
            if (oSelectedBranch == null)
            {
                MessageBox.Show("Bạn chưa chọn chi nhánh!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

         
    }
}
