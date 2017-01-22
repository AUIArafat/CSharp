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
    /// Interaction logic for EditOperatorInfo.xaml
    /// </summary>
    public partial class EditOperatorInfo : Window,IDisposable
    {
        static String operatorId;
        public EditOperatorInfo(String id)
        {
            InitializeComponent();
            operatorId = id;
            String query = "select NAME,CONTACTNO,EMAIL,ADDRESS,INITIALSALARY from Operator where OPERATORID='"+id+"'";
            SqlDataReader reader = DataAccess.GetData(query);
            reader.Read();
            nameTextBox.Text = reader.GetString(0);
            contactNoTextBox.Text = reader.GetString(1);
            emailTextBox.Text = reader.GetString(2);
            addressTextBox.Text = reader.GetString(3);
            initialSalaryTextBox.Text = Convert.ToString(reader.GetDouble (4));
                  
        }

        public void Dispose() { }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {

            OperatorService operatorService = new OperatorService();
            Operator op = new Operator();
            op.Id = 
            op.Name = nameTextBox.Text;
            op.ContactNo = contactNoTextBox.Text;
            op.Email = emailTextBox.Text;
            op.Address = addressTextBox.Text;
            op.InitialSalary = Convert.ToDouble(initialSalaryTextBox.Text);
            operatorService.EditOperatorInfo(op,operatorId);
            this.Close();

        }
    }
}
