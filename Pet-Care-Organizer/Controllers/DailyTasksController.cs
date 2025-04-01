using Microsoft.AspNetCore.Mvc;
using Pet_Care_Organizer.Models;

namespace Pet_Care_Organizer.Controllers
{
    public class DailyTasksController : Controller
    {
        // Counter for genertating unique Ids
        private static int _nextId = 1;

        // temperary storage for tasks will remove when we use database
        private static List<DailyTasks> _tasks = new()
        {
            new DailyTasks { Id = 1, Description = "Morning feeding", IsCompleted = false },
            new DailyTasks { Id = 2, Description = "Afternoon walk", IsCompleted = true }
        };

        // Display all tasks
        public IActionResult Index()
        {
            return View(_tasks);
        }

        // Handles new task creation, Doesn't work yet 
        public IActionResult Create()
        {
            return View();
        }

        // Handle the new task submission by the user, Doesn't work yet
        [HttpPost]
        public IActionResult Create(DailyTasks task)
        {
            task.Id = _nextId++;
            _tasks.Add(task);
            return RedirectToAction("Index");
        }

        // Lets the user Edit a task, Doesn't work yet
        public IActionResult Edit(int id)
        {
            var task = _tasks.FirstOrDefault(t => t.Id == id);
            if (task == null) return NotFound();
            return View(task);
        }

        // Lets the user edit a specific task, Doesn't work yet
        [HttpPost]
        public IActionResult Edit(DailyTasks updatedTask)
        {
            var existingTask = _tasks.FirstOrDefault(t => t.Id == updatedTask.Id);
            if (existingTask == null) return NotFound();

            existingTask.Description = updatedTask.Description;
            existingTask.IsCompleted = updatedTask.IsCompleted;

            return RedirectToAction("Index");
        }

        // Allows user to delete a task, Doesn't work yet
        public IActionResult Delete(int id)
        {
            var task = _tasks.FirstOrDefault(t => t.Id == id);
            if (task == null) return NotFound();
            return View(task);
        }

        // Allows the deletion of a task on the list, Doesn't work yet
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var task = _tasks.FirstOrDefault(t => t.Id == id);
            if (task != null)
            {
                _tasks.Remove(task);
            }
            return RedirectToAction("Index");
        }
    }
}
