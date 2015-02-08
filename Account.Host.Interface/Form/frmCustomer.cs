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
    public partial class frmCustomer : Form
    {
        private static frmCustomer m_CurrentInstance = null;
        protected static frmCustomer CurrentInstance
        {
            get
            {
                if (m_CurrentInstance == null)
                {
                    m_CurrentInstance = new frmCustomer();
                }
                else if (m_CurrentInstance.IsDisposed)
                {
                    m_CurrentInstance = new frmCustomer();
                }
                return m_CurrentInstance;
            }
        }
        public Account.Common.Entities.Customer_Info oCustomer = null;
        Account.Common.Entities.Branches_Info oSelectedBranch = null;
        Account.Common.Entities.Industry_Info oSelectedIndustry = null;
        Account.Common.Entities.Sector_Info oSelectedSector = null;   

        public frmCustomer()
        {
            InitializeComponent();
            cbo_Approved.Items.Insert(0, true);
            cbo_Approved.Items.Insert(1, false);

            Program.eButton = Program.Button.None;
            m_CurrentInstance = this;
        }

        private void frmCustomer_Load(object sender, EventArgs e)
        {
            Program.GetAll_Branch();
            Program.GetAll_Industry();
            Program.GetAll_Sector();

            lookUEdit_BranchID.Properties.Columns[0].FieldName = "ID";
            lookUEdit_BranchID.Properties.Columns[1].FieldName = "Name";
            lookUEdit_BranchID.Properties.ValueMember = "ID";
            lookUEdit_BranchID.Properties.DisplayMember = "ID";
            lookUEdit_BranchID.Properties.DataSource = Program.lstBranch;

            lookUEdit_Industry.Properties.Columns[0].FieldName = "ID";
            lookUEdit_Industry.Properties.Columns[1].FieldName = "Name";
            lookUEdit_Industry.Properties.ValueMember = "ID";
            lookUEdit_Industry.Properties.DisplayMember = "ID";
            lookUEdit_Industry.Properties.DataSource = Program.lstIndustry;

            lookUEdit_Sector.Properties.Columns[0].FieldName = "ID";
            lookUEdit_Sector.Properties.Columns[1].FieldName = "Name";
            lookUEdit_Sector.Properties.ValueMember = "ID";
            lookUEdit_Sector.Properties.DisplayMember = "ID";
            lookUEdit_Sector.Properties.DataSource = Program.lstSector;

            if (lookUEdit_BranchID.ItemIndex < 0) lookUEdit_BranchID.EditValue = string.Empty;
            Detail_Customer(frmCustomerList.oSelectedCustomerInfo);
            Enable(false);
        }

        private void frmCustomer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.N) sbtnNew.PerformClick();
            else if (e.Control  && e.KeyCode == Keys.E) sbtnEdit.PerformClick();
            else if (e.Control && e.KeyCode == Keys.S) sbtnOK.PerformClick();
            else if (e.Control && e.KeyCode == Keys.D) sbtnDel.PerformClick();           
            else if (e.KeyCode == Keys.Escape) sbtnExit.PerformClick();
        }

        private void lookUEditBranchID_EditValueChanged(object sender, EventArgs e)
        {
            if (lookUEdit_BranchID.ItemIndex < 0)
            {
                lookUEdit_BranchID.EditValue = string.Empty;
                return;
            }
            oSelectedBranch = Program.lstBranch[lookUEdit_BranchID.ItemIndex];
            txt_BranchName.Text = oSelectedBranch.Name;
            lookUEdit_BranchID.ClosePopup();
        }

        private void sbtnNew_Click(object sender, EventArgs e)
        {
            Program.eButton = Program.Button.New;
            oCustomer = new Account.Common.Entities.Customer_Info();
            Clear();
            txt_UserCreate.Text = Program.CurrentUser.User_ID;
            dt_DateCreated.DateTime = DateTime.Now;
            dt_Last_Date.DateTime = DateTime.Now;
            Enable(true);
            txt_Ref.Focus();            
        }

        private void sbtnOK_Click(object sender, EventArgs e)
        {            
            if (CheckValue() == false) return;            
            Save_Customer();
        }

        private void sbtnEdit_Click(object sender, EventArgs e)
        {
            Program.eButton = Program.Button.Edit;
            oCustomer = frmCustomerList.oSelectedCustomerInfo;
            if (UIProviders.UICustomer.Update_Auth(oCustomer) != 0)
            {
                MessageBox.Show(UIProviders.UICustomer.ValidationMessage, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            txt_UserCreate.Text = Program.CurrentUser.User_ID;
            dt_Last_Date.DateTime = DateTime.Now;
            Enable(true);
            txt_Ref.Focus();   
        }

        private void sbtnDel_Click(object sender, EventArgs e)
        {
            Program.eButton = Program.Button.Del;
            oCustomer = frmCustomerList.oSelectedCustomerInfo;
            if (UIProviders.UICustomer.Delete_Auth(oCustomer.ID) != 0)
            {
                MessageBox.Show(UIProviders.UICustomer.ValidationMessage, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Delete_Customer(oCustomer);
        }

        private void sbtnExit_Click(object sender, EventArgs e)
        {
            Program.eButton = Program.Button.None;
            this.Close();            
        }      

        private void Detail_Customer(Account.Common.Entities.Customer_Info oCurCustomer)
        {  
            txt_ID.Text = oCurCustomer.ID;
            txt_Ref.Text = oCurCustomer.Reference;
            txt_Name.Text = oCurCustomer.Name;
            txt_FamilyName.Text = oCurCustomer.FamilyName;
            txt_ShortName.Text =  oCurCustomer.ShortName;
            txt_Address.Text = oCurCustomer.Address;
            txt_Address1.Text = oCurCustomer.Address1;
            txt_EName.Text = oCurCustomer.EName;
            txt_EAddress.Text = oCurCustomer.EAddress;            
            txt_Cust_Cert.Text =  oCurCustomer.Cust_Cert;
            txt_Cust_Cert_Type.Text = oCurCustomer.Cust_Cert_Type;
            dt_Cust_Cert_Dated.EditValue =  oCurCustomer.Cust_Cert_Dated;
            txt_Cust_Cert_By.Text = oCurCustomer.Cust_Cert_By;
            txt_Tell.Text = oCurCustomer.Tel;
            txt_Handphone.Text = oCurCustomer.Handphone;
            txt_Tel1.Text = oCurCustomer.Tel1;
            txt_Fax.Text = oCurCustomer.Fax;
            txt_Email.Text = oCurCustomer.Email;
            txt_WebSite.Text = oCurCustomer.Website;
            //if (oCurCustomer.Locked == true) cbo_Locked.SelectedIndex = 0;
            //else cbo_Locked.SelectedIndex = 1;
            //txt_UserCreate.Text = Program.User.User_ID;
            txt_VATCode.Text = oCurCustomer.VATCode;
            oSelectedBranch = Program.FindBranch(oCurCustomer.Branch_ID);
            if (oSelectedBranch != null)
            {
                lookUEdit_BranchID.EditValue = oSelectedBranch.ID;
                txt_BranchName.Text = oSelectedBranch.Name;
            }
            dt_ApprovedTime.EditValue = oCurCustomer.ApprovedTime;
            dt_Last_Date.EditValue = oCurCustomer.LastUpdate;

            if (oCurCustomer.Approved == true) cbo_Approved.SelectedIndex = 0;
            else cbo_Approved.SelectedIndex = 1;
            dt_DateCreated.EditValue = oCurCustomer.DateCreated;

            oSelectedSector = new Account.Common.Entities.Sector_Info();
            oSelectedSector = Program.FindSector(oCurCustomer.Sector);
            if (oSelectedSector != null)            
                lookUEdit_Sector.EditValue = oSelectedSector.ID + "-" + oSelectedSector.Name;

            oSelectedIndustry = new Account.Common.Entities.Industry_Info();
            oSelectedIndustry = Program.FindIndustry(oCurCustomer.Industry);
            if (oSelectedIndustry != null)
                lookUEdit_Industry.EditValue = oSelectedIndustry.ID + "-" + oSelectedIndustry.Name;       
          
        }

        private void Save_Customer()
        {            
            if (oCustomer == null) return;            
            oCustomer.Reference = txt_Ref.Text.Trim();
            oCustomer.Name = txt_Name.Text.Trim();
            oCustomer.FamilyName = txt_FamilyName.Text.Trim();
            oCustomer.ShortName = txt_ShortName.Text.Trim();
            oCustomer.Address = txt_Address.Text.Trim();
            oCustomer.Address1 = txt_Address1.Text.Trim();
            oCustomer.EName = txt_EName.Text.Trim();
            oCustomer.EAddress = txt_EAddress.Text.Trim();
            oCustomer.Cust_Cert = txt_Cust_Cert.Text.Trim();
            oCustomer.Cust_Cert_Type = txt_Cust_Cert_Type.Text.Trim();
            oCustomer.Cust_Cert_Dated = dt_Cust_Cert_Dated.DateTime;
            oCustomer.Cust_Cert_By = txt_Cust_Cert_By.Text.Trim();
            oCustomer.Tel = txt_Tell.Text.Trim();
            oCustomer.Handphone = txt_Handphone.Text.Trim();
            oCustomer.Tel1 = txt_Tel1.Text.Trim();
            oCustomer.Fax = txt_Fax.Text.Trim();
            oCustomer.Email = txt_Email.Text.Trim();
            oCustomer.Website = txt_WebSite.Text.Trim();
           
            
            oCustomer.VATCode = txt_VATCode.Text.Trim();
            oCustomer.Branch_ID = oSelectedBranch.ID;
            
            if (cbo_Approved.SelectedIndex == 0)
            {
                oCustomer.Approved = true;
                oCustomer.ApprovedTime = dt_ApprovedTime.DateTime;
            }
            else oCustomer.Approved = false;
            oCustomer.DateCreated = dt_DateCreated.DateTime;
            oCustomer.LastUpdate = DateTime.Now;
            oCustomer.Sector = oSelectedSector.ID;
            oCustomer.Industry = oSelectedIndustry.ID;

            oCustomer.UserCreate = Program.CurrentUser.User_ID;

            try
            {
                if (Program.eButton == Program.Button.New)
                    Insert_Customer(oCustomer);
                else if (Program.eButton == Program.Button.Edit)
                    Update_Customer(oCustomer);
                else if (Program.eButton == Program.Button.Del)
                    Delete_Customer(oCustomer);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
        }

        private void Insert_Customer(Account.Common.Entities.Customer_Info oCustomer)
        {
            
            oCustomer.ID = Account.UIProviders.UICustomer.GenerateID();
            if (oCustomer.ID == string.Empty)
            {
                MessageBox.Show("Xảy ra lỗi trong quá trình tạo khách hàng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            if (Account.UIProviders.UICustomer.Insert(oCustomer) == 0)
            {
                MessageBox.Show("Thêm mới thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                oCustomer = Account.UIProviders.UICustomer.GetCustomerByID(oCustomer.ID);
                frmCustomerList.lstCustomerInfo.Insert(frmCustomerList.lstCustomerInfo.Count, oCustomer);
                Enable(false);
                Program.eButton = Program.Button.None;
            }
            else
            {
                MessageBox.Show(Account.UIProviders.UICustomer.ValidationMessage, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Enable(true);
            }
        }

        private void Update_Customer(Account.Common.Entities.Customer_Info oCustomer)
        {
            if (Account.UIProviders.UICustomer.Update(oCustomer) == 0)
            {
                MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                frmCustomerList.lstCustomerInfo.Remove(frmCustomerList.oSelectedCustomerInfo);
                frmCustomerList.lstCustomerInfo.Insert(frmCustomerList.lstCustomerInfo.Count, oCustomer);
                Enable(false);
                Program.eButton = Program.Button.None;
            }
            else
            {
                MessageBox.Show(Account.UIProviders.UICustomer.ValidationMessage, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Enable(true);
            }
        }

        private void Delete_Customer(Account.Common.Entities.Customer_Info oCustomer)
        {
            DialogResult dlg = MessageBox.Show("Bạn có thật sự muốn xóa khách hàng có mã " + oCustomer.ID + "  ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlg == DialogResult.Yes)
            {
                if (Account.UIProviders.UICustomer.Delete(oCustomer.ID) == 0)
                {
                    MessageBox.Show("Xóa khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frmCustomerList.lstCustomerInfo.Remove(frmCustomerList.oSelectedCustomerInfo);
                    Enable(false);
                    Program.eButton = Program.Button.None;
                    this.Close();
                }
                else
                {
                    MessageBox.Show(Account.UIProviders.UICustomer.ValidationMessage, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //Enable(true);
                }
            }
            else {
                Program.eButton = Program.Button.None;
                Enable(true);
            }

        }

        private void Clear()
        { 
            txt_ID.Text = string.Empty;
            txt_Ref.Text = string.Empty;
            txt_Name.Text = string.Empty;
            txt_FamilyName.Text = string.Empty;
            txt_ShortName.Text = string.Empty;
            txt_Address.Text = string.Empty;
            txt_Address1.Text = string.Empty;
            txt_EName.Text = string.Empty;
            txt_EAddress.Text = string.Empty;
            txt_Cust_Cert.Text = string.Empty;
            txt_Cust_Cert_Type.Text = string.Empty;
            dt_Cust_Cert_Dated.EditValue = null;
            txt_Cust_Cert_By.Text = string.Empty;
            txt_Tell.Text = string.Empty;
            txt_Handphone.Text = string.Empty;
            txt_Tel1.Text = string.Empty;
            txt_Fax.Text = string.Empty;
            txt_Email.Text = string.Empty;
            txt_WebSite.Text = string.Empty;
            //cbo_Locked.SelectedIndex = 1;
            //txt_UserCreate.Text = Program.CurrentUser.User_ID;

            txt_VATCode.Text = string.Empty;            
            lookUEdit_BranchID.EditValue = string.Empty;
            txt_BranchName.Text = string.Empty;
            dt_ApprovedTime.EditValue = null;
            cbo_Approved.Text = string.Empty;
            dt_DateCreated.EditValue = null;
            dt_Last_Date.EditValue = null;
            lookUEdit_Sector.EditValue = string.Empty;
            lookUEdit_Industry.EditValue = string.Empty;
        }

        private void Enable(bool value)
        {
            txt_ID.Enabled = false;
            txt_Ref.Enabled = value;
            txt_Name.Enabled = value;
            txt_FamilyName.Enabled = value;
            txt_ShortName.Enabled = value;
            txt_Address.Enabled = value;
            txt_Address1.Enabled = value;
            txt_EName.Enabled = value;
            txt_EAddress.Enabled = value;
            txt_Cust_Cert.Enabled = value;
            txt_Cust_Cert_Type.Enabled = value;
            dt_Cust_Cert_Dated.Enabled = value;
            txt_Cust_Cert_By.Enabled = value;
            txt_Tell.Enabled = value;
            txt_Handphone.Enabled = value;
            txt_Tel1.Enabled = value;
            txt_Fax.Enabled = value;
            txt_Email.Enabled = value;
            txt_WebSite.Enabled = value;
            //cbo_Locked.Enabled = value;
            txt_UserCreate.Enabled = false;

            txt_VATCode.Enabled = value;
            lookUEdit_BranchID.Enabled = value;
            txt_BranchName.Enabled = false;
            dt_ApprovedTime.Enabled = false;
            cbo_Approved.Enabled = value;
            dt_DateCreated.Enabled = false;
            dt_Last_Date.Enabled = false;
            lookUEdit_Sector.Enabled = value;
            lookUEdit_Industry.Enabled = value;
            sbtnOK.Enabled = value;
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
                return DialogMess("Bạn chưa nhập tên người dùng!", MessageBoxIcon.Stop, txt_Name);
            if (txt_Cust_Cert.Text.Trim() == string.Empty)
                return DialogMess("Bạn chưa nhập số CMTND/Hộ chiếu", MessageBoxIcon.Stop, txt_Cust_Cert);            
            if (oSelectedBranch == null)
                return DialogMess("Bạn chưa chọn chi nhánh!", MessageBoxIcon.Stop, lookUEdit_BranchID);            
            return true;
        }

        private void sbtnApproved_Click(object sender, EventArgs e)
        {
            if (Account.UIProviders.UICustomer.Approved_Auth(txt_ID.Text) != 0)
            {
                MessageBox.Show(Account.UIProviders.UICustomer.ValidationMessage, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                if (Account.UIProviders.UICustomer.Approved(txt_ID.Text) != 0)
                {
                    MessageBox.Show(Account.UIProviders.UICustomer.ValidationMessage, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else MessageBox.Show("Duyệt hồ sơ khách hàng thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
       
    }
}
