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
    public partial class frmAccountGL : Form
    {
        public frmAccountGL()
        {
            InitializeComponent();
        }

        Account.Common.Entities.Account_GL_Info oAccountGL = null;
        Account.Common.Entities.Branches_Info oSelectedBranch = null;

        private void sbtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void sbtnNew_Click(object sender, EventArgs e)
        {
            Program.eButton = Program.Button.New;
            Clear();
            Enable(true);
            oAccountGL = new Account.Common.Entities.Account_GL_Info();
            txt_AccountID.Focus();
        }

        private void sbtnDel_Click(object sender, EventArgs e)
        {
            Program.eButton = Program.Button.Del;
            oAccountGL = frmAccountGLList.oSelectedAccountGl;
            Enable(true);
            txt_AccountID.Focus();            
        }

        private void sbtnOK_Click(object sender, EventArgs e)
        {
            Save_AccountGL();
        }

        private void sbtnEdit_Click(object sender, EventArgs e)
        {
            Program.eButton = Program.Button.Edit;
            oAccountGL = frmAccountGLList.oSelectedAccountGl;
            Enable(true);
            txt_AccountID.Focus();            
        } 


        private void Detail_AccountGL(Account.Common.Entities.Account_GL_Info oCurAccountGL)
        {
            txt_AccountID.Text = oCurAccountGL.Account_ID;
            txt_AccountName.Text = oCurAccountGL.Name;
            if (oSelectedBranch != null)
            {
                lookUEditBranchID.EditValue = oSelectedBranch.ID;
                txt_BranchName.Text = oSelectedBranch.Name;
            }
            txt_CreditDebit.EditValue = oCurAccountGL.CreditDebit;        
            txt_Cyc.Text = oCurAccountGL.Ccy;
        }

        private void Save_AccountGL()
        {
            if (oAccountGL == null) return;

            oAccountGL.Account_ID = txt_AccountID.Text;
            oAccountGL.Name = txt_AccountName.Text;
            oSelectedBranch = Program.FindBranch(lookUEditBranchID.EditValue.ToString());
            oAccountGL.Branch_ID = oSelectedBranch.ID;
            oAccountGL.Name = oSelectedBranch.Name;           
           //oAccountGL.CreditDebit = Convert.ToDecimal(txt_CreditDebit.EditValue.ToString());           
           if (Program.eButton == Program.Button.New) Insert_AccountGL();
           else if (Program.eButton == Program.Button.Edit) Update_AccountGL();
           else if (Program.eButton == Program.Button.Del) Delete_AccountGL();
        }

        private void Insert_AccountGL()
        {
            oAccountGL.Account_ID = Account.UIProviders.UIAccount_GL.Insert(oAccountGL).ToString();
            if (oAccountGL.Account_ID != string.Empty)
            {
                Program.eButton = Program.Button.None;
                MessageBox.Show("Thêm mới thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                frmAccountGLList.lstAccountGL.Insert(frmAccountGLList.lstAccountGL.Count, oAccountGL);
                Enable(false);
            }
            else
            {
                MessageBox.Show("Thêm mới chưa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Enable(true);
            }
        }
        private void Update_AccountGL()
        {
            int ID = Account.UIProviders.UIAccount_GL.Update(oAccountGL);
            if (ID > 0)
            {
                Program.eButton = Program.Button.None;
                MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                frmAccountGLList.lstAccountGL.Remove(frmAccountGLList.oSelectedAccountGl);
                frmAccountGLList.lstAccountGL.Insert(frmAccountGLList.lstAccountGL.Count, oAccountGL);
                Enable(false);
            }
            else
            {
                MessageBox.Show("Cập nhật chưa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Enable(true);
            }
        }
        private void Delete_AccountGL()
        {
            DialogResult dlg = MessageBox.Show("Bạn có muốn xóa sổ cái " + oAccountGL.Name + "?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlg == DialogResult.Yes)
            {

                int ID = Account.UIProviders.UIAccount_GL.Update(oAccountGL);
                if (ID > 0)
                {
                    Program.eButton = Program.Button.None;
                    MessageBox.Show("Xóa sổ cái thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frmAccountGLList.lstAccountGL.Remove(frmAccountGLList.oSelectedAccountGl);
                    Enable(false);
                }
                else
                {
                    MessageBox.Show("Xóa sổ cái chưa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Enable(false);
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
            txt_AccountID.Text = string.Empty;
            txt_AccountName.Text = string.Empty;
            lookUEditBranchID.EditValue = string.Empty;
            txt_BranchName.Text = string.Empty;
            txt_CreditDebit.Text = string.Empty;
        }

        private void Enable(bool value)
        {
            txt_AccountID.Enabled = value;
            txt_AccountName.Enabled = value;
            lookUEditBranchID.Enabled = value;
            txt_BranchName.Enabled = false;           

            txt_CreditDebit.Enabled = value;            
            txt_Cyc.Enabled = value;
        }

        private void frmAccountGL_Load(object sender, EventArgs e)
        {
            Program.GetAll_Branch();
            lookUEditBranchID.Properties.Columns[0].FieldName = "ID";
            lookUEditBranchID.Properties.Columns[1].FieldName = "Name";
            lookUEditBranchID.Properties.ValueMember = "ID";
            lookUEditBranchID.Properties.DisplayMember = "ID";
            lookUEditBranchID.Properties.DataSource = Program.lstBranch;
            if (lookUEditBranchID.ItemIndex < 0) lookUEditBranchID.EditValue = string.Empty;

            Detail_AccountGL(frmAccountGLList.oSelectedAccountGl);
            Enable(false);
        }

        private void frmAccountGL_KeyDown(object sender, KeyEventArgs e)
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

       
    }
}
