using Microsoft.AspNetCore.Mvc;
using Pet_Care_Organizer.Models;
using Microsoft.AspNetCore.Authorization;
using Pet_Care_Organizer.Repositories;
using System.Collections.Generic;

namespace Pet_Care_Organizer.Controllers
{
    [Authorize]
    public class DailyTasksController : Controller
    {
        private readonly IDailyTasksRepository _repository;
        private readonly IStatusRepository _statusRepository;

        public DailyTasksController(IDailyTasksRepository repository, IStatusRepository statusRepository)
        {
            _repository = repository;
            _statusRepository = statusRepository;
        }

        public IActionResult Index()
        {
            return View(_repository.GetAll());
        }

        public IActionResult Create()
        {
            ViewBag.StatusOptions = _statusRepository.GetAll();
            return View();
        }

        [HttpPost]
        public IActionResult Create(DailyTasks task)
        {
            _repository.Add(task);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            ViewBag.StatusOptions = _statusRepository.GetAll();
            var task = _repository.GetById(id);
            if (task == null) return NotFound();
            return View(task);
        }

        [HttpPost]
        public IActionResult Edit(DailyTasks updatedTask)
        {
            ViewBag.StatusOptions = _statusRepository.GetAll();
            var success = _repository.Update(updatedTask);
            if (!success) return NotFound();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var task = _repository.GetById(id);
            if (task == null) return NotFound();
            return View(task);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _repository.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
