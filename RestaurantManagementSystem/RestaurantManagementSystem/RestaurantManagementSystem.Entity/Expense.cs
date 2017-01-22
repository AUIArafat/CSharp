using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantManagementSystem.Data;

namespace RestaurantManagementSystem.Entity
{
    public class Expense
    {
        String expenseID;
        String expenseCategory;
        String expenseDescription;
        Double expenseAmount;
        //static int Count = 0;
        DateTime expenseDate;
        public Expense(String ID, String expenseCategory, String expenseDescription, Double expenseAmount, DateTime expenseDate)
        {
            this.expenseID = ID;
            this.expenseCategory = expenseCategory;
            this.expenseDescription = expenseDescription;
            this.expenseAmount = expenseAmount;
            this.expenseDate = expenseDate;

        }
        public Expense(int count)
        {
            //Count = Count + count;
            expenseID = "Ex-" + ++count;
        }
        public Expense() { }
        public String ExpenseId
        {
            get
            {
                return expenseID;
            }
        }
        public String ExpenseCategory { set { this.expenseCategory = value; } get { return this.expenseCategory; } }
        public String ExpenseDescription { set { this.expenseDescription = value; } get { return this.expenseDescription; } }
        public Double ExpenseAmount
        {
            set
            {
                this.expenseAmount = value;
            }
            get
            {
                return this.expenseAmount;
            }
        }
        public DateTime ExpenseDate { set { this.expenseDate = value; } get { return this.expenseDate; } }

    }
}
