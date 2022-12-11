using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace workingwithDB_05_12_2022
{
    internal class Product
    {
        public int ProductID { get; }
        public string ProductName { get; }
        public SqlMoney UnitPrice { get; }
        public  int UnitsInStock { get; }

        public Product(int a_productID, string a_productName, SqlMoney a_unitPrice, int a_unitsInStock)
        {
            ProductID = a_productID;
            ProductName = a_productName;
            UnitPrice = a_unitPrice;
            UnitsInStock = a_unitsInStock;
        }
    }
}
