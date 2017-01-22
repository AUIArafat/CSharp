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
using System.Data.SqlClient;
using RestaurantManagementSystem.Entity;
using RestaurantManagementSystem.Data;
using RestaurantManagementSystem.Service;
using System.Data;

namespace RestaurantManagementSystem.Main
{
    /// <summary>
    /// Interaction logic for ExpenseOperation.xaml
    /// </summary>
    public partial class ExpenseOperation : Window
    {
        public ExpenseOperation()
        {
            InitializeComponent();
        }
        String Id;
        public ExpenseOperation(String Id)
        {
            this.Id = Id;
        }
        private void LoadData()
        {
            String query = "select ID, CATEGORY, DESCRIPTION, AMOUNT, DATE from Expense";
            SqlDataReader reader = DataAccess.GetData(query);
            List<Expense> ExpenseList = new List<Expense>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    ExpenseList.Add(new Expense(reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetDouble(3), reader.GetDateTime(4)));
                }
            }
            expenseDataGrid.ItemsSource = ExpenseList;

        }
        private void Window_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            LoadData();
        }
        private void expenseDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //MessageBox.Show("Changed");
            if (e.AddedItems.Count > 0)
            {
                Expense p = (Expense)e.AddedItems[0];
                expenseDate.Text = p.ExpenseDate.ToString();
                expenseCategoryTextBox.Text = p.ExpenseCategory;
                expenseAmountTextBox.Text = p.ExpenseAmount.ToString();
                expenseDescriptionTextBox.Text = p.ExpenseDescription;
            }
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            String Query = "Select COUNT(ID) from Expense";
            SqlDataReader reader = DataAccess.GetData(Query);
            reader.Read();
            ExpenseService ex = new ExpenseService();
            Expense expense = new Expense(reader.GetInt32(0));
            expense.ExpenseCategory = expenseCategoryTextBox.Text;
            expense.ExpenseDescription = expenseDescriptionTextBox.Text;
            expense.ExpenseAmount = Convert.ToDouble(expenseAmountTextBox.Text);
            expense.ExpenseDate = expenseDate.SelectedDate.Value;
            ex.Add(expense);
            LoadData();
        }
        private void expenseDataGrid_Loaded(object sender, RoutedEventArgs e)
        {
            if (expenseDataGrid.Items.Count > 0)
            {
                Expense p = (Expense)expenseDataGrid.Items[0];
                expenseCategoryTextBox.Text = p.ExpenseCategory;
                expenseDate.Text = p.ExpenseDate.ToString();
                expenseAmountTextBox.Text = p.ExpenseAmount.ToString();
                expenseDescriptionTextBox.Text = p.ExpenseDescription;
            }
        }

        private void editButton_Click(object sender, RoutedEventArgs e)
        {
            Expense exp = (Expense)expenseDataGrid.SelectedItem;
            (new Edit(exp.ExpenseId)).ShowDialog();
            LoadData();
        }
        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            Expense ex = (Expense)expenseDataGrid.SelectedItem;
            if (ex != null)
            {
                ExpenseService exs = new ExpenseService();

                if (MessageBox.Show("Are you want to Delete ?", "Confirm", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    exs.Delete(ex.ExpenseId);
                }

                LoadData();
            }
        }
    }
}
