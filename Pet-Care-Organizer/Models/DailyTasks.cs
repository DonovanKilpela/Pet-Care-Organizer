using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pet_Care_Organizer.Models
{
    public class DailyTasks
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Task description is required")]
        [StringLength(200, MinimumLength = 2, ErrorMessage = "Description must be between 2 and 200 characters")]
        [Display(Name = "Task Description")]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = "Status is required")]
        [Display(Name = "Status")]
        [StringLength(10)]  
        public string StatusId { get; set; } = string.Empty;

        [ForeignKey(nameof(StatusId))]
        public virtual Status? Status { get; set; }
    }
}
