using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace E___Commerce.Models
{
    public class User
    {
        
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserID { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; } // Consider using a hashed or encrypted password

        [Required]
        public string UserType { get; set; } // 'Admin' or 'Customer'

        // Navigation properties
        public Admin Admin { get; set; }
        public Customer Customer { get; set; }
        public ICollection<Order> Orders { get; set; }
    
}
}