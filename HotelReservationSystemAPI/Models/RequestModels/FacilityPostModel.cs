using System.ComponentModel.DataAnnotations;

namespace HotelReservationSystemAPI.Models.RequestModels
{
    public class FacilityPostModel
    {
        [Required]
        public int HotelId { get; set; }

        [Required(ErrorMessage = "Enter additional facility name")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Additional facility name length must be between 3 and 20 characters")]
        public string Name { get; set; }

        [Required]
        [Range(0, 9999, ErrorMessage = "Price must be between 0 and 9999")]
        public decimal Cost { get; set; }
    }
}
