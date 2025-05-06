using Pet_Care_Organizer.Models;
using System.Collections.Generic;

namespace Pet_Care_Organizer.Repositories
{
    public interface IAppointmentRepository
    {
        List<Appointments> GetAll();
        void Add(Appointments appointment);
    }
}