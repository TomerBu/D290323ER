using System.ComponentModel.DataAnnotations;

namespace Lec5.Models;

public class Country
{
    [Key]
    public int Id { get; set; }

    [Required]
    public required string Name { get; set; }


    public Capital? Capital { get; set; }
}

//1) added models
//2) add dbSets to the context
//3) add migration
//4) update database
//5) review