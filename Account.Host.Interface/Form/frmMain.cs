using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

//using System.Net;
//using System.ServiceModel;
//using System.ServiceModel.Description;

using Account.Common.Entities;
using Account.Host;


using log4net;
[assembly: log4net.Config.XmlConfigurator(Watch = true)]
namespace Account.Host.Interface
{
    public partial class frmMain : Form
    {    
        ILog logger;
        public frmMain()
        {
            InitializeComponent();
            logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        }
        private void frmMain_Load(object sender, EventArgs e) {}
        private List<Form> m_lstForm = null;
        public List<Form> LstForm
        {
            get {
                if (m_lstForm == null) m_lstForm = new List<Form>();
                frmAccount ofrmAccount = null; m_lstForm.Add(ofrmAccount);
                frmAccountGL ofrmAccountGL = null; m_lstForm.Add(ofrmAccountGL);
                frmAccountGLList ofrmAccountGLList = null; m_lstForm.Add(ofrmAccountGLList);
                frmAccountList ofrmAccountList = null; m_lstForm.Add(ofrmAccountList);
                frmAccountRole ofrmAccountRole = null; m_lstForm.Add(ofrmAccountRole);
                frmAccountRoleList ofrmAccountRoleList = null; m_lstForm.Add(ofrmAccountRoleList);
                frmBranchList ofrmBranchList = null; m_lstForm.Add(ofrmBranchList);
                frmCategoryList ofrmCategoryList = null; m_lstForm.Add(ofrmCategoryList);
                frmChannel ofrmChannel = null; m_lstForm.Add(ofrmChannel);
                frmChannelList ofrmChannelList = null; m_lstForm.Add(ofrmChannelList);
                frmCustomer ofrmCustomer = null; m_lstForm.Add(ofrmCustomer);
                frmCustomerList ofrmCustomerList = null; m_lstForm.Add(ofrmCustomerList);
                frmEndOfDay ofrmEndOfDay = null; m_lstForm.Add(ofrmEndOfDay);
                frmLogin ofrmLogin = null; m_lstForm.Add(ofrmLogin);
                frmMain ofrmMain = null; m_lstForm.Add(ofrmMain);
                //frmParameter ofrmParameter = null; m_lstForm.Add(ofrmParameter);
                frmParameterList ofrmParameterList = null; m_lstForm.Add(ofrmParameterList);
                frmTranCodeList ofrmTranCodeList = null; m_lstForm.Add(ofrmTranCodeList);
                frmTransactionFilter ofrmTransaction = null; m_lstForm.Add(ofrmTransaction);

                //m_lstForm.Add(ofrmAccount,
                // ofrmAccountGL,
                // ofrmAccountGLList,
                // ofrmAccountList,
                // ofrmAccountRole,
                // ofrmAccountRoleList,
                // ofrmBegin,
                // ofrmBranch,
                // ofrmBranchList,
                // ofrmCategoryList,
                // ofrmChannel,
                // ofrmChannelList,
                // ofrmCustomer,
                // ofrmCustomerList,
                // ofrmEndOfDay,
                // ofrmLogin,
                // ofrmMain,
                // ofrmParameter,
                // ofrmParameterList,
                // ofrmTranCodeList,
                // ofrmTransaction);


                return m_lstForm; 
            }
            set { m_lstForm = value; }
        }

        #region He thong...

