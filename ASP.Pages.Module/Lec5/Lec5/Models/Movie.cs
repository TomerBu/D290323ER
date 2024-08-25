namespace Lec5.Models;

public class Movie
{
    public int Id { get; set; }
    public required string Title { get; set; }

    //Navigation Properties
    public ICollection<Genre> Genres { get; set; } = [];
}
