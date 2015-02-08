using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;


namespace Account.Host
{
    [RunInstaller(true)]
    public partial class EODServiceInstaller : Installer
    {
        public EODServiceInstaller()
        {
            InitializeComponent();
        }
    }
}
