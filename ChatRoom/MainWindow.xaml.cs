using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ChatRoom
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        // SERVER STUFF:
        private static byte[] buffer = new byte[1000];
        private static Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        private static List<Socket> clientSockets = new List<Socket>();

        private void ServerSetup()
        {
            serverPrint("setting up server...");
            serverSocket.Bind(new IPEndPoint(IPAddress.Any, 10000));
            serverSocket.Listen(5);
            serverSocket.BeginAccept(new AsyncCallback(AcceptCallBack), null);
        }
        private void AcceptCallBack(IAsyncResult ar)
        {
            Socket socket = serverSocket.EndAccept(ar);
            clientSockets.Add(socket);
            serverPrint("client connected");
            socket.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, new AsyncCallback(ReceiveCallback), socket);
            //Console.WriteLine("Client connected...");
            serverSocket.BeginAccept(new AsyncCallback(AcceptCallBack), null);
        }
        private void ReceiveCallback(IAsyncResult ar)
        {
            Socket socket = (Socket)ar.AsyncState;
            int received = socket.EndReceive(ar);
            byte[] dataBuffer = new byte[received];
            Array.Copy(buffer, dataBuffer, received);
            string text = Encoding.UTF8.GetString(dataBuffer);
            serverPrint("text received: " + text);

            byte[] data = Encoding.UTF8.GetBytes(text);
            socket.BeginSend(data, 0, data.Length, SocketFlags.None, new AsyncCallback(SendCallBack), socket);
            socket.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, new AsyncCallback(ReceiveCallback), socket);
        }
        private static void SendCallBack(IAsyncResult ar)
        {
            Socket socket = (Socket)ar.AsyncState;
            socket.EndSend(ar);
        }
        private async void startServer()
        {
            await Task.Run(() => ServerSetup());
        }
        // CLIENT STUFF:

        // MainWindow STUFF:
        private void serverPrint(string str)
        {
            Dispatcher.BeginInvoke((Action)(() => serverBox.AppendText(str + "\n")));
        }

        public MainWindow()
        {
            InitializeComponent();
        }
        public void btn_connect_click(object sender, RoutedEventArgs e)
        {
            startServer();
        }
        public void btn_send_click(object sender, RoutedEventArgs e)
        {
            clientBox.Text += "\nspunk!\n";
        }
    }
}
