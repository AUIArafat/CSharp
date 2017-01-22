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
using RestaurantManagementSystem.Data;
using RestaurantManagementSystem.Entity;
using RestaurantManagementSystem.Service;
using System.Data.SqlClient;

namespace RestaurantManagementSystem.Main
{
    /// <summary>
    /// Interaction logic for SignIn.xaml
    /// </summary>
    public partial class SignIn : IDisposable
    {
        String Query;
        SqlDataReader reader;
        public SignIn()
        {
            InitializeComponent();
            String query = "Select COUNT(ID) from Person";
            SqlDataReader Reader = DataAccess.GetData(query);
            Reader.Read();
            if (Reader.GetInt32(0) != 0)
            {
                Query = "Select ID,PASSWORD,NAME from Person";
                reader = DataAccess.GetData(Query);
                reader.Read();
                idTextBox.Text = reader.GetString(0);
                signUp.Visibility=Visibility.Hidden;
            }
            if (Reader.GetInt32(0) == 0)
            {
                signInButton.IsEnabled = false;
            }
        }

        public void Dispose() { }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
             if(reader.GetString(1).Equals(passwordTextBox.Password.ToString()))
                using (HomePage homePage = new HomePage(reader.GetString(2)))
                {
                    homePage.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Invalid Password Or Id", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
        }

        private void SignUpButton_Click(object sender, RoutedEventArgs e)
        {
            using(SignUp signUp= new SignUp())
            {
                signUp.Show();
                this.Close();
            }
        }
    }
}
