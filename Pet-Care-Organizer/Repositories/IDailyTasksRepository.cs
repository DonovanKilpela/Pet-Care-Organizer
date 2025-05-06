using Pet_Care_Organizer.Models;
using System.Collections.Generic;

namespace Pet_Care_Organizer.Repositories
{
    public interface IDailyTasksRepository
    {
        List<DailyTasks> GetAll();
        DailyTasks? GetById(int id);
        void Add(DailyTasks task);
        bool Update(DailyTasks task);
        void Delete(int id);
    }
}
