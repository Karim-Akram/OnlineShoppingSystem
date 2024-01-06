using E___Commerce.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

public class Product
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ProductID { get; set; }

    [Required]
    public string ProductName { get; set; }
    [Required]
    public string ProductArabicName { get; set; }

    public string ProductDescription { get; set; }

    [Required]
    public decimal ProductPrice { get; set; }

    public string ProductImage { get; set; }

    // Foreign keys
    public int? CategoryID { get; set; }

    // Allow NULL for SupplierID
    public int? SupplierID { get; set; }

    public Category Category { get; set; }
    public Supplier Supplier { get; set; }
}
