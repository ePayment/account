namespace Account.Host.Interface
{
    partial class frmUserProfileList
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
            this.grdCtrlAccountGL = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcolUserID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcolFullName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcolBranchID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcolBranchName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcolLastLogin = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcolLastLogout = new DevExpress.XtraGrid.Columns.GridColumn();
            this.sbtnExit = new DevExpress.XtraEditors.SimpleButton();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.sbtnDetail = new DevExpress.XtraEditors.SimpleButton();
            this.sbtnResetPass = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.grdCtrlAccountGL)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // grdCtrlAccountGL
            // 
            this.grdCtrlAccountGL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdCtrlAccountGL.Location = new System.Drawing.Point(3, 3);
            this.grdCtrlAccountGL.MainView = this.gridView1;
            this.grdCtrlAccountGL.Name = "grdCtrlAccountGL";
            this.grdCtrlAccountGL.Size = new System.Drawing.Size(715, 331);
            this.grdCtrlAccountGL.TabIndex = 0;
            this.grdCtrlAccountGL.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcolUserID,
            this.gcolFullName,
            this.gcolBranchID,
            this.gcolBranchName,
            this.gcolLastLogin,
            this.gcolLastLogout});
            this.gridView1.GridControl = this.grdCtrlAccountGL;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.PaintStyleName = "UltraFlat";
            // 
            // gcolUserID
            // 
            this.gcolUserID.AppearanceHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gcolUserID.AppearanceHeader.Options.UseFont = true;
            this.gcolUserID.AppearanceHeader.Options.UseTextOptions = true;
            this.gcolUserID.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcolUserID.Caption = "UserID";
            this.gcolUserID.Name = "gcolUserID";
            this.gcolUserID.OptionsColumn.FixedWidth = true;
            this.gcolUserID.OptionsColumn.ReadOnly = true;
            this.gcolUserID.Visible = true;
            this.gcolUserID.VisibleIndex = 0;
            this.gcolUserID.Width = 61;
            // 
            // gcolFullName
            // 
            this.gcolFullName.AppearanceHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gcolFullName.AppearanceHeader.Options.UseFont = true;
            this.gcolFullName.AppearanceHeader.Options.UseTextOptions = true;
            this.gcolFullName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcolFullName.Caption = "FullName";
            this.gcolFullName.Name = "gcolFullName";
            this.gcolFullName.OptionsColumn.FixedWidth = true;
            this.gcolFullName.OptionsColumn.ReadOnly = true;
            this.gcolFullName.Visible = true;
            this.gcolFullName.VisibleIndex = 1;
            this.gcolFullName.Width = 125;
            // 
            // gcolBranchID
            // 
            this.gcolBranchID.AppearanceHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gcolBranchID.AppearanceHeader.Options.UseFont = true;
            this.gcolBranchID.AppearanceHeader.Options.UseTextOptions = true;
            this.gcolBranchID.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcolBranchID.Caption = "Mã chi nhánh";
            this.gcolBranchID.Name = "gcolBranchID";
            this.gcolBranchID.OptionsColumn.ReadOnly = true;
            this.gcolBranchID.Visible = true;
            this.gcolBranchID.VisibleIndex = 2;
            this.gcolBranchID.Width = 98;
            // 
            // gcolBranchName
            // 
            this.gcolBranchName.AppearanceHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gcolBranchName.AppearanceHeader.Options.UseFont = true;
            this.gcolBranchName.AppearanceHeader.Options.UseTextOptions = true;
            this.gcolBranchName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcolBranchName.Caption = "Tên chi nhánh";
            this.gcolBranchName.Name = "gcolBranchName";
            this.gcolBranchName.OptionsColumn.ReadOnly = true;
            this.gcolBranchName.Visible = true;
            this.gcolBranchName.VisibleIndex = 3;
            this.gcolBranchName.Width = 106;
            // 
            // gcolLastLogin
            // 
            this.gcolLastLogin.AppearanceHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gcolLastLogin.AppearanceHeader.Options.UseFont = true;
            this.gcolLastLogin.AppearanceHeader.Options.UseTextOptions = true;
            this.gcolLastLogin.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcolLastLogin.Caption = "LastLogin";
            this.gcolLastLogin.Name = "gcolLastLogin";
            this.gcolLastLogin.OptionsColumn.ReadOnly = true;
            this.gcolLastLogin.Visible = true;
            this.gcolLastLogin.VisibleIndex = 4;
            this.gcolLastLogin.Width = 88;
            // 
            // gcolLastLogout
            // 
            this.gcolLastLogout.AppearanceHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gcolLastLogout.AppearanceHeader.Options.UseFont = true;
            this.gcolLastLogout.AppearanceHeader.Options.UseTextOptions = true;
            this.gcolLastLogout.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcolLastLogout.Caption = "LastLogout";
            this.gcolLastLogout.Name = "gcolLastLogout";
            this.gcolLastLogout.OptionsColumn.ReadOnly = true;
            this.gcolLastLogout.Visible = true;
            this.gcolLastLogout.VisibleIndex = 5;
            // 
            // sbtnExit
            // 
            this.sbtnExit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sbtnExit.Location = new System.Drawing.Point(588, 3);
            this.sbtnExit.Name = "sbtnExit";
            this.sbtnExit.Size = new System.Drawing.Size(124, 33);
            this.sbtnExit.TabIndex = 1;
            this.sbtnExit.Text = "Thoát(ESC)";
            this.sbtnExit.Click += new System.EventHandler(this.sbtnExit_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.grdCtrlAccountGL, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(721, 382);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 4;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 130F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 130F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 130F));
            this.tableLayoutPanel2.Controls.Add(this.sbtnExit, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.sbtnDetail, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.sbtnResetPass, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 340);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(715, 39);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // sbtnDetail
            // 
            this.sbtnDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sbtnDetail.Location = new System.Drawing.Point(458, 3);
            this.sbtnDetail.Name = "sbtnDetail";
            this.sbtnDetail.Size = new System.Drawing.Size(124, 33);
            this.sbtnDetail.TabIndex = 0;
            this.sbtnDetail.Text = "Chi tiêt (ENTER)";
            this.sbtnDetail.Click += new System.EventHandler(this.sbtnDetail_Click);
            // 
            // sbtnResetPass
            // 
            this.sbtnResetPass.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sbtnResetPass.Location = new System.Drawing.Point(328, 3);
            this.sbtnResetPass.Name = "sbtnResetPass";
            this.sbtnResetPass.Size = new System.Drawing.Size(124, 33);
            this.sbtnResetPass.TabIndex = 2;
            this.sbtnResetPass.Text = "Reset Password(Ctrl+R)";
            this.sbtnResetPass.Click += new System.EventHandler(this.sbtnResetPass_Click);
            // 
            // frmUserProfileList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(721, 382);
            this.Controls.Add(this.tableLayoutPanel1);
            this.KeyPreview = true;
            this.Name = "frmUserProfileList";
            this.Load += new System.EventHandler(this.frmUserProfileList_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmUserProfileList_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.grdCtrlAccountGL)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grdCtrlAccountGL;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gcolUserID;
        private DevExpress.XtraGrid.Columns.GridColumn gcolFullName;
        private DevExpress.XtraGrid.Columns.GridColumn gcolLastLogout;
        private DevExpress.XtraGrid.Columns.GridColumn gcolBranchID;
        private DevExpress.XtraGrid.Columns.GridColumn gcolBranchName;
        private DevExpress.XtraGrid.Columns.GridColumn gcolLastLogin;
        private DevExpress.XtraEditors.SimpleButton sbtnExit;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private DevExpress.XtraEditors.SimpleButton sbtnDetail;
        private DevExpress.XtraEditors.SimpleButton sbtnResetPass;
    }
}