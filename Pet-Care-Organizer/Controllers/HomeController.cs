using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Pet_Care_Organizer.Models;
using Microsoft.AspNetCore.Authorization;

namespace Pet_Care_Organizer.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                HttpContext.Session.SetString("WelcomeMessage", "Welcome back, Pet Lover!");
            }
            else
            {
                HttpContext.Session.Remove("WelcomeMessage");
            }

            return View();
        }
    }
}
