using RestaurantManagementSystem.Data;
using RestaurantManagementSystem.Entity;
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
using System.Data;
namespace RestaurantManagementSystem.Main
{
    /// <summary>
    /// Interaction logic for Billing.xaml
    /// </summary>
    public partial class Billing : Window,IDisposable
    {
        List<Item> BookingList = new List<Item>();
        List<Item> billingList = new List<Item>();
        public Billing()
        {
            InitializeComponent();
            getCategoryId();
        }

        public void Dispose() { }

        private void getCategoryId()
        {
            String Query = "Select CATEGORYID, CATEGORYNAME from CATEGORY";
            SqlDataReader reader = DataAccess.GetData(Query);

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    categoryComboBox.Items.Add(reader.GetString(1));
                }
            }
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void GoButton_Click(object sender, RoutedEventArgs e)
        {
            String query = "select MENULIST,CATEGORYPRICE from Category where CATEGORYNAME = '"+categoryComboBox.Text+"' ";
            SqlDataReader reader = DataAccess.GetData(query);
            if (reader.HasRows)
            {

                reader.Read();
                //Item i= new Item();
                //i.MenuList=reader.GetString(0);
                //i.CategoryPrice = reader.GetDouble(1);
                //BookingList.Add(i);
                DataTable dt = new DataTable();
                dt.Columns.Add("MenuList");
                dt.Columns.Add("CategoryPrice");
                dt.Columns.Add("Quantity");
                dt.Rows.Add(reader.GetString(0), reader.GetDouble(1));
                BookingDataGrid.ItemsSource = dt.DefaultView;
            }
            //BookingDataGrid.ItemsSource = BookingList;
            
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            Item i = new Item();
            i.CategoryName = categoryComboBox.Text;
           // i.Quantity = BookingList[0].Quantity;
           int i = book
            DataView dv = (DataView)BookingDataGrid.ItemsSource;
            MessageBox.Show(dv.Table.DefaultView[0]["Quantity"].ToString());

            i.CategoryPrice = BookingList[0].CategoryPrice * i.Quantity;
            billingList.Add(i);
            billingDataGrid.ItemsSource = billingList;
            

            //i.CategoryPrice = 
        }
    }
}
