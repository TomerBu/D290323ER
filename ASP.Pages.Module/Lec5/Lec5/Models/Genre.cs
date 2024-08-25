namespace Lec5.Models
{
    public class Genre 
    {
        public int Id { get; set; }
        public required string Name { get; set; }

        //Navigation Properties
        public ICollection<Movie> Movies { get; set; } = [];
    }
}
