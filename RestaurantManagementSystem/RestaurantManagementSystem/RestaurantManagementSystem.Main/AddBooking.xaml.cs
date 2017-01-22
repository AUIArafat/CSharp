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
using System.Data.SqlClient;
using RestaurantManagementSystem.Data;

namespace RestaurantManagementSystem.Main
{
    /// <summary>
    /// Interaction logic for AddBooking.xaml
    /// </summary>
    public partial class AddBooking : Window, IDisposable
    {
        String tableNo = null;
        public AddBooking()
        {
            InitializeComponent();
            bookingDate.SelectedDate = DateTime.Now.Date;
            LoadData(bookingDate.SelectedDate.Value);
        }

        public void Dispose() { }


        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            int tableCount = tableNoTextBox.Text.Split(',').Length;
            Booking b = new Booking(Convert.ToDateTime(bookingDate.Text), startTimeTextBox.Text, endingTimeTextBox.Text, tableNoTextBox.Text, tableCount, customerNameTextBox.Text, phoneTextBox.Text, addressTextBox.Text, Convert.ToDouble(advanceTextBox.Text));
            BookingService bs = new BookingService();
            bs.AddBooking(b);
            MessageBox.Show("Successfull Booking");
            this.Close();
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void One_Click(object sender, RoutedEventArgs e)
        {
            if (tableNo != null)
            {
                tableNo = tableNo + "," + "1";
                tableNoTextBox.Text = tableNo;
            }
            else
            {
                tableNo = "1";
                tableNoTextBox.Text = tableNo;
            }

        }

        private void Four_Click(object sender, RoutedEventArgs e)
        {
            if (tableNo != null)
            {
                tableNo = tableNo + "," + "4";
                tableNoTextBox.Text = tableNo;
            }
            else
            {
                tableNo = "4";
                tableNoTextBox.Text = tableNo;
            }

        }

        private void Two_Click(object sender, RoutedEventArgs e)
        {
            if (tableNo != null)
            {
                tableNo = tableNo + "," + "2";
                tableNoTextBox.Text = tableNo;
            }
            else
            {
                tableNo = "2";
                tableNoTextBox.Text = tableNo;
            }

        }

        private void Three_Click(object sender, RoutedEventArgs e)
        {
            if (tableNo != null)
            {
                tableNo = tableNo + "," + "3";
                tableNoTextBox.Text = tableNo;
            }
            else
            {
                tableNo = "3";
                tableNoTextBox.Text = tableNo;
            }

        }

        private void Five_Click(object sender, RoutedEventArgs e)
        {
            if (tableNo != null)
            {
                tableNo = tableNo + "," + "5";
                tableNoTextBox.Text = tableNo;
            }
            else
            {
                tableNo = "5";
                tableNoTextBox.Text = tableNo;
            }

        }

        private void Six_Click(object sender, RoutedEventArgs e)
        {
            if (tableNo != null)
            {
                tableNo = tableNo + "," + "6";
                tableNoTextBox.Text = tableNo;
            }
            else
            {
                tableNo = "6";
                tableNoTextBox.Text = tableNo;
            }

        }

        private void Seven_Click(object sender, RoutedEventArgs e)
        {
            if (tableNo != null)
            {
                tableNo = tableNo + "," + "7";
                tableNoTextBox.Text = tableNo;
            }
            else
            {
                tableNo = "7";
                tableNoTextBox.Text = tableNo;
            }
        }

        private void Eight_Click(object sender, RoutedEventArgs e)
        {
            if (tableNo != null)
            {
                tableNo = tableNo + "," + "8";
                tableNoTextBox.Text = tableNo;
            }
            else
            {
                tableNo = "8";
                tableNoTextBox.Text = tableNo;
            }

        }

        private void Nine_Click(object sender, RoutedEventArgs e)
        {
            if (tableNo != null)
            {
                tableNo = tableNo + "," + "9";
                tableNoTextBox.Text = tableNo;
            }
            else
            {
                tableNo = "9";
                tableNoTextBox.Text = tableNo;
            }

        }

        private void Ten_Click(object sender, RoutedEventArgs e)
        {
            if (tableNo != null)
            {
                tableNo = tableNo + "," + "10";
                tableNoTextBox.Text = tableNo;
            }
            else
            {
                tableNo = "10";
                tableNoTextBox.Text = tableNo;
            }
        }

