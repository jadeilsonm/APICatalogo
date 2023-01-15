using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APICatalogo.Models;
[Table("Categories")]
public class Category
{
    public int CategoryId { get; set; }
    [Required]
    [StringLength(70)]
    public string? Name { get; set; }
    [Required]
    [StringLength(300)]
    public string? ImageUrl { get; set; }
    private ICollection<Product>? Products { get; set; } 
} 