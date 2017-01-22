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
using RestaurantManagementSystem.Service;
using System.Drawing.Printing;
using System.Drawing;

namespace RestaurantManagementSystem.Main
{
    /// <summary>
    /// Interaction logic for Billing.xaml
    /// </summary>
    public partial class Billing : Window, IDisposable
    {
        List<Item> BookingList = new List<Item>();
        List<Item> billingList = new List<Item>();
        Double SubTotal = 0;
        Double WithVat = 0;
        Double Total = 0;
        public Billing()
        {
            InitializeComponent();
            getCategoryId();
            billingDate.SelectedDate = DateTime.Now.Date;
            String query = "Select COUNT(BILLINGNO) from Billing";
            SqlDataReader reader = DataAccess.GetData(query);
            reader.Read();
            BillingOperation bl = new BillingOperation(reader.GetInt32(0));
            billingNo.Text = bl.BillingNo;
            if (this.IsLoaded == false)
            {
                BillingService bs = new BillingService();
                bs.TruncateOrder();
            }
            priceTextBox.IsEnabled = false;
            menuComboBox.IsEnabled = false;
            NextButton1.IsEnabled = false;
            quantityTextBox.IsEnabled = false;
            AddButton.IsEnabled = false;
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

        private void GoButton_Click(object sender, RoutedEventArgs e)
        {
            menuComboBox.Items.Clear();
            String query = "select MENUNAME from Menu, CATEGORY where CATEGORYNAME LIKE '" + categoryComboBox.Text + "' AND Menu.CATEGORYID = Category.CATEGORYID";
            SqlDataReader reader = DataAccess.GetData(query);
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    menuComboBox.Items.Add(reader.GetString(0));
                }
            }
            menuComboBox.IsEnabled = true;
            NextButton1.IsEnabled = true;
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            BillingOperation b = new BillingOperation(Convert.ToDouble(priceTextBox.Text), Convert.ToInt32(quantityTextBox.Text), menuComboBox.Text);
            BillingService bs = new BillingService();
            String query = "select ORDERID,CATEGORYNAME, QUANTITY, PRICE from Orders where CATEGORYNAME = '"+ menuComboBox.Text + "'";
            SqlDataReader reader = DataAccess.GetData(query);
            if (reader.HasRows)
            {
                reader.Read();
                if (reader.GetString(1).Equals(menuComboBox.Text))
                {
                    MessageBox.Show(reader.GetString(0));
                    b.Quantity = b.Quantity + reader.GetInt32(2);
                    b.OrderPrice = Convert.ToDouble(priceTextBox.Text) * b.Quantity;
                    bs.Edit(b, reader.GetString(0));
                }
            }
           
            else
            {
                //MessageBox.Show(reader.GetString(0));
                bs.AddOrder(b);
            }
            
            LoadData();
        }

        private void billingDataGrid_Loaded(object sender, RoutedEventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {
            String query = "select ORDERID,CATEGORYNAME, QUANTITY, PRICE from Orders";
            SqlDataReader reader = DataAccess.GetData(query);
            List<BillingOperation> BillingList = new List<BillingOperation>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    BillingOperation bl = new BillingOperation();
                    bl.OrderId = reader.GetString(0);
                    bl.CategoryName = reader.GetString(1);
                    bl.OrderPrice = reader.GetDouble(3);
                    bl.Quantity = reader.GetInt32(2);
                    BillingList.Add(bl);
                }
            }
            billingDataGrid.ItemsSource = BillingList;
            String Query = "Select SUM(PRICE) from Orders";
            SqlDataReader read = DataAccess.GetData(Query);
            read.Read();
            subTotal.Text = read.IsDBNull(0) ? null : read.GetDouble(0).ToString();
        }

        private void printButton_Click(object sender, RoutedEventArgs e)
        {
            PrintDialog printDlg = new PrintDialog();
            FlowDocument doc = CreateFlowDocument();
            doc.Name = "FlowDoc";
            IDocumentPaginatorSource idpSource = doc;
            printDlg.PrintDocument(idpSource.DocumentPaginator, "Billing");
            BillingOperation Bo = new BillingOperation(billingNo.Text, customerName.Text, Convert.ToDateTime(billingDate.Text), tableNo.Text, contact.Text, 
                                                        Convert.ToDouble(subTotal.Text),Convert.ToDouble(serviceTax.Text),Convert.ToDouble(vat.Text),Convert.ToDouble(discount.Text), Total);
            BillingService bs = new BillingService();
            bs.AddBilling(Bo);
            bs.TruncateOrder();
            this.Close();
        }
        private FlowDocument CreateFlowDocument()
        {
            FlowDocument doc = new FlowDocument();
            Section sec = new Section();
            Paragraph p1 = new Paragraph();
            SubTotal = Convert.ToDouble(subTotal.Text) + Convert.ToDouble(serviceTax.Text);
            WithVat = SubTotal + (SubTotal * Convert.ToDouble(vat.Text) * .01);
            Total = WithVat - (WithVat * Convert.ToDouble(discount.Text) * .01);
            //total.Text = Total.ToString();
            String query = "select CATEGORYNAME, PRICE from Orders";
            SqlDataReader reader = DataAccess.GetData(query);
            p1.Inlines.Add("Customer Name           :       " + customerName.Text + "\n");
            p1.Inlines.Add("Billing No                  :       " + billingNo.Text + "\n");
            p1.Inlines.Add("Table No                    :       " + tableNo.Text + "\n");
            p1.Inlines.Add("Date                        :       " + billingDate.Text + "\n");
            p1.Inlines.Add("---------------------------------------\n");
            p1.Inlines.Add("Taken Item\n");
            p1.Inlines.Add(".......................................\n");
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    p1.Inlines.Add(reader.GetString(0) + "                      :       " + reader.GetDouble(1) + "Tk\n");
                }
            }
            p1.Inlines.Add("Sub Total                    :       " + subTotal.Text + "Tk\n");
            p1.Inlines.Add("Vat(%)                        :       " + (SubTotal * Convert.ToDouble(vat.Text) * .01) + "Tk\n");
            p1.Inlines.Add("Service Tax                 :       " + serviceTax.Text + "\n");
            //bld.Inlines.Add(new Run());
            p1.Inlines.Add("Discount                     :       " + "-" + (WithVat * Convert.ToDouble(discount.Text) * .01) + "Tk\n");
            p1.Inlines.Add("--------------------------------------\n");
            Bold bl = new Bold();
            bl.Inlines.Add("Total                          :       " + Total + "Tk\n");
            
            p1.Inlines.Add(bl);
            // Add Paragraph to Section
            sec.Blocks.Add(p1);
            // Add Section to FlowDocument
            doc.Blocks.Add(sec);

            return doc;
        }

        private void orderDeleteButton_Click(object sender, RoutedEventArgs e)
        {

            BillingOperation order = (BillingOperation)billingDataGrid.SelectedItem;
            if (order != null)
            {
                BillingService billingService = new BillingService();

                if (MessageBox.Show("Are you want to Delete ?", "Confirm", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    billingService.DeleteOrder(order.OrderId);
                }

                LoadData();
            }
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            BillingService bs = new BillingService();
            bs.TruncateOrder();
            this.Close();
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            String query = "select PRICE from Menu where MENUNAME = '" + menuComboBox.Text + "'";
            SqlDataReader reader = DataAccess.GetData(query);
            if (reader.HasRows)
            {
                reader.Read();
                priceTextBox.Text = reader.GetDouble(0).ToString();
            }
            priceTextBox.IsEnabled = true;
            quantityTextBox.IsEnabled = true;
            AddButton.IsEnabled = true;
        }
    }
}
