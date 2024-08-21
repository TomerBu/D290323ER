using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Lec2.Models;

public class Dog
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage ="Required!"), MinLength(2), MaxLength(20)]

    [DisplayName("Dog Breed")]
    public required string Breed { get; set; }

    public override string? ToString()
    {
        return $"Id: {Id}, Breed: {Breed}";
    }
}
