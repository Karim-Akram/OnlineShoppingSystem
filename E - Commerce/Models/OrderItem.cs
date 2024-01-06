using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using E___Commerce.Models;

namespace E_Commerce.Models
{
    public class OrderItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderItemID { get; set; }

        [ForeignKey("Order")]
        public int OrderID { get; set; }

        [ForeignKey("Product")]
        public int ProductID { get; set; }

        [Required]
        public int Quantity { get; set; }


        
        public Order Order { get; set; }
        public Product Product { get; set; }

       
        [NotMapped] 
        public decimal TotalPrice
        {
            get
            {
                return Quantity * Product.ProductPrice;
            }
        }
    }
}