        private void mnuFileExit_Click(object sender, EventArgs e)
        {
            DialogResult dlg = MessageBox.Show("Bạn muốn thoát khỏi chương trình?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlg == DialogResult.Yes)
            {
                if (Account.UIProviders.UIUser.Logout(Program.CurrentUser.User_ID) == 0)
                    this.Close();
                else
                {
                    MessageBox.Show(Account.UIProviders.UIUser.ValidationMessage, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else return;
        }

        #endregion 

        #region Ho So...

        private void mnuTransactionCustomer_Click(object sender, EventArgs e)
        {
            if (frmCustomerList.CurrentInstance != null)
            {
                frmCustomerList.CurrentInstance.Close();
                frmCustomerList.CurrentInstance.Dispose();
            }
            frmCustomerList ofrm = frmCustomerList.CurrentInstance;
            ofrm.MdiParent = this;
            ofrm.Show();          
        }
        
        private void mnuTransactionDay_Click(object sender, EventArgs e)
        {
            frmTransactionFilter ofrm = new frmTransactionFilter();
            ofrm.ShowDialog();
        }
        #endregion     

        private void mnuToolChannels_Click(object sender, EventArgs e)
        {
            if (frmChannelList.CurrentInstance != null)
            {
                frmChannelList.CurrentInstance.Close();
                frmChannelList.CurrentInstance.Dispose();
            }            
                frmChannelList ofrm = frmChannelList.CurrentInstance;
                ofrm.MdiParent = this;
                ofrm.Show();
        }

        private void mnuToolSystemParameters_Click(object sender, EventArgs e)
        {
            if (frmParameterList.CurrentInstance != null)
            {
                frmParameterList.CurrentInstance.Close();
                frmParameterList.CurrentInstance.Dispose();
            }
            frmParameterList ofrm = frmParameterList.CurrentInstance;
            ofrm.MdiParent = this;
            ofrm.Show();
        }

        private void mnuToolCategories_Click(object sender, EventArgs e)
        {
            if (frmCategoryList.CurrentInstance != null)
            {
                frmCategoryList.CurrentInstance.Close();
                frmCategoryList.CurrentInstance.Dispose();
            }
            frmCategoryList ofrm = frmCategoryList.CurrentInstance;
            ofrm.MdiParent = this;
            ofrm.Show();           
        }

        private void mnuToolTranCode_Click(object sender, EventArgs e)
        {
            if (frmTranCodeList.CurrentInstance != null)
            {
                frmTranCodeList.CurrentInstance.Close();
                frmTranCodeList.CurrentInstance.Dispose();
            }
            frmTranCodeList ofrm = frmTranCodeList.CurrentInstance;
            ofrm.MdiParent = this;
            ofrm.Show();     
        }

        private void mnuToolAccount_Roles_Click(object sender, EventArgs e)
        {
            if (frmAccountRoleList.CurrentInstance != null)
            {
                frmAccountRoleList.CurrentInstance.Close();
                frmAccountRoleList.CurrentInstance.Dispose();
            }
            frmAccountRoleList ofrm = frmAccountRoleList.CurrentInstance;
            ofrm.MdiParent = this;
            ofrm.Show();                 
        }

        private void mnuToolAccount_GL_Click(object sender, EventArgs e)
        {
            if (frmAccountGLList.CurrentInstance != null)
            {
                frmAccountGLList.CurrentInstance.Close();
                frmAccountGLList.CurrentInstance.Dispose();
            }
            frmAccountGLList ofrm = frmAccountGLList.CurrentInstance;
            ofrm.MdiParent = this;
            ofrm.Show();  
           
        }

        private void mnuTransactionAccountList_Click(object sender, EventArgs e)
        {
            if (frmAccountList.CurrentInstance != null)
            {
                frmAccountList.CurrentInstance.Close();
                frmAccountList.CurrentInstance.Dispose();
            }
            frmAccountList ofrm = frmAccountList.CurrentInstance;
            ofrm.MdiParent = this;
            ofrm.Show();     
        }

        private void mnuTracsactionAccountOpen_Click(object sender, EventArgs e)
        {
            if (frmAccountOpen.CurrentInstance != null)
            {
                frmAccountOpen.CurrentInstance.Close();
                frmAccountOpen.CurrentInstance.Dispose();
            }
            frmAccountOpen ofrm = frmAccountOpen.CurrentInstance;
            ofrm.ShowDialog();
        }

        private void mnuTransactionAccountBLock_Click(object sender, EventArgs e)
        {
            frmAccountBlock ofrm = new frmAccountBlock();
            ofrm.Mode = true;
            ofrm.ShowDialog();
        }

        private void mnuTransactionAccountUnBlock_Click(object sender, EventArgs e)
        {
            frmAccountBlock ofrm = new frmAccountBlock();
            ofrm.Mode = false;
            ofrm.ShowDialog();
        }

        private void mnuToolCurrency_Click(object sender, EventArgs e)
        {
            if (frmCurrencyList.CurrentInstance != null)
            {
                frmCurrencyList.CurrentInstance.Close();
                frmCurrencyList.CurrentInstance.Dispose();
            }
            frmCurrencyList ofrm = frmCurrencyList.CurrentInstance;
            ofrm.MdiParent = this;
            ofrm.Show();
        }
        
        private void mnuBranch_Click(object sender, EventArgs e)
        {
            if (frmBranchList.CurrentInstance != null)
            {
                frmBranchList.CurrentInstance.Close();
                frmBranchList.CurrentInstance.Dispose();
            }
            frmBranchList ofrm = frmBranchList.CurrentInstance;
            ofrm.MdiParent = this;
            ofrm.Show();

        }

        private void mnuUserProfileList_Click(object sender, EventArgs e)
        {
            if (Program.CurrentUser.IsAdministrator == false)
            {
                MessageBox.Show("Bạn không được phép sử dụng chức năng này", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (frmUserProfileList.CurrentInstance != null)
            {
                frmUserProfileList.CurrentInstance.Close();
                frmUserProfileList.CurrentInstance.Dispose();
            }
            frmUserProfileList ofrm = frmUserProfileList.CurrentInstance;
            ofrm.MdiParent = this;
            ofrm.Show();
        }

        private void mnuChangePassword_Click(object sender, EventArgs e)
        {
            frmUserPassword ofrm = new frmUserPassword();
            ofrm.ShowDialog();
        }
    }
}

