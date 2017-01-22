using System;
using RestaurantManagementSystem.Data;
using System.Data.SqlClient;

namespace RestaurantManagementSystem.Entity
{
    public class Person
    {
        private String id;
        private String name;
        private String contactNo;
        private String address;
        private DateTime joinDate;
        private String bloodGroup;
        private byte[] image;
        private String password;
        static int count = 0;
        public string Id
        {
            get
            {
                return id;
            }
        }
        public string Password
        {
            set
            {
                password = value;
            }
            get
            {
                return password;
            }
        }
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

        public string BloodGroup
        {
            get
            {
                return bloodGroup;
            }

            set
            {
                bloodGroup = value;
            }
        }

        public byte[] Image
        {
            get
            {
                return image;
            }

            set
            {
                image = value;
            }
        }
        static String query = "Select COUNT(ID) from Person";
        SqlDataReader reader = DataAccess.GetData(query);
        
        public Person() { }
        public Person(string name, string contactNo, string address, DateTime joinDate, string bloodGroup, byte[] image)
        {
            reader.Read();
            count = reader.GetInt32(0);
            String[] splitJoinDate = joinDate.ToString().Split('/');
            String[] S1 = splitJoinDate[2].Split(' ');
            this.id = splitJoinDate[0]+"-"+ S1[0] + "-" + ++count;
            Random random = new Random();
            this.password = random.Next(0,1000000).ToString();
            this.name = name;
            this.contactNo = contactNo;
            this.address = address;
            this.joinDate = joinDate;
            this.bloodGroup = bloodGroup;
            this.image = image;
        }
    }
}
