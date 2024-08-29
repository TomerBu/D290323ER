using System.ComponentModel.DataAnnotations;

namespace Lec5.Models;

public class Capital
{
    [Key]
    public int Id { get; set; }

    [Required, MinLength(1), MaxLength(30)]
    public required string Name { get; set; }

    public int CountryId { get; set; }

    //Navigation Properties:
    public  Country? Country { get; set; }
}
