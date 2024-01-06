using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace E___Commerce.Models
{
    public class Customer
    {
        [Key]
        [ForeignKey("User")]
        public int CustomerID { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Address { get; set; }

        // Navigation property
        public User User { get; set; }
    }
}