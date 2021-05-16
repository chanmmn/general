using System;
using System.Linq;
using System.Collections.Generic;

namespace ConAppListEdit
{

    public class Products
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
    }
    
    class Program
    {
        public static List<Products> list = new List<Products>() {
                new Products{ProductID=1, ProductName="Chai"},
                new Products{ProductID=3, ProductName="Aniseed Syrup"},
                new Products{ProductID=2, ProductName="Chang"}
         };

        static void Main(string[] args)
        {
            foreach (Products prod in list)
            {
                Console.WriteLine("Product ID {0} Product Name: {1}", prod.ProductID, prod.ProductName);
            }
            Console.WriteLine("Before UpdateList----------------------------");
            UpdateList();
            foreach (Products prod in list)
            {
                Console.WriteLine("Product ID {0} Product Name: {1}", prod.ProductID, prod.ProductName);
            }
            Console.WriteLine("Before DeleteListItem----------------------------");
            DeleteListItem();
            foreach (Products prod in list)
            {
                Console.WriteLine("Product ID {0} Product Name: {1}", prod.ProductID, prod.ProductName);
            }
        }

        public static void UpdateList()
        {
            var result = from r in list where r.ProductID == 2 select r;
            result.First().ProductName = "Chan";
        }

        public static void DeleteListItem()
        {
            var result = from r in list where r.ProductID == 2 select r;
            list.Remove(result.First());
        }
    }
}
