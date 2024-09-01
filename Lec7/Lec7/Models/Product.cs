using System.ComponentModel.DataAnnotations;

namespace Lec7.Models;

public class Product
{
    [Key]
    public int Id { get; set; }

    [Required, MinLength(2), Display(Name="Product Name")]
    public string Name { get; set; } = string.Empty;
}
//db + context + controller?