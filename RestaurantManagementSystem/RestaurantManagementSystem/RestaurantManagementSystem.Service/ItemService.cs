using RestaurantManagementSystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantManagementSystem.Entity;

namespace RestaurantManagementSystem.Service
{
    public class ItemService
    {
        public int AddDept(Entity.Item item)
        {
            String Query = "INSERT into Department (DEPTID,DEPTNAME) values ('" + item.DeptId + "','" + item.DeptName+"')";
            return DataAccess.ExecuteQuery(Query);
        }

        public int AddCategory(Entity.Item item)
        {
            String Query = "INSERT into Category (CATEGORYID,CATEGORYNAME,IMAGE,CATEGORYPRICE,DEPTID) values ('" + item.CategoryId + "','" + item.CategoryName + "','" + item.Image + "','" + item.CategoryPrice + "','"+item.DeptId+ "')";
            return DataAccess.ExecuteQuery(Query);
        }

        public int AddMenuItem(Entity.Item item)
        {
            String Query = "INSERT into MENU (MENUID,MENUNAME,CATEGORYID) values ('" + item.MenuId + "','" + item.MenuName + "','" + item.CategoryId+ "')";
            return DataAccess.ExecuteQuery(Query);
        }


        public int DeleteDept(String Id)
        {
            String Query = "Delete From Department Where DEPTID = '" + Id + "'";
            return DataAccess.ExecuteQuery(Query);
        }
        public int DeleteCate(String Id)
        {
            String Query = "Delete From Category Where DEPTID = '" + Id + "'";
            return DataAccess.ExecuteQuery(Query);
        }

        public int DeleteCate1(String Id)
        {
            String Query = "Delete From Category Where CATEGORYID = '" + Id + "'";
            return DataAccess.ExecuteQuery(Query);
        }


        public int DeleteMenu(String Id)
        {
            String Query = "Delete From Menu Where MENUID = '" + Id + "'";
            return DataAccess.ExecuteQuery(Query);
        }



    }
}
