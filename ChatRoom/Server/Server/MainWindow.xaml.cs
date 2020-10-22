using ServerClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
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

namespace Server
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SocketServer mServer;

        public MainWindow()
        {
            InitializeComponent();
            mServer = new SocketServer(testblock);
           
        }

        private void btnStartServer_Click(object sender, RoutedEventArgs e)
        {
            mServer.StartListeningForIncomingConnection();
        }

        private void btnSendAll_Click(object sender, RoutedEventArgs e)
        {
            mServer.SendToAll(txtMessage.Text.Trim());
            
        }

        private void btnStopServer_Click(object sender, RoutedEventArgs e)
        {
            mServer.StopServer();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            mServer.StopServer();
        }
    }
}
