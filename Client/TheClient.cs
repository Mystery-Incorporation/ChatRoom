using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class TheClient
    {
        private static Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        static void Main(string[] args)
        {
            Connect();
            SendData();
            Console.ReadLine();
        }

        private static void SendData()
        {
            while (true)
            {
                Console.Write("Send a message: ");
                string msg = Console.ReadLine();
                byte[] buffer = Encoding.UTF8.GetBytes(msg);
                clientSocket.Send(buffer);

                byte[] receivedBuffer = new byte[1000];
                int receiveData = clientSocket.Receive(receivedBuffer);
                byte[] data = new byte[receiveData];
                Array.Copy(receivedBuffer, data, receiveData);
                Console.WriteLine("Received: " + Encoding.UTF8.GetString(data));
            }
        }

        private static void Connect()
        {
            int connections = 0;

            while (!clientSocket.Connected)
            {
                try
                {
                    connections++;
                    clientSocket.Connect(IPAddress.Loopback, 10000);
                }
                catch (SocketException)
                {
                    Console.WriteLine("Connections attempts: " + connections.ToString());
                }
            }
            Console.Clear();
            Console.WriteLine("Connected");
        }
    }
}
