using ECommerce.DatabaseContext;
using ECommerce.Models;
using ECommerce.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ECommerce
{
    class Program
    {
        static void Main(string[] args)
        {

            ProductRepository productRepository = new ProductRepository();
            CategoryRepository categoryRepository = new CategoryRepository();


            var order = new Order()
            {
                OrderDate = DateTime.Today,
                OrderNo = "001",
                Products = new List<ProductOrder>()
                {
                    new ProductOrder()
                    {
                        ProductId = 1
                    },
                    new ProductOrder()
                    {
                        ProductId=2
                    },
                    new ProductOrder()
                    {
                        ProductId = 3
                    }
                }
            };

            EcommerceDbContext db = new EcommerceDbContext();

            db.Orders.Add(order);

            bool isSaved = db.SaveChanges() > 0;

            if (isSaved)
            {
                Console.WriteLine("Success");
            }

            //var category = categoryRepository.GetById(2);

            //category.Name = "Electronics New";

            //var categoryProducts = productRepository.GetByCategory(category.Id);

            //category.Products = categoryProducts;

            //category.Products.Add (new Product()
            //{
            //    Name = "ABC",
            //    Price = 50000,
            //    ExpireDate = new DateTime(2020, 05, 06)
            //});

            //categoryRepository.LoadProducts(category);

            //var product = category.Products.FirstOrDefault(x=>x.Id == 8);

            //product.Name = "Air Cooler";

            //bool isUpdated = categoryRepository.Update(category);

            //if (isUpdated)
            //{
            //    Console.WriteLine("Successfull");
            //}

            //var isAdded = productRepository.Add(product);

            //if (isAdded)
            //{
            //    Console.WriteLine("Success");
            //}



            //var products = productRepository.GetAll();

            //foreach (var p in products)
            //{

            //    Console.WriteLine("Name: " + p.Name + " Price " + p.Price + " Category " + p.Category.Name);
            //}


            //Console.WriteLine("Showing All Categories.........");


            //var categories = categoryRepository.GetAll();

            //foreach (var category in categories)
            //{
            //    Console.WriteLine("Category: " + category.Name);

            //    if (category.Products != null && category.Products.Any())
            //    {
            //        foreach (var p in category.Products)
            //        {
            //            Console.WriteLine("\t\t Name: " + p.Name + " Price: " + p.Price);
            //        }
            //    }
            //    else
            //    {
            //        Console.WriteLine("\t\t No Product Found!");
            //    }
            //}


            Console.ReadKey();  
        }

        static void ShowAllProducts()
        {
            EcommerceDbContext db = new EcommerceDbContext();
            var products = db.Products.ToList();

            foreach (var product in products)
            {
                Console.WriteLine(product.Id + " " + product.Name + " " + product.Price + " " + product.ExpireDate.ToShortDateString());
            }
        }
    }
}
