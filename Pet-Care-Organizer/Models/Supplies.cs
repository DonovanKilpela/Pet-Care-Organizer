using System.ComponentModel.DataAnnotations;

namespace Pet_Care_Organizer.Models
{
    public class Supplies
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Supply name is required")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Name must be between 2 and 100 characters")]
        [Display(Name = "Supply Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Quantity is required")]
        [Range(0, int.MaxValue, ErrorMessage = "Quantity must be 0 or greater")]
        [Display(Name = "Current Quantity")]
        public int Quantity { get; set; }
        [Required(ErrorMessage = "Low threshold is required")]
        [Range(0, int.MaxValue, ErrorMessage = "Low threshold must be 0 or greater")]
        [Display(Name = "Low Threshold")]
        public int LowThreshold { get; set; }
        [StringLength(500, ErrorMessage = "Notes cannot exceed 500 characters")]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Notes")]
        public string Notes { get; set; }
        [Required(ErrorMessage = "Estimated usage per day is required")]
        [Range(0, double.MaxValue, ErrorMessage = "Estimated usage must be 0 or greater")]
        [Display(Name = "Estimated Usage Per Day")]
        [DisplayFormat(DataFormatString = "{0:F2}", ApplyFormatInEditMode = true)]
        public double EstimatedUsagePerDay {get; set;}
    }
}
