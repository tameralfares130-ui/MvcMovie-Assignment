using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MvcMovie.Data;
using MvcMovie.Models;

namespace MvcMovie.Controllers;
public class MoviesController(MvcMovieContext context) : Controller
{
    public async Task<IActionResult> Index() => View(await context.Movie.ToListAsync());

    public async Task<IActionResult> Details(int? id)
    {
        if (id is null) return NotFound();
        var movie = await context.Movie.FirstOrDefaultAsync(m => m.Id == id);
        return movie is null ? NotFound() : View(movie);
    }

    public IActionResult Create() => View();

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Title,ReleaseDate,Genre,Price")] Movie movie)
    {
        if (!ModelState.IsValid) return View(movie);
        context.Add(movie);
        await context.SaveChangesAsync();
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
        context.Update(movie);
        await context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Delete(int? id)
    {
        if (id is null) return NotFound();
        var movie = await context.Movie.FirstOrDefaultAsync(m => m.Id == id);
        return movie is null ? NotFound() : View(movie);
    }

    [HttpPost, ActionName("Delete"), ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var movie = await context.Movie.FindAsync(id);
        if (movie != null) context.Movie.Remove(movie);
        await context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
}
