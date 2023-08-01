using Microsoft.Build.Framework;
using ProniaMvc.Models;

namespace MVCPronia.Models;

public class ProductCategory:BaseEntity
{
    [Required]
    public int ProductId { get; set; }
    public Product? Product { get; set; }
    [Required]
    public int CategoryId { get; set; }
    public Category? Category { get; set; }


}
