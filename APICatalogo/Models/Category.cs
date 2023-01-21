using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace APICatalogo.Models;
[Table("Categories")]
public class Category
{
    public Category()
    {
        Products = new Collection<Product>();
    }
    
    public int CategoryId { get; set; }
    [Required]
    [StringLength(70)]
    public string? Name { get; set; }
    [Required]
    [StringLength(300)]
    public string? ImageUrl { get; set; }
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public ICollection<Product>? Products { get; set; }
} 