        private void Eleven_Click(object sender, RoutedEventArgs e)
        {
            if (tableNo != null)
            {
                tableNo = tableNo + "," + "11";
                tableNoTextBox.Text = tableNo;
            }
            else
            {
                tableNo = "11";
                tableNoTextBox.Text = tableNo;
            }
        }

        private void Twelve_Click(object sender, RoutedEventArgs e)
        {
            if (tableNo != null)
            {
                tableNo = tableNo + "," + "12";
                tableNoTextBox.Text = tableNo;
            }
            else
            {
                tableNo = "12";
                tableNoTextBox.Text = tableNo;
            }
        }

        private void Thirteen_Click(object sender, RoutedEventArgs e)
        {
            if (tableNo != null)
            {
                tableNo = tableNo + "," + "13";
                tableNoTextBox.Text = tableNo;
            }
            else
            {
                tableNo = "13";
                tableNoTextBox.Text = tableNo;
            }

        }

        private void Fourteen_Click(object sender, RoutedEventArgs e)
        {
            if (tableNo != null)
            {
                tableNo = tableNo + "," + "14";
                tableNoTextBox.Text = tableNo;
            }
            else
            {
                tableNo = "14";
                tableNoTextBox.Text = tableNo;
            }

        }

        private void Fifteen_Click(object sender, RoutedEventArgs e)
        {
            if (tableNo != null)
            {
                tableNo = tableNo + "," + "15";
                tableNoTextBox.Text = tableNo;
            }
            else
            {
                tableNo = "15";
                tableNoTextBox.Text = tableNo;
            }

        }

        private void Sixteen_Click(object sender, RoutedEventArgs e)
        {
            if (tableNo != null)
            {
                tableNo = tableNo + "," + "16";
                tableNoTextBox.Text = tableNo;
            }
            else
            {
                tableNo = "16";
                tableNoTextBox.Text = tableNo;
            }

        }

        private void Seventeen_Click(object sender, RoutedEventArgs e)
        {
            if (tableNo != null)
            {
                tableNo = tableNo + "," + "17";
                tableNoTextBox.Text = tableNo;
            }
            else
            {
                tableNo = "17";
                tableNoTextBox.Text = tableNo;
            }

        }

        private void Eighteen_Click(object sender, RoutedEventArgs e)
        {
            if (tableNo != null)
            {
                tableNo = tableNo + "," + "18";
                tableNoTextBox.Text = tableNo;
            }
            else
            {
                tableNo = "18";
                tableNoTextBox.Text = tableNo;
            }
        }

        private void Nineteen_Click(object sender, RoutedEventArgs e)
        {
            if (tableNo != null)
            {
                tableNo = tableNo + "," + "19";
                tableNoTextBox.Text = tableNo;
            }
            else
            {
                tableNo = "19";
                tableNoTextBox.Text = tableNo;
            }
        }

        private void Twenty_Click(object sender, RoutedEventArgs e)
        {
            if (tableNo != null)
            {
                tableNo = tableNo + "," + "20";
                tableNoTextBox.Text = tableNo;
            }
            else
            {
                tableNo = "20";
                tableNoTextBox.Text = tableNo;
            }
        }

        private void bookingDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            LoadData(bookingDate.SelectedDate.Value);
        }

