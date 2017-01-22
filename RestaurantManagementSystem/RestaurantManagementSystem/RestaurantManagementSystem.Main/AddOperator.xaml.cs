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
using RestaurantManagementSystem.Data;

namespace RestaurantManagementSystem.Main
{
    /// <summary>
    /// Interaction logic for AddOperator.xaml
    /// </summary>
    /// 
   

    public partial class AddOperator : Window,IDisposable
    {
        public AddOperator()
        {
            InitializeComponent();
            joinDatePicker.Text = DateTime.Now.ToString() ;
        }

        public void Dispose() { }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            List<Operator> OperatorList = new List<Operator>();
            String query = "Select OPERATORID,NAME,CONTACTNO,EMAIL,ADDRESS,INITIALSALARY,JOINDATE,PASSWORD from Operator";
            SqlDataReader reader = DataAccess.GetData (query) ;
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Operator op = new Operator();
                    op.Id = reader.GetString(0);
                    op.Name = reader.GetString(1);
                    op.ContactNo = reader.GetString(2);
                    op.Email = reader.GetString(3);
                    op.Address = reader.GetString(4);
                    op.InitialSalary = reader.GetDouble (5);
                    op.JoinDate = reader.GetDateTime(6);
                    op.Password = reader.GetString(7);
                    //OperatorList.Add(new Operator(reader.GetString (1),reader.GetString (2), reader.GetString(3), reader.GetString(4), reader.GetDouble(5),Convert.ToDateTime(reader.GetString (6)) ));
                    OperatorList.Add(op);
                }
            }
            addOperatorDataGrid.ItemsSource = OperatorList;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            Operator op = new Operator(nameTextBox.Text,contactNoTextBox.Text,emailTextBox.Text,addressTextBox.Text,Convert.ToDouble(initialSalaryTextBox.Text),Convert.ToDateTime(joinDatePicker.Text));
            
            OperatorService operatorService = new OperatorService();
            operatorService.AddOperator(op);
            MessageBox.Show("Operator Added Successfully \nID : " + op.Id + " \nPassword : " + op.Password + " \n *Please Keep Id and Password in mind", "Successful", MessageBoxButton.OK, MessageBoxImage.Information);
            LoadData();

        }

        private void DeleteButton_Click(Object sender, RoutedEventArgs e)
        {
            Operator op = (Operator)addOperatorDataGrid.SelectedItem;
            if (op != null)
            {
                OperatorService operatorService = new OperatorService();
                
                if (MessageBox.Show("Do you want to DELETE?", "Confirm", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes){
                    operatorService.DeleteOperator(op.Id);
                    LoadData();
                }

            }
        }

        private void EditButton_Click(Object sender, RoutedEventArgs e)
        {
            Operator op = (Operator)addOperatorDataGrid.SelectedItem;
            using (EditOperatorInfo operatorInfo = new EditOperatorInfo (op.Id))
            {
                operatorInfo.ShowDialog();
                LoadData();
            }
        }

    }
}
