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
    public partial class frmChannel : Form
    {
        
        Account.Common.Entities.Channel_Info oChannelInfo = null;
        Account.Common.Entities.Branches_Info oSelectedBranch = null;
        Account.Common.Entities.Currency_Info oSelectedCcy = null;
        Account.Common.Entities.Categories_Info oSelectedCate = null;
        Account.Common.Entities.Trancode_Info oSelectedTranCode = null;
        Account.Common.Entities.TranCodeDetailFull_Info oSelectedTranCodeDetail = null;

        public frmChannel()
        {
            InitializeComponent();
            
        }       
     
        private void frmChannel_Load(object sender, EventArgs e)
        {
            Program.GetAll_Branch();
            Program.GetAll_Ccy();
            Program.GetAll_Categories();
            Program.GetAll_TranCode();

            cbo_Security.Items.Insert(0, true);
            cbo_Security.Items.Insert(1, false);

            lookUEditBranchID.Properties.Columns[0].FieldName = "ID";
            lookUEditBranchID.Properties.Columns[1].FieldName = "Name";
            lookUEditBranchID.Properties.ValueMember = "ID";
            lookUEditBranchID.Properties.DisplayMember = "ID";
            lookUEditBranchID.Properties.DataSource = Program.lstBranch;
            if (lookUEditBranchID.ItemIndex < 0) lookUEditBranchID.EditValue = string.Empty;

            lookUEdit_Categories.Properties.Columns[0].FieldName = "ID";
            lookUEdit_Categories.Properties.Columns[1].FieldName = "Name";
            lookUEdit_Categories.Properties.ValueMember = "ID";
            lookUEdit_Categories.Properties.DisplayMember = "ID";
            lookUEdit_Categories.Properties.DataSource = Program.lstCategories;
            if (lookUEdit_Categories.ItemIndex < 0) lookUEdit_Categories.EditValue = string.Empty;

            lookUpEdit_Ccy.Properties.Columns[0].FieldName = "Code";
            lookUpEdit_Ccy.Properties.Columns[1].FieldName = "Name";
            lookUpEdit_Ccy.Properties.ValueMember = "Code";
            lookUpEdit_Ccy.Properties.DisplayMember = "Code";
            lookUpEdit_Ccy.Properties.DataSource = Program.lstCcy;
            if (lookUpEdit_Ccy.ItemIndex < 0) lookUpEdit_Ccy.EditValue = string.Empty;

            lue_AddFund.Properties.Columns[0].FieldName = "Code";
            lue_AddFund.Properties.Columns[1].FieldName = "Name";
            lue_AddFund.Properties.ValueMember = "Code";
            lue_AddFund.Properties.DisplayMember = "Code";
            lue_AddFund.Properties.DataSource = Program.lstTranCode;
            if (lue_AddFund.ItemIndex < 0) lue_AddFund.EditValue = string.Empty;

            lue_Retail.Properties.Columns[0].FieldName = "Code";
            lue_Retail.Properties.Columns[1].FieldName = "Name";
            lue_Retail.Properties.ValueMember = "Code";
            lue_Retail.Properties.DisplayMember = "Code";
            lue_Retail.Properties.DataSource = Program.lstTranCode;
            if (lue_Retail.ItemIndex < 0) lue_Retail.EditValue = string.Empty;

            lue_FundTransfer.Properties.Columns[0].FieldName = "Code";
            lue_FundTransfer.Properties.Columns[1].FieldName = "Name";
            lue_FundTransfer.Properties.ValueMember = "Code";
            lue_FundTransfer.Properties.DisplayMember = "Code";
            lue_FundTransfer.Properties.DataSource = Program.lstTranCode;
            if (lue_FundTransfer.ItemIndex < 0) lue_FundTransfer.EditValue = string.Empty;
            
            Detail_Channel(frmChannelList.oSelectedChannel);
            Enable(false);
        }

        private void frmChannel_KeyDown(object sender, KeyEventArgs e)
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


        private void lookUEdit_Categories_EditValueChanged(object sender, EventArgs e)
        {
            if (lookUEdit_Categories.ItemIndex < 0)
            {
                lookUEdit_Categories.EditValue = string.Empty;
                return;
            }
            oSelectedCate = Program.lstCategories[lookUEdit_Categories.ItemIndex];            
        }

        private void sbtnNew_Click(object sender, EventArgs e)
        {
            Program.eButton = Program.Button.New;
            Clear();
            oChannelInfo = new Account.Common.Entities.Channel_Info();
            Enable(true);
            dtCreatedDate.DateTime = DateTime.Now;
            dtLastDate.DateTime = DateTime.Now;
            txt_UserCreate.Text = Program.CurrentUser.User_ID;
            txt_Name.Focus();
        }

        private void sbtnDel_Click(object sender, EventArgs e)
        {
            Program.eButton = Program.Button.Del;
            oChannelInfo = frmChannelList.oSelectedChannel;
            Delete_Channel();
        }
       
        private void sbtnOK_Click(object sender, EventArgs e)
        {
            Save_Channel();
        }

        private void sbtnEdit_Click(object sender, EventArgs e)
        {
            Program.eButton = Program.Button.Edit;
            oChannelInfo = frmChannelList.oSelectedChannel;
            Enable(true);
            dtLastDate.DateTime = DateTime.Now;
            txt_Name.Focus();
        }

        private void sbtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Detail_Channel(Account.Common.Entities.Channel_Info oCurChannel)
        {
            txt_Name.Text = oCurChannel.Name;
            txt_ISOPort.Text = oCurChannel.ISO_Port.ToString();
            txt_ServicePort.Text = oCurChannel.Service_Port.ToString();            
            txt_ListenerHost.Text = oCurChannel.Listener_Host;
            if (!string.IsNullOrEmpty(oCurChannel.Branch))
            {
                oSelectedBranch = Program.FindBranch(oCurChannel.Branch);
                if (oSelectedBranch != null)
                {
                    lookUEditBranchID.EditValue = oSelectedBranch.ID;
                    txt_BranchName.Text = oSelectedBranch.Name;
                }
            }
            txt_UserID.Text = oCurChannel.UserLogin;
            txt_UserCreate.Text = oCurChannel.User_Create;
            lookUpEdit_Ccy.EditValue = oCurChannel.Currency_Code;
            if (oCurChannel.Security == true) cbo_Security.SelectedIndex = 0;
            else cbo_Security.SelectedIndex = 1;            
            dtCreatedDate.DateTime = oCurChannel.Create_Date;

            oSelectedCate = Program.FindCategories(oCurChannel.Categories);
            if (oSelectedCate != null)
                lookUEdit_Categories.EditValue = oSelectedCate.ID;

            oSelectedTranCode = Program.FindTranCode(oCurChannel.AddFund_Trancode);
            if (oSelectedTranCode != null)
                lue_AddFund.EditValue = oSelectedTranCode.Code;

            oSelectedTranCode = Program.FindTranCode(oCurChannel.Retail_Trancode);
            if (oSelectedTranCode != null)
                lue_Retail.EditValue = oSelectedTranCode.Code;

            oSelectedTranCode = Program.FindTranCode(oCurChannel.FundTranfer_Trancode);
            if (oSelectedTranCode != null)
                lue_FundTransfer.EditValue = oSelectedTranCode.Code;
            
            txt_PrivateKey.Text = oCurChannel.Key;
            txt_Descript.Text = oCurChannel.Descript;

            dtLastDate.DateTime = oCurChannel.Last_Date;
            dtCreatedDate.DateTime = oCurChannel.Create_Date;
        }

        private void Save_Channel()
        {
            if (oChannelInfo == null) return;

            oChannelInfo.Name = txt_Name.Text;
            oChannelInfo.Service_Port = Convert.ToInt32(txt_ServicePort.Text.Trim());            
            oChannelInfo.Listener_Host = txt_ListenerHost.Text;
            oChannelInfo.Branch = lookUEditBranchID.Text;
            oChannelInfo.ISO_Port = Convert.ToInt32(txt_ISOPort.Text);
            oChannelInfo.UserLogin = txt_UserID.Text;
            oChannelInfo.Currency_Code = lookUpEdit_Ccy.Text;

            oChannelInfo.AddFund_Trancode = lue_AddFund.Text;
            oChannelInfo.Retail_Trancode = lue_Retail.Text;
            oChannelInfo.FundTranfer_Trancode = lue_FundTransfer.Text;
            
            if (cbo_Security.SelectedIndex == 0) oChannelInfo.Security = true;
            else oChannelInfo.Security = false;                  
            oChannelInfo.Categories = lookUEdit_Categories.Text;

            oChannelInfo.Key = txt_PrivateKey.Text;
            oChannelInfo.Descript = txt_Descript.Text;
            oChannelInfo.User_Create = txt_UserCreate.Text;
            oChannelInfo.Create_Date = DateTime.Now;
            oChannelInfo.Last_Date = DateTime.Now;

            try
            {

                if (Program.eButton == Program.Button.New) Insert_Channel();
                else if (Program.eButton == Program.Button.Edit) Update_Channel();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void Insert_Channel()
        {
            if (Account.UIProviders.UIChannels.Insert(oChannelInfo) == 0)
            {
                Program.eButton = Program.Button.None;
                MessageBox.Show("Thêm mới thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                frmChannelList.lstChannelInfo.Insert(frmChannelList.lstChannelInfo.Count, oChannelInfo);
                Enable(false);
            }
            else
            {
                MessageBox.Show(Account.UIProviders.UIChannels.ValidationMessage, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Enable(true);
            }
        }

        private void Update_Channel()
        {
            if (Account.UIProviders.UIChannels.Update(oChannelInfo) == 0)
            {
                Program.eButton = Program.Button.None;
                MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                frmChannelList.lstChannelInfo.Remove(frmChannelList.oSelectedChannel);
                frmChannelList.lstChannelInfo.Insert(frmChannelList.lstChannelInfo.Count, oChannelInfo);
                Enable(false);
            }
            else
            {
                MessageBox.Show(Account.UIProviders.UIChannels.ValidationMessage, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Enable(true);
            }
        }

        private void Delete_Channel()
        {
            DialogResult dlg = MessageBox.Show("Bạn có muốn xóa kênh giao dịch " + oChannelInfo.Name + "?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlg == DialogResult.Yes)
            {
                if (Account.UIProviders.UIChannels.Delete(oChannelInfo.Name) == 0)
                {
                    MessageBox.Show("Xóa kênh giao dịch thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frmChannelList.lstChannelInfo.Remove(frmChannelList.oSelectedChannel);
                    Program.eButton = Program.Button.None;
                    this.Close();
                }
                else
                {
                    MessageBox.Show(Account.UIProviders.UIChannels.ValidationMessage, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            txt_Name.Text = string.Empty;
            txt_ServicePort.Text = string.Empty;            
            txt_ListenerHost.Text = string.Empty;
            txt_ISOPort.Text = string.Empty;
            lookUEditBranchID.ItemIndex = -1;
            txt_BranchName.Text = string.Empty;
            txt_UserCreate.Text = Program.CurrentUser.User_ID;
            txt_UserID.Text = string.Empty;

            lookUpEdit_Ccy.ItemIndex = -1;
            lue_AddFund.ItemIndex = -1;
            lue_Retail.ItemIndex = -1;
            lue_FundTransfer.ItemIndex = -1;

            cbo_Security.SelectedIndex = -1;
            dtCreatedDate.Text = string.Empty;
            lookUEdit_Categories.ItemIndex = -1;
            
            txt_PrivateKey.Text = string.Empty;
            dtLastDate.EditValue = string.Empty;
            dtCreatedDate.EditValue = string.Empty;
        }

        private void Enable(bool value)
        {
            txt_Name.Enabled = value;
            txt_ISOPort.Enabled = value;
            txt_ServicePort.Enabled = value;            
            txt_ListenerHost.Enabled = value;
            lookUEditBranchID.Enabled = value;
            txt_Descript.Enabled = value;
            txt_UserID.Enabled = value;
            lookUpEdit_Ccy.Enabled = value;
            lookUEdit_Categories.Enabled = value;

            lue_AddFund.Enabled = value;
            lue_FundTransfer.Enabled = value;
            lue_Retail.Enabled = value;
            cbo_Security.Enabled = value;

            txt_BranchName.Enabled = false;
            txt_UserCreate.Enabled = false;
            dtCreatedDate.Enabled = false;
            txt_PrivateKey.Enabled = false;
            dtLastDate.Enabled = false;
        }

        private void cbo_Security_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbo_Security.SelectedIndex == 0) txt_PrivateKey.Enabled = true;
            else txt_PrivateKey.Enabled = false;
        }

    }
}
