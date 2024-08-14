using System.ComponentModel.DataAnnotations;

namespace Lec2.Models;

public class Person
{
    [Key]//Primary Key
    public int Id { get; set; } 

    [Required]
    [MinLength(1)]
    [MaxLength(20)]
    public string Name { get; set; }
}
