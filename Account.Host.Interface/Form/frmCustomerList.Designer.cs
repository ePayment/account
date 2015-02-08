namespace Account.Host.Interface
{
    partial class frmCustomerList
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
            this.gcolCusRef = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcolName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcolVATCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcolCustCert = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcolBranchID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcolBranchName = new DevExpress.XtraGrid.Columns.GridColumn();
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
            this.grdCtrlAccountGL.Size = new System.Drawing.Size(872, 452);
            this.grdCtrlAccountGL.TabIndex = 0;
            this.grdCtrlAccountGL.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcolID,
            this.gcolCusRef,
            this.gcolName,
            this.gcolVATCode,
            this.gcolCustCert,
            this.gcolBranchID,
            this.gcolBranchName});
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
            this.gcolID.Caption = "Mã khách hàng";
            this.gcolID.Name = "gcolID";
            this.gcolID.OptionsColumn.FixedWidth = true;
            this.gcolID.OptionsColumn.ReadOnly = true;
            this.gcolID.Visible = true;
            this.gcolID.VisibleIndex = 0;
            // 
            // gcolCusRef
            // 
            this.gcolCusRef.AppearanceHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gcolCusRef.AppearanceHeader.Options.UseFont = true;
            this.gcolCusRef.AppearanceHeader.Options.UseTextOptions = true;
            this.gcolCusRef.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcolCusRef.Caption = "Tham chiếu khác";
            this.gcolCusRef.Name = "gcolCusRef";
            this.gcolCusRef.OptionsColumn.ReadOnly = true;
            this.gcolCusRef.Visible = true;
            this.gcolCusRef.VisibleIndex = 1;
            this.gcolCusRef.Width = 97;
            // 
            // gcolName
            // 
            this.gcolName.AppearanceHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gcolName.AppearanceHeader.Options.UseFont = true;
            this.gcolName.AppearanceHeader.Options.UseTextOptions = true;
            this.gcolName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcolName.Caption = "Tên khách hàng";
            this.gcolName.Name = "gcolName";
            this.gcolName.OptionsColumn.ReadOnly = true;
            this.gcolName.Visible = true;
            this.gcolName.VisibleIndex = 2;
            this.gcolName.Width = 126;
            // 
            // gcolVATCode
            // 
            this.gcolVATCode.AppearanceHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gcolVATCode.AppearanceHeader.Options.UseFont = true;
            this.gcolVATCode.AppearanceHeader.Options.UseTextOptions = true;
            this.gcolVATCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcolVATCode.Caption = "Mã số thuế";
            this.gcolVATCode.Name = "gcolVATCode";
            this.gcolVATCode.OptionsColumn.ReadOnly = true;
            this.gcolVATCode.Visible = true;
            this.gcolVATCode.VisibleIndex = 3;
            this.gcolVATCode.Width = 126;
            // 
            // gcolCustCert
            // 
            this.gcolCustCert.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gcolCustCert.AppearanceHeader.Options.UseFont = true;
            this.gcolCustCert.AppearanceHeader.Options.UseTextOptions = true;
            this.gcolCustCert.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcolCustCert.Caption = "Số CMND/Hộ chiếu";
            this.gcolCustCert.Name = "gcolCustCert";
            this.gcolCustCert.OptionsColumn.ReadOnly = true;
            this.gcolCustCert.Visible = true;
            this.gcolCustCert.VisibleIndex = 4;
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
            this.gcolBranchID.Width = 126;
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
            this.gcolBranchName.VisibleIndex = 6;
            this.gcolBranchName.Width = 126;
            // 
            // sbtnExit
            // 
            this.sbtnExit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sbtnExit.Location = new System.Drawing.Point(750, 3);
            this.sbtnExit.Name = "sbtnExit";
            this.sbtnExit.Size = new System.Drawing.Size(119, 33);
            this.sbtnExit.TabIndex = 2;
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
            this.tableLayoutPanel1.Size = new System.Drawing.Size(878, 503);
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
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 461);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 39F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(872, 39);
            this.tableLayoutPanel2.TabIndex = 4;
            // 
            // sbtnDetail
            // 
            this.sbtnDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sbtnDetail.Location = new System.Drawing.Point(625, 3);
            this.sbtnDetail.Name = "sbtnDetail";
            this.sbtnDetail.Size = new System.Drawing.Size(119, 33);
            this.sbtnDetail.TabIndex = 1;
            this.sbtnDetail.Text = "Chi tiết(Enter)";
            this.sbtnDetail.Click += new System.EventHandler(this.sbtnDetail_Click);
            // 
            // frmCustomerList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(878, 503);
            this.Controls.Add(this.tableLayoutPanel1);
            this.KeyPreview = true;
            this.Name = "frmCustomerList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Danh sách khách hàng";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmCustomerList_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmCustomerList_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.grdCtrlAccountGL)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grdCtrlAccountGL;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gcolCusRef;
        private DevExpress.XtraGrid.Columns.GridColumn gcolName;
        private DevExpress.XtraGrid.Columns.GridColumn gcolVATCode;
        private DevExpress.XtraGrid.Columns.GridColumn gcolBranchID;
        private DevExpress.XtraGrid.Columns.GridColumn gcolBranchName;
        private DevExpress.XtraEditors.SimpleButton sbtnExit;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private DevExpress.XtraEditors.SimpleButton sbtnDetail;
        private DevExpress.XtraGrid.Columns.GridColumn gcolID;
        private DevExpress.XtraGrid.Columns.GridColumn gcolCustCert;
    }
}