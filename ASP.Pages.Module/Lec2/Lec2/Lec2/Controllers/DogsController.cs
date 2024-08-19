using Lec2.Data;
using Lec2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Lec2.Controllers;

public class DogsController(Lec2DbContext dbContext) : Controller
{
    //GET /dogs/index
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var dogs = await dbContext.Dogs.ToListAsync();
        return View(dogs); //Views/Dogs/Index.cshtml
    }

    //GET /dogs/create
    [HttpGet]
    public IActionResult Create()
    {
        return View(); // Views/Dogs/Create.cshtml
    }

    //POST /dogs/create
    [HttpPost]
    public async Task<IActionResult> Create(Dog d)
    {
        if (ModelState.IsValid)
        {
            //add the dog to the database
            var result = await dbContext.Dogs.AddAsync(d);
            await dbContext.SaveChangesAsync();

            //now we got an id
            //if all is good -> goto dogs list
            return Redirect("/dogs/index");
        }

        return View(d);
    }
}
//hyper text transfer protocol <html><body>