using Lec1.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lec1.Controllers;

public class BooksController : Controller
{
    private static List<BookViewModel> books = [
        new BookViewModel() {
                Id = 1,
                Title = "Harry potter 1",
                Description = "The only book :-)"
            },
            new BookViewModel() {
                Id = 2,
                Title = "The Godfather",
                Description = "The only other book :-)"
            }
    ];
    public IActionResult Index()
    {
        return View(books);
    }


    public IActionResult Details(int id)
    {
        var book = books.FirstOrDefault(b => b.Id == id);
        return View(book);
    }
}


