using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using E_Commerce.Models;

namespace E___Commerce.Models
{
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderID { get; set; }

        [ForeignKey("User")]
        public int UserID { get; set; }

        [Required]
        public DateTime OrderDate { get; set; }

        public string OrderNumber { get; set; }

        public string DeliveryAddress { get; set; }
        public decimal TotalPrice { get; set; }
        


       
        public User User { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }
    }

}