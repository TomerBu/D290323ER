using System.ComponentModel.DataAnnotations;

namespace Lec2.Models;

public class Dog
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage ="Foo!"), MinLength(2), MaxLength(20)]
    public required string Breed { get; set; }
}
