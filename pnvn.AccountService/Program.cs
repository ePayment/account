using System;
using System.Diagnostics;
using System.ServiceProcess;

using System.Windows;
using System.Windows.Forms;

namespace Account.Host
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Account.Host.SystemConsole());
        }
    }
}
