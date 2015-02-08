using System;
using System.Collections.Generic;
using System.Text;

using System.ServiceModel;
using System.ServiceModel.Diagnostics;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.Data;
using System.Net;
using System.Net.Sockets;
using System.Net.NetworkInformation;

using Account.Common.Entities;
using Account.Business;

using log4net;

namespace Account.Host
{
    public class ServiceHostEnhanced
    {
        ServiceHost host = null;
        public Channel_Info channel;
        string urlservice;
        string urlmeta;
        ILog logger;
        CommunicationState _host_state;

        public CommunicationState Status
        { get { return _host_state; } }
        public ServiceHostEnhanced(Channel_Info _channel)
        {
            channel = _channel;
            logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        }
        public void Open()
        {
            urlservice = string.Format("http://{0}:{1}/{2}", channel.Listener_Host, channel.Service_Port - 1, channel.Name);
            urlmeta = string.Format("http://{0}:{1}/{2}", channel.Listener_Host, channel.Service_Port, channel.Name);
            host = new ServiceHost(new AccountService(channel));
            host.Opening += new EventHandler(host_Opening);
            host.Opened += new EventHandler(host_Opened);
            host.Closing += new EventHandler(host_Closing);
            host.Closed += new EventHandler(host_Closed);

            BasicHttpBinding httpbinding = new BasicHttpBinding();
            httpbinding.Security.Mode = BasicHttpSecurityMode.None;
            host.AddServiceEndpoint(typeof(IAccountService), httpbinding, urlservice);
            //host.AddServiceEndpoint(ServiceMetadataBehavior.MexContractName, MetadataExchangeBindings.CreateMexHttpBinding(), "mex");
            ServiceMetadataBehavior metaBehavior = host.Description.Behaviors.Find<ServiceMetadataBehavior>();
            if (metaBehavior == null)
            {
                metaBehavior = new ServiceMetadataBehavior();
                metaBehavior.HttpGetUrl = new Uri(urlmeta);
                metaBehavior.HttpGetEnabled = true;
                host.Description.Behaviors.Add(metaBehavior);
            }
            Append(string.Format("{0} channel starting .....", channel.Name));
            host.Open();
        }
        public void Close()
        { host.Close(); }

        void host_Closed(object sender, EventArgs e)
        {
            _host_state = CommunicationState.Closed;
            Append(string.Format("Host channel {0} closed", channel.Name));
        }
        void host_Closing(object sender, EventArgs e)
        {
            _host_state = CommunicationState.Closing;
            Append(string.Format("Host channel {0} closing ... stand by",channel.Name));
        }
        void host_Opened(object sender, EventArgs e)
        {
            _host_state = CommunicationState.Opened;
            Append(string.Format( "Host channel {0} opened.",channel.Name));
            Append(string.Format("Host channel {0} URL:\t{1}\t(Security is {2})", channel.Name, urlservice, channel.Security));
            Append(string.Format("Host channel {0} meta URL:\t{1}\t(Not that relevant)",channel.Name, urlmeta));
            Append(string.Format("Host channel {0} Waiting for clients...",channel.Name));
        }
        void host_Opening(object sender, EventArgs e)
        {
            _host_state = CommunicationState.Opening;
            Append(string.Format("Host channel {0} opening ... Stand by",channel.Name));
        }
        private void Append(string str)
        {
            logger.Info(string.Format("{0}\t{1}", channel.Name, str));
        }
    }
}
