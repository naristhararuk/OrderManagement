using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Model
{
    class DataInfo
    {
        public static string UserLoginName { get; set; }
        public class Product
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public string Abbr { get; set; }
            public decimal Price { get; set; }
            public int Unit { get; set; }

        }

        public class ProductList
        {
            public List<Product> Products { get; set; }
        }
    }
}
