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
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Extra_Click(object sender, RoutedEventArgs e)
        {
        }


       
        private void ViewList_Click_ViewHide(object sender, RoutedEventArgs e)
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
    }
}
