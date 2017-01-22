using RestaurantManagementSystem.Data;
using RestaurantManagementSystem.Service;
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

namespace RestaurantManagementSystem.Main
{
    /// <summary>
    /// Interaction logic for Payment.xaml
    /// </summary>
    public partial class Payment : Window,IDisposable
    {
        public Payment()
        {
            InitializeComponent();
            payingDate.Text = DateTime.Now.ToString ();
            getOperatorId();
        }
        public void Dispose() { }
        private void getOperatorId()
        {
            String query = "select OPERATORID,NAME from Operator";
            SqlDataReader reader = DataAccess.GetData(query);
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    operatorComboBox.Items.Add(reader.GetString (0));
                }
            }

        }
        private void dataGrid_Loaded(object sender, RoutedEventArgs e)
        {
            LoadData();
        }


        private void LoadData()
        {
            List<Entity.Payment> paymentList = new List<Entity.Payment>();
            String query = "select OPERATORNAME,SALARY,PAYMENTDATE,PAYMENTSTATUS from Payment";
            SqlDataReader reader = DataAccess.GetData(query);
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Entity.Payment payment = new Entity.Payment();
                    payment.OperatorName = reader.GetString(0);
                    payment.OperatorSalary = reader.GetDouble(1);
                    payment.PaymentDate = reader.GetDateTime(2);
                    payment.PaymentStatus = reader.GetString(3);
                    paymentList.Add(payment);
                }
            }
            paymentDataGrid.ItemsSource = paymentList;
        }

        private void GoButton_Click(object sender, RoutedEventArgs e)
        {
            String query = "select NAME,INITIALSALARY from Operator where OPERATORID='"+operatorComboBox.Text+"'";
            SqlDataReader reader = DataAccess.GetData(query);
            reader.Read();
            nameTextBlock.Text = reader.GetString(0);
            salaryTextBlock.Text = reader.GetDouble(1).ToString ();

        }

        private void PayButton_Click(object sender, RoutedEventArgs e)
        {
            Entity.Payment payment = new Entity.Payment(nameTextBlock.Text, Convert.ToDouble(salaryTextBlock.Text)+Convert.ToDouble(BonusTextBox.Text),Convert.ToDateTime(payingDate.Text),"Paid");
            PaymentService paymentService = new PaymentService();
            paymentService.AddPayment(payment);
            LoadData();
        }
    }
}
