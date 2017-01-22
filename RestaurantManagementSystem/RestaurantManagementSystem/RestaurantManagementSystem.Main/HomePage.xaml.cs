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

namespace RestaurantManagementSystem.Main
{
    /// <summary>
    /// Interaction logic for HomePage.xaml
    /// </summary>
    public partial class HomePage : IDisposable
    {
        public void Dispose() { }
        public HomePage(String loginName)
        {
            InitializeComponent();
            MessageBox.Show(loginName);
            loginNameTextBlock.Text = loginName;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            (new ExpenseOperation()).ShowDialog();
        }
        private void loginNameTextBlock_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            using (PersonDetails pd = new PersonDetails())
            {
                pd.ShowDialog();
            }
        }

        private void signOutButton_Click(object sender, RoutedEventArgs e)
        {
            using (SignIn si = new SignIn())
            {
                si.Show();
                this.Close();
            }
        }

        private void restaurentOperationButton_Click(object sender, RoutedEventArgs e)
        {
            using (ItemOperationHome ih = new ItemOperationHome())
            {
                ih.ShowDialog();

            }
        }

        private void BillingButton_Click(object sender, RoutedEventArgs e)
        {
            using (Billing bl = new Billing())
            {
                bl.ShowDialog();
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }



        private void BookingButton_Click(object sender, RoutedEventArgs e)
        {
            using (AddBooking ab = new AddBooking())
            {
                ab.ShowDialog();
            }
        }

        private void bookingReportButton_click(object sender, RoutedEventArgs e)
        {
            using (BookingReport bookingReport = new BookingReport())
            {
                bookingReport.ShowDialog();
            }
        }

        private void profitLossStatusButton_Click(object sender, RoutedEventArgs e)
        {
            using (ProfitStatus PS = new ProfitStatus())
            {
                PS.ShowDialog();
            }
        }

        private void AddOperatorButton_Click(object sender, RoutedEventArgs e)
        {
            using (AddOperator addOperator = new AddOperator())
            {
                addOperator.ShowDialog();
            }
        }

        private void paymentReportButton_click(object sender, RoutedEventArgs e)
        {
            using (Payment payment = new Payment())
            {
                payment.ShowDialog();
            }
        }

        private void aboutButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Will Be updated Soon!!!");
        }
    }
}
