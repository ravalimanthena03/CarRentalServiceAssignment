using System.ComponentModel.DataAnnotations;
namespace CarRentalServiceAssignment.Models
{
    public class Car
    {
        public int Id { get; set; }

        [Required]
        public string Make { get; set; }

        [Required]
        public string Model { get; set; }

        [Required]
        public int Year { get; set; }

        [Required]
        public decimal PricePerDay { get; set; }

        public bool IsAvailable { get; set; } = true;
    }
}
