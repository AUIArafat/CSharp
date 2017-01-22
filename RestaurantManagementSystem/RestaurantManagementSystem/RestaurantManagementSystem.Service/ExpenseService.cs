using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantManagementSystem.Entity;
using RestaurantManagementSystem.Data;
namespace RestaurantManagementSystem.Service
{
    public class ExpenseService
    {
        public int Add(Entity.Expense expense)
        {
            String Query = "INSERT into Expense  values ('" + expense.ExpenseId + "','" + expense.ExpenseCategory + "','" + expense.ExpenseDescription + "'," + expense.ExpenseAmount + ",'"+expense.ExpenseDate+"')";
            return DataAccess.ExecuteQuery(Query);
        }
        public int Delete(String Id)
        {
            String Query = "Delete From Expense Where ID = '" + Id + "'";
            return DataAccess.ExecuteQuery(Query);
        }
        public int Edit(Entity.Expense expense, String Id)
        {
            String Query = "Update Expense Set CATEGORY='" + expense.ExpenseCategory + "',DESCRIPTION='" + expense.ExpenseDescription + "',AMOUNT=" + expense.ExpenseAmount + ",DATE='" + expense.ExpenseDate + "' Where ID='"+Id+"'";
            return DataAccess.ExecuteQuery(Query);
        }
    }
}
