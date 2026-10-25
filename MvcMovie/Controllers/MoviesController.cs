using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MvcMovie.Data;
using MvcMovie.Models;

namespace MvcMovie.Controllers;
public class MoviesController(MvcMovieContext context) : Controller
{
    // All movie operations use the injected EF Core context.
    public async Task<IActionResult> Index() =>
        View(await context.Movie.AsNoTracking().OrderBy(m => m.Title).ToListAsync());

    public async Task<IActionResult> Details(int? id)
    {
        if (id is null) return NotFound();
        var movie = await context.Movie.AsNoTracking().FirstOrDefaultAsync(m => m.Id == id);
        return movie is null ? NotFound() : View(movie);
    }

    public IActionResult Create() => View();

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Title,ReleaseDate,Genre,Price")] Movie movie)
    {
        if (!ModelState.IsValid) return View(movie);
        context.Add(movie);
        await context.SaveChangesAsync();
        TempData["Success"] = "Movie created successfully.";
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Edit(int? id)
    {
        if (id is null) return NotFound();
        var movie = await context.Movie.FindAsync(id);
        return movie is null ? NotFound() : View(movie);
    }

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id,Title,ReleaseDate,Genre,Price")] Movie movie)
    {
        if (id != movie.Id) return NotFound();
        if (!ModelState.IsValid) return View(movie);
        try
        {
            context.Update(movie);
            await context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!await context.Movie.AnyAsync(m => m.Id == id)) return NotFound();
            throw;
        }
        TempData["Success"] = "Movie updated successfully.";
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Delete(int? id)
    {
        if (id is null) return NotFound();
        var movie = await context.Movie.AsNoTracking().FirstOrDefaultAsync(m => m.Id == id);
        return movie is null ? NotFound() : View(movie);
    }

    [HttpPost, ActionName("Delete"), ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var movie = await context.Movie.FindAsync(id);
        if (movie != null) context.Movie.Remove(movie);
        await context.SaveChangesAsync();
        TempData["Success"] = "Movie deleted successfully.";
        return RedirectToAction(nameof(Index));
    }
}
