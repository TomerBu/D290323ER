using System.ComponentModel.DataAnnotations;

namespace Lec5.Models;

public class Album
{
    [Key]
    public int Id { get; set; }

    [Required]
    public required string Name { get; set; }

    //Navigation Property:
    public ICollection<Song> Songs { get; set; } = [];
}
//models
//dbcontext
//migration
//update database 
//review