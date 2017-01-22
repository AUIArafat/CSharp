using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantManagementSystem.Entity;
using RestaurantManagementSystem.Data;

namespace RestaurantManagementSystem.Service
{
    public class BookingService
    {
        public BookingService() { }
        public int AddBooking(Entity.Booking booking)
        {
            String query = "Insert into Booking (BOOKINGID,BOOKINGDATE,STARTTIME,ENDINGTIME,TABLENO,TOTALTABLE,CUSTOMERNAME,PHONE,ADDRESS,ADVANCE) values('"+booking.BookingNo+"','"+booking.BookingDate+"','"+booking.StartTime+"','"+booking.EndingTime+"','"+booking.TableNo+"','"+booking.TotalTable+"','"+booking.CustomerName+"','"+booking.Phone+"','"+booking.Address+"','"+booking.Advance+"') ";
            return DataAccess.ExecuteQuery(query);
        }


        public int DeleteBooking(String id)
        {
            String query = "Delete from BOOKING where BOOKINGID ='"+id+"'";
            return DataAccess.ExecuteQuery(query);
        }


    }

}