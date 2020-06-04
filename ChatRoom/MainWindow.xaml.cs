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

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Extra_Click(object sender, RoutedEventArgs e)
        {

        }



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

        private void DirectMessages_Click(object sender, RoutedEventArgs e)
        {
            listActiveChats.Items.Clear();
            foreach(string contact in contacts)
            {
                listActiveChats.Items.Add(contact);
            }
        }

        private void GroupChat_Click(object sender, RoutedEventArgs e)
        {
            listActiveChats.Items.Clear();
            foreach(string group in groups)
            {
                listActiveChats.Items.Add(group);
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Send_Click(object sender, RoutedEventArgs e)
        {
            MessageLabel.Visibility = Visibility.Visible;
            MessageLabel.Content = textBox1.Text;
            textBox1.Clear();
        }
    }
}