        private void LoadData(DateTime bookingDate)
        {
            One.IsEnabled = true;
            Two.IsEnabled = true;
            Three.IsEnabled = true;
            Four.IsEnabled = true;
            Five.IsEnabled = true;
            Six.IsEnabled = true;
            Seven.IsEnabled = true;
            Eight.IsEnabled = true;
            Nine.IsEnabled = true;
            Ten.IsEnabled = true;
            Eleven.IsEnabled = true;
            Twelve.IsEnabled = true;
            Thirteen.IsEnabled = true;
            Fourteen.IsEnabled = true;
            Fifteen.IsEnabled = true;
            Sixteen.IsEnabled = true;
            Seventeen.IsEnabled = true;
            Eighteen.IsEnabled = true;
            Nineteen.IsEnabled = true;
            Twenty.IsEnabled = true;
            String Query = "Select TABLENO from Booking Where BOOKINGDATE='" + bookingDate.ToString() + "'";
            SqlDataReader reader = DataAccess.GetData(Query);
            String[] S1 = null;
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    
                    if (reader.GetString(0).Contains(','))
                    {
                        S1 = reader.GetString(0).Split(',');
                        for (int i = 0; i < S1.Length; i++)
                        {
                            if (S1[i].Equals("1"))
                            {
                                One.IsEnabled = false;
                            }
                            if (S1[i].Equals("2"))
                            {
                                Two.IsEnabled = false;

                            }
                            if (S1[i].Equals("3"))
                            {
                                Three.IsEnabled = false;
                            }
                            if (S1[i].Equals("4"))
                            {
                                Four.IsEnabled = false;
                            }
                            if (S1[i].Equals("5"))
                            {
                                Five.IsEnabled = false;
                            }
                            if (S1[i].Equals("6"))
                            {
                                Six.IsEnabled = false;
                            }
                            if (S1[i].Equals("7"))
                            {
                                Seven.IsEnabled = false;
                            }
                            if (S1[i].Equals("8"))
                            {
                                Eight.IsEnabled = false;
                            }
                            if (S1[i].Equals("9"))
                            {
                                Nine.IsEnabled = false;
                            }
                            if (S1[i].Equals("10"))
                            {
                                Ten.IsEnabled = false;
                            }
                            if (S1[i].Equals("11"))
                            {
                                Eleven.IsEnabled = false;
                            }
                            if (S1[i].Equals("12"))
                            {
                                Twelve.IsEnabled = false;
                            }
                            if (S1[i].Equals("13"))
                            {
                                Thirteen.IsEnabled = false;
                            }
                            if (S1[i].Equals("14"))
                            {
                                Fourteen.IsEnabled = false;
                            }
                            if (S1[i].Equals("15"))
                            {
                                Fifteen.IsEnabled = false;
                            }
                            if (S1[i].Equals("16"))
                            {
                                Sixteen.IsEnabled = false;
                            }
                            if (S1[i].Equals("17"))
                            {
                                Seventeen.IsEnabled = false;
                            }
                            if (S1[i].Equals("18"))
                            {
                                Eighteen.IsEnabled = false;
                            }
                            if (S1[i].Equals("19"))
                            {
                                Nineteen.IsEnabled = false;
                            }
                            if (S1[i].Equals("20"))
                            {
                                Twenty.IsEnabled = false;
                            }
                        }
                    }
                    else
                    {
                        if (reader.GetString(0).Equals("1"))
                        {
                            One.IsEnabled = false;
                        }
                        if (reader.GetString(0).Equals("2"))
                        {
                            Two.IsEnabled = false;
                        }
                        if (reader.GetString(0).Equals("3"))
                        {
                            Three.IsEnabled = false;
                        }
                        if (reader.GetString(0).Equals("4"))
                        {
                            Four.IsEnabled = false;
                        }
                        if (reader.GetString(0).Equals("5"))
                        {
                            Five.IsEnabled = false;
                        }
                        if (reader.GetString(0).Equals("6"))
                        {
                            Six.IsEnabled = false;
                        }
                        if (reader.GetString(0).Equals("7"))
                        {
                            Seven.IsEnabled = false;
                        }
                        if (reader.GetString(0).Equals("8"))
                        {
                            Eight.IsEnabled = false;
                        }
                        if (reader.GetString(0).Equals("9"))
                        {
                            Nine.IsEnabled = false;
                        }
                        if (reader.GetString(0).Equals("10"))
                        {
                            Ten.IsEnabled = false;
                        }
                        if (reader.GetString(0).Equals("11"))
                        {
                            Eleven.IsEnabled = false;
                        }
                        if (reader.GetString(0).Equals("12"))
                        {
                            Twelve.IsEnabled = false;
                        }
                        if (reader.GetString(0).Equals("13"))
                        {
                            Thirteen.IsEnabled = false;
                        }
                        if (reader.GetString(0).Equals("14"))
                        {
                            Fourteen.IsEnabled = false;
                        }
                        if (reader.GetString(0).Equals("15"))
                        {
                            Fifteen.IsEnabled = false;
                        }
                        if (reader.GetString(0).Equals("16"))
                        {
                            Sixteen.IsEnabled = false;
                        }
                        if (reader.GetString(0).Equals("17"))
                        {
                            Seventeen.IsEnabled = false;
                        }
                        if (reader.GetString(0).Equals("18"))
                        {
                            Eighteen.IsEnabled = false;
                        }
                        if (reader.GetString(0).Equals("19"))
                        {
                            Nineteen.IsEnabled = false;
                        }
                        if (reader.GetString(0).Equals("20"))
                        {
                            
                            Twenty.IsEnabled = false;
                        }
                    }
                }
            }
        
    }
        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            LoadData(bookingDate.SelectedDate.Value);
        }
    }
}
