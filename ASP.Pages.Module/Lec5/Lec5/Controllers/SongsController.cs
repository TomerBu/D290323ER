using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Lec5.Data;
using Lec5.Models;

namespace Lec5.Controllers;

public class SongsController(Lec5Context context) : Controller
{

    // GET: Songs
    public async Task<IActionResult> Index()
    {

        var songs = await context.Songs.Include(s => s.Album).ToListAsync();
       
        return View(songs);
    }

    // GET: Songs/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var song = await context.Songs
            .FirstOrDefaultAsync(m => m.Id == id);
        if (song == null)
        {
            return NotFound();
        }

        return View(song);
    }

    // GET: Songs/Create
    public async Task<IActionResult> Create()
    {
        var albums = await context.Albums.ToListAsync();

        //pass the albums to the view
        ViewBag.Albums = albums;
        

        return View();
    }

    // POST: Songs/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Title")] Song song)
    {
        if (ModelState.IsValid)
        {
            context.Add(song);
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(song);
    }

    // GET: Songs/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var song = await context.Songs.FindAsync(id);
        if (song == null)
        {
            return NotFound();
        }
        return View(song);
    }

    // POST: Songs/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id,Title")] Song song)
    {
        if (id != song.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                context.Update(song);
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SongExists(song.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }
        return View(song);
    }

    // GET: Songs/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var song = await context.Songs
            .FirstOrDefaultAsync(m => m.Id == id);
        if (song == null)
        {
            return NotFound();
        }

        return View(song);
    }

    // POST: Songs/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var song = await context.Songs.FindAsync(id);
        if (song != null)
        {
            context.Songs.Remove(song);
        }

        await context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool SongExists(int id)
    {
        return context.Songs.Any(e => e.Id == id);
    }
}
