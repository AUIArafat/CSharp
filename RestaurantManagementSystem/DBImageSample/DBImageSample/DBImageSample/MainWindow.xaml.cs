using Microsoft.Win32;
using System;
using System.Data.SqlClient;
using System.IO;
using System.Windows;
using System.Windows.Media.Imaging;


namespace DBImageSample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        BitmapImage selectedImage;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void openButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();

            Uri uri;            
            if (dialog.ShowDialog() == true)
            {
                uri = new Uri(dialog.FileName);
                selectedImage = new BitmapImage(uri);
                openedImageHolder.Source = selectedImage;
            }

        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            //Converting the selected image into byte array
            byte[] imageInByte;
            JpegBitmapEncoder encoder = new JpegBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(selectedImage));
            using (MemoryStream ms = new MemoryStream())
            {
                encoder.Save(ms);
                imageInByte = ms.ToArray();
            }

            //Storing into database
            if (imageInByte != null)
            {
                //try
                //{                   
                    SqlConnection conn = new SqlConnection("Server = ARAFAT\\SQLEXPRESS; Database = persondb; User Id=sa; Password=P@$$w0rd");
                    conn.Open();
                    SqlCommand sc = new SqlCommand("INSERT INTO person(name, photo) VALUES('bond', '"+imageInByte+"')", conn);
                    //sc.Parameters.AddWithValue("@n", "bond");
                    //sc.Parameters.AddWithValue("@p", imageInByte);
                    sc.ExecuteNonQuery();

                    conn.Close();
                    MessageBox.Show("Inserted");
                //}
                //catch (Exception ex)
                //{
                //    MessageBox.Show(ex.Message);
                //}
            }

        }

        private void showButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection("Server = ARAFAT\\SQLEXPRESS; Database = persondb; User Id=sa; Password=P@$$w0rd");
                conn.Open();
                SqlCommand sc = new SqlCommand("SELECT photo FROM person WHERE name LIKE 'bond'", conn);
                SqlDataReader reader = sc.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    byte[] imageInByte = (byte[])reader["photo"];

                    Stream StreamObj = new MemoryStream(imageInByte);
                    BitmapImage retrievedImage = new BitmapImage();
                    retrievedImage.BeginInit();
                    retrievedImage.StreamSource = StreamObj;
                    retrievedImage.EndInit();

                    this.dbImageHolder.Source = retrievedImage;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
    }
}
