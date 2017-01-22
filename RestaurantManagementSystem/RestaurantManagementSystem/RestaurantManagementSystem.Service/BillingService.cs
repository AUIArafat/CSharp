using RestaurantManagementSystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantManagementSystem.Entity;

namespace RestaurantManagementSystem.Service
{
    public class BillingService
    {
        public int AddOrder(Entity.BillingOperation billings)
        {
            String Query = "INSERT into Orders (ORDERID, CATEGORYNAME, QUANTITY, PRICE) values ('"+billings.OrderId+"','"+billings.CategoryName+"','"+billings.Quantity+"','"+billings.OrderPrice+"')";
            return DataAccess.ExecuteQuery(Query);
        }
        public int Edit(Entity.BillingOperation order, String Id)
        {
            String Query = "Update Orders Set Quantity='" + order.Quantity + "',Price='" + order.OrderPrice + "' Where ORDERID='" + Id + "'";
            return DataAccess.ExecuteQuery(Query);
        }
        public int AddBilling(Entity.BillingOperation billings)
        {
            String Query = "INSERT into Billing (BILLINGNO,TABLENO,CUSTOMERNAME,CONTACTNO,SUBTOTAL,SERVICETAX,VAT,DISCOUNT,TOTAL,BILLINGDATE)"; 
             Query +=   "values ('" + billings.BillingNo + "','" + billings.TableNo + "','" + billings.CustomerName + "','" + billings.ContactNo + "','" + billings.SubTotal + "','"+billings.ServiceTax+"','"+billings.Vat+"','"+billings.Discount+"','"+billings.Total+"','"+billings.BillingDate+"')";
            return DataAccess.ExecuteQuery(Query);
        }

        public int AddMenuItem(Entity.Item item)
        {
            String Query = "INSERT into MENU (MENUID,MENUNAME,CATEGORYID) values ('" + item.MenuId + "','" + item.MenuName + "','" + item.CategoryId + "')";
            return DataAccess.ExecuteQuery(Query);
        }


        public int DeleteDept(String Id)
        {
            String Query = "Delete From Department Where DEPTID = '" + Id + "'";
            return DataAccess.ExecuteQuery(Query);
        }
        public int DeleteOrder(String Id)
        {
            String Query = "Delete From Orders Where ORDERID = '" + Id + "'";
            return DataAccess.ExecuteQuery(Query);
        }
        public int DeleteCate(String Id)
        {
            String Query = "Delete From Category Where DEPTID = '" + Id + "'";
            return DataAccess.ExecuteQuery(Query);
        }
        public int TruncateOrder()
        {
            String Query = "Truncate Table Orders";
            return DataAccess.ExecuteQuery(Query);
        }
    }
}
