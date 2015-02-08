namespace Account.Host
{
    partial class SystemConsole
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
            this.menuStripEnhanced1 = new Account.Components.MenuStripEnhanced();
            this.SuspendLayout();
            // 
            // menuStripEnhanced1
            // 
            this.menuStripEnhanced1.Form = null;
            this.menuStripEnhanced1.Location = new System.Drawing.Point(0, 0);
            this.menuStripEnhanced1.Name = "menuStripEnhanced1";
            this.menuStripEnhanced1.Size = new System.Drawing.Size(780, 24);
            this.menuStripEnhanced1.TabIndex = 3;
            this.menuStripEnhanced1.Text = "menuStripEnhanced1";
            this.menuStripEnhanced1.XmlPath = "MainMenu.xml";
            // 
            // SystemConsole
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(780, 467);
            this.Controls.Add(this.menuStripEnhanced1);
            this.IsMdiContainer = true;
            this.Name = "SystemConsole";
            this.Text = "SystemConsole";
            this.Load += new System.EventHandler(this.SystemConsole_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Account.Components.MenuStripEnhanced menuStripEnhanced1;


    }
}