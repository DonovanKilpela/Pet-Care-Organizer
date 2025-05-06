using Pet_Care_Organizer.Data;
using Pet_Care_Organizer.Models;
using System.Collections.Generic;
using System.Linq;

namespace Pet_Care_Organizer.Repositories
{
    public class DailyTasksRepository : IDailyTasksRepository
    {
        private readonly ApplicationDbContext _context;
        public DailyTasksRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<DailyTasks> GetAll() => _context.DailyTasks.ToList();

        public DailyTasks? GetById(int id) => _context.DailyTasks.Find(id);

        public void Add(DailyTasks task)
        {
            _context.DailyTasks.Add(task);
            _context.SaveChanges();
        }

        public bool Update(DailyTasks task)
        {
            var existing = _context.DailyTasks.Find(task.Id);
            if (existing == null) return false;
            existing.Description = task.Description;
            existing.StatusId = task.StatusId;
            _context.SaveChanges();
            return true;
        }

        public void Delete(int id)
        {
            var task = _context.DailyTasks.Find(id);
            if (task != null)
            {
                _context.DailyTasks.Remove(task);
                _context.SaveChanges();
            }
        }
    }
}
