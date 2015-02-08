using System;
using System.Collections.Generic;
using System.Linq;
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

namespace Account.Host.Interface
{
    public class HostManager
    {
       public ServiceHostEnhanced[] host;        
        public ChannelManager channels;
        public ServiceHostEnhanced[] ServiceHostEnhances
        { get { return host; } }
        public HostManager()
        { channels = new ChannelManager(); }
        public void Start()
        {
            host = new ServiceHostEnhanced[channels.Channels.Count];
            for (int i = 0; i < channels.Channels.Count; i++)
            {
                host[i] = new ServiceHostEnhanced(channels.Channels[i]);
                host[i].Open();
                System.Threading.Thread.Sleep(10);
            }
        }
        public void Close()
        {
            for (int i = 0; i < channels.Channels.Count; i++)
            {
                host[i].Close();
                host[i] = null;
                System.Threading.Thread.Sleep(10);
            }
        }
    }

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
            //logger = LogManager.GetLogger("Account.Host");
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
            Append("channel closed");
        }
        void host_Closing(object sender, EventArgs e)
        {
            _host_state = CommunicationState.Closing;
            Append("Service closing ... stand by");
        }
        void host_Opened(object sender, EventArgs e)
        {
            _host_state = CommunicationState.Opened;
            Append("channel opened.");
            Append("channel URL:\t" + urlservice + string.Format("\t(Security is {0})", channel.Security));
            Append("channel meta URL:\t" + urlmeta + "\t(Not that relevant)");
            Append("Waiting for clients...");
        }
        void host_Opening(object sender, EventArgs e)
        {
            _host_state = CommunicationState.Opening;
            Append("channel opening ... Stand by");
        }
        private void Append(string str)
        {
            logger.Info(string.Format("{0}\t{1}", channel.Name, str));
        }

        /*On Click*/
        public void OnClicked(string strMenu)
        {
            
        }

        public void _Closed(object sender, EventArgs e)
        {

        }

        public void _Exit(object sender, EventArgs e)
        {

        }

        public void _Customer(object sender, EventArgs e)
        {

        }

        public void _Branch(object sender, EventArgs e)
        {

        }

        public void _Account(object sender, EventArgs e)
        {

        }

        public void _TransactionDay(object sender, EventArgs e)
        {
        }
        public void _SystemParameters(object sender, EventArgs e)
        {

        }
        public void _Categories(object sender, EventArgs e)
        {

        }
        public void _TranCode(object sender, EventArgs e)
        {

        }
        public void _AccountRoles(object sender, EventArgs e)
        {

        }
        public void _Channels(object sender, EventArgs e)
        {

        }
        public void _AccountGLs(object sender, EventArgs e)
        {

        }
        public void _ErrorDetails(object sender, EventArgs e)
        {

        }
        public void _WorkingDays(object sender, EventArgs e)
        {

        }
        public void _Currency(object sender, EventArgs e)
        {

        }
        public void _Industry(object sender, EventArgs e)
        {

        }
        public void _Sector(object sender, EventArgs e)
        {

        }
        public void _Contents(object sender, EventArgs e)
        {

        }
        public void _About(object sender, EventArgs e)
        {

        }

    }
}
