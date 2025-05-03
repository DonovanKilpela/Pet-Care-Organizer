using System.ComponentModel.DataAnnotations;

namespace Pet_Care_Organizer.Models
{
    public class Status
    {
        [Key]
        [Required(ErrorMessage = "Status ID is required")]
        [StringLength(10, ErrorMessage = "Status ID cannot exceed 10 characters")]
        [Display(Name = "Status ID")]
        public string StatusId { get; set; } = string.Empty;
        [Required(ErrorMessage = "Status name is required")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Status name must be between 2 and 50 characters")]
        [Display(Name = "Status Name")]
        public string Name { get; set; } = string.Empty;
    }
}
