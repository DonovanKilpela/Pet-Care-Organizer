using System.ComponentModel.DataAnnotations;

namespace Pet_Care_Organizer.Models
{
    public class Appointments
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Date is required")]
        [Display(Name = "Appointment Date")]
        [DataType(DataType.DateTime)]
        public DateTime Date { get; set; }
        [Required(ErrorMessage = "Title is required")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Title must be between 2 and 100 characters")]
        [Display(Name = "Appointment Title")]
        public string Title { get; set; } = string.Empty;
    }
}
