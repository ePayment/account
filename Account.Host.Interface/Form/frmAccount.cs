using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Account.Host.Interface
{
    public partial class frmAccount : Form
    {
        Account.Common.Entities.Account_Info oAccountInfo = null;
        Account.Common.Entities.Branches_Info oSelectedBranch = null;
        Account.Common.Entities.Customer_Info oSelectedCustomer = null;
        Account.Common.Entities.Categories_Info oSelectedCate = null;
        Account.Common.Entities.Account_GL_Info oSelectedAccountGL = null;
        Account.Common.Entities.Currency_Info oSelectedCcy = null;
        Account.Common.Utilities.AccountType[] arrAccType = (Account.Common.Utilities.AccountType[])Enum.GetValues(typeof(Account.Common.Utilities.AccountType));

        public frmAccount()
        {
            InitializeComponent();
            cbo_Approved.Items.Insert(0, true);
            cbo_Approved.Items.Insert(1, false);

            cbo_Closed.Items.Insert(0, true);
            cbo_Closed.Items.Insert(1, false);
            cbo_CreditDebit.DataSource = arrAccType;
        }

        private void frmAccount_Load(object sender, EventArgs e)
        {
            Program.eButton = Program.Button.None;
            Program.GetAll_Branch();
            Program.GetAll_Account_GL();
            Program.GetAll_Categories();
            Program.GetAll_Ccy();
            //Program.GetAll_Customer();
            cbo_Locked.Items.Insert(0, true);
            cbo_Locked.Items.Insert(1, false);

            lookUEdit_BranchID.Properties.Columns[0].FieldName = "ID";
            lookUEdit_BranchID.Properties.Columns[1].FieldName = "Name";
            lookUEdit_BranchID.Properties.ValueMember = "ID";
            lookUEdit_BranchID.Properties.DisplayMember = "ID";
            lookUEdit_BranchID.Properties.DataSource = Program.lstBranch;
            if (lookUEdit_BranchID.ItemIndex < 0) lookUEdit_BranchID.EditValue = string.Empty;

            lookUEdit_Account_GL.Properties.Columns[0].FieldName = "Account_ID";
            lookUEdit_Account_GL.Properties.Columns[1].FieldName = "Name";
            lookUEdit_Account_GL.Properties.ValueMember = "Account_ID";
            lookUEdit_Account_GL.Properties.DisplayMember = "Account_ID";
            lookUEdit_Account_GL.Properties.DataSource = Program.lstAccountGL;
            if (lookUEdit_Account_GL.ItemIndex < 0) lookUEdit_Account_GL.EditValue = string.Empty;

            lookUEdit_Categories.Properties.Columns[0].FieldName = "ID";
            lookUEdit_Categories.Properties.Columns[1].FieldName = "Name";
            lookUEdit_Categories.Properties.ValueMember = "ID";
            lookUEdit_Categories.Properties.DisplayMember = "ID";
            lookUEdit_Categories.Properties.DataSource = Program.lstCategories;
            if (lookUEdit_Categories.ItemIndex < 0) lookUEdit_Categories.EditValue = string.Empty;

            cbo_Ccy.DataSource = Program.lstCcy;
            cbo_Ccy.ValueMember = "Code";
            cbo_Ccy.DisplayMember = "Name";
            
            Detail_Account(frmAccountList.oSelectedAccount);
            Enable(false);
        }

        private void frmAccount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.D) sbtnDel.PerformClick();
            else if (e.Control && e.KeyCode == Keys.E) sbtnEdit.PerformClick();
            else if (e.Control && e.KeyCode == Keys.S) sbtnOK.PerformClick();
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
        }

        private void sbtnDel_Click(object sender, EventArgs e)
        {
            Program.eButton = Program.Button.Del;
            oAccountInfo = frmAccountList.oSelectedAccount;
            if (MessageBox.Show("Bạn có chắc chắn xóa tài khoản này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (Account.UIProviders.UIAccount.Delete(oAccountInfo.Account_ID) != 0)
                {
                    MessageBox.Show(Account.UIProviders.UIAccount.ValidationMessage, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    frmAccountList.lstAccountInfo.Remove(oAccountInfo);
                    Program.eButton = Program.Button.None;
                    this.Close(); 
                }
            }
        }

        private void sbtnEdit_Click(object sender, EventArgs e)
        {
            Program.eButton = Program.Button.Edit;
            oAccountInfo = frmAccountList.oSelectedAccount;
            if (Account.UIProviders.UIAccount.Update_Auth(oAccountInfo) != 0)
            {
                MessageBox.Show(Account.UIProviders.UIAccount.ValidationMessage, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Enable(true);
            // Chỉ cho phép sửa tên tài khoản.
            txt_Name.Enabled = true;
            txt_Name.Focus();
        }

        private void sbtnOK_Click(object sender, EventArgs e)
        {
            if (CheckValue() == false) return;
            Save_Account();
        }

        private void sbtnExit_Click(object sender, EventArgs e)
        {
            Program.eButton = Program.Button.None;
            this.Close();
        }

        private void Detail_Account(Account.Common.Entities.Account_Info oCurAccount)
        {
            txt_AccountID.Text = oCurAccount.Account_ID;
            txt_Ref.Text = oCurAccount.Reference;
            txt_Name.Text = oCurAccount.Name;
            oSelectedCustomer = Program.FindCustomer(oCurAccount.Customer_ID);
            if (oSelectedCustomer != null)            
                txt_CustomerID.Text = oSelectedCustomer.ID;
            
            oSelectedAccountGL = Program.FindAccount_GL(oCurAccount.Account_GL);
            if (oSelectedAccountGL != null)
            {
                lookUEdit_Account_GL.EditValue = oSelectedAccountGL.Account_ID;
                lookUEdit_Account_GL.Text = oSelectedAccountGL.Name;
            }  
            oSelectedBranch = Program.FindBranch(oCurAccount.Branch_ID);
            if (oSelectedBranch != null)
            {
                lookUEdit_BranchID.EditValue = oSelectedBranch.ID;
                txt_BranchName.Text = oSelectedBranch.Name;
            }          
            dtOpenDate.EditValue = oCurAccount.Open_Date;
            dtLastDate.EditValue = oCurAccount.Last_Date;
            dtApprovedTime.EditValue = oCurAccount.ApprovedTime;
            if (oCurAccount.Approved == true) cbo_Approved.SelectedIndex = 0;
            else cbo_Approved.SelectedIndex = 1;

            dtClosedDate.EditValue = oCurAccount.Closed_date;
            if (oCurAccount.Closed == true) cbo_Closed.SelectedIndex = 0;
            else cbo_Closed.SelectedIndex = 1;
            if (oCurAccount.Locked == true) cbo_Locked.SelectedIndex = 0;
            else cbo_Locked.SelectedIndex = 1;
            oSelectedCate = Program.FindCategories(oCurAccount.Categories);
            if (oSelectedCate != null)
            {
                lookUEdit_Categories.EditValue = oSelectedCate.ID;
                lookUEdit_Categories.Text = oSelectedCate.Name;
            }   
            txt_UserCreate.Text = oCurAccount.UserCreate;

            txt_bCredit.EditValue = oCurAccount.b_Credit;
            for (int i = 0; i < arrAccType.Length; i++)
            {
                if (arrAccType[i].ToString() == oCurAccount.CreditDebit.ToString())
                {
                    cbo_CreditDebit.SelectedIndex = i;
                    break;
                }
            }
            oSelectedCcy = Program.FindCcy(oCurAccount.Ccy);
            if (oSelectedCcy != null)
            {
                cbo_Ccy.SelectedValue = oSelectedCcy;
                cbo_Ccy.SelectedValue = oSelectedCcy.Code;
            }

            txt_dCredit.EditValue = oCurAccount.d_Credit;
            txt_dDebit.EditValue = oCurAccount.d_Debit;
            txt_qCredit.EditValue = oCurAccount.q_Credit;
            txt_qDebit.EditValue = oCurAccount.q_Debit;
            txt_mCredit.EditValue = oCurAccount.m_Credit;
            txt_mDebit.EditValue = oCurAccount.m_Debit;
            txt_yCredit.EditValue = oCurAccount.y_Credit;
            txt_yDebit.EditValue = oCurAccount.y_Debit;
            txt_AmountBlock.EditValue = oCurAccount.Amount_Blocked;
            txt_Bal.EditValue = oCurAccount.Balance;
            txt_BalAvai.EditValue = oCurAccount.BalanceAvaiable;
            if (oCurAccount.Locked == true) sbtnLocked.Text = "Bỏ khóa";
            else sbtnLocked.Text = "Khóa";

        }

        private void Save_Account()
        {
            if (oAccountInfo == null) return;           

            oAccountInfo.Reference = txt_Ref.Text;
            oAccountInfo.Name = txt_Name.Text.Trim();            
            if (oSelectedCustomer != null) 
                oAccountInfo.Customer_ID = oSelectedCustomer.ID;
            if (oSelectedAccountGL != null)
                oAccountInfo.Account_GL = oSelectedAccountGL.Account_ID;            
            if (oSelectedBranch != null)            
                oAccountInfo.Branch_ID = oSelectedBranch.ID;
            ////oAccountInfo.Open_Date = dtOpenDate.DateTime;
            ////oAccountInfo.Last_Date = dtLastDate.DateTime;

            if (cbo_Approved.SelectedIndex == 0)
            {
                oAccountInfo.Approved = true;
                oAccountInfo.ApprovedTime = dtApprovedTime.DateTime;
            }
            else 
            { 
                oAccountInfo.Approved = false;
                oAccountInfo.ApprovedTime = DateTime.MinValue;
            }
            
            if (cbo_Closed.SelectedIndex == 0)
            {
                oAccountInfo.Closed = true;
                oAccountInfo.Closed_date = dtClosedDate.DateTime;
            }
            else oAccountInfo.Closed = false;

            if (oSelectedCate != null)
                oAccountInfo.Categories = oSelectedCate.ID;
            oSelectedCcy = Program.FindCcy(cbo_Ccy.SelectedValue.ToString());
            oAccountInfo.UserCreate = Program.CurrentUser.User_ID;

            if (oSelectedCcy != null)
                oAccountInfo.Ccy = oSelectedCcy.Code;
            try
            {

                if (Program.eButton == Program.Button.Edit) Update_Account();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            this.Close();
        }

        private void Update_Account()
        {
            int result = Account.UIProviders.UIAccount.Update(oAccountInfo);
            if (result == 0)
            {
                MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                int index = frmAccountList.lstAccountInfo.IndexOf(frmAccountList.oSelectedAccount);
                frmAccountList.lstAccountInfo.RemoveAt(index);
                frmAccountList.lstAccountInfo.Insert(index, oAccountInfo);                
                Enable(false);
                Program.eButton = Program.Button.None;
            }
            else
            {
                MessageBox.Show("Cập nhật chưa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Enable(true);
            }
        }

        private void Clear()
        {
            txt_AccountID.Text = string.Empty;
            txt_Ref.Text = string.Empty;
            txt_Name.Text = string.Empty;
            txt_CustomerID.Text = string.Empty; oSelectedCustomer = null;
            lookUEdit_Account_GL.EditValue = string.Empty; oSelectedAccountGL = null;
            lookUEdit_BranchID.EditValue = string.Empty; oSelectedBranch = null;
            txt_BranchName.Enabled = false;
            dtOpenDate.DateTime = System.DateTime.Now;
            dtLastDate.DateTime = System.DateTime.Now;
            dtApprovedTime.Text = string.Empty;
            cbo_Approved.SelectedIndex = 0;
            dtClosedDate.DateTime = System.DateTime.Now;
            cbo_Closed.SelectedIndex = 0;
            cbo_Locked.SelectedIndex = 0;
            cbo_CreditDebit.Text = string.Empty;
            lookUEdit_Categories.EditValue = string.Empty; oSelectedCate = null;
            cbo_Ccy.SelectedIndex = 0;
            txt_UserCreate.Text = Program.CurrentUser.User_ID;

            txt_bCredit.Text = string.Empty;
            txt_dCredit.Text = string.Empty;
            txt_dDebit.Text = string.Empty;
            txt_qCredit.Text = string.Empty;
            txt_qDebit.Text = string.Empty;
            txt_mCredit.Text = string.Empty;
            txt_mDebit.Text = string.Empty;
            txt_yCredit.Text = string.Empty;
            txt_yDebit.Text = string.Empty;
            txt_AmountBlock.Text = string.Empty;
            txt_Bal.Text = string.Empty;
            txt_BalAvai.Text = string.Empty;
        }

        private void Enable(bool value)
        {
            sbtnOK.Enabled = value;
            txt_AccountID.Properties.ReadOnly = true;
            txt_Ref.Enabled = value;
            txt_Name.Enabled = value;
            txt_CustomerID.Properties.ReadOnly = true;
            
            lookUEdit_BranchID.Properties.ReadOnly = true;
            lookUEdit_Categories.Properties.ReadOnly = true;
            lookUEdit_Account_GL.Properties.ReadOnly = true;
            txt_BranchName.Properties.ReadOnly = true;

            dtOpenDate.Properties.ReadOnly = true;
            dtLastDate.Properties.ReadOnly = true;
            dtApprovedTime.Properties.ReadOnly = true;
            cbo_Approved.Enabled = value;
            
            dtClosedDate.Properties.ReadOnly = true;
            cbo_Closed.Enabled = false;
            cbo_Locked.Enabled = false;
            cbo_CreditDebit.Enabled=false;
            
            cbo_Ccy.Enabled = false;
            txt_UserCreate.Properties.ReadOnly = true;

            txt_bCredit.Properties.ReadOnly = true;
            txt_dCredit.Properties.ReadOnly = true;
            txt_dDebit.Properties.ReadOnly = true;
            txt_qCredit.Properties.ReadOnly = true;
            txt_qDebit.Properties.ReadOnly = true;
            txt_mCredit.Properties.ReadOnly = true;
            txt_mDebit.Properties.ReadOnly = true;
            txt_yCredit.Properties.ReadOnly = true;
            txt_yDebit.Properties.ReadOnly = true;
            txt_AmountBlock.Properties.ReadOnly = true;
            txt_Bal.Properties.ReadOnly = true;
            txt_BalAvai.Properties.ReadOnly = true;
        }     

        public bool DialogMess(string strMessage, MessageBoxIcon msgIcon, Control ctrl)
        {
            MessageBox.Show(strMessage, "Thông báo", MessageBoxButtons.OK, msgIcon);
            ctrl.Focus();
            return false;
        }

        private bool CheckValue()
        {
            if (txt_CustomerID.Text.Trim() == string.Empty)
                return DialogMess("Bạn chưa nhập mã khách hàng!", MessageBoxIcon.Stop, txt_CustomerID);
            else
            {
                oSelectedCustomer = Program.FindCustomer(txt_CustomerID.Text.Trim());
                if (oSelectedCustomer == null || oSelectedCustomer.ID == null)
                {
                    return DialogMess("Mã khách hàng chưa đúng!", MessageBoxIcon.Stop, txt_CustomerID);
                }
            }
            if (txt_Name.Text.Trim() == string.Empty)
                return DialogMess("Bạn chưa nhập tên tài khoản!", MessageBoxIcon.Stop, txt_Name);
            if (oSelectedAccountGL == null)
                return DialogMess("Bạn chưa chọn sổ cái!", MessageBoxIcon.Stop, lookUEdit_Account_GL);
            if (oSelectedCate == null)
                return DialogMess("Bạn chưa chọn Categories!", MessageBoxIcon.Stop, lookUEdit_Categories);
            //if (dtOpenDate.DateTime == null || dtOpenDate.Text.Trim() == string.Empty)
            //    return DialogMess("Bạn chưa chọn thời gian mở tài khoản!", MessageBoxIcon.Stop, dtOpenDate);
            //if (dtClosedDate.DateTime == null || dtClosedDate.Text.Trim() == string.Empty)
            //    return DialogMess("Bạn chưa chọn ngày đóng hồ sơ!", MessageBoxIcon.Stop, dtClosedDate);
            //if (dtLastDate.DateTime == null || dtLastDate.Text.Trim() == string.Empty)
            //    return DialogMess("Bạn chưa chọn ngày cuối cùng cập nhật hồ sơ!", MessageBoxIcon.Stop, dtLastDate);
            //if (dtLastDate.DateTime < dtOpenDate.DateTime)
            //    return DialogMess("Thời gian cập nhật cuối cùng chưa phù hợp!", MessageBoxIcon.Stop, dtLastDate);
            //if (dtApprovedTime.DateTime != null && dtApprovedTime.DateTime >= dtOpenDate.DateTime)
            //    return DialogMess("Thời gian phê duyệt không hợp lệ!", MessageBoxIcon.Stop, dtApprovedTime);
            if (cbo_Approved.SelectedIndex < 0)
                return DialogMess("Bạn chưa chọn trạng thái phê duyệt tài khoản!", MessageBoxIcon.Stop, cbo_Approved);
            if (oSelectedCustomer == null)
                return DialogMess("Bạn chưa chọn khách hàng!", MessageBoxIcon.Stop, txt_CustomerID);            
            if (oSelectedBranch == null)
                return DialogMess("Bạn chưa chọn chi nhánh!", MessageBoxIcon.Stop, lookUEdit_Account_GL);            
            if (oSelectedCcy == null)
                return DialogMess("Bạn chưa chọn loại tiền tệ!", MessageBoxIcon.Stop, cbo_Ccy);
           
            return true;
        }
       
        private void lookUEdit_Account_GL_EditValueChanged(object sender, EventArgs e)
        {
            if (lookUEdit_Account_GL.ItemIndex < 0)
            {
                lookUEdit_Account_GL.EditValue = string.Empty;
                return;
            }
            oSelectedAccountGL = Program.lstAccountGL[lookUEdit_Account_GL.ItemIndex];   
        }

        private void lookUEdit_Categories_EditValueChanged(object sender, EventArgs e)
        {
            if (lookUEdit_Categories.ItemIndex < 0)
            {
                lookUEdit_Categories.EditValue = string.Empty;
                return;
            }
            oSelectedCate = Program.lstCategories[lookUEdit_Categories.ItemIndex];
            lookUEdit_Account_GL.EditValue = oSelectedCate.Account_GL.Account_ID;
            cbo_Ccy.Text = oSelectedCate.Account_GL.Ccy;
            cbo_CreditDebit.Text = oSelectedCate.Account_GL.CreditDebit.ToString();
        }

        private void cbo_Approved_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbo_Approved.SelectedIndex == 0) dtApprovedTime.DateTime = DateTime.Now;
            else dtApprovedTime.DateTime = DateTime.MinValue;
        }

        private void cbo_Closed_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbo_Closed.SelectedIndex == 0) dtClosedDate.DateTime = DateTime.Now;
            else dtClosedDate.DateTime = DateTime.MinValue;

        }

        private void txt_CustomerID_LostFocus(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_CustomerID.Text))
                return;
            else
            {
                oSelectedCustomer = Program.FindCustomer(txt_CustomerID.Text);
                if (oSelectedCustomer == null)
                {
                    DialogMess("Mã khách hàng không có", MessageBoxIcon.Error, txt_CustomerID);
                }
                else
                    txt_Name.Text = oSelectedCustomer.Name;
            }
        }

        private void sbtnApproved_Click(object sender, EventArgs e)
        {
            oAccountInfo = frmAccountList.oSelectedAccount;
            if (Account.UIProviders.UIAccount.Approved_Auth(oAccountInfo.Account_ID) != 0)
            {
                MessageBox.Show(Account.UIProviders.UIAccount.ValidationMessage, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                if (MessageBox.Show("Bạn có chắc chắn duyệt tài khoản này không?","Thông báo",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
                {
                    if (Account.UIProviders.UIAccount.Approved(oAccountInfo.Account_ID) == 0)
                    {
                        MessageBox.Show("Tài khoản đã duyệt xong\n Bạn có thể định khoản", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        int index = frmAccountList.lstAccountInfo.IndexOf(frmAccountList.oSelectedAccount);
                        frmAccountList.lstAccountInfo.RemoveAt(index);
                        oAccountInfo.Approved = true;
                        frmAccountList.lstAccountInfo.Insert(index, oAccountInfo);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show(Account.UIProviders.UIAccount.ValidationMessage, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
        }

        private void sbtnLocked_Click(object sender, EventArgs e)
        {
            oAccountInfo = frmAccountList.oSelectedAccount;
            if (oAccountInfo.Locked == false)
            {
                if (Account.UIProviders.UIAccount.Lock_Auth(oAccountInfo.Account_ID) != 0)
                {
                    MessageBox.Show(Account.UIProviders.UIAccount.ValidationMessage, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    if (MessageBox.Show("Bạn có chắc chắn tạm khóa khoản này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (Account.UIProviders.UIAccount.Lock(oAccountInfo.Account_ID) == 0)
                        {
                            MessageBox.Show("Tài khoản đã khóa xong\n Để định khoản lại được bạn cần bỏ khóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            int index = frmAccountList.lstAccountInfo.IndexOf(frmAccountList.oSelectedAccount);
                            frmAccountList.lstAccountInfo.RemoveAt(index);
                            oAccountInfo.Locked = true;
                            frmAccountList.lstAccountInfo.Insert(index, oAccountInfo);
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show(Account.UIProviders.UIAccount.ValidationMessage, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                }
            }
            else 
            {
                if (Account.UIProviders.UIAccount.UnLock_Auth(oAccountInfo.Account_ID) != 0)
                {
                    MessageBox.Show(Account.UIProviders.UIAccount.ValidationMessage, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    if (MessageBox.Show("Bạn có chắc chắn bỏ khóa khoản này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (Account.UIProviders.UIAccount.UnLock(oAccountInfo.Account_ID) == 0)
                        {
                            MessageBox.Show("Tài khoản đã được bỏ khóa xong\n Bạn đã có thể định khoản được", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            int index = frmAccountList.lstAccountInfo.IndexOf(frmAccountList.oSelectedAccount);
                            frmAccountList.lstAccountInfo.RemoveAt(index);
                            oAccountInfo.Locked = false;
                            frmAccountList.lstAccountInfo.Insert(index, oAccountInfo);
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show(Account.UIProviders.UIAccount.ValidationMessage, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                }
            }
        }

        private void sbtnClose_Click(object sender, EventArgs e)
        {

            oAccountInfo = frmAccountList.oSelectedAccount;
            if (Account.UIProviders.UIAccount.Close_Auth(oAccountInfo.Account_ID) != 0)
            {
                MessageBox.Show(Account.UIProviders.UIAccount.ValidationMessage, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                if (MessageBox.Show("Bạn có chắc chắn đóng tài khoản này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (Account.UIProviders.UIAccount.Close(oAccountInfo.Account_ID) == 0)
                    {
                        MessageBox.Show("Tài khoản đã đóng xong\n", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        int index = frmAccountList.lstAccountInfo.IndexOf(frmAccountList.oSelectedAccount);
                        frmAccountList.lstAccountInfo.RemoveAt(index);
                        oAccountInfo.Closed = true;
                        frmAccountList.lstAccountInfo.Insert(index, oAccountInfo);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show(Account.UIProviders.UIAccount.ValidationMessage, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
        }

    }
}
