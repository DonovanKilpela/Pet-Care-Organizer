using Microsoft.AspNetCore.Mvc;
using Pet_Care_Organizer.Models;
using Microsoft.EntityFrameworkCore;
using Pet_Care_Organizer.Data;


namespace Pet_Care_Organizer.Controllers
{
    public class SuppliesController : Controller
    {
        private readonly ApplicationDbContext _context;
        public SuppliesController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var supplies = _context.Supplies.ToList();
            return View(supplies);
        }

        public IActionResult Create() => View();

        [HttpPost]
        public IActionResult Create(Supplies supply)
        {
            if (ModelState.IsValid)
            {
                _context.Supplies.Add(supply);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(supply);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null) return NotFound();

            var supply = _context.Supplies.Find(id);
            return supply == null ? NotFound() : View(supply);
        }

        [HttpPost]
        public IActionResult Edit(int id, Supplies supply)
        {
            if (id != supply.Id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(supply);
                    _context.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SupplyExists(supply.Id))
                    {
                        return NotFound();
                    }
                    throw;
                }
            }
            return View(supply);
        }

        // GET: Supplies/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null) return NotFound();

            var supply = _context.Supplies
                .FirstOrDefault(m => m.Id == id);

            if (supply == null) return NotFound();

            return View(supply);
        }

        // POST: Supplies/Delete/5
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var supply = _context.Supplies.Find(id);
            if (supply == null) return NotFound();

            try
            {
                _context.Supplies.Remove(supply);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateException)
            {
                ModelState.AddModelError("", "Unable to delete supply. Please try again.");
                return View(supply);
            }
        }

        private bool SupplyExists(int id)
        {
            return _context.Supplies.Any(e => e.Id == id);
        }

    }
}