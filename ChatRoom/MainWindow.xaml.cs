﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Microsoft.AspNetCore.SignalR.Client;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;

namespace ChatRoom
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<string> contacts = new List<string>() { "Anna", "Johan", "Sara", "Bertil" };
        private List<string> groups = new List<string>() { "The first group", "Amazing Group", "Fantastic Group", "The AmazeBallz" };
        private object content;
        public HubConnection Connection { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            content = Content;

            Connection = new HubConnectionBuilder()
                .WithUrl("http://localhost:55427/chathub")
                .Build();

            Connection.Closed += async (error) =>
            {
                await Task.Delay(new Random().Next(0, 5) * 1000);
                await Connection.StartAsync();
            };
        }

        private void Extra_Click(object sender, RoutedEventArgs e)
        {

        }

        /// <summary>
        /// Declare this page as the main window
        /// </summary>
        public void GoToChatWindow()
        {
            Content = content;
        }

        /// <summary>
        /// Opens up the collapsible listView
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void viewChats_Click(object sender, RoutedEventArgs e)
        {
            if (listActiveChats.Visibility == Visibility.Hidden)
            {
                listActiveChats.Visibility = Visibility.Visible;

            }
            else
            {
                listActiveChats.Visibility = Visibility.Hidden;
            }
        }

        /// <summary>
        /// Opens up the users direct messages
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DirectMessages_Click(object sender, RoutedEventArgs e)
        {
            listActiveChats.Items.Clear();
            foreach(string contact in contacts)
            {
                listActiveChats.Items.Add(contact);
            }
        }

        /// <summary>
        /// Opens up the users group chats
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GroupChat_Click(object sender, RoutedEventArgs e)
        {
            listActiveChats.Items.Clear();
            foreach(string group in groups)
            {
                listActiveChats.Items.Add(group);
            }
        }

        /// <summary>
        /// Opens up the users profile page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void profile_Click(object sender, RoutedEventArgs e)
        {
            ProfilePage profile = new ProfilePage(this);
            this.Content = profile;
        }

        private void WriteMessage_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private async void SendButton_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                String userName = "Legion";
                if (File.Exists("chat_profile.xml"))
                {
                    userName = XmlFile.readXMLFile(new StoredData(), Directory.GetCurrentDirectory() + @"\" + "chat_profile.xml").userName;
                }
                await Connection.InvokeAsync("SendMessage", userName, WriteMessage.Text);
            }
            catch (Exception ex)
            {
                ChatHistory.Items.Add(ex.Message);
            }
        }

        private async void OnWindowLoaded(object sender, RoutedEventArgs e)
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
                ConnectionStatus.Text = "Online";
                SendButton.IsEnabled = true;
            }
            catch (Exception ex)
            {
                ChatHistory.Items.Add(ex.Message);
            }
        }
    }
}
