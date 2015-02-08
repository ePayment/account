namespace Account.Host.Interface
{
    partial class frmBranchList
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.sbtnDel = new DevExpress.XtraEditors.SimpleButton();
            this.sbtnOK = new DevExpress.XtraEditors.SimpleButton();
            this.sbtnExit = new DevExpress.XtraEditors.SimpleButton();
            this.sbtnEdit = new DevExpress.XtraEditors.SimpleButton();
            this.sbtnNew = new DevExpress.XtraEditors.SimpleButton();
            this.grdCtrlBranch = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcolID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcolName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grpCtrlBranch = new DevExpress.XtraEditors.GroupControl();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.lbl_ID = new System.Windows.Forms.Label();
            this.lbl_Name = new System.Windows.Forms.Label();
            this.txt_ID = new DevExpress.XtraEditors.TextEdit();
            this.mEdit_Name = new DevExpress.XtraEditors.MemoEdit();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdCtrlBranch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpCtrlBranch)).BeginInit();
            this.grpCtrlBranch.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_ID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mEdit_Name.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.grdCtrlBranch, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.grpCtrlBranch, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 115F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(723, 448);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 6;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 125F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 125F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 125F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 125F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 125F));
            this.tableLayoutPanel3.Controls.Add(this.sbtnDel, 3, 0);
            this.tableLayoutPanel3.Controls.Add(this.sbtnOK, 4, 0);
            this.tableLayoutPanel3.Controls.Add(this.sbtnExit, 5, 0);
            this.tableLayoutPanel3.Controls.Add(this.sbtnEdit, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.sbtnNew, 1, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 406);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(717, 39);
            this.tableLayoutPanel3.TabIndex = 2;
            // 
            // sbtnDel
            // 
            this.sbtnDel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sbtnDel.Location = new System.Drawing.Point(345, 3);
            this.sbtnDel.Name = "sbtnDel";
            this.sbtnDel.Size = new System.Drawing.Size(119, 33);
            this.sbtnDel.TabIndex = 2;
            this.sbtnDel.Text = "Xóa(Ctrl+D)";
            this.sbtnDel.Click += new System.EventHandler(this.sbtnDel_Click);
            // 
            // sbtnOK
            // 
            this.sbtnOK.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sbtnOK.Location = new System.Drawing.Point(470, 3);
            this.sbtnOK.Name = "sbtnOK";
            this.sbtnOK.Size = new System.Drawing.Size(119, 33);
            this.sbtnOK.TabIndex = 3;
            this.sbtnOK.Text = "Đồng ý(Ctrl+S)";
            this.sbtnOK.Click += new System.EventHandler(this.sbtnOK_Click);
            // 
            // sbtnExit
            // 
            this.sbtnExit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sbtnExit.Location = new System.Drawing.Point(595, 3);
            this.sbtnExit.Name = "sbtnExit";
            this.sbtnExit.Size = new System.Drawing.Size(119, 33);
            this.sbtnExit.TabIndex = 4;
            this.sbtnExit.Text = "Thoát(ESC)";
            this.sbtnExit.Click += new System.EventHandler(this.sbtnExit_Click);
            // 
            // sbtnEdit
            // 
            this.sbtnEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sbtnEdit.Location = new System.Drawing.Point(220, 3);
            this.sbtnEdit.Name = "sbtnEdit";
            this.sbtnEdit.Size = new System.Drawing.Size(119, 33);
            this.sbtnEdit.TabIndex = 1;
            this.sbtnEdit.Text = "Sửa(Ctrl+E)";
            this.sbtnEdit.Click += new System.EventHandler(this.sbtnEdit_Click);
            // 
            // sbtnNew
            // 
            this.sbtnNew.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sbtnNew.Location = new System.Drawing.Point(95, 3);
            this.sbtnNew.Name = "sbtnNew";
            this.sbtnNew.Size = new System.Drawing.Size(119, 33);
            this.sbtnNew.TabIndex = 0;
            this.sbtnNew.Text = "Thêm mới(Ctrl+N)";
            this.sbtnNew.Click += new System.EventHandler(this.sbtnNew_Click);
            // 
            // grdCtrlBranch
            // 
            this.grdCtrlBranch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdCtrlBranch.Location = new System.Drawing.Point(3, 3);
            this.grdCtrlBranch.MainView = this.gridView1;
            this.grdCtrlBranch.Name = "grdCtrlBranch";
            this.grdCtrlBranch.Size = new System.Drawing.Size(717, 282);
            this.grdCtrlBranch.TabIndex = 0;
            this.grdCtrlBranch.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcolID,
            this.gcolName});
            this.gridView1.GridControl = this.grdCtrlBranch;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.PaintStyleName = "UltraFlat";
            this.gridView1.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridView1_FocusedRowChanged);
            // 
            // gcolID
            // 
            this.gcolID.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gcolID.AppearanceHeader.Options.UseFont = true;
            this.gcolID.AppearanceHeader.Options.UseTextOptions = true;
            this.gcolID.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcolID.Caption = "Mã chi nhánh";
            this.gcolID.Name = "gcolID";
            this.gcolID.OptionsColumn.ReadOnly = true;
            this.gcolID.Visible = true;
            this.gcolID.VisibleIndex = 0;
            this.gcolID.Width = 142;
            // 
            // gcolName
            // 
            this.gcolName.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gcolName.AppearanceHeader.Options.UseFont = true;
            this.gcolName.AppearanceHeader.Options.UseTextOptions = true;
            this.gcolName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcolName.Caption = "Tên chi nhánh";
            this.gcolName.Name = "gcolName";
            this.gcolName.OptionsColumn.ReadOnly = true;
            this.gcolName.Visible = true;
            this.gcolName.VisibleIndex = 1;
            this.gcolName.Width = 380;
            // 
            // grpCtrlBranch
            // 
            this.grpCtrlBranch.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpCtrlBranch.Appearance.Options.UseFont = true;
            this.grpCtrlBranch.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpCtrlBranch.AppearanceCaption.Options.UseFont = true;
            this.grpCtrlBranch.Controls.Add(this.tableLayoutPanel2);
            this.grpCtrlBranch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpCtrlBranch.Location = new System.Drawing.Point(3, 291);
            this.grpCtrlBranch.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat;
            this.grpCtrlBranch.LookAndFeel.UseDefaultLookAndFeel = false;
            this.grpCtrlBranch.Name = "grpCtrlBranch";
            this.grpCtrlBranch.Size = new System.Drawing.Size(717, 109);
            this.grpCtrlBranch.TabIndex = 1;
            this.grpCtrlBranch.Text = "Thông tin chi nhánh";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 125F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.lbl_ID, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.lbl_Name, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.txt_ID, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.mEdit_Name, 1, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 21);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(711, 85);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // lbl_ID
            // 
            this.lbl_ID.AutoSize = true;
            this.lbl_ID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_ID.Location = new System.Drawing.Point(3, 0);
            this.lbl_ID.Name = "lbl_ID";
            this.lbl_ID.Size = new System.Drawing.Size(119, 26);
            this.lbl_ID.TabIndex = 0;
            this.lbl_ID.Text = "Mã chi nhánh";
            this.lbl_ID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_Name
            // 
            this.lbl_Name.AutoSize = true;
            this.lbl_Name.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_Name.Location = new System.Drawing.Point(3, 26);
            this.lbl_Name.Name = "lbl_Name";
            this.lbl_Name.Size = new System.Drawing.Size(119, 59);
            this.lbl_Name.TabIndex = 2;
            this.lbl_Name.Text = "Tên chi nhánh";
            this.lbl_Name.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txt_ID
            // 
            this.txt_ID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_ID.Location = new System.Drawing.Point(128, 3);
            this.txt_ID.Name = "txt_ID";
            this.txt_ID.Size = new System.Drawing.Size(580, 20);
            this.txt_ID.TabIndex = 1;
            // 
            // mEdit_Name
            // 
            this.mEdit_Name.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mEdit_Name.Location = new System.Drawing.Point(128, 29);
            this.mEdit_Name.Name = "mEdit_Name";
            this.mEdit_Name.Size = new System.Drawing.Size(580, 53);
            this.mEdit_Name.TabIndex = 3;
            // 
            // frmBranchList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(723, 448);
            this.Controls.Add(this.tableLayoutPanel1);
            this.KeyPreview = true;
            this.Name = "frmBranchList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Danh sách chi nhánh";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmBranchList_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmBranchList_KeyDown);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdCtrlBranch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpCtrlBranch)).EndInit();
            this.grpCtrlBranch.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_ID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mEdit_Name.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraGrid.GridControl grdCtrlBranch;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gcolID;
        private DevExpress.XtraGrid.Columns.GridColumn gcolName;
        private DevExpress.XtraEditors.GroupControl grpCtrlBranch;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label lbl_ID;
        private System.Windows.Forms.Label lbl_Name;
        private DevExpress.XtraEditors.TextEdit txt_ID;
        private DevExpress.XtraEditors.MemoEdit mEdit_Name;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private DevExpress.XtraEditors.SimpleButton sbtnOK;
        private DevExpress.XtraEditors.SimpleButton sbtnExit;
        private DevExpress.XtraEditors.SimpleButton sbtnEdit;
        private DevExpress.XtraEditors.SimpleButton sbtnNew;
        private DevExpress.XtraEditors.SimpleButton sbtnDel;
    }
}