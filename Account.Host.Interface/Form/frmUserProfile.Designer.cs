namespace Account.Host.Interface
{
    partial class frmUserProfile
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
            this.dtLastLogout = new DevExpress.XtraEditors.DateEdit();
            this.grpCtrlInfo = new DevExpress.XtraEditors.GroupControl();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.txt_BranchName = new DevExpress.XtraEditors.TextEdit();
            this.lbl_BranchName = new System.Windows.Forms.Label();
            this.lookUEdit_BranchID = new DevExpress.XtraEditors.LookUpEdit();
            this.lbl_BranchID = new System.Windows.Forms.Label();
            this.dtLastLogin = new DevExpress.XtraEditors.DateEdit();
            this.lbl_LastLogout = new System.Windows.Forms.Label();
            this.lbl_LastLogin = new System.Windows.Forms.Label();
            this.txt_Password = new DevExpress.XtraEditors.TextEdit();
            this.lbl_User_ID = new System.Windows.Forms.Label();
            this.lbl_Password = new System.Windows.Forms.Label();
            this.lbl_FullName = new System.Windows.Forms.Label();
            this.lbl_TID = new System.Windows.Forms.Label();
            this.txt_User_ID = new DevExpress.XtraEditors.TextEdit();
            this.txt_FullName = new DevExpress.XtraEditors.TextEdit();
            this.txt_TID = new DevExpress.XtraEditors.TextEdit();
            this.chk_IsAdmin = new DevExpress.XtraEditors.CheckEdit();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.sbtnOK = new DevExpress.XtraEditors.SimpleButton();
            this.sbtnExit = new DevExpress.XtraEditors.SimpleButton();
            this.sbtnEdit = new DevExpress.XtraEditors.SimpleButton();
            this.sbtnNew = new DevExpress.XtraEditors.SimpleButton();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            //((System.ComponentModel.ISupportInitialize)(this.dtLastLogout.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtLastLogout.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpCtrlInfo)).BeginInit();
            this.grpCtrlInfo.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_BranchName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUEdit_BranchID.Properties)).BeginInit();
            //((System.ComponentModel.ISupportInitialize)(this.dtLastLogin.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtLastLogin.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Password.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_User_ID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_FullName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_TID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chk_IsAdmin.Properties)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtLastLogout
            // 
            this.dtLastLogout.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.dtLastLogout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtLastLogout.EditValue = null;
            this.dtLastLogout.Location = new System.Drawing.Point(477, 96);
            this.dtLastLogout.Name = "dtLastLogout";
            this.dtLastLogout.Properties.AppearanceDisabled.BackColor = System.Drawing.SystemColors.Control;
            this.dtLastLogout.Properties.AppearanceDisabled.Options.UseBackColor = true;
            this.dtLastLogout.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtLastLogout.Properties.EditFormat.FormatString = "dd/MM/yyyy HH:mm:ss";
            this.dtLastLogout.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtLastLogout.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Buffered;
            this.dtLastLogout.Properties.Mask.EditMask = "dd/MM/yyyy HH:mm:ss";
            //this.dtLastLogout.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            //new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtLastLogout.Size = new System.Drawing.Size(168, 20);
            this.dtLastLogout.TabIndex = 15;
            // 
            // grpCtrlInfo
            // 
            this.grpCtrlInfo.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpCtrlInfo.AppearanceCaption.Options.UseFont = true;
            this.grpCtrlInfo.Controls.Add(this.tableLayoutPanel3);
            this.grpCtrlInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpCtrlInfo.Location = new System.Drawing.Point(3, 3);
            this.grpCtrlInfo.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat;
            this.grpCtrlInfo.LookAndFeel.UseDefaultLookAndFeel = false;
            this.grpCtrlInfo.Name = "grpCtrlInfo";
            this.grpCtrlInfo.Size = new System.Drawing.Size(654, 183);
            this.grpCtrlInfo.TabIndex = 0;
            this.grpCtrlInfo.Text = "Thông tin  người sử dụng";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 4;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.txt_BranchName, 3, 2);
            this.tableLayoutPanel3.Controls.Add(this.lbl_BranchName, 2, 2);
            this.tableLayoutPanel3.Controls.Add(this.lookUEdit_BranchID, 1, 2);
            this.tableLayoutPanel3.Controls.Add(this.lbl_BranchID, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.dtLastLogout, 3, 3);
            this.tableLayoutPanel3.Controls.Add(this.dtLastLogin, 1, 3);
            this.tableLayoutPanel3.Controls.Add(this.lbl_LastLogout, 2, 3);
            this.tableLayoutPanel3.Controls.Add(this.lbl_LastLogin, 0, 3);
            this.tableLayoutPanel3.Controls.Add(this.txt_Password, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.lbl_User_ID, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.lbl_Password, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.lbl_FullName, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.lbl_TID, 2, 1);
            this.tableLayoutPanel3.Controls.Add(this.txt_User_ID, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.txt_FullName, 3, 0);
            this.tableLayoutPanel3.Controls.Add(this.txt_TID, 3, 1);
            this.tableLayoutPanel3.Controls.Add(this.chk_IsAdmin, 1, 4);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 21);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 5;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(648, 159);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // txt_BranchName
            // 
            this.txt_BranchName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_BranchName.Location = new System.Drawing.Point(477, 65);
            this.txt_BranchName.Name = "txt_BranchName";
            this.txt_BranchName.Size = new System.Drawing.Size(168, 20);
            this.txt_BranchName.TabIndex = 11;
            // 
            // lbl_BranchName
            // 
            this.lbl_BranchName.AutoSize = true;
            this.lbl_BranchName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_BranchName.Location = new System.Drawing.Point(327, 62);
            this.lbl_BranchName.Name = "lbl_BranchName";
            this.lbl_BranchName.Size = new System.Drawing.Size(144, 31);
            this.lbl_BranchName.TabIndex = 10;
            this.lbl_BranchName.Text = "Tên chi nhánh";
            this.lbl_BranchName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lookUEdit_BranchID
            // 
            this.lookUEdit_BranchID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lookUEdit_BranchID.Location = new System.Drawing.Point(153, 65);
            this.lookUEdit_BranchID.Name = "lookUEdit_BranchID";
            this.lookUEdit_BranchID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUEdit_BranchID.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ID", "ID",15),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name",50)});
            this.lookUEdit_BranchID.Size = new System.Drawing.Size(168, 20);
            this.lookUEdit_BranchID.TabIndex = 9;
            this.lookUEdit_BranchID.EditValueChanged += new System.EventHandler(this.lookUEdit_BranchID_EditValueChanged);
            // 
            // lbl_BranchID
            // 
            this.lbl_BranchID.AutoSize = true;
            this.lbl_BranchID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_BranchID.Location = new System.Drawing.Point(3, 62);
            this.lbl_BranchID.Name = "lbl_BranchID";
            this.lbl_BranchID.Size = new System.Drawing.Size(144, 31);
            this.lbl_BranchID.TabIndex = 8;
            this.lbl_BranchID.Text = "Chi nhánh";
            this.lbl_BranchID.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dtLastLogin
            // 
            this.dtLastLogin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtLastLogin.EditValue = null;
            this.dtLastLogin.Location = new System.Drawing.Point(153, 96);
            this.dtLastLogin.Name = "dtLastLogin";
            this.dtLastLogin.Properties.AppearanceDisabled.BackColor = System.Drawing.SystemColors.Control;
            this.dtLastLogin.Properties.AppearanceDisabled.Options.UseBackColor = true;
            this.dtLastLogin.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtLastLogin.Properties.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss";
            this.dtLastLogin.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtLastLogin.Properties.EditFormat.FormatString = "dd/MM/yyyy HH:mm:ss";
            this.dtLastLogin.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtLastLogin.Properties.Mask.EditMask = "dd/MM/yyyy HH:mm:ss";
            //this.dtLastLogin.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            //new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtLastLogin.ShowToolTips = false;
            this.dtLastLogin.Size = new System.Drawing.Size(168, 20);
            this.dtLastLogin.TabIndex = 13;
            // 
            // lbl_LastLogout
            // 
            this.lbl_LastLogout.AutoSize = true;
            this.lbl_LastLogout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_LastLogout.Location = new System.Drawing.Point(327, 93);
            this.lbl_LastLogout.Name = "lbl_LastLogout";
            this.lbl_LastLogout.Size = new System.Drawing.Size(144, 31);
            this.lbl_LastLogout.TabIndex = 14;
            this.lbl_LastLogout.Text = "Thời gian thoát khỏi hệ thống lần cuối";
            this.lbl_LastLogout.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_LastLogin
            // 
            this.lbl_LastLogin.AutoSize = true;
            this.lbl_LastLogin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_LastLogin.Location = new System.Drawing.Point(3, 93);
            this.lbl_LastLogin.Name = "lbl_LastLogin";
            this.lbl_LastLogin.Size = new System.Drawing.Size(144, 31);
            this.lbl_LastLogin.TabIndex = 12;
            this.lbl_LastLogin.Text = "Thời gian truy cập lần cuối";
            this.lbl_LastLogin.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txt_Password
            // 
            this.txt_Password.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_Password.Location = new System.Drawing.Point(153, 34);
            this.txt_Password.Name = "txt_Password";
            this.txt_Password.Properties.AppearanceDisabled.BackColor = System.Drawing.SystemColors.Control;
            this.txt_Password.Properties.AppearanceDisabled.Options.UseBackColor = true;
            this.txt_Password.Properties.PasswordChar = '*';
            this.txt_Password.Size = new System.Drawing.Size(168, 20);
            this.txt_Password.TabIndex = 5;
            // 
            // lbl_User_ID
            // 
            this.lbl_User_ID.AutoSize = true;
            this.lbl_User_ID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_User_ID.Location = new System.Drawing.Point(3, 0);
            this.lbl_User_ID.Name = "lbl_User_ID";
            this.lbl_User_ID.Size = new System.Drawing.Size(144, 31);
            this.lbl_User_ID.TabIndex = 0;
            this.lbl_User_ID.Text = "Mã truy cập";
            this.lbl_User_ID.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_Password
            // 
            this.lbl_Password.AutoSize = true;
            this.lbl_Password.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_Password.Location = new System.Drawing.Point(3, 31);
            this.lbl_Password.Name = "lbl_Password";
            this.lbl_Password.Size = new System.Drawing.Size(144, 31);
            this.lbl_Password.TabIndex = 4;
            this.lbl_Password.Text = "Mật khẩu";
            this.lbl_Password.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_FullName
            // 
            this.lbl_FullName.AutoSize = true;
            this.lbl_FullName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_FullName.Location = new System.Drawing.Point(327, 0);
            this.lbl_FullName.Name = "lbl_FullName";
            this.lbl_FullName.Size = new System.Drawing.Size(144, 31);
            this.lbl_FullName.TabIndex = 2;
            this.lbl_FullName.Text = "Họ và tên";
            this.lbl_FullName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_TID
            // 
            this.lbl_TID.AutoSize = true;
            this.lbl_TID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_TID.Location = new System.Drawing.Point(327, 31);
            this.lbl_TID.Name = "lbl_TID";
            this.lbl_TID.Size = new System.Drawing.Size(144, 31);
            this.lbl_TID.TabIndex = 6;
            this.lbl_TID.Text = "TID";
            this.lbl_TID.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txt_User_ID
            // 
            this.txt_User_ID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_User_ID.Location = new System.Drawing.Point(153, 3);
            this.txt_User_ID.Name = "txt_User_ID";
            this.txt_User_ID.Properties.AppearanceDisabled.BackColor = System.Drawing.SystemColors.Control;
            this.txt_User_ID.Properties.AppearanceDisabled.Options.UseBackColor = true;
            this.txt_User_ID.Size = new System.Drawing.Size(168, 20);
            this.txt_User_ID.TabIndex = 1;
            // 
            // txt_FullName
            // 
            this.txt_FullName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_FullName.Location = new System.Drawing.Point(477, 3);
            this.txt_FullName.Name = "txt_FullName";
            this.txt_FullName.Size = new System.Drawing.Size(168, 20);
            this.txt_FullName.TabIndex = 3;
            // 
            // txt_TID
            // 
            this.txt_TID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_TID.Location = new System.Drawing.Point(477, 34);
            this.txt_TID.Name = "txt_TID";
            this.txt_TID.Properties.AppearanceDisabled.BackColor = System.Drawing.SystemColors.Control;
            this.txt_TID.Properties.AppearanceDisabled.Options.UseBackColor = true;
            this.txt_TID.Size = new System.Drawing.Size(168, 20);
            this.txt_TID.TabIndex = 7;
            // 
            // chk_IsAdmin
            // 
            this.chk_IsAdmin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chk_IsAdmin.Location = new System.Drawing.Point(153, 127);
            this.chk_IsAdmin.Name = "chk_IsAdmin";
            this.chk_IsAdmin.Properties.Caption = "Là quản trị hệ thống";
            this.chk_IsAdmin.Size = new System.Drawing.Size(168, 19);
            this.chk_IsAdmin.TabIndex = 16;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 5;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 125F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 125F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 125F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 125F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Controls.Add(this.sbtnOK, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.sbtnExit, 4, 0);
            this.tableLayoutPanel2.Controls.Add(this.sbtnEdit, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.sbtnNew, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 192);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(654, 39);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // sbtnOK
            // 
            this.sbtnOK.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sbtnOK.Location = new System.Drawing.Point(407, 3);
            this.sbtnOK.Name = "sbtnOK";
            this.sbtnOK.Size = new System.Drawing.Size(119, 33);
            this.sbtnOK.TabIndex = 2;
            this.sbtnOK.Text = "Đồng ý(Ctrl+S)";
            this.sbtnOK.Click += new System.EventHandler(this.sbtnOK_Click);
            // 
            // sbtnExit
            // 
            this.sbtnExit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sbtnExit.Location = new System.Drawing.Point(532, 3);
            this.sbtnExit.Name = "sbtnExit";
            this.sbtnExit.Size = new System.Drawing.Size(119, 33);
            this.sbtnExit.TabIndex = 3;
            this.sbtnExit.Text = "Thoát(ESC)";
            this.sbtnExit.Click += new System.EventHandler(this.sbtnExit_Click);
            // 
            // sbtnEdit
            // 
            this.sbtnEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sbtnEdit.Location = new System.Drawing.Point(282, 3);
            this.sbtnEdit.Name = "sbtnEdit";
            this.sbtnEdit.Size = new System.Drawing.Size(119, 33);
            this.sbtnEdit.TabIndex = 1;
            this.sbtnEdit.Text = "Sửa(Ctrl+E)";
            this.sbtnEdit.Click += new System.EventHandler(this.sbtnEdit_Click);
            // 
            // sbtnNew
            // 
            this.sbtnNew.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sbtnNew.Location = new System.Drawing.Point(157, 3);
            this.sbtnNew.Name = "sbtnNew";
            this.sbtnNew.Size = new System.Drawing.Size(119, 33);
            this.sbtnNew.TabIndex = 0;
            this.sbtnNew.Text = "Thêm mới(Ctrl+N)";
            this.sbtnNew.Click += new System.EventHandler(this.sbtnNew_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.grpCtrlInfo, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(660, 234);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // frmUserProfile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(660, 234);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "frmUserProfile";
            this.Text = "frmUserProfile";
            this.Load += new System.EventHandler(this.frmUserProfile_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmUserProfile_KeyDown);
            //((System.ComponentModel.ISupportInitialize)(this.dtLastLogout.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtLastLogout.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpCtrlInfo)).EndInit();
            this.grpCtrlInfo.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_BranchName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUEdit_BranchID.Properties)).EndInit();
            //((System.ComponentModel.ISupportInitialize)(this.dtLastLogin.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtLastLogin.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Password.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_User_ID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_FullName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_TID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chk_IsAdmin.Properties)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.DateEdit dtLastLogout;
        private DevExpress.XtraEditors.GroupControl grpCtrlInfo;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private DevExpress.XtraEditors.DateEdit dtLastLogin;
        private System.Windows.Forms.Label lbl_LastLogout;
        private System.Windows.Forms.Label lbl_LastLogin;
        private DevExpress.XtraEditors.TextEdit txt_Password;
        private System.Windows.Forms.Label lbl_User_ID;
        private System.Windows.Forms.Label lbl_Password;
        private System.Windows.Forms.Label lbl_FullName;
        private System.Windows.Forms.Label lbl_TID;
        private DevExpress.XtraEditors.TextEdit txt_User_ID;
        private DevExpress.XtraEditors.TextEdit txt_FullName;
        private DevExpress.XtraEditors.TextEdit txt_TID;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private DevExpress.XtraEditors.SimpleButton sbtnOK;
        private DevExpress.XtraEditors.SimpleButton sbtnExit;
        private DevExpress.XtraEditors.SimpleButton sbtnEdit;
        private DevExpress.XtraEditors.SimpleButton sbtnNew;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lbl_BranchID;
        private DevExpress.XtraEditors.LookUpEdit lookUEdit_BranchID;
        private System.Windows.Forms.Label lbl_BranchName;
        private DevExpress.XtraEditors.TextEdit txt_BranchName;
        private DevExpress.XtraEditors.CheckEdit chk_IsAdmin;
    }
}