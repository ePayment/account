using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceProcess;
using System.Text;
using System.Threading;

using Account.Business;

using log4net;
// Configure logging for this assembly using the 'Account.Listener.exe.log4net' file
[assembly: log4net.Config.XmlConfigurator(ConfigFileExtension = "config", Watch = true)]

namespace Account.Switching
{
    public partial class SwitchingService : ServiceBase
    {
        //private SocketServer server = null;
        

        public SwitchingService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            //server = new SocketServer("127.0.0.1","8583");
            //server.Listen();
        }

        protected override void OnStop()
        {
            //server.Stop();
            //server = null;
        }

        static void Main()
        {
            //ServiceBase[] ServicesToRun;
            //ServicesToRun = new ServiceBase[] 
            //{ new SwitchingService() };
            //ServiceBase.Run(ServicesToRun);

            // DEBUG
            //SocketServer srv = new SocketServer("127.0.0.1", "8583");
            //srv.Listen();
            LogManager.GetLogger("root");
            ChannelManager channels=new ChannelManager();
            //channels.StartAll();
            
            while (true)
                Thread.Sleep(10000);
        }
    }
}
