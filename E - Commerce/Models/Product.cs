using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E___Commerce.Models
{
    // Product.cs
    public class Product
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public decimal ProductPrice { get; set; }


        // Foreign keys
        public int CategoryID { get; set; }
        public int SupplierID { get; set; }

        // Navigation properties
        public Category Category { get; set; }
        public Supplier Supplier { get; set; }
    }


}