using Microsoft.AspNetCore.Mvc;
using Pet_Care_Organizer.Models;
using Microsoft.AspNetCore.Authorization;
using Pet_Care_Organizer.Repositories;
using System.Collections.Generic;

namespace Pet_Care_Organizer.Controllers
{
    [Authorize]
    public class SuppliesController : Controller
    {
        private readonly ISuppliesRepository _repository;

        public SuppliesController(ISuppliesRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            return View(_repository.GetAll());
        }

        public IActionResult Create() => View();

        [HttpPost]
        public IActionResult Create(Supplies supply)
        {
            if (ModelState.IsValid)
            {
                _repository.Add(supply);
                return RedirectToAction(nameof(Index));
            }
            return View(supply);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null) return NotFound();

            var supply = _repository.GetById(id.Value);
            return supply == null ? NotFound() : View(supply);
        }

        [HttpPost]
        public IActionResult Edit(int id, Supplies supply)
        {
            if (id != supply.Id) return NotFound();

            if (ModelState.IsValid)
            {
                var updated = _repository.Update(supply);
                if (!updated) return NotFound();
                return RedirectToAction(nameof(Index));
            }
            return View(supply);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null) return NotFound();

            var supply = _repository.GetById(id.Value);
            if (supply == null) return NotFound();

            return View(supply);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var deleted = _repository.Delete(id);
            if (!deleted) return NotFound();
            return RedirectToAction(nameof(Index));
        }
    }
}