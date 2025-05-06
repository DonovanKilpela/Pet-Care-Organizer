using Microsoft.AspNetCore.Mvc;
using Pet_Care_Organizer.Models;
using Pet_Care_Organizer.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Pet_Care_Organizer.Repositories;
using System;
using System.Collections.Generic;

namespace Pet_Care_Organizer.Controllers
{
    [Authorize]
    public class AppointmentsController : Controller
    {
        private readonly IAppointmentRepository _repository;

        public AppointmentsController(IAppointmentRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            DateTime startDate = DateTime.Now;
            DateTime endDate = startDate.AddDays(7);

            var days = new List<DateTime>();
            for (DateTime date = startDate; date <= endDate; date = date.AddDays(1))
                days.Add(date);

            var model = new AppointmentsViewModel
            {
                Days = days,
                Appointments = _repository.GetAll()
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult AddAppointment(Appointments appointment)
        {
            if (!ModelState.IsValid)
            {
                return View(appointment);
            }
            _repository.Add(appointment);
            return RedirectToAction("Index");
        }
    }
}