using Microsoft.AspNetCore.Mvc;
using Pet_Care_Organizer.Models;
using Pet_Care_Organizer.ViewModels;
using System.Runtime.CompilerServices;

namespace Pet_Care_Organizer.Controllers
{
    public class AppointmentsController : Controller
    {
        private static List<Appointments> appointments = new List<Appointments>();

       
        public IActionResult Index()
        {
            DateTime startDate = DateTime.Now;
            DateTime endDate = startDate.AddDays(7);

            var days = new List<DateTime>();
            for (DateTime date = startDate; date <= endDate; date = date.AddDays(1))
            {
                days.Add(date);
            }
            var model = new AppointmentsViewModel
            {
                Days = days,
                Appointments = appointments
            };

            return View(model);
        }

        // Doesn't work yet 
        [HttpPost]
        public ActionResult AddAppointment(Appointments appointment)
        {
            appointments.Add(appointment);
            return RedirectToAction("Index");
        } 
    }
}
