using Pet_Care_Organizer.Data;
using Pet_Care_Organizer.Models;

namespace Pet_Care_Organizer.Repositories
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly ApplicationDbContext _context;
        public AppointmentRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public List<Appointments> GetAll() => _context.Appointments.ToList();
        public void Add(Appointments appointment)
        {
            _context.Appointments.Add(appointment);
            _context.SaveChanges();
        }
    }
}