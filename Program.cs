using System.Collections.Generic;
using System.Diagnostics;
using System.Net.NetworkInformation;
using task10.Data;
using static System.Runtime.InteropServices.JavaScript.JSType;
using task10.Models;

namespace task10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ApplicationDbContext dbcontext = new ApplicationDbContext();


            //1--Retrieve all categories from the production.categories table.
            var categorie = dbcontext.Categories.ToList();
            foreach (var item in categorie)
            {
                Console.WriteLine($"ID:{item.CategoryId},Name: {item.CategoryName}  ");
            }
            Console.WriteLine($"...........................");


            //2--Retrieve the first product from the production.products table.
            var product1 = dbcontext.Products.FirstOrDefault(e => e.ProductId == 1);
            Console.WriteLine($"{product1.ProductId},{product1.ModelYear},{product1.ListPrice}");

            Console.WriteLine($"...........................");

            //3--Retrieve a specific product from the production.products table by ID.
            var product2 = dbcontext.Products.Where(e => e.ProductId == 7);
            foreach (var item in product2)
            {
                Console.WriteLine($"ID:{item.ProductId},Name: {item.ProductName}  ");
                
            }

            Console.WriteLine($"...........................");

            //4--Retrieve all products from the production.products table with a certain model year.
            var product3 = dbcontext.Products.Where(e => e.ModelYear == 2016);
            int count = 0;
            foreach (var item in product3)
            {
                Console.WriteLine($"ID:{item.ProductId},Name: {item.ProductName}  ");
                count++;
            }
            Console.WriteLine(count);
            Console.WriteLine($"...........................");

            //5--Retrieve a specific customer from the sales.customers table by ID.
            var customer = dbcontext.Customers.Where(e=>e.CustomerId==5);
            foreach (var item in customer)
            {
                Console.WriteLine($"ID:{item.CustomerId},Name: {item.FirstName+ ' '+item.LastName}  ");
                
            }
            Console.WriteLine($"...........................");

            //6--Retrieve a list of product names and their corresponding brand names.
            var product4=dbcontext.Products.Select(e=> new {
                productName= e.ProductName,brandName=e.Brand.BrandName 
            }).ToList();
            foreach (var item in product4)
            {
                Console.WriteLine($"{item.productName},{item.brandName}");
            }  


            Console.WriteLine($"...........................");


            //7--Count the number of products in a specific category.
            var product6 = dbcontext.Products.Count(p => p.CategoryId == 5);
            Console.WriteLine($"{product6}");

            Console.WriteLine($"...........................");


            //8--Calculate the total list price of all products in a specific category.
            var product7 = dbcontext.Products. Where(e=>e.CategoryId==4).Sum(p => p.ListPrice);
            Console.WriteLine($"{product7}");

            Console.WriteLine($"...........................");


            //9--Calculate the average list price of products.
            var product5=dbcontext.Products. ToList().Average(e=>e.ListPrice);
            Console.WriteLine($"{product5}");

            Console.WriteLine($"...........................");


            //10--Retrieve orders that are completed.
            var order1 =dbcontext.Orders.Where(e=>e.OrderStatus == 4).ToList();
            foreach (var item in order1) 
            {  
                Console.WriteLine($"{item.OrderId},{item.CustomerId},{item.OrderDate},{item.OrderStatus}");
            }

        }
    }
}
