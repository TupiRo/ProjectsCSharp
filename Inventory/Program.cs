using System;
using System.IO;

namespace Inventory
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Product> productList = new List<Product>();
            productList.Add(new Product(){Name = "ProductA", Price = 100, Stock = 5});
            productList.Add(new Product(){Name = "ProductB", Price = 200, Stock = 3});
            productList.Add(new Product(){Name = "ProductC", Price = 50, Stock = 510});

            Console.WriteLine("---- Actual List ----");
            Inventory.PrintList(productList);
            
            var sortedList = Inventory.GetSortedList(productList, "Stock", false);

            Console.WriteLine("---- Result List ----");    
            Inventory.PrintList(sortedList);


        }
    }

    public class Product
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public int Stock { get; set; }
    }

    public static class Inventory
    {
        public static List<Product> GetSortedList(List<Product> productList, string sortKey, bool ascending = true)
        {
            var propertyInfo = typeof(Product).GetProperty(sortKey);
            var sortedListByKey = ascending ? productList.OrderBy(p => propertyInfo.GetValue(p, null)).ToList()
                                            : productList.OrderByDescending(p => propertyInfo.GetValue(p, null)).ToList();
            return sortedListByKey;
        }

        public static void PrintList(List<Product> productList)
        {
            foreach (var item in productList)
            {
                Console.WriteLine("Name: " + item.Name + " Price: " + item.Price + " Stock: " + item.Stock);
            }
            
        }
    } 
}