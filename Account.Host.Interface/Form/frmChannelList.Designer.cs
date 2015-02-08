namespace Account.Host.Interface
{
    partial class frmChannelList
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
            this.gcolID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcolName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcolServicePort = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcolListennerPort = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcolListennerHost = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcolBranchID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcolCcy = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcolDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcolSecurity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcolKey = new DevExpress.XtraGrid.Columns.GridColumn();
            this.sbtnExit = new DevExpress.XtraEditors.SimpleButton();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.sbtnDetail = new DevExpress.XtraEditors.SimpleButton();
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
            this.grdCtrlAccountGL.Size = new System.Drawing.Size(786, 379);
            this.grdCtrlAccountGL.TabIndex = 0;
            this.grdCtrlAccountGL.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
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
            this.gcolServicePort,
            this.gcolListennerPort,
            this.gcolListennerHost,
            this.gcolBranchID,
            this.gcolCcy,
            this.gcolDescription,
            this.gcolSecurity,
            this.gcolKey});
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
            this.gcolID.Caption = "ID";
            this.gcolID.Name = "gcolID";
            this.gcolID.OptionsColumn.FixedWidth = true;
            this.gcolID.OptionsColumn.ReadOnly = true;
            this.gcolID.Width = 142;
            // 
            // gcolName
            // 
            this.gcolName.AppearanceHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gcolName.AppearanceHeader.Options.UseFont = true;
            this.gcolName.AppearanceHeader.Options.UseTextOptions = true;
            this.gcolName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcolName.Caption = "Kênh";
            this.gcolName.Name = "gcolName";
            this.gcolName.OptionsColumn.FixedWidth = true;
            this.gcolName.OptionsColumn.ReadOnly = true;
            this.gcolName.Visible = true;
            this.gcolName.VisibleIndex = 0;
            this.gcolName.Width = 125;
            // 
            // gcolServicePort
            // 
            this.gcolServicePort.AppearanceHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gcolServicePort.AppearanceHeader.Options.UseFont = true;
            this.gcolServicePort.AppearanceHeader.Options.UseTextOptions = true;
            this.gcolServicePort.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcolServicePort.Caption = "Service Port";
            this.gcolServicePort.Name = "gcolServicePort";
            this.gcolServicePort.OptionsColumn.ReadOnly = true;
            this.gcolServicePort.Visible = true;
            this.gcolServicePort.VisibleIndex = 1;
            // 
            // gcolListennerPort
            // 
            this.gcolListennerPort.AppearanceHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gcolListennerPort.AppearanceHeader.Options.UseFont = true;
            this.gcolListennerPort.AppearanceHeader.Options.UseTextOptions = true;
            this.gcolListennerPort.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcolListennerPort.Caption = "Listenner Port";
            this.gcolListennerPort.Name = "gcolListennerPort";
            this.gcolListennerPort.OptionsColumn.ReadOnly = true;
            this.gcolListennerPort.Visible = true;
            this.gcolListennerPort.VisibleIndex = 2;
            // 
            // gcolListennerHost
            // 
            this.gcolListennerHost.AppearanceHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gcolListennerHost.AppearanceHeader.Options.UseFont = true;
            this.gcolListennerHost.AppearanceHeader.Options.UseTextOptions = true;
            this.gcolListennerHost.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcolListennerHost.Caption = "Listener Host";
            this.gcolListennerHost.Name = "gcolListennerHost";
            this.gcolListennerHost.OptionsColumn.ReadOnly = true;
            this.gcolListennerHost.Visible = true;
            this.gcolListennerHost.VisibleIndex = 3;
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
            this.gcolBranchID.VisibleIndex = 4;
            this.gcolBranchID.Width = 125;
            // 
            // gcolCcy
            // 
            this.gcolCcy.AppearanceHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gcolCcy.AppearanceHeader.Options.UseFont = true;
            this.gcolCcy.AppearanceHeader.Options.UseTextOptions = true;
            this.gcolCcy.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcolCcy.Caption = "Loại tiền";
            this.gcolCcy.Name = "gcolCcy";
            this.gcolCcy.OptionsColumn.ReadOnly = true;
            this.gcolCcy.Visible = true;
            this.gcolCcy.VisibleIndex = 5;
            this.gcolCcy.Width = 133;
            // 
            // gcolDescription
            // 
            this.gcolDescription.AppearanceHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gcolDescription.AppearanceHeader.Options.UseFont = true;
            this.gcolDescription.AppearanceHeader.Options.UseTextOptions = true;
            this.gcolDescription.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcolDescription.Caption = "Mô tả";
            this.gcolDescription.Name = "gcolDescription";
            this.gcolDescription.OptionsColumn.ReadOnly = true;
            this.gcolDescription.Visible = true;
            this.gcolDescription.VisibleIndex = 6;
            this.gcolDescription.Width = 125;
            // 
            // gcolSecurity
            // 
            this.gcolSecurity.Caption = "Bảo mật";
            this.gcolSecurity.Name = "gcolSecurity";
            this.gcolSecurity.OptionsColumn.ReadOnly = true;
            this.gcolSecurity.Visible = true;
            this.gcolSecurity.VisibleIndex = 7;
            // 
            // gcolKey
            // 
            this.gcolKey.Caption = "Key";
            this.gcolKey.Name = "gcolKey";
            this.gcolKey.OptionsColumn.ReadOnly = true;
            this.gcolKey.Visible = true;
            this.gcolKey.VisibleIndex = 8;
            // 
            // sbtnExit
            // 
            this.sbtnExit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sbtnExit.Location = new System.Drawing.Point(664, 3);
            this.sbtnExit.Name = "sbtnExit";
            this.sbtnExit.Size = new System.Drawing.Size(119, 33);
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
            this.tableLayoutPanel1.Size = new System.Drawing.Size(792, 430);
            this.tableLayoutPanel1.TabIndex = 2;
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
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 388);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 39F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(786, 39);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // sbtnDetail
            // 
            this.sbtnDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sbtnDetail.Location = new System.Drawing.Point(539, 3);
            this.sbtnDetail.Name = "sbtnDetail";
            this.sbtnDetail.Size = new System.Drawing.Size(119, 33);
            this.sbtnDetail.TabIndex = 0;
            this.sbtnDetail.Text = "Chi tiêt (ENTER)";
            this.sbtnDetail.Click += new System.EventHandler(this.sbtnDetail_Click);
            // 
            // frmChannelList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 430);
            this.Controls.Add(this.tableLayoutPanel1);
            this.KeyPreview = true;
            this.Name = "frmChannelList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Danh sách kênh giao dịch";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmChannelList_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmChannelList_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.grdCtrlAccountGL)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grdCtrlAccountGL;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gcolID;
        private DevExpress.XtraGrid.Columns.GridColumn gcolName;
        private DevExpress.XtraGrid.Columns.GridColumn gcolDescription;
        private DevExpress.XtraGrid.Columns.GridColumn gcolBranchID;
        private DevExpress.XtraGrid.Columns.GridColumn gcolCcy;
        private DevExpress.XtraEditors.SimpleButton sbtnExit;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private DevExpress.XtraEditors.SimpleButton sbtnDetail;
        private DevExpress.XtraGrid.Columns.GridColumn gcolServicePort;
        private DevExpress.XtraGrid.Columns.GridColumn gcolListennerPort;
        private DevExpress.XtraGrid.Columns.GridColumn gcolListennerHost;
        private DevExpress.XtraGrid.Columns.GridColumn gcolSecurity;
        private DevExpress.XtraGrid.Columns.GridColumn gcolKey;
    }
}