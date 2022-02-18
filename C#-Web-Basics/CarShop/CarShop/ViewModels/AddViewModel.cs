using System.ComponentModel.DataAnnotations;

namespace CarShop.ViewModels
{
    public class AddViewModel
    {
        [Required]
        [StringLength(20, MinimumLength = 5)]
        public string Model { get; set; }

        [Required]
        [Range(1900, 2022)]
        public int Year { get; set; }

        public string ImageUrl { get; set; }

        [Required]
        [RegularExpression(@"^[A-Z]{2} \d{4} [A-Z]{2}$")]
        public string PlateNumber { get; set; }
    }
}
