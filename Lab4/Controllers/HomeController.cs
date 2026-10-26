using Microsoft.AspNetCore.Mvc;

namespace MyWebApp.Controllers;

public class HomeController : Controller
{
    public IActionResult Index() => RedirectToAction("Index", "Learner");
    public IActionResult Privacy() => View();
}
