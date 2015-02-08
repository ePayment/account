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
    public partial class frmParameterList : Form
    {
        private static frmParameterList m_CurrentInstance = null;
        public static frmParameterList CurrentInstance
        {
            get
            {
                if (m_CurrentInstance == null)
                {
                    m_CurrentInstance = new frmParameterList();
                }
                else if (m_CurrentInstance.IsDisposed)
                {
                    m_CurrentInstance = new frmParameterList();
                }
                return m_CurrentInstance;
            }
        }
        DataTable dtTemp = new DataTable();
        public static List<Account.Common.Entities.Parameter_Info> lstParameter = new List<Account.Common.Entities.Parameter_Info>();
        public static Account.Common.Entities.Parameter_Info oSelectedPara= null;
        public Account.Common.Entities.Parameter_Info oPara = null;

        public frmParameterList()
        {
            InitializeComponent();
        }

        private void frmParameterList_Load(object sender, EventArgs e)
        {
            Program.eButton = Program.Button.None;
            lstParameter = Account.UIProviders.UIParameters.GetAll();
            Create_DataSource_Table();
            SetDataSource();
        }

        private void frmParameterList_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.E) sbtnEdit.PerformClick();
            else if (e.Control && e.KeyCode == Keys.S) sbtnOK.PerformClick();
            else if (e.KeyCode == Keys.Escape) sbtnExit.PerformClick();
        }

        private void sbtnNew_Click(object sender, EventArgs e)
        {
            Program.eButton = Program.Button.New;
            oPara = new Account.Common.Entities.Parameter_Info();
            Clear();
            Enable(true);
        }

        private void sbtnOK_Click(object sender, EventArgs e)
        {
            Save_Para();
            SetDataSource();            
        }

        private void sbtnEdit_Click(object sender, EventArgs e)
        {
            Program.eButton = Program.Button.Edit;
            txtName.Focus();
            oPara = oSelectedPara;
        }

        private void sbtnDel_Click(object sender, EventArgs e)
        {
            Program.eButton = Program.Button.Del;
            txtName.Focus();
            oPara = oSelectedPara;
        }

        private void sbtnExit_Click(object sender, EventArgs e)
        {
            Program.eButton = Program.Button.None;
            this.Close();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gridView1.FocusedRowHandle < 0) return;
            else
            {
                string Name = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gcolName).ToString();
                for (int i = 0; i <lstParameter.Count; i++)
                {

                    if (lstParameter[i].Name == Name)
                    {
                        oSelectedPara =lstParameter[i];
                        break;
                    }

                }
                Detail_Para(oSelectedPara);
            }
        }

        public static void Get_All()
        {
           lstParameter = Account.UIProviders.UIParameters.GetAll();
        }
        private void Detail_Para(Account.Common.Entities.Parameter_Info oCurPara)
        {
            if (gridView1.FocusedRowHandle < 0 || oCurPara == null) return;
            else
            {                
                txtName.Text = oCurPara.Name;
                txtValue.Text = oCurPara.Value;
                mEditDescript.Text = oCurPara.Descript;
            }
        }

        private void Save_Para()
        {
            if (CheckValue() == false) return;
            if (oPara == null) oPara = new Account.Common.Entities.Parameter_Info();
            oPara.Name = txtName.Text.Trim();
            oPara.Value = txtValue.Text;

            oPara.Descript = mEditDescript.Text.Trim();

            try
            {

                if (Program.eButton == Program.Button.New) Insert_Parameter();
                else if (Program.eButton == Program.Button.Edit) Update_Parameter();
                else if (Program.eButton == Program.Button.Del) Delete_Parameter();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void Insert_Parameter()
        {
            int result = -1;
            //int result = Account.UIProviders.UIParameters.Insert(oPara);
            if (result == 0)
            {
                MessageBox.Show("Thêm mới thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lstParameter.Insert(lstParameter.Count, oPara);
                Enable(false);
            }
            else
            {
                MessageBox.Show("Thêm mới chưa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Enable(true);
            }
        }

        private void Update_Parameter()
        {
            string ID = Account.UIProviders.UIParameters.Update(oPara).ToString();
            if (ID == "0")
            {
                int index = lstParameter.IndexOf(oSelectedPara);
                MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lstParameter.RemoveAt(index);
                lstParameter.Insert(index, oPara);
                Enable(false);
            }
            else
            {
                MessageBox.Show("Cập nhật chưa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Enable(true);
            }
            return;
        }

        private void Delete_Parameter()
        {
            DialogResult dlg = MessageBox.Show("Bạn có thật sự muốn xóa tham số " + oPara.Name + " ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlg == DialogResult.Yes)
            {
                int ID = -1;
                //int ID = Account.UIProviders.UIParameters.Delete(oPara.Name);
                if (ID ==0)
                {
                    int index = lstParameter.IndexOf(oSelectedPara);
                    MessageBox.Show("Xóa tham số thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    lstParameter.RemoveAt(index);                    
                    Enable(false);
                }
                else
                {
                    MessageBox.Show("Xóa tham số chưa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Enable(true);
                }
                return;
            }
        }

        private void Clear()
        {
            txtName.Text = string.Empty;
            txtValue.Text = string.Empty;
            mEditDescript.Text = string.Empty;
            txtName.Focus();

        }
        private void Enable(bool value)
        {
            txtName.Enabled = value;
            txtValue.Enabled = value;
            mEditDescript.Enabled = value;
        }

        private void Create_DataSource_Table()
        {
            dtTemp = new DataTable();
            dtTemp.Columns.Add("Name");
            dtTemp.Columns.Add("Value");
            dtTemp.Columns.Add("Descript");

            gcolName.FieldName = "Name";
            gcolValue.FieldName = "Value";
            gcolDescript.FieldName = "Descript";
            
        }
        private void SetDataSource()
        {
            if (lstParameter.Count == 0)
            {
                dtTemp.Rows.Clear();
                return;
            }
            dtTemp.Rows.Clear();
            for (int i = 0; i <lstParameter.Count; i++)
            {
                DataRow oRow = dtTemp.NewRow();
                oRow["Name"] = lstParameter[i].Name;
                oRow["Value"] = lstParameter[i].Value;
                oRow["Descript"] = lstParameter[i].Descript;
                dtTemp.Rows.Add(oRow);
            }
            grdCtrlParameter.DataSource = null;
            grdCtrlParameter.DataSource = dtTemp;
        }

        public bool DialogMess(string strMessage, MessageBoxIcon msgIcon, Control ctrl)
        {
            MessageBox.Show(strMessage, "Thông báo", MessageBoxButtons.OK, msgIcon);
            ctrl.Focus();
            return false;
        }
        private bool CheckValue()
        {
            if (txtName.Text.Trim() == string.Empty)
                return DialogMess("Bạn chưa nhập tên tham số!", MessageBoxIcon.Stop, txtName);
            for (int i = 0; i < txtName.Text.Trim().Length; i++)
            {
                if (Char.IsWhiteSpace(txtName.Text.Trim(),i))
                    return DialogMess("Tên tham số không được chứa dấu cách!", MessageBoxIcon.Stop, txtName);
            }           
                
            if (txtValue.Text.Trim() == string.Empty)
                return DialogMess("Bạn chưa nhập giá trị tham số!", MessageBoxIcon.Stop, txtValue);

            return true;
        }
              
        
    }
}

