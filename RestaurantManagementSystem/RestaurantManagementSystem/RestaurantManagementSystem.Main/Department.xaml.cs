using RestaurantManagementSystem.Entity;
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
using RestaurantManagementSystem.Service;
using System.Data.SqlClient;
using System.Data.Sql;
using RestaurantManagementSystem.Data;

namespace RestaurantManagementSystem.Main
{
    /// <summary>
    /// Interaction logic for Department.xaml
    /// </summary>
    public partial class Department : Window,IDisposable
    {
        public Department()
        {
            InitializeComponent();
        }

        public void Dispose() { }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            Item i = new Item(departmentTextBox.Text);
            ItemService Is = new ItemService();
            Is.AddDept(i);
            MessageBox.Show("Department Successfully Added", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
            LoadData();
        }
        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            Item it = (Item)departmentDataGrid.SelectedItem;
            if (it != null)
            {
                ItemService Is = new ItemService();

                if (MessageBox.Show("Are you want to Delete ?", "Confirm", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    Is.DeleteDept(it.DeptId);
                    Is.DeleteCate(it.DeptId);
                    Is.DeleteMenu(it.DeptId);
                }

                LoadData();
            }
        }
        private void editButton_Click(object sender, RoutedEventArgs e)
        {
            Item i = new Item(departmentTextBox.Text);
            ItemService Is = new ItemService();
            Is.AddDept(i);
        }

        private void ItemDataGridLoaded(object sender, RoutedEventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            String query = "select DEPARTMENT.DEPTID,DEPTNAME,CATEGORYLIST from DEPARTMENT";
            SqlDataReader reader = DataAccess.GetData(query);
            List<Item> DepartmentList = new List<Item>();
            
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    DepartmentList.Add(new Item(reader.GetString(0), reader.GetString(1), reader.IsDBNull(2) ? null : reader.GetString(2)));

                }
                departmentDataGrid.ItemsSource = DepartmentList;
            }
            
            

        }
        



    }
}
