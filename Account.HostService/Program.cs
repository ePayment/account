using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Diagnostics;
using System.Threading;

using Account.Business;
using Account.Common.Entities;

using log4net;
[assembly: log4net.Config.XmlConfigurator(Watch = true)]
namespace Account.Host
{
    static class Program
    {

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            //ServiceBase[] ServicesToRun;
            //ServicesToRun = new ServiceBase[] 
            //{ 
            //    new HostService() 
            //};
            //ServiceBase.Run(ServicesToRun);

            ServiceHostEnhanced[] host;
            Channels channels;
            dynamic[] list;
            int i = 0;
            channels = new Channels();
            list = channels.GetAllChannels();
            host = new ServiceHostEnhanced[list.Length];
            foreach (dynamic channel in list)
            {
                int _id = channel._id;
                host[i] = new ServiceHostEnhanced(channel);
                host[i].Open();
                i++;
                System.Threading.Thread.Sleep(10);
            }
            Console.WriteLine("Hosted...");
            while (true)
            {
                Thread.Sleep(10000);
            }
        }
    }
}
