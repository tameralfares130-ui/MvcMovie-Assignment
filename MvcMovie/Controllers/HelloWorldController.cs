using Microsoft.AspNetCore.Mvc;
namespace MvcMovie.Controllers;

// Demonstrates the controller part of MVC.
public class HelloWorldController : Controller
{
    public string Index() => "Hello from the MVC controller!";
    public string Welcome(string name = "Student", int numTimes = 1) =>
        $"Hello {name}; number of greetings: {numTimes}";
}
