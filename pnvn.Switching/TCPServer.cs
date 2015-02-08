using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.IO;
using System.Text;

using Account.Common;
using Account.Common.Entities;
using Account.Business;

using log4net;

namespace Account.Switching
{
    public class SocketServer
    {
        TcpListener listener;
		IPAddress ipaAddress;
		int iPort;

        ISO8583TranDay merchant;

		public delegate void ListenForMessageDelegate(Client client) ;
		public delegate void ClientConnectedEventHandler (object sender, Client  client);
		public delegate void ClientDisconnectingEventHandler (object sender, string clientName);
		public delegate void MessageReceivedEventHandler (object sender, byte[] bytBuffer);

		public event ClientConnectedEventHandler ClientConnected;
		public event ClientDisconnectingEventHandler ClientDisconnecting;
		public event MessageReceivedEventHandler MessageReceived;

		Thread thrListenForClients;
		
		ListenForMessageDelegate listenForMessageDelegate ;

		bool bListenForClients;

		public SocketServer(Channel_Info channel)
		{
            ipaAddress = IPAddress.Parse(channel.Listener_Host);
            iPort = channel.ISO_Port;
			IPEndPoint endPoint = new IPEndPoint (ipaAddress, iPort);
			listener = new TcpListener (endPoint);
			listener.Start();
            merchant = new ISO8583TranDay(channel);
		}

		public IPAddress SocketIPAddress
		{ get{return ipaAddress;} }
		public int Port
		{ get{return iPort;} }
		public void Listen ()
		{
			thrListenForClients = new Thread (new ThreadStart(ListenForClients));
			thrListenForClients.Start();		
		}
		public void Stop ()
		{ listener.Stop(); }
		private void ListenForClients ()
		{
			bListenForClients = true;

			while (bListenForClients)
			{
				Client acceptClient = new Client ();
				try
				{					
					acceptClient.Socket = listener.AcceptTcpClient();

					listenForMessageDelegate 
						= new ListenForMessageDelegate (ListenForMessages);

					listenForMessageDelegate.BeginInvoke
						(acceptClient, new AsyncCallback(ListenForMessagesCallback), "Completed");
				}
				catch (Exception)
				{
					bListenForClients = false;
				}
			}
		}

		private void ListenForMessages (Client client)
		{
            int recv = 0;
            while (true)
			{
                try
                {
                    NetworkStream stream = client.Socket.GetStream();
                    byte[] bytAcceptMessage = new byte[2048];
                    
                    recv = stream.Read(bytAcceptMessage, 0, bytAcceptMessage.Length);
                    if (recv == 0) { break; }
                    if (LogManager.GetLogger("root").IsDebugEnabled)
                        LogManager.GetLogger("root").Debug(string.Format("{0}",Encoding.ASCII.GetString(bytAcceptMessage)));
                    H2HMessage h2hMsg = ParseReceiveBuffer(bytAcceptMessage, recv);
                    // gửi lại lại lệnh
                    byte[] sbyt = h2hMsg.GetBytes();
                    stream.Write(sbyt, 0, sbyt.Length);
                    //client.SendMessage(h2hMsg.GetBytes());
                    //break;
                }
                catch (IOException ex)
                {
                    if (LogManager.GetLogger("root").IsDebugEnabled)
                        LogManager.GetLogger("root").Debug(ex);
                    break; 
                }
			}
		}

        private H2HMessage ParseReceiveBuffer(Byte[] byteBuffer, int size)
        {
            H2HMessage h2hmsg = H2HMessage.Create(byteBuffer);
            H2HMessage msg = h2hmsg;
            if (LogManager.GetLogger("root").IsDebugEnabled)
                LogManager.GetLogger("root").Debug(string.Format("{0}", h2hmsg.Convert2String()));
            switch (h2hmsg.Type)
            {
                case "0800":
                    msg = H2HMessage.SignOnAnswer(h2hmsg,merchant.NetworkMessages());
                    break;
                case "0100":
                    msg = H2HMessage.BalanceMessageAnswer(h2hmsg, merchant.BalanceInquiry(h2hmsg.Fields[2]));
                    break;
                case "0200":
                    // phân loại tiếp theo processing code F3
                    if (h2hmsg.Fields[3] == "400000")
                    {
                        // fundtransfer
                        msg = H2HMessage.FundTransferAnswer(h2hmsg, merchant.FundTransfer(h2hmsg.Fields[2],Convert.ToDecimal(h2hmsg.Fields[4]),h2hmsg.Fields[102],h2hmsg.Fields[103]));
                    }
                    if (h2hmsg.Fields[3] == "000000")
                    {
                        // retail
                        msg = H2HMessage.RetailAnswer(h2hmsg, merchant.Retail(h2hmsg.Fields[11],h2hmsg.Fields[2],Convert.ToDecimal(h2hmsg.Fields[4]),h2hmsg.GetString()));
                    }
                    break;
                case "0420":
                    msg = H2HMessage.ReversalAnswer(h2hmsg, merchant.Reverse(h2hmsg.Fields[11], h2hmsg.Fields[37]));
                    break;
            }
            return msg;
        }
		private void ListenForMessagesCallback (IAsyncResult ar)
		{
            try
            {
                listenForMessageDelegate.EndInvoke(ar);
            }
            catch (Exception ex)
            {
                if (LogManager.GetLogger("root").IsDebugEnabled)
                    LogManager.GetLogger("root").Debug(ex);
            }
		}		
    }

    public class Client
    {
        string strName;
        TcpClient tcpClient;

        public Client()
        { }

        public string Name
        { get { return strName; } set { this.strName = value; } }
        public TcpClient Socket
        { get { return tcpClient; } set { this.tcpClient = value; } }

        public void SendMessage(byte[] bytmsg)
        {
            if (tcpClient.Connected)
            {
                NetworkStream stream = tcpClient.GetStream();
                if (stream.CanWrite && stream.DataAvailable)
                    stream.Write(bytmsg, 0, bytmsg.Length);
                stream.Flush();
            }
        }
    }

}
