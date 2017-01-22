using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantManagementSystem.Data;
using RestaurantManagementSystem.Entity;
using System.Data.SqlClient;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Expense ex = new Expense();
            String query = "select '" + ex.ExpenseId + "','" + ex.ExpenseCategory + "','" + ex.ExpenseDescription + "','" + ex.ExpenseAmount + "','" + ex.ExpenseDate + "'";
            SqlDataReader reader = DataAccess.GetData(query);
            List<Expense> ExpenseList = new List<Expense>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    //ExpenseList.Add(new Expense(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetInt32(3), reader.GetDateTime(4)));
                    Console.WriteLine(reader.GetString(0));
                    Console.WriteLine(reader.GetString(1));
                    Console.WriteLine(reader.GetString(2));
                    Console.WriteLine(reader.GetString(3));
                    //Console.WriteLine(reader.GetDateTime(4));
                }
            }
        }
    }
}
