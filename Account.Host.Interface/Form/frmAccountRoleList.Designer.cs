namespace Account.Host.Interface
{
    partial class frmAccountRoleList
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
            this.grdCtrlAccountRole = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcolID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcolName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcolAccountID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcolType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcolOperator = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcolValue = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcolSeq = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcolActive = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcolActiveDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.sbtnDetail = new DevExpress.XtraEditors.SimpleButton();
            this.sbtnExit = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.grdCtrlAccountRole)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // grdCtrlAccountRole
            // 
            this.grdCtrlAccountRole.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdCtrlAccountRole.Location = new System.Drawing.Point(3, 3);
            this.grdCtrlAccountRole.MainView = this.gridView1;
            this.grdCtrlAccountRole.Name = "grdCtrlAccountRole";
            this.grdCtrlAccountRole.Size = new System.Drawing.Size(690, 360);
            this.grdCtrlAccountRole.TabIndex = 0;
            this.grdCtrlAccountRole.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridView1.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridView1.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gridView1.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcolID,
            this.gcolName,
            this.gcolAccountID,
            this.gcolType,
            this.gcolOperator,
            this.gcolValue,
            this.gcolSeq,
            this.gcolActive,
            this.gcolActiveDate});
            this.gridView1.GridControl = this.grdCtrlAccountRole;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.PaintStyleName = "UltraFlat";
            // 
            // gcolID
            // 
            this.gcolID.Caption = "ID";
            this.gcolID.Name = "gcolID";
            this.gcolID.OptionsColumn.ReadOnly = true;
            this.gcolID.Visible = true;
            this.gcolID.VisibleIndex = 0;
            this.gcolID.Width = 40;
            // 
            // gcolName
            // 
            this.gcolName.AppearanceHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gcolName.AppearanceHeader.Options.UseFont = true;
            this.gcolName.AppearanceHeader.Options.UseTextOptions = true;
            this.gcolName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcolName.Caption = "Tên điều kiện";
            this.gcolName.Name = "gcolName";
            this.gcolName.OptionsColumn.FixedWidth = true;
            this.gcolName.OptionsColumn.ReadOnly = true;
            this.gcolName.Visible = true;
            this.gcolName.VisibleIndex = 2;
            this.gcolName.Width = 150;
            // 
            // gcolAccountID
            // 
            this.gcolAccountID.AppearanceHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gcolAccountID.AppearanceHeader.Options.UseFont = true;
            this.gcolAccountID.AppearanceHeader.Options.UseTextOptions = true;
            this.gcolAccountID.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcolAccountID.Caption = "Mã tài khoản";
            this.gcolAccountID.Name = "gcolAccountID";
            this.gcolAccountID.OptionsColumn.ReadOnly = true;
            this.gcolAccountID.Visible = true;
            this.gcolAccountID.VisibleIndex = 1;
            this.gcolAccountID.Width = 57;
            // 
            // gcolType
            // 
            this.gcolType.AppearanceHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gcolType.AppearanceHeader.Options.UseFont = true;
            this.gcolType.AppearanceHeader.Options.UseTextOptions = true;
            this.gcolType.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcolType.Caption = "Loại điều kiện";
            this.gcolType.Name = "gcolType";
            this.gcolType.OptionsColumn.ReadOnly = true;
            this.gcolType.Visible = true;
            this.gcolType.VisibleIndex = 3;
            this.gcolType.Width = 72;
            // 
            // gcolOperator
            // 
            this.gcolOperator.Caption = "Toán tử";
            this.gcolOperator.Name = "gcolOperator";
            this.gcolOperator.OptionsColumn.ReadOnly = true;
            this.gcolOperator.Visible = true;
            this.gcolOperator.VisibleIndex = 4;
            this.gcolOperator.Width = 47;
            // 
            // gcolValue
            // 
            this.gcolValue.AppearanceHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gcolValue.AppearanceHeader.Options.UseFont = true;
            this.gcolValue.AppearanceHeader.Options.UseTextOptions = true;
            this.gcolValue.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcolValue.Caption = "Giá trị";
            this.gcolValue.Name = "gcolValue";
            this.gcolValue.OptionsColumn.ReadOnly = true;
            this.gcolValue.Visible = true;
            this.gcolValue.VisibleIndex = 5;
            this.gcolValue.Width = 74;
            // 
            // gcolSeq
            // 
            this.gcolSeq.Caption = "STT";
            this.gcolSeq.Name = "gcolSeq";
            this.gcolSeq.OptionsColumn.ReadOnly = true;
            this.gcolSeq.Visible = true;
            this.gcolSeq.VisibleIndex = 6;
            this.gcolSeq.Width = 47;
            // 
            // gcolActive
            // 
            this.gcolActive.AppearanceHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gcolActive.AppearanceHeader.Options.UseFont = true;
            this.gcolActive.AppearanceHeader.Options.UseTextOptions = true;
            this.gcolActive.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcolActive.Caption = "Hiệu lực";
            this.gcolActive.Name = "gcolActive";
            this.gcolActive.OptionsColumn.FixedWidth = true;
            this.gcolActive.OptionsColumn.ReadOnly = true;
            this.gcolActive.Visible = true;
            this.gcolActive.VisibleIndex = 7;
            this.gcolActive.Width = 50;
            // 
            // gcolActiveDate
            // 
            this.gcolActiveDate.Caption = "Ngày hiệu lực";
            this.gcolActiveDate.Name = "gcolActiveDate";
            this.gcolActiveDate.OptionsColumn.ReadOnly = true;
            this.gcolActiveDate.Visible = true;
            this.gcolActiveDate.VisibleIndex = 8;
            this.gcolActiveDate.Width = 171;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.grdCtrlAccountRole, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(696, 411);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 125F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 125F));
            this.tableLayoutPanel2.Controls.Add(this.sbtnDetail, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.sbtnExit, 2, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 369);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 39F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(690, 39);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // sbtnDetail
            // 
            this.sbtnDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sbtnDetail.Location = new System.Drawing.Point(443, 3);
            this.sbtnDetail.Name = "sbtnDetail";
            this.sbtnDetail.Size = new System.Drawing.Size(119, 33);
            this.sbtnDetail.TabIndex = 0;
            this.sbtnDetail.Text = "Chi tiết (ENTER)";
            this.sbtnDetail.Click += new System.EventHandler(this.sbtnDetail_Click);
            // 
            // sbtnExit
            // 
            this.sbtnExit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sbtnExit.Location = new System.Drawing.Point(568, 3);
            this.sbtnExit.Name = "sbtnExit";
            this.sbtnExit.Size = new System.Drawing.Size(119, 33);
            this.sbtnExit.TabIndex = 1;
            this.sbtnExit.Text = "Thoát(ESC)";
            this.sbtnExit.Click += new System.EventHandler(this.sbtnExit_Click);
            // 
            // frmAccountRoleList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(696, 411);
            this.Controls.Add(this.tableLayoutPanel1);
            this.KeyPreview = true;
            this.Name = "frmAccountRoleList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Danh sách điều kiện định khoản";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmAccountRoleList_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmAccountRoleList_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.grdCtrlAccountRole)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grdCtrlAccountRole;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gcolName;
        private DevExpress.XtraGrid.Columns.GridColumn gcolAccountID;
        private DevExpress.XtraGrid.Columns.GridColumn gcolType;
        private DevExpress.XtraGrid.Columns.GridColumn gcolValue;
        private DevExpress.XtraGrid.Columns.GridColumn gcolActive;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private DevExpress.XtraEditors.SimpleButton sbtnDetail;
        private DevExpress.XtraEditors.SimpleButton sbtnExit;
        private DevExpress.XtraGrid.Columns.GridColumn gcolID;
        private DevExpress.XtraGrid.Columns.GridColumn gcolOperator;
        private DevExpress.XtraGrid.Columns.GridColumn gcolSeq;
        private DevExpress.XtraGrid.Columns.GridColumn gcolActiveDate;
    }
}