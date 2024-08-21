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


    //GET /dogs/details
    [HttpGet]
    public async Task<IActionResult> Details(int id)
    {
        var dog = await dbContext.Dogs.FindAsync(id);

        if (dog is null)
        {
            return NotFound($"Dogs with id = {id} Not Found");
        }

        return View(dog);
    }


    //GET /dogs/create
    [HttpGet]
    public IActionResult Create()
    {
        return View(); // Views/Dogs/Create.cshtml
    }
    [HttpPost]
    public async Task<IActionResult> Create(Dog d)
    {
        if (ModelState.IsValid)
        {
            //add the dog to the database
            await dbContext.Dogs.AddAsync(d);
            await dbContext.SaveChangesAsync();

            //now we got an id
            //if all is good -> goto dogs list
            return Redirect("/dogs/index");
        }

        return View(d);
    }

    //GET /dogs/Edit/id
    [HttpGet]
    public async Task<IActionResult> Edit(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var dog = await dbContext.Dogs.FindAsync(id);

        if (dog is null)
        {
            return NotFound();
        }

        return View(dog);//CREATE THE VIEW
    }


    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(Dog? dog)
    {
        if (dog is null)
        {
            return NotFound();
        }

        //if no such dog => not found
        if (!dbContext.Dogs.Any(o => o.Id == dog.Id))
        {
            return NotFound();
        }

        //id = 4, breed = "k"
        if (ModelState.IsValid)
        {
            dbContext.Update(dog);
            await dbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        else
        {
            return View(dog);
        }
    }
}



