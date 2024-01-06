using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace E___Commerce.Models
{
    public class Admin
    {
        [Key]
        [ForeignKey("User")]
        public int AdminID { get; set; }

        [Required]
        public string AdminRole { get; set; } // 'SuperAdmin', 'Moderator', etc.

        // Navigation property
        public User User { get; set; }
    }
}