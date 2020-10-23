using System;
using Microsoft.AspNetCore.SignalR.Client;
using System.Threading.Tasks;
using System.Windows;

namespace WpfCoreClient2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public HubConnection Connection { get; set; }
        public MainWindow()
        {
            InitializeComponent();

            Connection = new HubConnectionBuilder()
                .WithUrl("http://localhost:55427/chathub")
                .Build();

            Connection.Closed += async (error) =>
            {
                await Task.Delay(new Random().Next(0, 5) * 1000);
                await Connection.StartAsync();
            };
        }

        private async void ConnectButton_Click(object sender, RoutedEventArgs e)
        {
            Connection.On<string, string>("ReceiveMessage", (user, message) =>
            {
                this.Dispatcher.Invoke(() =>
                {
                    var newMessage = $"{user}: {message}";
                    ChatHistory.Items.Add(newMessage);
                });
            });

            try
            {
                await Connection.StartAsync();
                ConnectionStatus.Text = "Connection: OK";
                ConnectButton.IsEnabled = false;
                SendButton.IsEnabled = true;
            }
            catch (Exception ex)
            {
                ChatHistory.Items.Add(ex.Message);
            }
        }

        private async void SendButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                await Connection.InvokeAsync("SendMessage",
                    UserName.Text, SendText.Text);
            }
            catch (Exception ex)
            {
                ChatHistory.Items.Add(ex.Message);
            }
        }
    }
}
