using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace ServerClassLibrary
{
    public class SocketServer 
    {
        IPAddress mIP;
        int mPort;
        TcpListener mTCPListener;
        public string userOnline;
        TextBlock text;

        List<TcpClient> mClients;
        public bool KeepRunning { get; set; }

        public SocketServer(TextBlock text)
        {
            mClients = new List<TcpClient>();
            this.text = text;
        }

        public async void StartListeningForIncomingConnection(IPAddress ipaddr = null, int port = 23000)
        {
            if (ipaddr == null)
            {
                ipaddr = IPAddress.Any;
            }
            if (port <= 0)
            {
                port = 23000;
            }

            mIP = ipaddr;
            mPort = port;
            
            
            string woop = string.Format("IP Adress: {0} - Port: {1}", mIP.ToString(), mPort.ToString());
            text.Text = woop;
            mTCPListener = new TcpListener(mIP, mPort);

            try
            {
                mTCPListener.Start();

                KeepRunning = true;
                while (KeepRunning)
                {
                    var returnedByAccept = await mTCPListener.AcceptTcpClientAsync();
                    mClients.Add(returnedByAccept);
                    Debug.WriteLine(string.Format("Client connected successfully, count: " + returnedByAccept.Client.RemoteEndPoint));
                    userOnline = mClients.Count.ToString();
                    
                    TakeCareOfTCPClient(returnedByAccept);
                }
            }
            catch (Exception excp)
            {
                System.Diagnostics.Debug.WriteLine(excp.ToString());
            }
        }

        public void StopServer()
        {
            try
            {
                if (mTCPListener != null)
                {
                    mTCPListener.Stop();
                }
                foreach (TcpClient c in mClients)
                {
                    c.Close();
                }
                mClients.Clear();
            }
            catch (Exception excp)
            {

                Debug.WriteLine(excp.ToString());
            }
        }

        private async void TakeCareOfTCPClient(TcpClient paramClient)
        {
            NetworkStream stream = null;
            StreamReader reader = null;

            try
            {
                stream = paramClient.GetStream();
                reader = new StreamReader(stream);

                char[] buff = new char[64];

                while (KeepRunning)
                {
                    Debug.WriteLine("*** Ready to read");

                    int nRent = await reader.ReadAsync(buff, 0, buff.Length);

                    System.Diagnostics.Debug.WriteLine("Returned: " + nRent);

                    if (nRent == 0)
                    {
                        RemoveClient(paramClient);
                        System.Diagnostics.Debug.WriteLine("Socket disconnected");
                        break;
                    }

                    string receivedText = new string(buff);
                    System.Diagnostics.Debug.WriteLine("*** RECEIVED: " + receivedText);
                    Array.Clear(buff, 0, buff.Length);

                }
            }
            catch (Exception excp)
            {
                RemoveClient(paramClient);
                System.Diagnostics.Debug.WriteLine(excp.ToString());
            }
        }

        private void RemoveClient(TcpClient paramClient)
        {
            if (mClients.Contains(paramClient))
            {
                mClients.Remove(paramClient);
                Debug.WriteLine(String.Format("Client removed, count: {0}", mClients.Count));
                userOnline = mClients.Count.ToString();

            }
        }

        public async void SendToAll(string leMessage)
        {
            if (string.IsNullOrEmpty(leMessage))
            {
                return;
            }
            try
            {
                byte[] buffMessage = Encoding.UTF8.GetBytes(leMessage);

                foreach (TcpClient c in mClients)
                {
                    c.GetStream().WriteAsync(buffMessage, 0, buffMessage.Length);
                }
            }
            catch (Exception excp)
            {
                Debug.WriteLine(excp.ToString());
            }
        }
    }
}
