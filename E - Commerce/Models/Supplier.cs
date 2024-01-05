using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E___Commerce.Models
{
    public class Supplier
    {
        public int SupplierID { get; set; }
        public string SupplierName { get; set; }
        public string ContactInfo { get; set; }

        public string SupplierEmail { get; set; }

        public string SupplierAddress { get; set; }


        public ICollection<Product> Products { get; set; }
    }

}