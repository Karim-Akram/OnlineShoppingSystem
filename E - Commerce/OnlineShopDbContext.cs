using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Data.Entity;
using E___Commerce.Models;
using System.Data.Entity.Infrastructure;

namespace E___Commerce
{
    public class OnlineShopDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Product> Products { get; set; }

        // Add this method to handle adding a category
        public void AddCategory(string categoryName, string categoryDescription)
        {
            try
            {
                // Create a new Category object
                var newCategory = new Category
                {
                    CategoryName = categoryName,
                    CategoryDescription = categoryDescription
                    // Set other properties as needed
                };

                // Add the new category to the context
                Categories.Add(newCategory);

                // Save changes to the database
                SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                // Log the inner exception for more details
                var innerException = ex.InnerException;
                while (innerException != null)
                {
                    // Log or print the details of the inner exception
                    Console.WriteLine($"Inner Exception: {innerException.Message}");
                    innerException = innerException.InnerException;
                }

                // Optionally, rethrow the exception
                throw;
            }
        }
    }



}