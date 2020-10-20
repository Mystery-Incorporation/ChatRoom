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

        public MainWindow()
        {
            InitializeComponent();
            content = Content;
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
        /// Opens up the collapseable listView
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
    }
}
