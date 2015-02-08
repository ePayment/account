namespace Account.Host.Interface
{
    partial class frmTranDayList
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
            this.grdCtrlTransDay = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcolDocID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcolTraceNum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcolTransDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcolStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcolVerified = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcolBranchID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcolBranchName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcolVerified_User = new DevExpress.XtraGrid.Columns.GridColumn();
            this.sbtnExit = new DevExpress.XtraEditors.SimpleButton();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.sbtnDetail = new DevExpress.XtraEditors.SimpleButton();
            this.gcolAllowReverse = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grdCtrlTransDay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // grdCtrlTransDay
            // 
            this.grdCtrlTransDay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdCtrlTransDay.EmbeddedNavigator.Name = "";
            this.grdCtrlTransDay.Location = new System.Drawing.Point(3, 3);
            this.grdCtrlTransDay.MainView = this.gridView1;
            this.grdCtrlTransDay.Name = "grdCtrlTransDay";
            this.grdCtrlTransDay.Size = new System.Drawing.Size(743, 394);
            this.grdCtrlTransDay.TabIndex = 1;
            this.grdCtrlTransDay.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcolDocID,
            this.gcolTraceNum,
            this.gcolTransDate,
            this.gcolBranchID,
            this.gcolBranchName,
            this.gcolStatus,
            this.gcolAllowReverse,
            this.gcolVerified,
            this.gcolVerified_User});
            this.gridView1.GridControl = this.grdCtrlTransDay;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.PaintStyleName = "UltraFlat";
            // 
            // gcolDocID
            // 
            this.gcolDocID.AppearanceHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gcolDocID.AppearanceHeader.Options.UseFont = true;
            this.gcolDocID.AppearanceHeader.Options.UseTextOptions = true;
            this.gcolDocID.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcolDocID.Caption = "Số chứng từ";
            this.gcolDocID.Name = "gcolDocID";
            this.gcolDocID.OptionsColumn.AllowEdit = false;
            this.gcolDocID.OptionsColumn.FixedWidth = true;
            this.gcolDocID.Visible = true;
            this.gcolDocID.VisibleIndex = 0;
            // 
            // gcolTraceNum
            // 
            this.gcolTraceNum.AppearanceHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gcolTraceNum.AppearanceHeader.Options.UseFont = true;
            this.gcolTraceNum.AppearanceHeader.Options.UseTextOptions = true;
            this.gcolTraceNum.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcolTraceNum.Caption = "Số chứng từ tham chiếu ";
            this.gcolTraceNum.Name = "gcolTraceNum";
            this.gcolTraceNum.OptionsColumn.AllowEdit = false;
            this.gcolTraceNum.Visible = true;
            this.gcolTraceNum.VisibleIndex = 1;
            this.gcolTraceNum.Width = 97;
            // 
            // gcolTransDate
            // 
            this.gcolTransDate.AppearanceHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gcolTransDate.AppearanceHeader.Options.UseFont = true;
            this.gcolTransDate.AppearanceHeader.Options.UseTextOptions = true;
            this.gcolTransDate.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcolTransDate.Caption = "Ngày giao dịch";
            this.gcolTransDate.Name = "gcolTransDate";
            this.gcolTransDate.OptionsColumn.AllowEdit = false;
            this.gcolTransDate.Visible = true;
            this.gcolTransDate.VisibleIndex = 2;
            this.gcolTransDate.Width = 126;
            // 
            // gcolStatus
            // 
            this.gcolStatus.AppearanceHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gcolStatus.AppearanceHeader.Options.UseFont = true;
            this.gcolStatus.AppearanceHeader.Options.UseTextOptions = true;
            this.gcolStatus.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcolStatus.Caption = "Trạng thái bút toán";
            this.gcolStatus.Name = "gcolStatus";
            this.gcolStatus.OptionsColumn.AllowEdit = false;
            this.gcolStatus.Visible = true;
            this.gcolStatus.VisibleIndex = 3;
            this.gcolStatus.Width = 126;
            // 
            // gcolVerified
            // 
            this.gcolVerified.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gcolVerified.AppearanceHeader.Options.UseFont = true;
            this.gcolVerified.AppearanceHeader.Options.UseTextOptions = true;
            this.gcolVerified.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcolVerified.Caption = "Trạng thái duyệt chứng từ";
            this.gcolVerified.Name = "gcolVerified";
            this.gcolVerified.OptionsColumn.AllowEdit = false;
            this.gcolVerified.Visible = true;
            this.gcolVerified.VisibleIndex = 4;
            // 
            // gcolBranchID
            // 
            this.gcolBranchID.AppearanceHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gcolBranchID.AppearanceHeader.Options.UseFont = true;
            this.gcolBranchID.AppearanceHeader.Options.UseTextOptions = true;
            this.gcolBranchID.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcolBranchID.Caption = "Mã chi nhánh";
            this.gcolBranchID.Name = "gcolBranchID";
            this.gcolBranchID.OptionsColumn.AllowEdit = false;
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
            this.gcolBranchName.OptionsColumn.AllowEdit = false;
            this.gcolBranchName.Visible = true;
            this.gcolBranchName.VisibleIndex = 7;
            this.gcolBranchName.Width = 126;
            // 
            // gcolVerified_User
            // 
            this.gcolVerified_User.AppearanceHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gcolVerified_User.AppearanceHeader.Options.UseFont = true;
            this.gcolVerified_User.AppearanceHeader.Options.UseTextOptions = true;
            this.gcolVerified_User.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcolVerified_User.Caption = "Người duyệt chứng từ";
            this.gcolVerified_User.Name = "gcolVerified_User";
            this.gcolVerified_User.OptionsColumn.AllowEdit = false;
            this.gcolVerified_User.OptionsColumn.FixedWidth = true;
            this.gcolVerified_User.Visible = true;
            this.gcolVerified_User.VisibleIndex = 8;
            this.gcolVerified_User.Width = 130;
            // 
            // sbtnExit
            // 
            this.sbtnExit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sbtnExit.Location = new System.Drawing.Point(621, 3);
            this.sbtnExit.Name = "sbtnExit";
            this.sbtnExit.Size = new System.Drawing.Size(119, 33);
            this.sbtnExit.TabIndex = 0;
            this.sbtnExit.Text = "Thoát(ESC)";
            this.sbtnExit.Click += new System.EventHandler(this.sbtnExit_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.grdCtrlTransDay, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(749, 445);
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
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 403);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 39F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(743, 39);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // sbtnDetail
            // 
            this.sbtnDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sbtnDetail.Location = new System.Drawing.Point(496, 3);
            this.sbtnDetail.Name = "sbtnDetail";
            this.sbtnDetail.Size = new System.Drawing.Size(119, 33);
            this.sbtnDetail.TabIndex = 1;
            this.sbtnDetail.Text = "&Chi tiết";
            this.sbtnDetail.Click += new System.EventHandler(this.sbtnDetail_Click);
            // 
            // gcolAllowReverse
            // 
            this.gcolAllowReverse.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gcolAllowReverse.AppearanceHeader.Options.UseFont = true;
            this.gcolAllowReverse.AppearanceHeader.Options.UseTextOptions = true;
            this.gcolAllowReverse.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcolAllowReverse.Caption = "Cho phép hủy";
            this.gcolAllowReverse.Name = "gcolAllowReverse";
            this.gcolAllowReverse.OptionsColumn.AllowEdit = false;
            this.gcolAllowReverse.Visible = true;
            this.gcolAllowReverse.VisibleIndex = 6;
            // 
            // frmTranDayList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(749, 445);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "frmTranDayList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Danh sách giao dịch ngày";
            this.Load += new System.EventHandler(this.frmTranDayList_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmTranDayList_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.grdCtrlTransDay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grdCtrlTransDay;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gcolDocID;
        private DevExpress.XtraGrid.Columns.GridColumn gcolTraceNum;
        private DevExpress.XtraGrid.Columns.GridColumn gcolTransDate;
        private DevExpress.XtraGrid.Columns.GridColumn gcolStatus;
        private DevExpress.XtraGrid.Columns.GridColumn gcolVerified;
        private DevExpress.XtraGrid.Columns.GridColumn gcolBranchID;
        private DevExpress.XtraGrid.Columns.GridColumn gcolBranchName;
        private DevExpress.XtraGrid.Columns.GridColumn gcolVerified_User;
        private DevExpress.XtraEditors.SimpleButton sbtnExit;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private DevExpress.XtraEditors.SimpleButton sbtnDetail;
        private DevExpress.XtraGrid.Columns.GridColumn gcolAllowReverse;
    }
}