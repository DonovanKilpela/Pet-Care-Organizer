using Microsoft.AspNetCore.Mvc;
using Pet_Care_Organizer.Models;
using Microsoft.AspNetCore.Authorization;


namespace Pet_Care_Organizer.Controllers
{
    [Authorize]
    public class DailyTasksController : Controller
    {
        // Counter for genertating unique Ids
        private static int _nextId = 1;

        // list to store Status options 
        private static List<Status> _statusOptions = new()
        {
            new Status { StatusId = "Not Started", Name = "Not Started" },
            new Status { StatusId = "In Progress", Name = "In Progress" },
            new Status { StatusId = "Completed", Name = "Completed" }
        };
        // temperary storage for tasks will remove when we use database
        private static List<DailyTasks> _tasks = new()
        {
            new DailyTasks { Id = 1, Description = "Morning feeding", StatusId = "Not Started" },
            new DailyTasks { Id = 2, Description = "Afternoon walk", StatusId = "In Progress" },
            new DailyTasks { Id = 3, Description = "Evening grooming", StatusId = "Completed" }
        };

        // Display all tasks
        public IActionResult Index()
        {
            return View(_tasks);
        }

        public IActionResult Create()
        {
            if (_statusOptions == null || !_statusOptions.Any())
            {
                _statusOptions = new List<Status>
                {
                    new Status { StatusId = "Not Started", Name = "Not Started" },
                    new Status { StatusId = "In Progress", Name = "In Progress" },
                    new Status { StatusId = "Completed", Name = "Completed" }
                };
            }
            // Populate the status options for the dropdown
            ViewBag.StatusOptions = _statusOptions;
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
            if (_statusOptions == null || !_statusOptions.Any())
            {
                _statusOptions = new List<Status>
                {
                    new Status { StatusId = "Not Started", Name = "Not Started" },
                    new Status { StatusId = "In Progress", Name = "In Progress" },
                    new Status { StatusId = "Completed", Name = "Completed" }
                };
            }

            // Populate the status options for the dropdown
            ViewBag.StatusOptions = _statusOptions;

            var task = _tasks.FirstOrDefault(t => t.Id == id);
            if (task == null) 
                return NotFound();


            return View(task);
        }

        // Lets the user edit a specific task, Doesn't work yet
        [HttpPost]
        public IActionResult Edit(DailyTasks updatedTask)
        {
            if (_statusOptions == null || !_statusOptions.Any())
            {
                _statusOptions = new List<Status>
                {
                    new Status { StatusId = "Not Started", Name = "Not Started" },
                    new Status { StatusId = "In Progress", Name = "In Progress" },
                    new Status { StatusId = "Completed", Name = "Completed" }
                };
            }
            // Populate the status options for the dropdown
            ViewBag.StatusOptions = _statusOptions;
            var existingTask = _tasks.FirstOrDefault(t => t.Id == updatedTask.Id);
            if (existingTask == null) return NotFound();

            existingTask.Description = updatedTask.Description;
            existingTask.StatusId = updatedTask.StatusId;

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
