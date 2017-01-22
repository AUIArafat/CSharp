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

namespace RestaurantManagementSystem.Main
{
    /// <summary>
    /// Interaction logic for ProfitStatus.xaml
    /// </summary>
    public partial class ProfitStatus : Window, IDisposable
    {
        //
        //
        //
        //
        public ProfitStatus()
        {
            InitializeComponent();
            //fromDate.SelectedDate = DateTime.Now.Date;
            //toDate.SelectedDate = DateTime.Now.Date;
            //LoadExpense();
        }
        public void Dispose() { }
        public void LoadExpense()
        {
            if (fromDate.SelectedDate != null && toDate.SelectedDate != null)
            {
                Double Profit = 0;
                Double Loss = 0;
                Double TotalEarn = 0;
                Double TotalExpense = 0;
                List<Expense> expenseList = new List<Expense>();
                List<BillingOperation> earningList = new List<BillingOperation>();
                List<Entity.Payment> paymentList = new List<Entity.Payment>();
                String Query = "Select CATEGORY,DESCRIPTION,AMOUNT,DATE from Expense where DATE between '" + fromDate.SelectedDate.Value + "'AND '" + toDate.SelectedDate.Value + "'";
                SqlDataReader reader = DataAccess.GetData(Query);
                if (reader.HasRows)
                {
                   
                    while (reader.Read())
                    {
                        Expense ex = new Expense();
                        ex.ExpenseCategory = reader.GetString(0);
                        ex.ExpenseDescription = reader.GetString(1);
                        ex.ExpenseAmount = reader.GetDouble(2);
                        ex.ExpenseDate = reader.GetDateTime(3);
                        expenseList.Add(ex);
                        
                        TotalExpense = TotalExpense + reader.GetDouble(2);
                        //MessageBox.Show(TotalExpense.ToString());
                    }
                }
                expenseDataGrid.ItemsSource = expenseList;

                String Query1 = "Select BILLINGNO, BILLINGDATE, TOTAL from Billing where BILLINGDATE between '" + fromDate.SelectedDate.Value + "'AND '" + toDate.SelectedDate.Value + "'";
                SqlDataReader reader1 = DataAccess.GetData(Query1);
                if (reader1.HasRows)
                {
                    while (reader1.Read())
                    {
                        BillingOperation bl = new BillingOperation();
                        bl.BillingNo = reader1.GetString(0);
                        bl.BillingDate = reader1.GetDateTime(1);
                        bl.Total = reader1.GetDouble(2);
                        earningList.Add(bl);
                        
                        TotalEarn = TotalEarn + reader1.GetDouble(2);
                        //MessageBox.Show(TotalExpense.ToString());
                    }
                }
                earningDataGrid.ItemsSource = earningList;
                String Query2 = "Select OPERATORNAME, PAYMENTDATE, PAYMENTSTATUS, SALARY from Payment where PAYMENTDATE between '" + fromDate.SelectedDate.Value + "'AND '" + toDate.SelectedDate.Value + "'";
                SqlDataReader reader2 = DataAccess.GetData(Query2);
                if (reader2.HasRows)
                {

                    while (reader2.Read())
                    {
                        Entity.Payment payment = new Entity.Payment();
                        payment.OperatorName = reader2.GetString(0);
                        payment.PaymentDate = reader2.GetDateTime(1);
                        payment.PaymentStatus = reader2.GetString(2);
                        payment.OperatorSalary = reader2.GetDouble(3);
                        paymentList.Add(payment);
                        TotalExpense = TotalExpense + reader2.GetDouble(3);
                        //MessageBox.Show(TotalExpense.ToString());
                    }
                }
                paymentDataGrid.ItemsSource = paymentList;
                totalEarnTextBlock.Text = TotalEarn.ToString();
                totalExTexBlock.Text = TotalExpense.ToString();
                Profit = TotalEarn - TotalExpense;
                MessageBox.Show(Profit.ToString());
                if (Profit > 0)
                {
                    profitTextBlock.Text = Profit.ToString();
                }
                else if (Profit == 0)
                {
                    lossTextBlock.Text = "No Loss";
                    profitTextBlock.Text = "No Profit";
                }
                else
                {
                    Loss = TotalExpense - TotalEarn;
                    lossTextBlock.Text = Loss.ToString();
                }
            }


        }
        private void expenseDataGrid_Loaded(object sender, RoutedEventArgs e)
        {
            LoadExpense();
        }

        private void fromDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            LoadExpense();
        }

        private void toDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            LoadExpense();
        }

        private void printButton_Click(object sender, RoutedEventArgs e)
        {
            PrintDialog printDlg = new PrintDialog();
            FlowDocument doc = CreateFlowDocument();
            doc.Name = "FlowDoc";
            IDocumentPaginatorSource idpSource = doc;
            printDlg.PrintDocument(idpSource.DocumentPaginator, "Profit-Loss");
        }
        private FlowDocument CreateFlowDocument()
        {
            FlowDocument doc = new FlowDocument();
            Section sec = new Section();
            
            Paragraph p1 = new Paragraph();
            Bold bl = new Bold();

            bl.Inlines.Add("From " + fromDate.Text + "  To  " + toDate.Text + "\n\n");
            p1.Inlines.Add(bl);
            p1.Inlines.Add("Total Investment          :       " + totalExTexBlock.Text + "\n");
            p1.Inlines.Add("Total Earning             :       " + totalEarnTextBlock.Text + "\n");
            p1.Inlines.Add("Profit                    :       " + profitTextBlock.Text + "\n");
            p1.Inlines.Add("Loss                      :       " + lossTextBlock.Text + "\n");
            // Add Paragraph to Section
            sec.Blocks.Add(p1);
            // Add Section to FlowDocument
            doc.Blocks.Add(sec);

            return doc;
        }
    }
}
