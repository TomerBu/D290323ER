using Lec5.Models;

namespace Lec5.ViewModels;

public class SongAlbumsViewModel
{
    public Song Song { get; set; } = new Song() { Title = string.Empty };
    public List<Album> Albums { get; set; } = [];
}
