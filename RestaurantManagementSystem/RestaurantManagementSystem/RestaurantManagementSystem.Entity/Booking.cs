using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantManagementSystem.Data;
using System.Data.SqlClient;

namespace RestaurantManagementSystem.Entity
{
    public class Booking
    {
        private String bookingNo;
        private DateTime bookingDate;
        private String startTime;
        private String endingTime;
        private String tableNo;
        private int totalTable;
        private String customerName;
        private String phone;
        private String address;
        private Double advance;
        private int counter = 0;


        public String BookingNo
        {
            get
            {
                return bookingNo;
            }
            set
            {
                bookingNo = value;
            }
        }

        public DateTime BookingDate
        {
            get{return bookingDate;}

            set
            {
                bookingDate = value;
            }
        }

        public string StartTime
        {
            get
            {
                return startTime;
            }

            set
            {
                startTime = value;
            }
        }

        public string EndingTime
        {
            get
            {
                return endingTime;
            }

            set
            {
                endingTime = value;
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

        public int TotalTable
        {
            get
            {
                return totalTable;
            }

            set
            {
                totalTable = value;
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

        public string Phone
        {
            get
            {
                return phone;
            }

            set
            {
                phone = value;
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

        public Double Advance
        {
            get
            {
                return advance;
            }

            set
            {
                advance = value;
            }
        }

        public Booking() { }

        public Booking(DateTime bookingDate, string startTime, string endingTime, string tableNo, int totalTable, string customerName, string phone, string address,Double advance)
        {
            String query = "select COUNT(BOOKINGID) from BOOKING";
            SqlDataReader reader = DataAccess.GetData(query);
            reader.Read();
            counter = reader.GetInt32(0);
            this.bookingNo = "Booking-" + ++counter;
            this.bookingDate = bookingDate;
            this.startTime = startTime;
            this.endingTime = endingTime;
            this.tableNo = tableNo;
            this.totalTable = totalTable;
            this.customerName = customerName;
            this.phone = phone;
            this.address = address;
            this.advance = advance;
        }

        public Booking(string bookingNo, DateTime bookingDate, string startTime, string endingTime, string tableNo, int totalTable, string customerName, string phone, string address, double advance)
        {
            this.bookingNo = bookingNo;
            this.bookingDate = bookingDate;
            this.startTime = startTime;
            this.endingTime = endingTime;
            this.tableNo = tableNo;
            this.totalTable = totalTable;
            this.customerName = customerName;
            this.phone = phone;
            this.address = address;
            this.advance = advance;
        }
    }
}
