using RestaurantManagementSystem.Data;
using RestaurantManagementSystem.Entity;
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
    /// Interaction logic for BookingReport.xaml
    /// </summary>
    public partial class BookingReport : Window,IDisposable
    {
        public BookingReport()
        {
            InitializeComponent();
        }

        public void Dispose() { }

        private void Window_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            String query = "select BOOKINGID,BOOKINGDATE,STARTTIME,ENDINGTIME,TABLENO,TOTALTABLE,CUSTOMERNAME,PHONE,ADDRESS,ADVANCE from BOOKING";
            SqlDataReader reader = DataAccess.GetData(query);
            List<Booking> bookingReportList = new List<Booking>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    bookingReportList.Add(new Booking (reader.GetString(0),reader.GetDateTime(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetInt32(5), reader.GetString(6), reader.GetString(7), reader.GetString(8), reader.GetDouble(9)));
                }
            }
            bookingReportDataGrid.ItemsSource = bookingReportList;
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            Booking booking = (Booking)bookingReportDataGrid.SelectedItem;
            if (booking != null)
            {
                BookingService bookingService = new BookingService();

                if (MessageBox.Show("Are you want to Delete ?", "Confirm", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    bookingService.DeleteBooking(booking.BookingNo);
                }

                LoadData();
            }
        }

        private void confirmButton_Click(object sender, RoutedEventArgs e)
        {
            Booking booking = (Booking)bookingReportDataGrid.SelectedItem;
            using (AdvanceBookingBilling adavanceBookingBilling = new AdvanceBookingBilling(booking))
            {
                adavanceBookingBilling.ShowDialog();
                this.Close();
            }
        }

    }
}
