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
    public partial class frmCategoryList : Form
    {
        public frmCategoryList()
        {
            InitializeComponent();
        }

        private static frmCategoryList m_CurrentInstance = null;
        public static frmCategoryList CurrentInstance
        {
            get
            {
                if (m_CurrentInstance == null)
                {
                    m_CurrentInstance = new frmCategoryList();
                }
                else if (m_CurrentInstance.IsDisposed)
                {
                    m_CurrentInstance = new frmCategoryList();
                }
                return m_CurrentInstance;
            }
        }
        DataTable dtTemp = new DataTable();
        public static List<Account.Common.Entities.Categories_Info> lstCategory;
        public static Account.Common.Entities.Categories_Info oSelectedCate = null;
        public Account.Common.Entities.Categories_Info oCate = null;
        Account.Common.Entities.Account_GL_Info oSelectedAccountGL = null;

        private void frmCategoryList_Load(object sender, EventArgs e)
        {
            Program.eButton = Program.Button.None;
            //Program.GetAll_Account_GL();
            lstCategory = Account.UIProviders.UICategories.GetAll();
            Create_DataSource_Table();
            SetDataSource();
            Enable(false);
        }

        private void frmCategoryList_KeyDown(object sender, KeyEventArgs e)
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
            oCate = new Account.Common.Entities.Categories_Info();
        }

        private void sbtnDel_Click(object sender, EventArgs e)
        {
            Program.eButton = Program.Button.Del;            
            oCate = oSelectedCate;
            Delete_Category();
            //Enable(true);
            //txtID.Focus();
        }

        private void sbtnOK_Click(object sender, EventArgs e)
        {            
            Save_Para();
        }

        private void sbtnEdit_Click(object sender, EventArgs e)
        {
            Program.eButton = Program.Button.Edit;
            oCate = oSelectedCate;
            Enable(true);
            txtID.Focus();
        }

        private void sbtnExit_Click(object sender, EventArgs e)
        {
            Program.eButton = Program.Button.None;
            this.Close();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {

            if (gridView1.FocusedRowHandle < 0) 
                return;
            else
            {
                string ID = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gcolID).ToString();
                for (int i = 0; i < lstCategory.Count; i++)
                {
                    if (lstCategory[i].ID == ID)
                    {
                        oSelectedCate = lstCategory[i];
                        break;
                    }

                }
                Detail_Cate(oSelectedCate);
            }
        }

        public static void Get_All()
        {
            lstCategory = Account.UIProviders.UICategories.GetAll();
        }

        private void Detail_Cate(Account.Common.Entities.Categories_Info oCurCate)
        {
            if (gridView1.FocusedRowHandle < 0 || oCurCate == null) return;
            else
            {
                txtID.Text = oCurCate.ID;
                txtName.Text = oCurCate.Name;
                txt_AccountGL.Text = oCurCate.Account_GL.Account_ID;
            }
        }

        private void Save_Para()
        {
            if (CheckValue() == false) return;
            if (oCate == null) oCate = new Account.Common.Entities.Categories_Info();
            oCate.ID = txtID.Text.Trim();
            oCate.Name = txtName.Text;
            oCate.Account_GL = oSelectedAccountGL;
            try
            {
                if (Program.eButton == Program.Button.New) Insert_Category();
                else if (Program.eButton == Program.Button.Edit) Update_Category();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

        }

        private void Insert_Category()
        {
            int result = Account.UIProviders.UICategories.Insert(oCate);
            if (result == 0)
            {
                MessageBox.Show("Thêm mới thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lstCategory.Insert(lstCategory.Count, oCate);
                SetDataSource();
                Enable(false);
                Program.eButton = Program.Button.None;
            }
            else
            {
                MessageBox.Show("Thêm mới chưa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Enable(true);
            }
        }

        private void Update_Category()
        {
            if (Account.UIProviders.UICategories.Update(oCate) == 0)
            {
                MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                SetDataSource();
                Enable(false);
                Program.eButton = Program.Button.None;
            }
            else
            {
                MessageBox.Show(Account.UIProviders.UICategories.ValidationMessage, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Enable(true);
            }
        }

        private void Delete_Category()
        {
            DialogResult dlg = MessageBox.Show("Bạn có thật sự muốn xóa loại tài khoản " + oCate.Name + "?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlg == DialogResult.Yes)
            {
                if (Account.UIProviders.UICategories.Delete(oCate.ID) == 0)
                {
                    MessageBox.Show("Xóa loại tài khoản thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    lstCategory.Remove(oCate);
                    SetDataSource();
                    Program.eButton = Program.Button.None;
                }
                else
                {
                    MessageBox.Show("Xóa loại tài khoản chưa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            Enable(false);
        }

        private void Clear()
        {
            txtID.Text = string.Empty;
            txtName.Text = string.Empty;
            txt_AccountGL.Text = string.Empty;
            oSelectedAccountGL = null;
            txtID.Focus();

        }
        private void Enable(bool value)
        {
            txtID.Enabled = value;
            txtName.Enabled = value;
            txt_AccountGL.Enabled = value;
        }

        private void Create_DataSource_Table()
        {
            dtTemp = new DataTable();
            dtTemp.Columns.Add("ID");
            dtTemp.Columns.Add("Name");
            dtTemp.Columns.Add("Account_ID");
            dtTemp.Columns.Add("Account_Name");
            dtTemp.Columns.Add("CreditDebit");
            dtTemp.Columns.Add("Ccy");

            gcolID.FieldName = "ID";
            gcolName.FieldName = "Name";
            gcolAccount_ID.FieldName = "Account_ID";
            gcolAccount_Name.FieldName = "Account_Name";
            gcolDBCR.FieldName = "CreditDebit";
            gcolCcy.FieldName = "Ccy";

        }
        private void SetDataSource()
        {
            if (lstCategory == null) lstCategory = new List<Account.Common.Entities.Categories_Info>();
            if (lstCategory.Count == 0)
            {
                dtTemp.Rows.Clear();
                return;
            }
            dtTemp.Rows.Clear();
            for (int i = 0; i < lstCategory.Count; i++)
            {
                DataRow oRow = dtTemp.NewRow();
                oRow["ID"] = lstCategory[i].ID;
                oRow["Name"] = lstCategory[i].Name;
                oRow["Account_ID"] = lstCategory[i].Account_GL.Account_ID;
                oRow["Account_Name"] = lstCategory[i].Account_GL.Name;
                oRow["CreditDebit"] = lstCategory[i].Account_GL.CreditDebit;
                oRow["Ccy"] = lstCategory[i].Account_GL.Ccy;
                dtTemp.Rows.Add(oRow);
            }
            grd_Categories.DataSource = null;
            grd_Categories.DataSource = dtTemp;
            grd_Categories.Refresh();
        }

        public bool DialogMess(string strMessage, MessageBoxIcon msgIcon, Control ctrl)
        {
            MessageBox.Show(strMessage, "Thông báo", MessageBoxButtons.OK, msgIcon);
            ctrl.Focus();
            return false;
        }

        private bool CheckValue()
        {
            if (txtID.Text.Trim() == string.Empty)
                return DialogMess("Bạn chưa nhập mã loại tài khoản!", MessageBoxIcon.Stop, txtID);
            if (txtName.Text.Trim() == string.Empty)
                return DialogMess("Bạn chưa nhập tên loại tài khoản!", MessageBoxIcon.Stop, txtName);
            oSelectedAccountGL = Account.UIProviders.UIAccount_GL.GetAccountGLByID(txt_AccountGL.Text);
            if (oSelectedAccountGL == null)
                return DialogMess("Tài khoản tổng hợp chưa đúng!", MessageBoxIcon.Stop, txt_AccountGL);

            return true;
        }

        private void grd_Categories_Click(object sender, EventArgs e)
        {

        }

    }
}
