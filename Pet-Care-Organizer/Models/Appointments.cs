namespace Pet_Care_Organizer.Models
{
    public class Appointments
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Title { get; set; } = string.Empty;
    }
}
