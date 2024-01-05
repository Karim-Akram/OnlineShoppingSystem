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