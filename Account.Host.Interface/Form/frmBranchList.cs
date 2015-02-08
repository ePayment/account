using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Account.Host.Interface
{
    public partial class frmBranchList : Form
    {
        public frmBranchList()
        {
            InitializeComponent();
            m_CurrentInstance = this;
        }

        private static frmBranchList m_CurrentInstance = null;
        public static frmBranchList CurrentInstance
        {
            get
            {
                if (m_CurrentInstance == null)
                {
                    m_CurrentInstance = new frmBranchList();
                }
                else if (m_CurrentInstance.IsDisposed)
                {
                    m_CurrentInstance = new frmBranchList();
                }
                return m_CurrentInstance;
            }
        }
        DataTable dtTemp = new DataTable();        
        public static Account.Common.Entities.Branches_Info oSelectedBranch = null;
        public Account.Common.Entities.Branches_Info oBranch = null;

        private void frmBranchList_Load(object sender, EventArgs e)
        {
            Program.eButton = Program.Button.None;
            Create_DataSource_Table();
            Get_All();
            SetDataSource();
            Enable(false);
        }

        private void frmBranchList_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.N) sbtnNew.PerformClick();
            else if (e.Control && e.KeyCode == Keys.E) sbtnEdit.PerformClick();
            else if (e.Control && e.KeyCode == Keys.S) sbtnOK.PerformClick();
            else if (e.Control && e.KeyCode == Keys.D) sbtnDel.PerformClick();
            else if (e.KeyCode == Keys.Escape) sbtnExit.PerformClick();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gridView1.FocusedRowHandle < 0) return;
            else
            {
                string ID = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gcolID).ToString();
                for (int i = 0; i < Program.lstBranch.Count; i++)
                {
                    if (Program.lstBranch[i].ID == ID)
                    {
                        oSelectedBranch = Program.lstBranch[i];
                        break;
                    }

                }
                Detail_Branch(oSelectedBranch);
            }
        }

        private void sbtnNew_Click(object sender, EventArgs e)
        {
            Program.eButton = Program.Button.New;
            oBranch = new Account.Common.Entities.Branches_Info();
            Clear();
            Enable(true);
            
        }

        private void sbtnDel_Click(object sender, EventArgs e)
        {
            Program.eButton = Program.Button.Del;
            oBranch = oSelectedBranch;
            Delete_Branch();
            Clear();
            //Enable(true);
            SetDataSource();
        }    

        private void sbtnOK_Click(object sender, EventArgs e)
        {            
            if (CheckValue() == false) return;
            Save_Branch();
            SetDataSource();
        }

        private void sbtnEdit_Click(object sender, EventArgs e)
        {
            Program.eButton = Program.Button.Edit;
            oBranch = oSelectedBranch;
            Enable(true);
        }

        private void sbtnExit_Click(object sender, EventArgs e)
        {
            Program.eButton = Program.Button.None;
            this.Close();
        }

        public static void Get_All()
        {
            Program.lstBranch = Account.UIProviders.UIBranches.GetAll();
        }
        private void Detail_Branch(Account.Common.Entities.Branches_Info oCurBranch)
        {
            if (gridView1.FocusedRowHandle < 0 || oCurBranch == null) return;
            else
            {                
                 //oCurBranch = (Account.Common.Entities.Branches_Info)gridView1.GetRow(gridView1.FocusedRowHandle);               
                 txt_ID.Text = oCurBranch.ID;
                 mEdit_Name.Text = oCurBranch.Name;
            }            
        }

        private void Save_Branch()
        {
            try
            {
                if (oBranch == null) oBranch = new Account.Common.Entities.Branches_Info();
                oBranch.ID = txt_ID.Text.Trim();
                oBranch.Name = mEdit_Name.Text;
                if (Program.eButton == Program.Button.Edit) Edit_Branch();
                else if (Program.eButton == Program.Button.New) Insert_Branch();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

        }

        private void Edit_Branch()
        {
            for (int i = 0; i < Program.lstBranch.Count; i++)
            {
                if (Program.lstBranch[i].ID == oBranch.ID)
                {
                    /*Sửa */
                    if (Account.UIProviders.UIBranches.Update(oBranch) == 0)
                    {
                        MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Program.lstBranch.Remove(oSelectedBranch);
                        Program.lstBranch.Insert(Program.lstBranch.Count, oBranch);
                        Enable(false);
                        Program.eButton = Program.Button.None;
                    }
                    else
                    {
                        MessageBox.Show(Account.UIProviders.UIBranches.ValidationMessage, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Enable(true);
                    }
                    return;
                }
            }
 
        }

        private void Insert_Branch()
        {
            if (Account.UIProviders.UIBranches.Insert(oBranch) == 0)
            {
                MessageBox.Show("Thêm mới thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Program.lstBranch.Insert(Program.lstBranch.Count, oBranch);
                Enable(false);
                Program.eButton = Program.Button.None;
            }
            else
            {
                MessageBox.Show(Account.UIProviders.UIBranches.ValidationMessage, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Enable(true);
            }
        }

        private void Delete_Branch()
        {
            DialogResult dlgResult = MessageBox.Show("Bạn có muốn xóa chi nhánh " + oBranch.Name + "?", "Thông báo", MessageBoxButtons.YesNo,  MessageBoxIcon.Question);
            if (dlgResult == DialogResult.No)
                return;
            if (Account.UIProviders.UIBranches.Delete(oBranch.ID) == 0)
            {
                MessageBox.Show("Xóa chi nhánh thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Program.lstBranch.Remove(oBranch);
                SetDataSource();
                Enable(false);
                Program.eButton = Program.Button.None;
            }
            else
            {
                MessageBox.Show(Account.UIProviders.UIBranches.ValidationMessage, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        private void Clear()
        {
            txt_ID.Text = string.Empty;
            mEdit_Name.Text = string.Empty;          

        }
        private void Enable(bool value)
        {
            txt_ID.Enabled = value;
            mEdit_Name.Enabled = value;           
        }

        private void Create_DataSource_Table()
        {
            dtTemp = new DataTable();
            dtTemp.Columns.Add("ID");
            dtTemp.Columns.Add("Name");

            gcolID.FieldName = "ID";
            gcolName.FieldName = "Name";          
        }
        private void SetDataSource()
        {
            if (Program.lstBranch.Count == 0)
            {
                dtTemp.Rows.Clear();
                return;
            }
            dtTemp.Rows.Clear();
            for (int i = 0; i < Program.lstBranch.Count; i++)
            {
                DataRow oRow = dtTemp.NewRow();
                oRow["ID"] = Program.lstBranch[i].ID;
                oRow["Name"] = Program.lstBranch[i].Name;              
                dtTemp.Rows.Add(oRow);
            }
            grdCtrlBranch.DataSource = null;
            grdCtrlBranch.DataSource = dtTemp;
        }

        public bool DialogMess(string strMessage, MessageBoxIcon msgIcon, Control ctrl)
        {
            MessageBox.Show(strMessage, "Thông báo", MessageBoxButtons.OK, msgIcon);
            ctrl.Focus();
            return false;
        }

        private bool CheckValue()
        {
            if (txt_ID.Text.Trim() == string.Empty)
                return DialogMess("Bạn chưa nhập mã chi nhánh!", MessageBoxIcon.Stop, txt_ID);
            if (mEdit_Name.Text.Trim() == string.Empty)
                return DialogMess("Bạn chưa tên chi nhánh!", MessageBoxIcon.Stop, mEdit_Name);           
            return true;
        }

    }
}
