namespace Account.Host.Interface
{
    partial class frmAccountList
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
            this.gcolName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.sbtnDetail = new DevExpress.XtraEditors.SimpleButton();
            this.sbtnExit = new DevExpress.XtraEditors.SimpleButton();
            this.grdCtrlAccountGL = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcolID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcolRef = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcolCustomer = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcolCategories = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcolBranchID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcolApproved = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcolLock = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcolClose = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdCtrlAccountGL)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // gcolName
            // 
            this.gcolName.AppearanceHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gcolName.AppearanceHeader.Options.UseFont = true;
            this.gcolName.AppearanceHeader.Options.UseTextOptions = true;
            this.gcolName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcolName.Caption = "Tên tài khoản";
            this.gcolName.Name = "gcolName";
            this.gcolName.OptionsColumn.ReadOnly = true;
            this.gcolName.Visible = true;
            this.gcolName.VisibleIndex = 1;
            this.gcolName.Width = 150;
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
            this.tableLayoutPanel1.Size = new System.Drawing.Size(778, 502);
            this.tableLayoutPanel1.TabIndex = 3;
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
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 460);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 39F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(772, 39);
            this.tableLayoutPanel2.TabIndex = 4;
            // 
            // sbtnDetail
            // 
            this.sbtnDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sbtnDetail.Location = new System.Drawing.Point(525, 3);
            this.sbtnDetail.Name = "sbtnDetail";
            this.sbtnDetail.Size = new System.Drawing.Size(119, 33);
            this.sbtnDetail.TabIndex = 1;
            this.sbtnDetail.Text = "Chi tiêt (Enter)";
            this.sbtnDetail.Click += new System.EventHandler(this.sbtnDetail_Click);
            // 
            // sbtnExit
            // 
            this.sbtnExit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sbtnExit.Location = new System.Drawing.Point(650, 3);
            this.sbtnExit.Name = "sbtnExit";
            this.sbtnExit.Size = new System.Drawing.Size(119, 33);
            this.sbtnExit.TabIndex = 2;
            this.sbtnExit.Text = "Thoát(ESC)";
            this.sbtnExit.Click += new System.EventHandler(this.sbtnExit_Click);
            // 
            // grdCtrlAccountGL
            // 
            this.grdCtrlAccountGL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdCtrlAccountGL.Location = new System.Drawing.Point(3, 3);
            this.grdCtrlAccountGL.MainView = this.gridView1;
            this.grdCtrlAccountGL.Name = "grdCtrlAccountGL";
            this.grdCtrlAccountGL.Size = new System.Drawing.Size(772, 451);
            this.grdCtrlAccountGL.TabIndex = 0;
            this.grdCtrlAccountGL.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcolID,
            this.gcolName,
            this.gcolRef,
            this.gcolCustomer,
            this.gcolCategories,
            this.gcolBranchID,
            this.gcolApproved,
            this.gcolLock,
            this.gcolClose});
            this.gridView1.GridControl = this.grdCtrlAccountGL;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.PaintStyleName = "UltraFlat";
            // 
            // gcolID
            // 
            this.gcolID.AppearanceHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gcolID.AppearanceHeader.Options.UseFont = true;
            this.gcolID.AppearanceHeader.Options.UseTextOptions = true;
            this.gcolID.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcolID.Caption = "Số tài khoản";
            this.gcolID.Name = "gcolID";
            this.gcolID.OptionsColumn.FixedWidth = true;
            this.gcolID.OptionsColumn.ReadOnly = true;
            this.gcolID.Visible = true;
            this.gcolID.VisibleIndex = 0;
            this.gcolID.Width = 100;
            // 
            // gcolRef
            // 
            this.gcolRef.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gcolRef.AppearanceHeader.Options.UseFont = true;
            this.gcolRef.Caption = "Tham chiếu";
            this.gcolRef.Name = "gcolRef";
            this.gcolRef.OptionsColumn.ReadOnly = true;
            this.gcolRef.Visible = true;
            this.gcolRef.VisibleIndex = 2;
            this.gcolRef.Width = 54;
            // 
            // gcolCustomer
            // 
            this.gcolCustomer.AppearanceHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gcolCustomer.AppearanceHeader.Options.UseFont = true;
            this.gcolCustomer.AppearanceHeader.Options.UseTextOptions = true;
            this.gcolCustomer.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcolCustomer.Caption = "Mã khách hàng";
            this.gcolCustomer.Name = "gcolCustomer";
            this.gcolCustomer.OptionsColumn.ReadOnly = true;
            this.gcolCustomer.Visible = true;
            this.gcolCustomer.VisibleIndex = 3;
            this.gcolCustomer.Width = 82;
            // 
            // gcolCategories
            // 
            this.gcolCategories.AppearanceHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gcolCategories.AppearanceHeader.Options.UseFont = true;
            this.gcolCategories.AppearanceHeader.Options.UseTextOptions = true;
            this.gcolCategories.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcolCategories.Caption = "Loại tài khoản";
            this.gcolCategories.Name = "gcolCategories";
            this.gcolCategories.OptionsColumn.ReadOnly = true;
            this.gcolCategories.Visible = true;
            this.gcolCategories.VisibleIndex = 4;
            this.gcolCategories.Width = 79;
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
            this.gcolBranchID.VisibleIndex = 5;
            this.gcolBranchID.Width = 79;
            // 
            // gcolApproved
            // 
            this.gcolApproved.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gcolApproved.AppearanceHeader.Options.UseFont = true;
            this.gcolApproved.Caption = "Trạng thái duyệt";
            this.gcolApproved.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.gcolApproved.Name = "gcolApproved";
            this.gcolApproved.OptionsColumn.ReadOnly = true;
            this.gcolApproved.Visible = true;
            this.gcolApproved.VisibleIndex = 6;
            this.gcolApproved.Width = 65;
            // 
            // gcolLock
            // 
            this.gcolLock.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gcolLock.AppearanceHeader.Options.UseFont = true;
            this.gcolLock.Caption = "Trạng thái khóa";
            this.gcolLock.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.gcolLock.Name = "gcolLock";
            this.gcolLock.OptionsColumn.ReadOnly = true;
            this.gcolLock.Visible = true;
            this.gcolLock.VisibleIndex = 7;
            this.gcolLock.Width = 65;
            // 
            // gcolClose
            // 
            this.gcolClose.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gcolClose.AppearanceHeader.Options.UseFont = true;
            this.gcolClose.Caption = "Trạng thái đóng";
            this.gcolClose.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.gcolClose.Name = "gcolClose";
            this.gcolClose.OptionsColumn.ReadOnly = true;
            this.gcolClose.Visible = true;
            this.gcolClose.VisibleIndex = 8;
            this.gcolClose.Width = 83;
            // 
            // frmAccountList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(778, 502);
            this.Controls.Add(this.tableLayoutPanel1);
            this.KeyPreview = true;
            this.Name = "frmAccountList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Danh sách tài khoản";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmAccountList_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmAccountList_KeyDown);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdCtrlAccountGL)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.Columns.GridColumn gcolName;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private DevExpress.XtraEditors.SimpleButton sbtnDetail;
        private DevExpress.XtraEditors.SimpleButton sbtnExit;
        private DevExpress.XtraGrid.GridControl grdCtrlAccountGL;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gcolID;
        private DevExpress.XtraGrid.Columns.GridColumn gcolBranchID;
        private DevExpress.XtraGrid.Columns.GridColumn gcolCustomer;
        private DevExpress.XtraGrid.Columns.GridColumn gcolCategories;
        private DevExpress.XtraGrid.Columns.GridColumn gcolApproved;
        private DevExpress.XtraGrid.Columns.GridColumn gcolLock;
        private DevExpress.XtraGrid.Columns.GridColumn gcolClose;
        private DevExpress.XtraGrid.Columns.GridColumn gcolRef;
    }
}