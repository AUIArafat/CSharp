using RestaurantManagementSystem.Data;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagementSystem.Entity
{
    public class Item
    {
        private String deptId ;
        private String deptName ;
        private String categoryId ;
        private String categoryName;
        private Double categoryPrice;
        private string image ;
        private String menuId;
        private String menuName;
        private String menuList;
        private Double quantity;
        private int counter=0;

        public Item(string deptName)
        {
            String Query = "Select COUNT(DEPTID) from Department";
            SqlDataReader reader = DataAccess.GetData(Query);
            reader.Read();
            counter = reader.GetInt32(0);
            this.deptId = "Dept-"+ ++counter;
            this.deptName = deptName;
        }

        public Item() { }
        public Item(String deptId, string categoryName, double categoryPrice, String image)
        {

            this.deptId = deptId;
            this.categoryName = categoryName;
            this.categoryPrice = categoryPrice;
            this.Image = image;
        }
        public Item(String CATEGORYID, String CATEGORYNAME, String IMAGE,Double CATEGORYPRICE,String MENULIST)
        {
            this.CategoryId = CATEGORYID;
            this.CategoryName = CATEGORYNAME;
            this.CategoryPrice = CATEGORYPRICE;
            this.Image = IMAGE;
            this.MenuList = MENULIST;
        }

        public Item(string categoryName, double categoryPrice,String image)
        {
            String Query = "Select COUNT(DEPTID) from Category";
            SqlDataReader reader = DataAccess.GetData(Query);
            reader.Read();
            counter = reader.GetInt32(0);
            this.categoryId = "Cate-"+ ++ counter;
            this.categoryName = categoryName;
            this.categoryPrice = categoryPrice;
            this.Image = image;
        }

        public Item(string deptId, String deptName, String categoryName)
        {
            this.deptId = deptId;
            this.deptName = deptName;
            this.categoryName = categoryName;
        }




        public Item(string menuName,int counter)
        {
            this.MenuId = "Menu-" + ++counter;
            this.menuName = menuName;
        }

        
        public Item (String categoryName,String test)
        {
            this.CategoryName = categoryName;
        }


        public string DeptId
        {
            set
            {
                deptId = value;
            }
            get
            {
                return deptId;
            }

            
        }

        public string DeptName
        {
            get
            {
                return deptName;
            }

            set
            {
                deptName = value;
            }
        }

        public string CategoryId
        {
            set
            {
                categoryId = value;
            }
            get
            {
                return categoryId;
            }

            
        }

        public string CategoryName
        {
            get
            {
                return categoryName;
            }

            set
            {
                categoryName = value;
            }
        }

        public Double CategoryPrice
        {
            get
            {
                return categoryPrice;
            }

            set
            {
                categoryPrice = value;
            }
        }

        

        public string MenuName
        {
            get
            {
                return menuName;
            }

            set
            {
                menuName = value;
            }
        }

        public string Image
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

        public string MenuList
        {
            get
            {
                return menuList;
            }

            set
            {
                menuList = value;
            }
        }

        public string MenuId
        {
            get
            {
                return menuId;
            }

            set
            {
                menuId = value;
            }
        }

        public double Quantity
        {
            get
            {
                return quantity;
            }

            set
            {
                quantity = value;
            }
        }
    }
}
