namespace Account.Host.Interface
{
    partial class frmCategoryList
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
            this.sbtnOK = new DevExpress.XtraEditors.SimpleButton();
            this.sbtnExit = new DevExpress.XtraEditors.SimpleButton();
            this.sbtnEdit = new DevExpress.XtraEditors.SimpleButton();
            this.sbtnNew = new DevExpress.XtraEditors.SimpleButton();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.sbtnDel = new DevExpress.XtraEditors.SimpleButton();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.grpCtrlParameter = new DevExpress.XtraEditors.GroupControl();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.txtName = new DevExpress.XtraEditors.TextEdit();
            this.lblName = new System.Windows.Forms.Label();
            this.lblID = new System.Windows.Forms.Label();
            this.lblAccoutGL = new System.Windows.Forms.Label();
            this.txtID = new DevExpress.XtraEditors.TextEdit();
            this.txt_AccountGL = new DevExpress.XtraEditors.TextEdit();
            this.grd_Categories = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcolID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcolName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcolAccount_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcolAccount_Name = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcolDBCR = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcolCcy = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpCtrlParameter)).BeginInit();
            this.grpCtrlParameter.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_AccountGL.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd_Categories)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // sbtnOK
            // 
            this.sbtnOK.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sbtnOK.Location = new System.Drawing.Point(505, 3);
            this.sbtnOK.Name = "sbtnOK";
            this.sbtnOK.Size = new System.Drawing.Size(119, 33);
            this.sbtnOK.TabIndex = 12;
            this.sbtnOK.Text = "Đồng ý(Ctrl+S)";
            this.sbtnOK.Click += new System.EventHandler(this.sbtnOK_Click);
            // 
            // sbtnExit
            // 
            this.sbtnExit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sbtnExit.Location = new System.Drawing.Point(630, 3);
            this.sbtnExit.Name = "sbtnExit";
            this.sbtnExit.Size = new System.Drawing.Size(119, 33);
            this.sbtnExit.TabIndex = 13;
            this.sbtnExit.Text = "Thoát(ESC)";
            this.sbtnExit.Click += new System.EventHandler(this.sbtnExit_Click);
            // 
            // sbtnEdit
            // 
            this.sbtnEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sbtnEdit.Location = new System.Drawing.Point(255, 3);
            this.sbtnEdit.Name = "sbtnEdit";
            this.sbtnEdit.Size = new System.Drawing.Size(119, 33);
            this.sbtnEdit.TabIndex = 10;
            this.sbtnEdit.Text = "Sửa(Ctrl+E)";
            this.sbtnEdit.Click += new System.EventHandler(this.sbtnEdit_Click);
            // 
            // sbtnNew
            // 
            this.sbtnNew.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sbtnNew.Location = new System.Drawing.Point(130, 3);
            this.sbtnNew.Name = "sbtnNew";
            this.sbtnNew.Size = new System.Drawing.Size(119, 33);
            this.sbtnNew.TabIndex = 9;
            this.sbtnNew.Text = "Thêm mới(Ctrl+N)";
            this.sbtnNew.Click += new System.EventHandler(this.sbtnNew_Click);
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
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 374);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(752, 39);
            this.tableLayoutPanel3.TabIndex = 8;
            // 
            // sbtnDel
            // 
            this.sbtnDel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sbtnDel.Location = new System.Drawing.Point(380, 3);
            this.sbtnDel.Name = "sbtnDel";
            this.sbtnDel.Size = new System.Drawing.Size(119, 33);
            this.sbtnDel.TabIndex = 11;
            this.sbtnDel.Text = "Xóa(Ctrl+D)";
            this.sbtnDel.Click += new System.EventHandler(this.sbtnDel_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.grpCtrlParameter, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.grd_Categories, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 140F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(758, 416);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // grpCtrlParameter
            // 
            this.grpCtrlParameter.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpCtrlParameter.Appearance.Options.UseFont = true;
            this.grpCtrlParameter.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpCtrlParameter.AppearanceCaption.Options.UseFont = true;
            this.grpCtrlParameter.Controls.Add(this.tableLayoutPanel2);
            this.grpCtrlParameter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpCtrlParameter.Location = new System.Drawing.Point(3, 234);
            this.grpCtrlParameter.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat;
            this.grpCtrlParameter.LookAndFeel.UseDefaultLookAndFeel = false;
            this.grpCtrlParameter.Name = "grpCtrlParameter";
            this.grpCtrlParameter.Size = new System.Drawing.Size(752, 134);
            this.grpCtrlParameter.TabIndex = 1;
            this.grpCtrlParameter.Text = "Thông tin tham số";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 125F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.txtName, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.lblName, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.lblID, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblAccoutGL, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.txtID, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.txt_AccountGL, 1, 2);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 21);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 4;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(746, 110);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // txtName
            // 
            this.txtName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtName.Location = new System.Drawing.Point(128, 29);
            this.txtName.Name = "txtName";
            this.txtName.Properties.AppearanceDisabled.BackColor = System.Drawing.SystemColors.Control;
            this.txtName.Properties.AppearanceDisabled.Options.UseBackColor = true;
            this.txtName.Size = new System.Drawing.Size(615, 20);
            this.txtName.TabIndex = 5;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblName.Location = new System.Drawing.Point(3, 26);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(119, 26);
            this.lblName.TabIndex = 4;
            this.lblName.Text = "Tên loại tài khoản";
            this.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblID.Location = new System.Drawing.Point(3, 0);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(119, 26);
            this.lblID.TabIndex = 2;
            this.lblID.Text = "Mã loại tài khoản";
            this.lblID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblAccoutGL
            // 
            this.lblAccoutGL.AutoSize = true;
            this.lblAccoutGL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblAccoutGL.Location = new System.Drawing.Point(3, 52);
            this.lblAccoutGL.Name = "lblAccoutGL";
            this.lblAccoutGL.Size = new System.Drawing.Size(119, 26);
            this.lblAccoutGL.TabIndex = 6;
            this.lblAccoutGL.Text = "Tài khoản tổng hợp GL";
            this.lblAccoutGL.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtID
            // 
            this.txtID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtID.EditValue = "";
            this.txtID.Location = new System.Drawing.Point(128, 3);
            this.txtID.Name = "txtID";
            this.txtID.Properties.AppearanceDisabled.BackColor = System.Drawing.SystemColors.Control;
            this.txtID.Properties.AppearanceDisabled.Options.UseBackColor = true;
            this.txtID.Size = new System.Drawing.Size(615, 20);
            this.txtID.TabIndex = 3;
            // 
            // txt_AccountGL
            // 
            this.txt_AccountGL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_AccountGL.Location = new System.Drawing.Point(128, 55);
            this.txt_AccountGL.Name = "txt_AccountGL";
            this.txt_AccountGL.Size = new System.Drawing.Size(615, 20);
            this.txt_AccountGL.TabIndex = 7;
            // 
            // grd_Categories
            // 
            this.grd_Categories.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grd_Categories.Location = new System.Drawing.Point(3, 3);
            this.grd_Categories.MainView = this.gridView1;
            this.grd_Categories.Name = "grd_Categories";
            this.grd_Categories.Size = new System.Drawing.Size(752, 225);
            this.grd_Categories.TabIndex = 9;
            this.grd_Categories.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcolID,
            this.gcolName,
            this.gcolAccount_ID,
            this.gcolAccount_Name,
            this.gcolDBCR,
            this.gcolCcy});
            this.gridView1.GridControl = this.grd_Categories;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.FocusedRowChanged +=new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(gridView1_FocusedRowChanged);
            // 
            // gcolID
            // 
            this.gcolID.Caption = "Mã số";
            this.gcolID.Name = "gcolID";
            this.gcolID.OptionsColumn.ReadOnly = true;
            this.gcolID.Visible = true;
            this.gcolID.VisibleIndex = 0;
            this.gcolID.Width = 50;
            // 
            // gcolName
            // 
            this.gcolName.Caption = "Tên";
            this.gcolName.Name = "gcolName";
            this.gcolName.OptionsColumn.ReadOnly = true;
            this.gcolName.Visible = true;
            this.gcolName.VisibleIndex = 1;
            this.gcolName.Width = 150;
            // 
            // gcolAccount_ID
            // 
            this.gcolAccount_ID.Caption = "Tài khoản GL";
            this.gcolAccount_ID.Name = "gcolAccount_ID";
            this.gcolAccount_ID.OptionsColumn.ReadOnly = true;
            this.gcolAccount_ID.Visible = true;
            this.gcolAccount_ID.VisibleIndex = 2;
            this.gcolAccount_ID.Width = 50;
            // 
            // gcolAccount_Name
            // 
            this.gcolAccount_Name.Caption = "Tên TK";
            this.gcolAccount_Name.Name = "gcolAccount_Name";
            this.gcolAccount_Name.OptionsColumn.ReadOnly = true;
            this.gcolAccount_Name.Visible = true;
            this.gcolAccount_Name.VisibleIndex = 3;
            this.gcolAccount_Name.Width = 157;
            // 
            // gcolDBCR
            // 
            this.gcolDBCR.Caption = "Tính chất TK";
            this.gcolDBCR.Name = "gcolDBCR";
            this.gcolDBCR.OptionsColumn.ReadOnly = true;
            this.gcolDBCR.Visible = true;
            this.gcolDBCR.VisibleIndex = 4;
            this.gcolDBCR.Width = 50;
            // 
            // gcolCcy
            // 
            this.gcolCcy.Caption = "Loại tiền";
            this.gcolCcy.Name = "gcolCcy";
            this.gcolCcy.OptionsColumn.ReadOnly = true;
            this.gcolCcy.Visible = true;
            this.gcolCcy.VisibleIndex = 5;
            this.gcolCcy.Width = 50;
            // 
            // frmCategoryList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(758, 416);
            this.Controls.Add(this.tableLayoutPanel1);
            this.KeyPreview = true;
            this.Name = "frmCategoryList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Danh sách loại tài khoản";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmCategoryList_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmCategoryList_KeyDown);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grpCtrlParameter)).EndInit();
            this.grpCtrlParameter.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_AccountGL.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd_Categories)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton sbtnOK;
        private DevExpress.XtraEditors.SimpleButton sbtnExit;
        private DevExpress.XtraEditors.SimpleButton sbtnEdit;
        private DevExpress.XtraEditors.SimpleButton sbtnNew;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraEditors.GroupControl grpCtrlParameter;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private DevExpress.XtraEditors.TextEdit txtName;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.Label lblAccoutGL;
        private DevExpress.XtraEditors.TextEdit txtID;
        private DevExpress.XtraEditors.SimpleButton sbtnDel;
        private DevExpress.XtraEditors.TextEdit txt_AccountGL;
        private DevExpress.XtraGrid.GridControl grd_Categories;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gcolID;
        private DevExpress.XtraGrid.Columns.GridColumn gcolName;
        private DevExpress.XtraGrid.Columns.GridColumn gcolAccount_ID;
        private DevExpress.XtraGrid.Columns.GridColumn gcolAccount_Name;
        private DevExpress.XtraGrid.Columns.GridColumn gcolDBCR;
        private DevExpress.XtraGrid.Columns.GridColumn gcolCcy;
    }
}