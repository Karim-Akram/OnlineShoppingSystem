using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using E___Commerce.Models;
using E_Commerce.Models;

namespace E___Commerce
{
    public class OnlineShopDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Product> Products { get; set; }

        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }




        public void AddCategory(string categoryName, string categoryDescription)
        {
            try
            {
                var newCategory = new Category
                {
                    CategoryName = categoryName,
                    CategoryDescription = categoryDescription
                };

                Categories.Add(newCategory);
                SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                // Handle exceptions
                var innerException = ex.InnerException;
                while (innerException != null)
                {
                    Console.WriteLine($"Inner Exception: {innerException.Message}");
                    innerException = innerException.InnerException;
                }

                throw;
            }
        }

       
        public void AddProduct(string productName, string productArabicName, string productDescription, decimal productPrice, int categoryId, string productImage)
        {
            try
            {
                var newProduct = new Product
                {
                    ProductArabicName = productArabicName,
                    ProductName = productName,
                    ProductDescription = productDescription,
                    ProductPrice = productPrice,
                    CategoryID = categoryId,
                    ProductImage = productImage 
                };

                Products.Add(newProduct);
                SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                // Handle exceptions
                var innerException = ex.InnerException;
                while (innerException != null)
                {
                    Console.WriteLine($"Inner Exception: {innerException.Message}");
                    innerException = innerException.InnerException;
                }

                throw;
            }
        }

        public void SaveOrderToDatabase(Order newOrder)
        {
            try
            {
                Orders.Add(newOrder);
                SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                // Handle exceptions
                var innerException = ex.InnerException;
                while (innerException != null)
                {
                    Console.WriteLine($"Inner Exception: {innerException.Message}");
                    innerException = innerException.InnerException;
                }

                throw;
            }
        }

    }
}
