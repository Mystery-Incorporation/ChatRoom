using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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

            if (File.Exists("chat_profile.xml"))
            {
                StoredData info = XmlFile.readXMLFile(new StoredData(), Directory.GetCurrentDirectory() + "\\" + "chat_profile.xml");
                
                userNameBox.Text = info.userName;
                nameBox.Text = info.name;
                cityBox.Text = info.city;
            }

            if(File.Exists("profilePicture.bmp"))
            {
                //BitmapImage picsource = new BitmapImage(new Uri(Directory.GetCurrentDirectory() + "\\" + "profilePicture.bmp"));//,UriKind.Relative));
                profilePicture.Source = BitmapFrame.Create(
                    new Uri(Directory.GetCurrentDirectory() + "\\" + "profilePicture.bmp"),
                    BitmapCreateOptions.None,
                    BitmapCacheOption.OnLoad);
                
                //picsource;// new BitmapImage(new Uri(Directory.GetCurrentDirectory() + "\\" + "profilePicture.bmp"));//,UriKind.Relative));
                    //new ImageSourceConverter().ConvertFromString(Directory.GetCurrentDirectory() + "\\" + "profilePicture.bmp") as ImageSource;
                //new BitmapImage(new Uri(Directory.GetCurrentDirectory() + "\\" + "profilePicture.bmp"));//,UriKind.Relative));
            }
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
            pic.Filter = "Image Files(*.jpg, *.jpeg, *.jpe, *.jfif, *.png, .bmp)|.jpg; *.jpeg; *.jpe; *.jfif; *.png; *.bmp";

            if (pic.ShowDialog() == DialogResult.OK)
            {
                BitmapImage profileImage = new BitmapImage(new Uri(pic.FileName));
                BitmapEncoder encoder = new PngBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create(profileImage));

                using (var fileStream = new System.IO.FileStream("profilePicture.bmp", System.IO.FileMode.Create))
                {
                    encoder.Save(fileStream);
                }

                profilePicture.Source = profileImage;
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