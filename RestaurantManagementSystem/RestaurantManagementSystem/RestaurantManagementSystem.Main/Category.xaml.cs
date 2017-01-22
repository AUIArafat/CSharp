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
    /// Interaction logic for Category.xaml
    /// </summary>
    public partial class Category : Window
    {
        public Category()
        {
            InitializeComponent();
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
			private void addButton_Click(object sender, RoutedEventArgs e)
        {
            Item i = new Item(CategoryNameTextBox.Text,);
            ItemService Is = new ItemService();
            Is.AddDept(i);
            MessageBox.Show("Department Successfully Added", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
            LoadData();
        }
        }

        private void browseButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void expenseDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
