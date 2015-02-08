namespace Account.Host.Interface
{
    partial class frmTranCodeList
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
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.sbtnDetail = new DevExpress.XtraEditors.SimpleButton();
            this.sbtnExit = new DevExpress.XtraEditors.SimpleButton();
            this.gcolCodeType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcolAllowReverse = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcolDescript = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.grdCtrlTranCode = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcolCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcolName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcolStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcolCategories = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcolNextCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdCtrlTranCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
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
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 473);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 39F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(776, 39);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // sbtnDetail
            // 
            this.sbtnDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sbtnDetail.Location = new System.Drawing.Point(529, 3);
            this.sbtnDetail.Name = "sbtnDetail";
            this.sbtnDetail.Size = new System.Drawing.Size(119, 33);
            this.sbtnDetail.TabIndex = 0;
            this.sbtnDetail.Text = "Chi tiết (ENTER)";
            this.sbtnDetail.Click += new System.EventHandler(this.sbtnDetail_Click);
            // 
            // sbtnExit
            // 
            this.sbtnExit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sbtnExit.Location = new System.Drawing.Point(654, 3);
            this.sbtnExit.Name = "sbtnExit";
            this.sbtnExit.Size = new System.Drawing.Size(119, 33);
            this.sbtnExit.TabIndex = 1;
            this.sbtnExit.Text = "Thoát(ESC)";
            this.sbtnExit.Click += new System.EventHandler(this.sbtnExit_Click);
            // 
            // gcolCodeType
            // 
            this.gcolCodeType.AppearanceHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gcolCodeType.AppearanceHeader.Options.UseFont = true;
            this.gcolCodeType.AppearanceHeader.Options.UseTextOptions = true;
            this.gcolCodeType.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcolCodeType.Caption = "Loại định khoản";
            this.gcolCodeType.Name = "gcolCodeType";
            this.gcolCodeType.OptionsColumn.ReadOnly = true;
            this.gcolCodeType.Visible = true;
            this.gcolCodeType.VisibleIndex = 4;
            this.gcolCodeType.Width = 101;
            // 
            // gcolAllowReverse
            // 
            this.gcolAllowReverse.AppearanceHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gcolAllowReverse.AppearanceHeader.Options.UseFont = true;
            this.gcolAllowReverse.AppearanceHeader.Options.UseTextOptions = true;
            this.gcolAllowReverse.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcolAllowReverse.Caption = "Được phép hủy";
            this.gcolAllowReverse.Name = "gcolAllowReverse";
            this.gcolAllowReverse.OptionsColumn.ReadOnly = true;
            this.gcolAllowReverse.Visible = true;
            this.gcolAllowReverse.VisibleIndex = 5;
            this.gcolAllowReverse.Width = 101;
            // 
            // gcolDescript
            // 
            this.gcolDescript.AppearanceHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gcolDescript.AppearanceHeader.Options.UseFont = true;
            this.gcolDescript.AppearanceHeader.Options.UseTextOptions = true;
            this.gcolDescript.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcolDescript.Caption = "Mô tả";
            this.gcolDescript.Name = "gcolDescript";
            this.gcolDescript.OptionsColumn.ReadOnly = true;
            this.gcolDescript.Visible = true;
            this.gcolDescript.VisibleIndex = 6;
            this.gcolDescript.Width = 150;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.grdCtrlTranCode, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(782, 515);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // grdCtrlTranCode
            // 
            this.grdCtrlTranCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdCtrlTranCode.Location = new System.Drawing.Point(3, 3);
            this.grdCtrlTranCode.MainView = this.gridView1;
            this.grdCtrlTranCode.Name = "grdCtrlTranCode";
            this.grdCtrlTranCode.Size = new System.Drawing.Size(776, 464);
            this.grdCtrlTranCode.TabIndex = 0;
            this.grdCtrlTranCode.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcolCode,
            this.gcolName,
            this.gcolStatus,
            this.gcolCategories,
            this.gcolNextCode,
            this.gcolCodeType,
            this.gcolAllowReverse,
            this.gcolDescript});
            this.gridView1.GridControl = this.grdCtrlTranCode;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.PaintStyleName = "UltraFlat";
            // 
            // gcolCode
            // 
            this.gcolCode.AppearanceHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gcolCode.AppearanceHeader.Options.UseFont = true;
            this.gcolCode.AppearanceHeader.Options.UseTextOptions = true;
            this.gcolCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcolCode.Caption = "Mã định khoản";
            this.gcolCode.Name = "gcolCode";
            this.gcolCode.OptionsColumn.FixedWidth = true;
            this.gcolCode.OptionsColumn.ReadOnly = true;
            this.gcolCode.Visible = true;
            this.gcolCode.VisibleIndex = 0;
            this.gcolCode.Width = 50;
            // 
            // gcolName
            // 
            this.gcolName.AppearanceHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gcolName.AppearanceHeader.Options.UseFont = true;
            this.gcolName.AppearanceHeader.Options.UseTextOptions = true;
            this.gcolName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcolName.Caption = "Tên định khoản";
            this.gcolName.Name = "gcolName";
            this.gcolName.OptionsColumn.FixedWidth = true;
            this.gcolName.OptionsColumn.ReadOnly = true;
            this.gcolName.Visible = true;
            this.gcolName.VisibleIndex = 1;
            this.gcolName.Width = 150;
            // 
            // gcolStatus
            // 
            this.gcolStatus.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gcolStatus.AppearanceHeader.Options.UseFont = true;
            this.gcolStatus.Caption = "Trạng thái";
            this.gcolStatus.Name = "gcolStatus";
            this.gcolStatus.OptionsColumn.FixedWidth = true;
            this.gcolStatus.OptionsColumn.ReadOnly = true;
            this.gcolStatus.Visible = true;
            this.gcolStatus.VisibleIndex = 7;
            this.gcolStatus.Width = 50;
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
            this.gcolCategories.VisibleIndex = 2;
            this.gcolCategories.Width = 101;
            // 
            // gcolNextCode
            // 
            this.gcolNextCode.AppearanceHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gcolNextCode.AppearanceHeader.Options.UseFont = true;
            this.gcolNextCode.AppearanceHeader.Options.UseTextOptions = true;
            this.gcolNextCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcolNextCode.Caption = "Mã định khoản tiếp";
            this.gcolNextCode.Name = "gcolNextCode";
            this.gcolNextCode.OptionsColumn.ReadOnly = true;
            this.gcolNextCode.Visible = true;
            this.gcolNextCode.VisibleIndex = 3;
            this.gcolNextCode.Width = 101;
            // 
            // frmTranCodeList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 515);
            this.Controls.Add(this.tableLayoutPanel1);
            this.KeyPreview = true;
            this.Name = "frmTranCodeList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Danh sách loại định khoản";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmTranCodeList_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmTranCodeList_KeyDown);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdCtrlTranCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private DevExpress.XtraEditors.SimpleButton sbtnDetail;
        private DevExpress.XtraEditors.SimpleButton sbtnExit;
        private DevExpress.XtraGrid.Columns.GridColumn gcolCodeType;
        private DevExpress.XtraGrid.Columns.GridColumn gcolAllowReverse;
        private DevExpress.XtraGrid.Columns.GridColumn gcolDescript;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraGrid.GridControl grdCtrlTranCode;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gcolCode;
        private DevExpress.XtraGrid.Columns.GridColumn gcolName;
        private DevExpress.XtraGrid.Columns.GridColumn gcolCategories;
        private DevExpress.XtraGrid.Columns.GridColumn gcolNextCode;
        private DevExpress.XtraGrid.Columns.GridColumn gcolStatus;
    }
}