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

public class CapitalsController(Lec5Context context) : Controller
{

    // GET: Capitals
    public async Task<IActionResult> Index()
    {
        var lec5Context = context.Capitals.Include(c => c.Country);
        return View(await lec5Context.ToListAsync());
    }

    // GET: Capitals/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var capital = await context.Capitals
            .Include(c => c.Country)
            .FirstOrDefaultAsync(m => m.Id == id);
        if (capital == null)
        {
            return NotFound();
        }

        return View(capital);
    }

    // GET: Capitals/Create
    public async Task<IActionResult> Create()
    {
        var countries = await context.Countries.Where(c => c.Capital == null).ToListAsync();
        ViewData["CountryId"] = new SelectList(countries, "Id", "Name");
        return View();
    }

    // POST: Capitals/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Name,CountryId")] Capital capital)
    {
        if (ModelState.IsValid)
        {
            context.Add(capital);
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        ViewData["CountryId"] = new SelectList(context.Countries, "Id", "Name", capital.CountryId);
        return View(capital);
    }

    // GET: Capitals/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var capital = await context.Capitals.FindAsync(id);
        if (capital == null)
        {
            return NotFound();
        }
        ViewData["CountryId"] = new SelectList(context.Countries, "Id", "Name", capital.CountryId);
        return View(capital);
    }

    // POST: Capitals/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id,Name,CountryId")] Capital capital)
    {
        if (id != capital.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                context.Update(capital);
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CapitalExists(capital.Id))
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
        ViewData["CountryId"] = new SelectList(context.Countries, "Id", "Name", capital.CountryId);
        return View(capital);
    }

    // GET: Capitals/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var capital = await context.Capitals
            .Include(c => c.Country)
            .FirstOrDefaultAsync(m => m.Id == id);
        if (capital == null)
        {
            return NotFound();
        }

        return View(capital);
    }

    // POST: Capitals/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var capital = await context.Capitals.FindAsync(id);
        if (capital != null)
        {
            context.Capitals.Remove(capital);
        }

        await context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool CapitalExists(int id)
    {
        return context.Capitals.Any(e => e.Id == id);
    }
}
