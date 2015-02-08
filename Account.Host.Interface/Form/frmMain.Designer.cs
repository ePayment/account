namespace Account.Host.Interface
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mnuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuUserProfileList = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuChangePassword = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuFileExit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTransaction = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTransactionCustomer = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTransactionAccount = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTransactionAccountList = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuTracsactionAccountOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTransactionAccountBlock = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTransactionAccountUnBlock = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTransactionDay = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTool = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuToolSystemParameters = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuToolCategories = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuToolTranCode = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuToolAccount_Roles = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuToolChannels = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuToolCurrency = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuBranch = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHelpContents = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuHelpAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.statusTripMain = new System.Windows.Forms.StatusStrip();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFile,
            this.mnuTransaction,
            this.mnuTool,
            this.mnuHelp});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(758, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mnuFile
            // 
            this.mnuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuUserProfileList,
            this.mnuChangePassword,
            this.toolStripSeparator2,
            this.mnuFileExit});
            this.mnuFile.Name = "mnuFile";
            this.mnuFile.Size = new System.Drawing.Size(69, 20);
            this.mnuFile.Text = "Hệ thống";
            // 
            // mnuUserProfileList
            // 
            this.mnuUserProfileList.Name = "mnuUserProfileList";
            this.mnuUserProfileList.Size = new System.Drawing.Size(195, 22);
            this.mnuUserProfileList.Text = "Quản lý người sử dụng";
            this.mnuUserProfileList.Click += new System.EventHandler(this.mnuUserProfileList_Click);
            // 
            // mnuChangePassword
            // 
            this.mnuChangePassword.Name = "mnuChangePassword";
            this.mnuChangePassword.Size = new System.Drawing.Size(195, 22);
            this.mnuChangePassword.Text = "Đổi mật khẩu";
            this.mnuChangePassword.Click += new System.EventHandler(this.mnuChangePassword_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(192, 6);
            // 
            // mnuFileExit
            // 
            this.mnuFileExit.Name = "mnuFileExit";
            this.mnuFileExit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.mnuFileExit.Size = new System.Drawing.Size(195, 22);
            this.mnuFileExit.Text = "Thoát";
            this.mnuFileExit.Click += new System.EventHandler(this.mnuFileExit_Click);
            // 
            // mnuTransaction
            // 
            this.mnuTransaction.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuTransactionCustomer,
            this.mnuTransactionAccount,
            this.mnuTransactionDay});
            this.mnuTransaction.Name = "mnuTransaction";
            this.mnuTransaction.Size = new System.Drawing.Size(50, 20);
            this.mnuTransaction.Text = "Hồ sơ";
            // 
            // mnuTransactionCustomer
            // 
            this.mnuTransactionCustomer.Name = "mnuTransactionCustomer";
            this.mnuTransactionCustomer.Size = new System.Drawing.Size(176, 22);
            this.mnuTransactionCustomer.Text = "Khách hàng";
            this.mnuTransactionCustomer.Click += new System.EventHandler(this.mnuTransactionCustomer_Click);
            // 
            // mnuTransactionAccount
            // 
            this.mnuTransactionAccount.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuTransactionAccountList,
            this.toolStripMenuItem1,
            this.mnuTracsactionAccountOpen,
            this.mnuTransactionAccountBlock,
            this.mnuTransactionAccountUnBlock});
            this.mnuTransactionAccount.Name = "mnuTransactionAccount";
            this.mnuTransactionAccount.Size = new System.Drawing.Size(176, 22);
            this.mnuTransactionAccount.Text = "Tài khoản";
            // 
            // mnuTransactionAccountList
            // 
            this.mnuTransactionAccountList.Name = "mnuTransactionAccountList";
            this.mnuTransactionAccountList.Size = new System.Drawing.Size(201, 22);
            this.mnuTransactionAccountList.Text = "Danh sách tài khoản";
            this.mnuTransactionAccountList.Click += new System.EventHandler(this.mnuTransactionAccountList_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(198, 6);
            // 
            // mnuTracsactionAccountOpen
            // 
            this.mnuTracsactionAccountOpen.Name = "mnuTracsactionAccountOpen";
            this.mnuTracsactionAccountOpen.Size = new System.Drawing.Size(201, 22);
            this.mnuTracsactionAccountOpen.Text = "Mở mới tài khoản";
            this.mnuTracsactionAccountOpen.Click += new System.EventHandler(this.mnuTracsactionAccountOpen_Click);
            // 
            // mnuTransactionAccountBlock
            // 
            this.mnuTransactionAccountBlock.Name = "mnuTransactionAccountBlock";
            this.mnuTransactionAccountBlock.Size = new System.Drawing.Size(201, 22);
            this.mnuTransactionAccountBlock.Text = "Khóa số dư tài khoản";
            this.mnuTransactionAccountBlock.Click += new System.EventHandler(this.mnuTransactionAccountBLock_Click);
            // 
            // mnuTransactionAccountUnBlock
            // 
            this.mnuTransactionAccountUnBlock.Name = "mnuTransactionAccountUnBlock";
            this.mnuTransactionAccountUnBlock.Size = new System.Drawing.Size(201, 22);
            this.mnuTransactionAccountUnBlock.Text = "Bỏ khóa sổ dư tài khoản";
            this.mnuTransactionAccountUnBlock.Click += new System.EventHandler(this.mnuTransactionAccountUnBlock_Click);
            // 
            // mnuTransactionDay
            // 
            this.mnuTransactionDay.Name = "mnuTransactionDay";
            this.mnuTransactionDay.Size = new System.Drawing.Size(176, 22);
            this.mnuTransactionDay.Text = "Tìm kiếm giao dịch";
            this.mnuTransactionDay.Click += new System.EventHandler(this.mnuTransactionDay_Click);
            // 
            // mnuTool
            // 
            this.mnuTool.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuToolSystemParameters,
            this.toolStripSeparator3,
            this.mnuToolCategories,
            this.mnuToolTranCode,
            this.mnuToolAccount_Roles,
            this.toolStripSeparator4,
            this.mnuToolChannels,
            this.mnuToolCurrency,
            this.toolStripSeparator6,
            this.mnuBranch});
            this.mnuTool.Name = "mnuTool";
            this.mnuTool.Size = new System.Drawing.Size(74, 20);
            this.mnuTool.Text = "Danh mục";
            // 
            // mnuToolSystemParameters
            // 
            this.mnuToolSystemParameters.Name = "mnuToolSystemParameters";
            this.mnuToolSystemParameters.Size = new System.Drawing.Size(223, 22);
            this.mnuToolSystemParameters.Text = "Tham số hệ thống";
            this.mnuToolSystemParameters.Click += new System.EventHandler(this.mnuToolSystemParameters_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(220, 6);
            // 
            // mnuToolCategories
            // 
            this.mnuToolCategories.Name = "mnuToolCategories";
            this.mnuToolCategories.Size = new System.Drawing.Size(223, 22);
            this.mnuToolCategories.Text = "Loại tài khoản";
            this.mnuToolCategories.Click += new System.EventHandler(this.mnuToolCategories_Click);
            // 
            // mnuToolTranCode
            // 
            this.mnuToolTranCode.Name = "mnuToolTranCode";
            this.mnuToolTranCode.Size = new System.Drawing.Size(223, 22);
            this.mnuToolTranCode.Text = "Loại định khoản (hạch toán)";
            this.mnuToolTranCode.Click += new System.EventHandler(this.mnuToolTranCode_Click);
            // 
            // mnuToolAccount_Roles
            // 
            this.mnuToolAccount_Roles.Name = "mnuToolAccount_Roles";
            this.mnuToolAccount_Roles.Size = new System.Drawing.Size(223, 22);
            this.mnuToolAccount_Roles.Text = "Hạn mức định khoản";
            this.mnuToolAccount_Roles.Click += new System.EventHandler(this.mnuToolAccount_Roles_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(220, 6);
            // 
            // mnuToolChannels
            // 
            this.mnuToolChannels.Name = "mnuToolChannels";
            this.mnuToolChannels.Size = new System.Drawing.Size(223, 22);
            this.mnuToolChannels.Text = "Kênh giao dịch";
            this.mnuToolChannels.Click += new System.EventHandler(this.mnuToolChannels_Click);
            // 
            // mnuToolCurrency
            // 
            this.mnuToolCurrency.Name = "mnuToolCurrency";
            this.mnuToolCurrency.Size = new System.Drawing.Size(223, 22);
            this.mnuToolCurrency.Text = "Loại tiền tệ";
            this.mnuToolCurrency.Click += new System.EventHandler(this.mnuToolCurrency_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(220, 6);
            // 
            // mnuBranch
            // 
            this.mnuBranch.Name = "mnuBranch";
            this.mnuBranch.Size = new System.Drawing.Size(223, 22);
            this.mnuBranch.Text = "Chi nhánh";
            this.mnuBranch.Click += new System.EventHandler(this.mnuBranch_Click);
            // 
            // mnuHelp
            // 
            this.mnuHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuHelpContents,
            this.toolStripSeparator5,
            this.mnuHelpAbout});
            this.mnuHelp.Name = "mnuHelp";
            this.mnuHelp.Size = new System.Drawing.Size(64, 20);
            this.mnuHelp.Text = "Trợ giúp";
            // 
            // mnuHelpContents
            // 
            this.mnuHelpContents.Name = "mnuHelpContents";
            this.mnuHelpContents.Size = new System.Drawing.Size(181, 22);
            this.mnuHelpContents.Text = "Nội dung";
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(178, 6);
            // 
            // mnuHelpAbout
            // 
            this.mnuHelpAbout.Name = "mnuHelpAbout";
            this.mnuHelpAbout.Size = new System.Drawing.Size(181, 22);
            this.mnuHelpAbout.Text = "Thông tin sản phẩm";
            // 
            // statusTripMain
            // 
            this.statusTripMain.Location = new System.Drawing.Point(0, 433);
            this.statusTripMain.Name = "statusTripMain";
            this.statusTripMain.Size = new System.Drawing.Size(758, 22);
            this.statusTripMain.TabIndex = 5;
            this.statusTripMain.Text = "statusStrip1";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(758, 455);
            this.Controls.Add(this.statusTripMain);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.KeyPreview = true;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hệ thống quản lý tài khoản";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnuFile;
        private System.Windows.Forms.ToolStripMenuItem mnuUserProfileList;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem mnuFileExit;
        private System.Windows.Forms.ToolStripMenuItem mnuTransaction;
        private System.Windows.Forms.ToolStripMenuItem mnuTransactionCustomer;
        private System.Windows.Forms.ToolStripMenuItem mnuTransactionAccount;
        private System.Windows.Forms.ToolStripMenuItem mnuTransactionDay;
        private System.Windows.Forms.ToolStripMenuItem mnuTool;
        private System.Windows.Forms.ToolStripMenuItem mnuToolSystemParameters;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem mnuToolCategories;
        private System.Windows.Forms.ToolStripMenuItem mnuToolTranCode;
        private System.Windows.Forms.ToolStripMenuItem mnuToolAccount_Roles;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem mnuToolChannels;
        private System.Windows.Forms.ToolStripMenuItem mnuToolCurrency;
        private System.Windows.Forms.ToolStripMenuItem mnuHelp;
        private System.Windows.Forms.ToolStripMenuItem mnuHelpContents;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem mnuHelpAbout;
        private System.Windows.Forms.StatusStrip statusTripMain;
        private System.Windows.Forms.ToolStripMenuItem mnuBranch;
        private System.Windows.Forms.ToolStripMenuItem mnuTransactionAccountList;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem mnuTracsactionAccountOpen;
        private System.Windows.Forms.ToolStripMenuItem mnuTransactionAccountBlock;
        private System.Windows.Forms.ToolStripMenuItem mnuTransactionAccountUnBlock;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem mnuChangePassword;
    }
}