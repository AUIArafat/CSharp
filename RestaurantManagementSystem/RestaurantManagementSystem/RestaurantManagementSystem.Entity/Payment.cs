using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagementSystem.Entity
{
    public class Payment
    {
        private String operatorName;
        private Double operatorSalary;
        private DateTime paymentDate;
        private String paymentStatus;

        public Payment() { }
        public Payment(string operatorName, double operatorSalary, DateTime paymentDate, string paymentStatus)
        {
            this.OperatorName = operatorName;
            this.OperatorSalary = operatorSalary;
            this.PaymentDate = paymentDate;
            this.PaymentStatus = paymentStatus;
        }

        public string OperatorName
        {
            get
            {
                return operatorName;
            }

            set
            {
                operatorName = value;
            }
        }

        public double OperatorSalary
        {
            get
            {
                return operatorSalary;
            }

            set
            {
                operatorSalary = value;
            }
        }

        public DateTime PaymentDate
        {
            get
            {
                return paymentDate;
            }

            set
            {
                paymentDate = value;
            }
        }

        public string PaymentStatus
        {
            get
            {
                return paymentStatus;
            }

            set
            {
                paymentStatus = value;
            }
        }
    }
}
