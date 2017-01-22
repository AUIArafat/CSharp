using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
using RestaurantManagementSystem.Data;
using RestaurantManagementSystem.Entity;
using RestaurantManagementSystem.Service;
using System.Data;
using System.IO;
using System.Drawing;

namespace RestaurantManagementSystem.Main
{
    /// <summary>
    /// Interaction logic for PersonDetails.xaml
    /// </summary>
    public partial class PersonDetails : Window, IDisposable
    {
        public void Dispose() { }
        String imageName;
        public PersonDetails()
        {
            InitializeComponent();
        }


        private void LoadData()
        {
            String query = "select ID,NAME,CONTACTNO, PASSWORD, ADDRESS, JOINDATE,BLOODGROUP,IMAGE from Person";
            SqlDataReader reader = DataAccess.GetData(query);
            PersonService ps = new PersonService();
            Person p = new Person();
            reader.Read();
            try
            {
                byte[] imageInByte = (byte[])reader[7];

                Stream StreamObj = new MemoryStream(imageInByte);
                BitmapImage retrievedImage = new BitmapImage();
                retrievedImage.BeginInit();
                retrievedImage.StreamSource = StreamObj;
                retrievedImage.EndInit();
            this.image2.Source = retrievedImage;
            }
            catch (Exception e) { MessageBox.Show(e.Message.ToString()); }
            personIdTextBlock.Text = reader.GetString(0);
            personNameTextBlock.Text = reader.GetString(1);
            contactNoTextBox.Text = reader.GetString(2);
            passwordBox.Password = reader.GetString(3);
            addressTextBox.Text = reader.GetString(4);
            joinDate.SelectedDate = reader.GetDateTime(5);
            bloodGroupComboBox.Text = reader.GetString(6);
        }
        private void Window_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            LoadData();
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void browseButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Microsoft.Win32.FileDialog fldlg = new Microsoft.Win32.OpenFileDialog();
                fldlg.InitialDirectory = Environment.SpecialFolder.MyPictures.ToString();
                fldlg.Filter = "Image File (*.jpg;*.bmp;*.gif)|*.jpg;*.bmp;*.gif";
                fldlg.ShowDialog();
                {
                    imageName = fldlg.FileName;
                    ImageSourceConverter isc = new ImageSourceConverter();
                    image2.SetValue(System.Windows.Controls.Image.SourceProperty, isc.ConvertFromString(imageName));
                }
                fldlg = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void updateButton_Click(object sender, RoutedEventArgs e)
        {
            String query = "select ID from Person";
            SqlDataReader reader = DataAccess.GetData(query);
            PersonService ps = new PersonService();
            Person p = new Person();
            p.ContactNo = contactNoTextBox.Text;
            p.Address = addressTextBox.Text;
            p.BloodGroup = bloodGroupComboBox.Text;
            //p.Image = image2.Source;
            p.Password = passwordBox.Password;
            reader.Read();
            ps.Edit(p, reader.GetString(0));
            if (passwordBox.Password.Equals(confirmPasswordBox.Password))
            {

                MessageBox.Show("Update Successful", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                LoadData();
            }
            else
            {
                MessageBox.Show("Missmatch Password", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
