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

        private void frmTranCode_Load(object sender, EventArgs e)
        {
            cbo_Report.Items.Insert(0, true);
            cbo_Report.Items.Insert(1, false);

            cbo_Display.Items.Insert(0, true);
            cbo_Display.Items.Insert(1, false);

            cbo_CheckOn.Items.Insert(0, true);
            cbo_CheckOn.Items.Insert(1, false);

            Program.GetAll_Branch();            
            lookUEditBranchID.Properties.Columns[0].FieldName = "ID";
            lookUEditBranchID.Properties.Columns[1].FieldName = "Name";
            lookUEditBranchID.Properties.ValueMember = "ID";
            lookUEditBranchID.Properties.DisplayMember = "ID";
            lookUEditBranchID.Properties.DataSource = Program.lstBranch;
            if (lookUEditBranchID.ItemIndex < 0) lookUEditBranchID.EditValue = string.Empty;
            Detail_TranCode(frmTranCodeList.oSelectedTranCode);
            
        }

        private void frmTranCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Control)
            {
                if (e.KeyCode == Keys.N) sbtnNew.PerformClick();
                else if (e.KeyCode == Keys.E) sbtnEdit.PerformClick();
                else if (e.KeyCode == Keys.S) sbtnOK.PerformClick();
            }
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
            Enable(true);
            txt_Code.Focus();
        }

        private void sbtnEdit_Click(object sender, EventArgs e)
        {
            oTranCodeInfo = frmTranCodeList.oSelectedTranCode;            
            Enable(true);
            txt_Code.Focus();
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
            txt_Categories.Text = oCurTranCode.Categories;
            txt_RefNum.Text = oCurTranCode.RefNum;
            oSelectedBranch = Program.FindBranch(oCurTranCode.Branch_ID);
            lookUEditBranchID.EditValue = oSelectedBranch.ID;
            txt_BranchName.Text = oSelectedBranch.Name;
            //txt_UserCreate.Text = Program.CurrentUser.FullName;                        
            txt_NextCode.Text = oCurTranCode.NextCode;
            if (oCurTranCode.Report == true) cbo_Report.SelectedIndex = 0;
            else cbo_Report.SelectedIndex = 1;            
            txt_Formula.Text = oCurTranCode.Formula;                      
            txt_CostCode.Text = oCurTranCode.CostCode;
            if (oCurTranCode.Display == true) cbo_Display.SelectedIndex = 0;
            else cbo_Display.SelectedIndex = 1;
            if (oCurTranCode.CheckOn == true) cbo_CheckOn.SelectedIndex = 0;
            else cbo_CheckOn.SelectedIndex = 1;    
            dtDateCreated.DateTime = oCurTranCode.DateCreated;
        }

        private void Save_TranCode()
        {
            if (oTranCodeInfo == null) return;

            oTranCodeInfo.Code = txt_Code.Text;
            oTranCodeInfo.Name = txt_Name.Text.Trim();
            oTranCodeInfo.Categories = txt_Categories.Text.Trim();
            oTranCodeInfo.RefNum = txt_RefNum.Text;
            oTranCodeInfo.Branch_ID = oSelectedBranch.ID;            
            
            oTranCodeInfo.NextCode = txt_NextCode.Text;
            oTranCodeInfo.Report = false;
            oTranCodeInfo.Formula = txt_Formula.Text;
            oTranCodeInfo.CostCode = txt_CostCode.Text;
            oTranCodeInfo.Categories = txt_CostCode.Text;
            oTranCodeInfo.Display = false; //txt_Display.Text;
            oTranCodeInfo.CheckOn = false;//txt_CheckOn.Text;
            oTranCodeInfo.DateCreated = dtDateCreated.DateTime;

            if (oTranCodeInfo.Code != frmTranCodeList.oSelectedTranCode.Code) /*Them moi*/
            {
                int ID = Account.UIProviders.UITranCode.Insert(oTranCodeInfo);
                if (ID == 1)
                {
                    MessageBox.Show("Thêm mới thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frmTranCodeList.lstTranCodeInfo.Insert(frmTranCodeList.lstTranCodeInfo.Count, oTranCodeInfo);
                    Enable(false);
                }
                else
                {
                    MessageBox.Show("Thêm mới chưa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Enable(true);
                }
            }
            else
            {
                int index = frmTranCodeList.lstTranCodeInfo.IndexOf(frmTranCodeList.oSelectedTranCode);
                int ID = Account.UIProviders.UITranCode.Update(oTranCodeInfo);
                if (ID > 0)
                {
                    MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frmTranCodeList.lstTranCodeInfo.RemoveAt(index);
                    frmTranCodeList.lstTranCodeInfo.Insert(index, oTranCodeInfo);
                    Enable(false);
                }
                else
                {
                    MessageBox.Show("Cập nhật chưa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Enable(true);
                }
            }
        }

        private void Clear()
        {
            txt_Code.Text = string.Empty;
            txt_Name.Text = string.Empty;
            txt_Categories.Text = string.Empty;
            txt_RefNum.Text = string.Empty;
            lookUEditBranchID.ItemIndex = 0;
            txt_BranchName.Text = string.Empty;
            //txt_UserCreate.Text = Program.CurrentUser.FullName;

            txt_NextCode.Text = string.Empty;
            cbo_Report.SelectedIndex = 0;
            txt_Formula.Text = string.Empty;            
            txt_CostCode.Text = string.Empty;
            cbo_Display.SelectedIndex = 0;            
            cbo_CheckOn.Text = string.Empty;
            cbo_Report.SelectedIndex = 0;
            dtDateCreated.Text = string.Empty;
        }

        private void Enable(bool value)
        {
            txt_Code.Enabled = value;
            txt_Name.Enabled = value;
            txt_Categories.Enabled = value;
            txt_RefNum.Enabled = value;
            lookUEditBranchID.Enabled = value;
            txt_BranchName.Enabled = false;
            txt_UserCreate.Enabled = false;
            txt_NextCode.Enabled = value;
            cbo_Display.Enabled = value;
            txt_Formula.Enabled = value;            
            txt_CostCode.Enabled = value;
            cbo_CheckOn.Enabled = value;
            cbo_Report.Enabled = value;
            dtDateCreated.Enabled = value;
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
