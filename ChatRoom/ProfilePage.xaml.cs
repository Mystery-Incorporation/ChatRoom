using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MessageBox = System.Windows.Forms.MessageBox;
using OpenFileDialog = System.Windows.Forms.OpenFileDialog;


namespace ChatRoom
{
    /// <summary>
    /// Interaction logic for ProfilePage.xaml
    /// </summary>
    public partial class ProfilePage : Page
    {
        private MainWindow mainWindow;

        /// <summary>
        /// Sets this page as the temporarly main window
        /// </summary>
        /// <param name="mainWindow"></param>
        public ProfilePage(MainWindow mainWindow)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
        }

        /// <summary>
        /// Returns to the declared mainWindow
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void returnToChat_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.GoToChatWindow();
        }

        /// <summary>
        /// Opens up a file dialog for the user to choose a profile picture
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addProfilePic_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog pic = new OpenFileDialog();
            pic.InitialDirectory = "c:\\";
            pic.Title = "Select your profile picture";
            pic.Filter = "Image Files(*.jpg, *.jpeg, *.jpe, *.jfif, *.png *.bmp)|*.jpg; *.jpeg; *.jpe; *.jfif; *.png *.bmp";

            if (pic.ShowDialog() == DialogResult.OK)
            {
                profilePicture.Source = new BitmapImage(new Uri(pic.FileName));
            }
        }

        /// <summary>
        /// Button click function that saves user data through a StoredData as an xml-file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void save_profile_data(object sender, RoutedEventArgs e)
        {
            try
            {
                StoredData info = new StoredData();
                info.userName = userNameBox.Text;
                info.name = nameBox.Text;
                info.city = cityBox.Text;

                XmlFile.writeXMLFile(info, "chat_profile.xml");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
