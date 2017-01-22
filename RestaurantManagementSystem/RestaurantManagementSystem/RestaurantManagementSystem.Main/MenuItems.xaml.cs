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
    /// Interaction logic for MenuItems.xaml
    /// </summary>
    public partial class MenuItems : Window, IDisposable
    {
        public MenuItems()
        {
            InitializeComponent();
            getComboData();
        }

        public void Dispose() { }

        private void getComboData()
        {
            String Query = "Select CATEGORYID from CATEGORY";
            SqlDataReader reader = DataAccess.GetData(Query);
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    categoryNameComboBox.Items.Add(reader.GetString(0));
                }
            }
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            String MenuList = null;
            String qurey = "select Count(MenuId) from Menu";
            SqlDataReader read = DataAccess.GetData(qurey);
            read.Read();
            Item i = new Item(menuItemsTextBox.Text, read.GetInt32(0));
            i.CategoryId = categoryNameComboBox.Text;
            ItemService Is = new ItemService();
            Is.AddMenuItem(i);
            MessageBox.Show(menuItemsTextBox.Text);
            String query1 = "select MENUNAME from MENU where CATEGORYID = '" + categoryNameComboBox.Text + "'";
            SqlDataReader reader = DataAccess.GetData(query1);
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    if (MenuList != null)
                    {
                        MenuList = MenuList + "," + reader.GetString(0);
                        
                    }
                    else MenuList = reader.GetString(0);

                }

            }
            String query2 = "update CATEGORY set MENULIST ='" + MenuList + "' where CATEGORYID='" + categoryNameComboBox.Text + "' ";
            DataAccess.ExecuteQuery(query2);
            MessageBox.Show("Menu Successfully Added", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
            LoadData();
        }

        

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            String query = "select CATEGORYID, CATEGORYNAME,IMAGE, CATEGORYPRICE,MENULIST from Category";
            SqlDataReader reader = DataAccess.GetData(query);
            List<Item> CategoryList = new List<Item>();
            if (reader.HasRows)
            {

                while (reader.Read())
                {

                    CategoryList.Add(new Item(reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetDouble(3), reader.IsDBNull(4) ? null : reader.GetString(4)));
                }
            }
            menuDataGrid.ItemsSource = CategoryList;

        }
    }
}
