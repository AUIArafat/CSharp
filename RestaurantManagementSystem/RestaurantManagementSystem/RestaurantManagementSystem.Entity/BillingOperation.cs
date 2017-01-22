using RestaurantManagementSystem.Data;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagementSystem.Entity
{
    public class BillingOperation
    {
        private String orderId;
        private Double orderPrice = 0;
        private int quantity = 0;
        private String categoryName;
        private String billingNo;
        private String customerName;
        private DateTime billingDate;
        private String tableNo;
        private String contactNo;
        private Double subTotal;
        private Double serviceTax;
        private Double vat;
        private Double discount;
        private Double total;

        public BillingOperation() {
            this.orderPrice = 0;
            this.quantity = 0;
            this.categoryName = null;
        }
        public BillingOperation(double orderPrice, int quantity, String categoryName)
        {
            String query = "Select COUNT(ORDERID) from Orders";
            SqlDataReader reader = DataAccess.GetData(query);
            reader.Read();
            int Count = reader.GetInt32(0);
            this.orderId = "Order-" + ++Count;
            this.quantity = quantity;
            this.orderPrice = orderPrice * Quantity;
            this.categoryName = categoryName;
        }

        public BillingOperation(string billingNo, string customerName, DateTime billingDate, string tableNo, string contactNo, double subTotal, double serviceTax, double vat, double discount, double total)
        {
            this.BillingNo = billingNo;
            this.CustomerName = customerName;
            this.BillingDate = billingDate;
            this.TableNo = tableNo;
            this.ContactNo = contactNo;
            this.SubTotal = subTotal;
            this.ServiceTax = serviceTax;
            this.Vat = vat;
            this.Discount = discount;
            this.Total = total;
        }
        public BillingOperation(int Counter)
        {
            this.billingNo = "BillingNo-" + ++Counter;
        }

        public string OrderId
        {
            get
            {
                return orderId;
            }

            set
            {
                orderId = value;
            }
        }

        public double OrderPrice
        {
            get
            {
                return orderPrice;
            }

            set
            {
                orderPrice = value;
            }
        }

        public int Quantity
        {
            get
            {
                return quantity;
            }

            set
            {
                quantity = value;
            }
        }

        public string CategoryName
        {
            get
            {
                return categoryName;
            }

            set
            {
                categoryName = value;
            }
        }

        public string BillingNo
        {
            get
            {
                return billingNo;
            }

            set
            {
                billingNo = value;
            }
        }

        public string CustomerName
        {
            get
            {
                return customerName;
            }

            set
            {
                customerName = value;
            }
        }

        public DateTime BillingDate
        {
            get
            {
                return billingDate;
            }

            set
            {
                billingDate = value;
            }
        }

        public string TableNo
        {
            get
            {
                return tableNo;
            }

            set
            {
                tableNo = value;
            }
        }

        public string ContactNo
        {
            get
            {
                return contactNo;
            }

            set
            {
                contactNo = value;
            }
        }

        public double SubTotal
        {
            get
            {
                return subTotal;
            }

            set
            {
                subTotal = value;
            }
        }

        public double ServiceTax
        {
            get
            {
                return serviceTax;
            }

            set
            {
                serviceTax = value;
            }
        }

        public double Vat
        {
            get
            {
                return vat;
            }

            set
            {
                vat = value;
            }
        }

        public double Discount
        {
            get
            {
                return discount;
            }

            set
            {
                discount = value;
            }
        }

        public double Total
        {
            get
            {
                return total;
            }

            set
            {
                total = value;
            }
        }
    }
}
