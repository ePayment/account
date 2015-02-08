using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;

using Account.Business;
using Account.Common.Entities;

using log4net;

namespace Account.Host
{
    partial class HostService : ServiceBase
    {
        private ILog logger;
        private ServiceHostEnhanced[] host;
        private Channels channels;
        private List<Channel_Info> list;
        public HostService()
        {
            InitializeComponent();
            logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        }

        protected override void OnStart(string[] args)
        {
            try
            {
                int i = 0;
                channels = new Channels();
                list = channels.GetAllChannels();
                host = new ServiceHostEnhanced[list.Count];
                foreach (Channel_Info channel in list)
                {
                    host[i] = new ServiceHostEnhanced(channel);
                    host[i].Open();
                    i++;
                    //System.Threading.Thread.Sleep(10);
                }

            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
        }

        protected override void OnStop()
        {
            try
            {
                channels = null;
                list = null;
                host = null;
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
        }
    }
}
