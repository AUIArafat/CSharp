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
    /// Interaction logic for ItemOperationHome.xaml
    /// </summary>
    public partial class ItemOperationHome : Window,IDisposable
    {
        public ItemOperationHome()
        {
            InitializeComponent();
        }

        public void Dispose() { }

        private void AddDepartmentButton_Click(object sender, RoutedEventArgs e)
        {
            using (Department dp = new Department ())
            {
                dp.ShowDialog();
            }
        }

        private void AddCategoryButton_Click(object sender, RoutedEventArgs e)
        {
            using (Category cate = new Category ())
            {
                cate.ShowDialog();
            }
        }

        private void MenuItemsButton_Click(object sender, RoutedEventArgs e)
        {
            using (MenuItems menu = new MenuItems ())
            {
                menu.ShowDialog();
            }
        }

        private void SetChargesButton_Click(object sender, RoutedEventArgs e)
        {

        }

       

        
    }
}
