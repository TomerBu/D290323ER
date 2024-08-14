using Lec2.Data;
using Lec2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lec2.Controllers;

public class PeopleController(Lec2DbContext lec2Db) : Controller
{
    public async Task<IActionResult> Index()
    {
        var people = await lec2Db.People.ToListAsync();
        return View(people);
    }

    public async Task<IActionResult> Details(int id)
    {
        Person? person =  await lec2Db.People.FirstOrDefaultAsync(p => p.Id == id);
        return View(person);
    }
}
