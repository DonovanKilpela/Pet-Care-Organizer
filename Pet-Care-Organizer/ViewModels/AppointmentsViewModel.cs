using Pet_Care_Organizer.Models;

namespace Pet_Care_Organizer.ViewModels
{
    public class AppointmentsViewModel
    {
        public List<DateTime> Days { get; set; }
        public List<Appointments> Appointments { get; set; }
    }
}
