using RestaurantManagementSystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagementSystem.Service
{
    public class OperatorService
    {
        public int AddOperator(Entity.Operator op)
        {
            String query = "insert into Operator (OPERATORID,NAME,CONTACTNO,EMAIL,ADDRESS,INITIALSALARY,JOINDATE,PASSWORD) values ('" + op.Id+"','"+op.Name+ "','" +op.ContactNo+ "','" +op.Email+ "','" + op.Address+ "','" +op.InitialSalary + "','" +op.JoinDate+"','"+op.Password+"')";
            return DataAccess.ExecuteQuery(query);
        }

        public int DeleteOperator(String id)
        {
            String query = "delete from Operator where OPERATORID='"+id+"' ";
            return DataAccess.ExecuteQuery(query);
        }

        public int EditOperatorInfo (Entity.Operator op,String id)
        {
            String query = "update Operator set NAME='"+op.Name+"',CONTACTNO='"+op.ContactNo+"',EMAIL='"+op.Email+"',ADDRESS='"+op.Address+"',INITIALSALARY='"+op.InitialSalary+"' where OPERATORID='"+id+"' ";
            
            return DataAccess.ExecuteQuery(query);
        }

    }
}
