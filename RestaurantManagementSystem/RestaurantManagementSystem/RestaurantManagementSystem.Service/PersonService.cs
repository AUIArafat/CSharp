using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantManagementSystem.Entity;
using RestaurantManagementSystem.Data;
namespace RestaurantManagementSystem.Service
{
    public class PersonService
    {

        public PersonService() { }
        public int Add(Entity.Person person)
        {
            String Query = "INSERT into Person(ID,NAME,CONTACTNO,PASSWORD,ADDRESS,JOINDATE,BLOODGROUP,IMAGE) values ('" + person.Id + "','" + person.Name + "','" + person.ContactNo + "','"+person.Password+"','" + person.Address + "','" + person.JoinDate + "','" + person.BloodGroup + "','" + person.Image+ "')";
            return DataAccess.ExecuteQuery(Query);
        }
        public int Edit(Entity.Person person, String Id)
        {
            String Query = "Update Person Set CONTACTNO = '"+person.ContactNo+"',ADDRESS='"+person.Address+"',BLOODGROUP='"+person.BloodGroup+"',PASSWORD='"+person.Password+"',IMAGE='"+person.Image+"' where ID='"+Id+"'";
            return DataAccess.ExecuteQuery(Query);
        }
    }
}
