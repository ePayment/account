using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using System.Net;
using System.ServiceModel;
using System.ServiceModel.Description;
using Account.Host;

using log4net;

namespace Account.Host
{
    public partial class SystemConsole : Form
    {
        Account.Host.HostManager mhost=null;
        ILog logger;

        public SystemConsole()
        { 
            InitializeComponent();
            logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        }
        private void SystemConsole_Load(object sender, EventArgs e)
        {
            // Build menu
            menuStripEnhanced1.Form = this;
            menuStripEnhanced1.LoadDynamicMenu();
        }
        private void MenuItemOnClick_Begin(object sender, EventArgs e)
        {
            if (mhost != null)
                mhost.Close();
            mhost = new Account.Host.HostManager();
            this.UseWaitCursor = true;
            mhost.Start();
            this.UseWaitCursor = false;
            //ListView lv = new ListView();
            //this.SuspendLayout();
            //lv.Location = new Point(0, 24);
            //lv.Dock = DockStyle.Fill;
            //lv.Name = "listview1";
            //lv.TabIndex = 5;
            //this.Controls.Add(lv);
            //this.ResumeLayout(false);
            //this.PerformLayout();
        }
        private void MenuItemOnClick_Exit(object sender, EventArgs e)
        {Application.Exit();}
        private void MenuItemOnClick_About(object sender, EventArgs e)
        {
            Forms.AboutBox aboutform = new Forms.AboutBox();
            aboutform.ShowDialog();
        }
    }
}
