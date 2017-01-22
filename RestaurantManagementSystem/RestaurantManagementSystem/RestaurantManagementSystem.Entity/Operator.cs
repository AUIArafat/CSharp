using RestaurantManagementSystem.Data;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagementSystem.Entity
{
    public class Operator
    {
        private String id;
        private String name;
        private string contactNo;
        private String email;
        private String address;
        private Double initialSalary;
        private DateTime joinDate;
        private String password;
        static int count = 0;

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
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

        public string Email
        {
            get
            {
                return email;
            }

            set
            {
                email = value;
            }
        }

        public string Address
        {
            get
            {
                return address;
            }

            set
            {
                address = value;
            }
        }

        public double InitialSalary
        {
            get
            {
                return initialSalary;
            }

            set
            {
                initialSalary = value;
            }
        }

        public DateTime JoinDate
        {
            get
            {
                return joinDate;
            }

            set
            {
                joinDate = value;
            }
        }

        public string Id
        {
            get
            {
                return id;
            }
            set { id = value; }
            
        }

        public string Password
        {
            get
            {
                return password;
            }

            set
            {
                password = value;
            }
        }

        

        public Operator() { }

        public Operator(string name, string contactNo, string email, string address, double initialSalary, DateTime joinDate)
        {
            String query = "Select COUNT(OPERATORID) from Operator";
            SqlDataReader reader = DataAccess.GetData(query);
            reader.Read();
            count = reader.GetInt32(0);
            String[] splitJoinDate = joinDate.ToString().Split('/');
            String[] S1 = splitJoinDate[2].Split(' ');
            this.Id = splitJoinDate[0] + "-" + S1[0] + "-" + ++count;
            Random random = new Random();
            this.password = random.Next(0, 1000000).ToString();
            this.Name = name;
            this.ContactNo = contactNo;
            this.Email = email;
            this.Address = address;
            this.InitialSalary = initialSalary;
            this.JoinDate = joinDate;
        }
    }
}
