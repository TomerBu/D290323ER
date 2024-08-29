using Lec5.Models;

namespace Lec5.ViewModels
{
    public class MovieWithGenresViewModel
    {
        public Movie Movie { get; set; } = new Movie() { Title = string.Empty };

        public List<SelectGenre> Genres { get; set; } = [];
    }

    public class SelectGenre
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public bool IsSelected { get; set; } = false;
    }
}
