using Lec2.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Lec2.Controllers;

public class MoviesController : Controller
{
    static List<MovieViewModel> Movies = [
        new MovieViewModel(){
            Id = 1,
            Title = "Shrek",
            Overview = "Green Movie",
            ImageUrl =  "https://m.media-amazon.com/images/M/MV5BMjE0NGIwM2EtZjQxZi00ZTE5LWExN2MtNDBlMjY1ZmZkYjU3XkEyXkFqcGdeQXVyNjMwNzk3Mjk@._V1_QL75_UX240_CR0,1,240,350_.jpg"
        },
        new MovieViewModel(){
            Id = 2,
            Title = "Shrek 2",
            Overview = "Green Movie",
            ImageUrl =  "https://m.media-amazon.com/images/M/MV5BMjE0NGIwM2EtZjQxZi00ZTE5LWExN2MtNDBlMjY1ZmZkYjU3XkEyXkFqcGdeQXVyNjMwNzk3Mjk@._V1_QL75_UX240_CR0,1,240,350_.jpg"
        },
        new MovieViewModel(){
            Id = 3,
            Title = "Shrek 3",
            Overview = "Green Movie",
            ImageUrl =  "https://m.media-amazon.com/images/M/MV5BMjE0NGIwM2EtZjQxZi00ZTE5LWExN2MtNDBlMjY1ZmZkYjU3XkEyXkFqcGdeQXVyNjMwNzk3Mjk@._V1_QL75_UX240_CR0,1,240,350_.jpg"
        }
    ];
    public IActionResult Index()
    {
        return View(Movies);
    }

    //Movies/Details/1
    public IActionResult Details(int id)
    {

        var movie = Movies.FirstOrDefault(m => m.Id == id);

        return View(movie);
    }

}
