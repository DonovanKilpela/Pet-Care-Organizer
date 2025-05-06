using Pet_Care_Organizer.Data;
using Pet_Care_Organizer.Models;
using System.Collections.Generic;
using System.Linq;

namespace Pet_Care_Organizer.Repositories
{
    public class StatusRepository : IStatusRepository
    {
        private readonly ApplicationDbContext _context;
        public StatusRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Status> GetAll() => _context.Status.ToList();
    }
}
