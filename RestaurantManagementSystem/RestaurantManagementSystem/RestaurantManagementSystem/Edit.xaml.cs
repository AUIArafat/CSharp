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
using RestaurantManagementSystem.Data;
using RestaurantManagementSystem.Entity;
using RestaurantManagementSystem.Service;
using System.Data.SqlClient;

namespace RestaurantManagementSystem
{
    /// <summary>
    /// Interaction logic for Edit.xaml
    /// </summary>
    public partial class Edit : Window
    {
        public Edit()
        {
            InitializeComponent();
        }
        String Id;
        public Edit(String Id)
        {
            this.Id = Id;
            InitializeComponent();
        }
        private void LoadData()
        {
            String query = "select CATEGORY, DESCRIPTION, AMOUNT, DATE from Expense where ID = '" + Id + "'";
            SqlDataReader reader = DataAccess.GetData(query);
            reader.Read();
            expenseIdTextBox.Text = Id;
            expenseCategoryTextBox.Text = reader.GetString(0);
            expenseDescriptionTextBox.Text = reader.GetString(1);
            expenseAmountTextBox.Text = Convert.ToString(reader.GetInt32(2));
            expenseDate.SelectedDate = reader.GetDateTime(3);
        }
        private void Window_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            LoadData();
        }
        private void editButton_Click(object sender, RoutedEventArgs e)
        {
            ExpenseService ex = new ExpenseService();
            Expense expense = new Expense();
            expense.ExpenseCategory = expenseCategoryTextBox.Text;
            expense.ExpenseDescription = expenseDescriptionTextBox.Text;
            expense.ExpenseAmount = Convert.ToInt32(expenseAmountTextBox.Text);
            expense.ExpenseDate = expenseDate.SelectedDate.Value;
            ex.Edit(expense, Id);
            this.Close();
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
