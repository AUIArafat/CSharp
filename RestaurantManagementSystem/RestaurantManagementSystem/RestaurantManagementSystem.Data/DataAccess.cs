using System.Data.SqlClient;
using System.Data.OleDb;
namespace RestaurantManagementSystem.Data
{
    public static class DataAccess
    {

        static SqlConnection Conn;
        public static SqlConnection Connection
        {

            get
            {
                Conn = new SqlConnection("Server=ARAFAT\\SQLEXPRESS; Database=RMS; User Id=sa; Password=P@$$w0rd");
                Conn.Open();
                return Conn;
            }
        }
        public static int ExecuteQuery(string Query)
        {
            SqlCommand cmd = new SqlCommand(Query, Connection);
            return cmd.ExecuteNonQuery();
        }
        public static SqlDataReader GetData(string Query)
        {
            SqlCommand cmd = new SqlCommand(Query, Connection);
            return cmd.ExecuteReader();
        }

    }
}
