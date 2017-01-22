using RestaurantManagementSystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagementSystem.Service
{
    public class PaymentService
    {
        public int AddPayment(Entity.Payment payment)
        {
            String query = "insert into Payment (OPERATORNAME,SALARY,PAYMENTDATE,PAYMENTSTATUS) values ('"+payment.OperatorName+"','"+payment.OperatorSalary+"','"+payment.PaymentDate+"','"+payment.PaymentStatus+"') ";
            return DataAccess.ExecuteQuery(query);
        }
    }
}
