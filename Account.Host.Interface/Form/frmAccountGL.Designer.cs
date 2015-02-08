namespace Account.Host.Interface
{
    partial class frmAccountGL
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
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.sbtnDel = new DevExpress.XtraEditors.SimpleButton();
            this.sbtnOK = new DevExpress.XtraEditors.SimpleButton();
            this.sbtnExit = new DevExpress.XtraEditors.SimpleButton();
            this.sbtnEdit = new DevExpress.XtraEditors.SimpleButton();
            this.sbtnNew = new DevExpress.XtraEditors.SimpleButton();
            this.grpCtrlInfo = new DevExpress.XtraEditors.GroupControl();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.txt_Cyc = new DevExpress.XtraEditors.TextEdit();
            this.lookUEditBranchID = new DevExpress.XtraEditors.LookUpEdit();
            this.lbl_Cyc = new System.Windows.Forms.Label();
            this.lbl_AccountID = new System.Windows.Forms.Label();
            this.txt_CreditDebit = new DevExpress.XtraEditors.TextEdit();
            this.lblCreditDebit = new System.Windows.Forms.Label();
            this.lbl_BranchID = new System.Windows.Forms.Label();
            this.lbl_AccountName = new System.Windows.Forms.Label();
            this.lbl_BranchName = new System.Windows.Forms.Label();
            this.txt_AccountID = new DevExpress.XtraEditors.TextEdit();
            this.txt_AccountName = new DevExpress.XtraEditors.TextEdit();
            this.txt_BranchName = new DevExpress.XtraEditors.TextEdit();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpCtrlInfo)).BeginInit();
            this.grpCtrlInfo.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Cyc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUEditBranchID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_CreditDebit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_AccountID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_AccountName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_BranchName.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.grpCtrlInfo, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(703, 201);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 6;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 125F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 125F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 125F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 125F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 125F));
            this.tableLayoutPanel2.Controls.Add(this.sbtnDel, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.sbtnOK, 4, 0);
            this.tableLayoutPanel2.Controls.Add(this.sbtnExit, 5, 0);
            this.tableLayoutPanel2.Controls.Add(this.sbtnEdit, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.sbtnNew, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 159);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(697, 39);
            this.tableLayoutPanel2.TabIndex = 3;
            // 
            // sbtnDel
            // 
            this.sbtnDel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sbtnDel.Location = new System.Drawing.Point(325, 3);
            this.sbtnDel.Name = "sbtnDel";
            this.sbtnDel.Size = new System.Drawing.Size(119, 33);
            this.sbtnDel.TabIndex = 6;
            this.sbtnDel.Text = "Xóa(Ctrl+D)";
            this.sbtnDel.Click += new System.EventHandler(this.sbtnDel_Click);
            // 
            // sbtnOK
            // 
            this.sbtnOK.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sbtnOK.Location = new System.Drawing.Point(450, 3);
            this.sbtnOK.Name = "sbtnOK";
            this.sbtnOK.Size = new System.Drawing.Size(119, 33);
            this.sbtnOK.TabIndex = 3;
            this.sbtnOK.Text = "Đồng ý(Ctrl+S)";
            this.sbtnOK.Click += new System.EventHandler(this.sbtnOK_Click);
            // 
            // sbtnExit
            // 
            this.sbtnExit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sbtnExit.Location = new System.Drawing.Point(575, 3);
            this.sbtnExit.Name = "sbtnExit";
            this.sbtnExit.Size = new System.Drawing.Size(119, 33);
            this.sbtnExit.TabIndex = 0;
            this.sbtnExit.Text = "Thoát(ESC)";
            this.sbtnExit.Click += new System.EventHandler(this.sbtnExit_Click);
            // 
            // sbtnEdit
            // 
            this.sbtnEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sbtnEdit.Location = new System.Drawing.Point(200, 3);
            this.sbtnEdit.Name = "sbtnEdit";
            this.sbtnEdit.Size = new System.Drawing.Size(119, 33);
            this.sbtnEdit.TabIndex = 1;
            this.sbtnEdit.Text = "Sửa(Ctrl+E)";
            this.sbtnEdit.Click += new System.EventHandler(this.sbtnEdit_Click);
            // 
            // sbtnNew
            // 
            this.sbtnNew.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sbtnNew.Location = new System.Drawing.Point(75, 3);
            this.sbtnNew.Name = "sbtnNew";
            this.sbtnNew.Size = new System.Drawing.Size(119, 33);
            this.sbtnNew.TabIndex = 2;
            this.sbtnNew.Text = "Thêm mới(Ctrl+N)";
            this.sbtnNew.Click += new System.EventHandler(this.sbtnNew_Click);
            // 
            // grpCtrlInfo
            // 
            this.grpCtrlInfo.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpCtrlInfo.AppearanceCaption.Options.UseFont = true;
            this.grpCtrlInfo.Controls.Add(this.tableLayoutPanel3);
            this.grpCtrlInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpCtrlInfo.Location = new System.Drawing.Point(3, 3);
            this.grpCtrlInfo.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat;
            this.grpCtrlInfo.LookAndFeel.UseDefaultLookAndFeel = false;
            this.grpCtrlInfo.Name = "grpCtrlInfo";
            this.grpCtrlInfo.Size = new System.Drawing.Size(697, 150);
            this.grpCtrlInfo.TabIndex = 2;
            this.grpCtrlInfo.Text = "Thông tin sổ cái";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 4;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.txt_Cyc, 3, 2);
            this.tableLayoutPanel3.Controls.Add(this.lookUEditBranchID, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.lbl_Cyc, 2, 2);
            this.tableLayoutPanel3.Controls.Add(this.lbl_AccountID, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.txt_CreditDebit, 1, 2);
            this.tableLayoutPanel3.Controls.Add(this.lblCreditDebit, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.lbl_BranchID, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.lbl_AccountName, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.lbl_BranchName, 2, 1);
            this.tableLayoutPanel3.Controls.Add(this.txt_AccountID, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.txt_AccountName, 3, 0);
            this.tableLayoutPanel3.Controls.Add(this.txt_BranchName, 3, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 21);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 3;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(691, 126);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // txt_Cyc
            // 
            this.txt_Cyc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_Cyc.Location = new System.Drawing.Point(448, 87);
            this.txt_Cyc.Name = "txt_Cyc";
            this.txt_Cyc.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.txt_Cyc.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.txt_Cyc.Size = new System.Drawing.Size(240, 22);
            this.txt_Cyc.TabIndex = 25;
            // 
            // lookUEditBranchID
            // 
            this.lookUEditBranchID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lookUEditBranchID.Location = new System.Drawing.Point(103, 45);
            this.lookUEditBranchID.Name = "lookUEditBranchID";
            this.lookUEditBranchID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUEditBranchID.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ID", "ID",15),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name",50)});
            this.lookUEditBranchID.Size = new System.Drawing.Size(239, 20);
            this.lookUEditBranchID.TabIndex = 15;
            this.lookUEditBranchID.EditValueChanged += new System.EventHandler(this.lookUEditBranchID_EditValueChanged);
            // 
            // lbl_Cyc
            // 
            this.lbl_Cyc.AutoSize = true;
            this.lbl_Cyc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_Cyc.Location = new System.Drawing.Point(348, 84);
            this.lbl_Cyc.Name = "lbl_Cyc";
            this.lbl_Cyc.Size = new System.Drawing.Size(94, 42);
            this.lbl_Cyc.TabIndex = 24;
            this.lbl_Cyc.Text = "Loại tiền tệ";
            this.lbl_Cyc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_AccountID
            // 
            this.lbl_AccountID.AutoSize = true;
            this.lbl_AccountID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_AccountID.Location = new System.Drawing.Point(3, 0);
            this.lbl_AccountID.Name = "lbl_AccountID";
            this.lbl_AccountID.Size = new System.Drawing.Size(94, 42);
            this.lbl_AccountID.TabIndex = 0;
            this.lbl_AccountID.Text = "Số sổ cái";
            this.lbl_AccountID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txt_CreditDebit
            // 
            this.txt_CreditDebit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_CreditDebit.Location = new System.Drawing.Point(103, 87);
            this.txt_CreditDebit.Name = "txt_CreditDebit";
            this.txt_CreditDebit.Size = new System.Drawing.Size(239, 20);
            this.txt_CreditDebit.TabIndex = 11;
            // 
            // lblCreditDebit
            // 
            this.lblCreditDebit.AutoSize = true;
            this.lblCreditDebit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCreditDebit.Location = new System.Drawing.Point(3, 84);
            this.lblCreditDebit.Name = "lblCreditDebit";
            this.lblCreditDebit.Size = new System.Drawing.Size(94, 42);
            this.lblCreditDebit.TabIndex = 5;
            this.lblCreditDebit.Text = "Credit Debit";
            this.lblCreditDebit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_BranchID
            // 
            this.lbl_BranchID.AutoSize = true;
            this.lbl_BranchID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_BranchID.Location = new System.Drawing.Point(3, 42);
            this.lbl_BranchID.Name = "lbl_BranchID";
            this.lbl_BranchID.Size = new System.Drawing.Size(94, 42);
            this.lbl_BranchID.TabIndex = 1;
            this.lbl_BranchID.Text = "Mã chi nhánh";
            this.lbl_BranchID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_AccountName
            // 
            this.lbl_AccountName.AutoSize = true;
            this.lbl_AccountName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_AccountName.Location = new System.Drawing.Point(348, 0);
            this.lbl_AccountName.Name = "lbl_AccountName";
            this.lbl_AccountName.Size = new System.Drawing.Size(94, 42);
            this.lbl_AccountName.TabIndex = 4;
            this.lbl_AccountName.Text = "Tên sổ cái";
            this.lbl_AccountName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_BranchName
            // 
            this.lbl_BranchName.AutoSize = true;
            this.lbl_BranchName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_BranchName.Location = new System.Drawing.Point(348, 42);
            this.lbl_BranchName.Name = "lbl_BranchName";
            this.lbl_BranchName.Size = new System.Drawing.Size(94, 42);
            this.lbl_BranchName.TabIndex = 5;
            this.lbl_BranchName.Text = "Tên chi nhánh";
            this.lbl_BranchName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txt_AccountID
            // 
            this.txt_AccountID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_AccountID.Location = new System.Drawing.Point(103, 3);
            this.txt_AccountID.Name = "txt_AccountID";
            this.txt_AccountID.Size = new System.Drawing.Size(239, 20);
            this.txt_AccountID.TabIndex = 8;
            // 
            // txt_AccountName
            // 
            this.txt_AccountName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_AccountName.Location = new System.Drawing.Point(448, 3);
            this.txt_AccountName.Name = "txt_AccountName";
            this.txt_AccountName.Size = new System.Drawing.Size(240, 20);
            this.txt_AccountName.TabIndex = 9;
            // 
            // txt_BranchName
            // 
            this.txt_BranchName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_BranchName.Location = new System.Drawing.Point(448, 45);
            this.txt_BranchName.Name = "txt_BranchName";
            this.txt_BranchName.Size = new System.Drawing.Size(240, 20);
            this.txt_BranchName.TabIndex = 10;
            // 
            // frmAccountGL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(703, 201);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAccountGL";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chi tiết sổ cái";
            this.Load += new System.EventHandler(this.frmAccountGL_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmAccountGL_KeyDown);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grpCtrlInfo)).EndInit();
            this.grpCtrlInfo.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Cyc.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUEditBranchID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_CreditDebit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_AccountID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_AccountName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_BranchName.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraEditors.GroupControl grpCtrlInfo;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label lbl_AccountID;
        private System.Windows.Forms.Label lbl_BranchID;
        private System.Windows.Forms.Label lbl_AccountName;
        private System.Windows.Forms.Label lbl_BranchName;
        private System.Windows.Forms.Label lblCreditDebit;
        private DevExpress.XtraEditors.TextEdit txt_AccountID;
        private DevExpress.XtraEditors.TextEdit txt_AccountName;
        private DevExpress.XtraEditors.TextEdit txt_BranchName;
        private DevExpress.XtraEditors.TextEdit txt_CreditDebit;
        private System.Windows.Forms.Label lbl_Cyc;
        private DevExpress.XtraEditors.TextEdit txt_Cyc;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private DevExpress.XtraEditors.SimpleButton sbtnOK;
        private DevExpress.XtraEditors.SimpleButton sbtnExit;
        private DevExpress.XtraEditors.SimpleButton sbtnEdit;
        private DevExpress.XtraEditors.SimpleButton sbtnNew;
        private DevExpress.XtraEditors.LookUpEdit lookUEditBranchID;
        private DevExpress.XtraEditors.SimpleButton sbtnDel;
    }
}