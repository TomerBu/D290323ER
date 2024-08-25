using System.ComponentModel.DataAnnotations;

namespace Lec5.Models;

public class Song
{
    [Key]
    public int Id { get; set; }

    [Required]
    public required string Title { get; set; }
    public int? AlbumId { get; set; }

    //Navigation props:
    public Album? Album { get; set; }

    
}
