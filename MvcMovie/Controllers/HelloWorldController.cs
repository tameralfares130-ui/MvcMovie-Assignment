using Microsoft.AspNetCore.Mvc;
namespace MvcMovie.Controllers;

// Demonstrates the connection between controller actions and Razor views.
public class HelloWorldController : Controller
{
    public IActionResult Index() => View();
    public IActionResult Welcome(string name = "Student", int numTimes = 1)
    {
        ViewData["Message"] = $"Hello, {name}!";
        ViewData["NumTimes"] = Math.Clamp(numTimes, 1, 20);
        return View();
    }
}
