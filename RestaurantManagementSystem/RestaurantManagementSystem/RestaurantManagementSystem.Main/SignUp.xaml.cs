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
using System.Windows.Shapes;
using RestaurantManagementSystem.Entity;
using RestaurantManagementSystem.Service;
using RestaurantManagementSystem.Data;
using System.Data.SqlClient;
using System.IO;

namespace RestaurantManagementSystem.Main
{
    /// <summary>
    /// Interaction logic for SignUp.xaml
    /// </summary>
    public partial class SignUp : Window,IDisposable
    {
        BitmapImage selectedImage;
        public SignUp()
        {
            InitializeComponent();
        }
        public void Dispose() { }
        String imageName;
        String Query;
        SqlDataReader reader;
        private void submitButton_Click(object sender, RoutedEventArgs e)
        {
            byte[] imageInByte;
            JpegBitmapEncoder encoder = new JpegBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(selectedImage));
            using (MemoryStream ms = new MemoryStream())
            {
                encoder.Save(ms);
                imageInByte = ms.ToArray();
            }

            //Storing into database
            Person p = new Person(personNameTextBox.Text, contactNoTextBox.Text, addressTextBox.Text, joinDate.SelectedDate.Value,bloodGroupComboBox.SelectionBoxItem.ToString(), imageInByte);
            PersonService ps = new PersonService();
            ps.Add(p);
            Query = "Select ID, PASSWORD from Person";
            reader = DataAccess.GetData(Query);
            reader.Read();
            MessageBox.Show("Sign Up Successful \nID : "+reader.GetString(0)+" \nPassword : "+reader.GetString(1)+" \n *Please Keep Your Id and Password in mind", "Successful", MessageBoxButton.OK, MessageBoxImage.Information);
            using(SignIn signin = new SignIn())
            {
                signin.Show();
                this.Close();
            }
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            using (SignIn signin = new SignIn())
            {
                signin.Show();
                this.Close();
            }
        }

        private void browseButton_Click(object sender, RoutedEventArgs e)
        {
              
            try
            {
                Microsoft.Win32.FileDialog fldlg = new Microsoft.Win32.OpenFileDialog();
                fldlg.InitialDirectory = Environment.SpecialFolder.MyPictures.ToString();
                fldlg.Filter = "Image File (*.png;*.jpg;*.bmp;*.gif)|*.png;*.jpg;*.bmp;*.gif";
                Uri uri;
                fldlg.ShowDialog();
                {
                    uri = new Uri(fldlg.FileName);
                    selectedImage = new BitmapImage(uri);
                    image2.Source = selectedImage;
                }
                fldlg = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void showButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
