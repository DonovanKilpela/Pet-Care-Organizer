using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Pet_Care_Organizer.Models;

namespace Pet_Care_Organizer.Controllers
{
    public class HomeController : Controller
    {
        // Calls the Index view for the landing page of the project
        public IActionResult Index()
        {
            return View();
        }

    }
}
