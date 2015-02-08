namespace Account.Host.Interface
{
    partial class frmParameterList
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
            this.grpCtrlParameter = new DevExpress.XtraEditors.GroupControl();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.txtValue = new DevExpress.XtraEditors.TextEdit();
            this.lblValue = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblDescript = new System.Windows.Forms.Label();
            this.txtName = new DevExpress.XtraEditors.TextEdit();
            this.mEditDescript = new DevExpress.XtraEditors.MemoEdit();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.sbtnOK = new DevExpress.XtraEditors.SimpleButton();
            this.sbtnExit = new DevExpress.XtraEditors.SimpleButton();
            this.sbtnEdit = new DevExpress.XtraEditors.SimpleButton();
            this.grdCtrlParameter = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcolName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcolValue = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcolDescript = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grpCtrlParameter)).BeginInit();
            this.grpCtrlParameter.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtValue.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mEditDescript.Properties)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdCtrlParameter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // grpCtrlParameter
            // 
            this.grpCtrlParameter.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpCtrlParameter.Appearance.Options.UseFont = true;
            this.grpCtrlParameter.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpCtrlParameter.AppearanceCaption.Options.UseFont = true;
            this.grpCtrlParameter.Controls.Add(this.tableLayoutPanel2);
            this.grpCtrlParameter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpCtrlParameter.Location = new System.Drawing.Point(3, 202);
            this.grpCtrlParameter.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat;
            this.grpCtrlParameter.LookAndFeel.UseDefaultLookAndFeel = false;
            this.grpCtrlParameter.Name = "grpCtrlParameter";
            this.grpCtrlParameter.Size = new System.Drawing.Size(645, 134);
            this.grpCtrlParameter.TabIndex = 1;
            this.grpCtrlParameter.Text = "Thông tin tham số";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 125F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.txtValue, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.lblValue, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.lblName, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblDescript, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.txtName, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.mEditDescript, 1, 2);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 21);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(639, 110);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // txtValue
            // 
            this.txtValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtValue.Location = new System.Drawing.Point(128, 29);
            this.txtValue.Name = "txtValue";
            this.txtValue.Properties.AppearanceDisabled.BackColor = System.Drawing.SystemColors.Control;
            this.txtValue.Properties.AppearanceDisabled.Options.UseBackColor = true;
            this.txtValue.Size = new System.Drawing.Size(508, 20);
            this.txtValue.TabIndex = 3;
            // 
            // lblValue
            // 
            this.lblValue.AutoSize = true;
            this.lblValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblValue.Location = new System.Drawing.Point(3, 26);
            this.lblValue.Name = "lblValue";
            this.lblValue.Size = new System.Drawing.Size(119, 26);
            this.lblValue.TabIndex = 2;
            this.lblValue.Text = "Giá trị";
            this.lblValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblName.Location = new System.Drawing.Point(3, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(119, 26);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Tên tham số";
            this.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDescript
            // 
            this.lblDescript.AutoSize = true;
            this.lblDescript.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDescript.Location = new System.Drawing.Point(3, 52);
            this.lblDescript.Name = "lblDescript";
            this.lblDescript.Size = new System.Drawing.Size(119, 58);
            this.lblDescript.TabIndex = 4;
            this.lblDescript.Text = "Mô tả";
            this.lblDescript.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtName
            // 
            this.txtName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtName.Location = new System.Drawing.Point(128, 3);
            this.txtName.Name = "txtName";
            this.txtName.Properties.AppearanceDisabled.BackColor = System.Drawing.SystemColors.Control;
            this.txtName.Properties.AppearanceDisabled.Options.UseBackColor = true;
            this.txtName.Size = new System.Drawing.Size(508, 20);
            this.txtName.TabIndex = 1;
            // 
            // mEditDescript
            // 
            this.mEditDescript.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mEditDescript.Location = new System.Drawing.Point(128, 55);
            this.mEditDescript.Name = "mEditDescript";
            this.mEditDescript.Properties.AppearanceDisabled.BackColor = System.Drawing.SystemColors.Control;
            this.mEditDescript.Properties.AppearanceDisabled.Options.UseBackColor = true;
            this.mEditDescript.Size = new System.Drawing.Size(508, 52);
            this.mEditDescript.TabIndex = 5;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.grdCtrlParameter, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.grpCtrlParameter, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 140F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(651, 384);
            this.tableLayoutPanel1.TabIndex = 1;
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
            this.tableLayoutPanel3.Controls.Add(this.sbtnOK, 4, 0);
            this.tableLayoutPanel3.Controls.Add(this.sbtnExit, 5, 0);
            this.tableLayoutPanel3.Controls.Add(this.sbtnEdit, 3, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 342);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(645, 39);
            this.tableLayoutPanel3.TabIndex = 2;
            // 
            // sbtnOK
            // 
            this.sbtnOK.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sbtnOK.Location = new System.Drawing.Point(398, 3);
            this.sbtnOK.Name = "sbtnOK";
            this.sbtnOK.Size = new System.Drawing.Size(119, 33);
            this.sbtnOK.TabIndex = 3;
            this.sbtnOK.Text = "Đồng ý((Ctrl+S)";
            this.sbtnOK.Click += new System.EventHandler(this.sbtnOK_Click);
            // 
            // sbtnExit
            // 
            this.sbtnExit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sbtnExit.Location = new System.Drawing.Point(523, 3);
            this.sbtnExit.Name = "sbtnExit";
            this.sbtnExit.Size = new System.Drawing.Size(119, 33);
            this.sbtnExit.TabIndex = 4;
            this.sbtnExit.Text = "Thoát(ESC)";
            this.sbtnExit.Click += new System.EventHandler(this.sbtnExit_Click);
            // 
            // sbtnEdit
            // 
            this.sbtnEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sbtnEdit.Location = new System.Drawing.Point(273, 3);
            this.sbtnEdit.Name = "sbtnEdit";
            this.sbtnEdit.Size = new System.Drawing.Size(119, 33);
            this.sbtnEdit.TabIndex = 1;
            this.sbtnEdit.Text = "Sửa(Ctrl+E)";
            this.sbtnEdit.Click += new System.EventHandler(this.sbtnEdit_Click);
            // 
            // grdCtrlParameter
            // 
            this.grdCtrlParameter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdCtrlParameter.Location = new System.Drawing.Point(3, 3);
            this.grdCtrlParameter.MainView = this.gridView1;
            this.grdCtrlParameter.Name = "grdCtrlParameter";
            this.grdCtrlParameter.Size = new System.Drawing.Size(645, 193);
            this.grdCtrlParameter.TabIndex = 0;
            this.grdCtrlParameter.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcolName,
            this.gcolValue,
            this.gcolDescript});
            this.gridView1.GridControl = this.grdCtrlParameter;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.PaintStyleName = "UltraFlat";
            this.gridView1.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridView1_FocusedRowChanged);
            // 
            // gcolName
            // 
            this.gcolName.AppearanceHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gcolName.AppearanceHeader.Options.UseFont = true;
            this.gcolName.AppearanceHeader.Options.UseTextOptions = true;
            this.gcolName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcolName.Caption = "Tên tham số";
            this.gcolName.Name = "gcolName";
            this.gcolName.OptionsColumn.ReadOnly = true;
            this.gcolName.Visible = true;
            this.gcolName.VisibleIndex = 0;
            this.gcolName.Width = 157;
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
            this.gcolValue.VisibleIndex = 1;
            this.gcolValue.Width = 307;
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
            this.gcolDescript.VisibleIndex = 2;
            this.gcolDescript.Width = 300;
            // 
            // frmParameterList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(651, 384);
            this.Controls.Add(this.tableLayoutPanel1);
            this.KeyPreview = true;
            this.Name = "frmParameterList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Danh sách tham số";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmParameterList_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmParameterList_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.grpCtrlParameter)).EndInit();
            this.grpCtrlParameter.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtValue.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mEditDescript.Properties)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdCtrlParameter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl grpCtrlParameter;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblDescript;
        private DevExpress.XtraEditors.TextEdit txtName;
        private DevExpress.XtraEditors.MemoEdit mEditDescript;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private DevExpress.XtraEditors.SimpleButton sbtnOK;
        private DevExpress.XtraEditors.SimpleButton sbtnExit;
        private DevExpress.XtraEditors.SimpleButton sbtnEdit;
        private DevExpress.XtraGrid.GridControl grdCtrlParameter;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gcolValue;
        private DevExpress.XtraGrid.Columns.GridColumn gcolName;
        private DevExpress.XtraGrid.Columns.GridColumn gcolDescript;
        private System.Windows.Forms.Label lblValue;
        private DevExpress.XtraEditors.TextEdit txtValue;
    }
}