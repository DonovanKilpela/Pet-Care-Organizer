namespace Pet_Care_Organizer.Models
{
    public class DailyTasks
    {
        public int Id { get; set; }
        public string Description { get; set; } = string.Empty;
        public string StatusId { get; set; } = string.Empty;

        public Status Status { get; set; } = null!;
    }
}
