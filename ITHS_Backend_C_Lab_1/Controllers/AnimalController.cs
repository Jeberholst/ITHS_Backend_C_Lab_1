using Microsoft.AspNetCore.Mvc;

namespace ITHS_Backend_C_Lab_1.Controllers;

public class AnimalController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}