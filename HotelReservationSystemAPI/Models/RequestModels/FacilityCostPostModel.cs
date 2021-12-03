using System.ComponentModel.DataAnnotations;

namespace HotelReservationSystemAPI.Models.RequestModels
{
    public class FacilityCostPostModel
    {
        [Required]
        public int HotelId { get; set; }
        [Required]
        public string FacilityName { get; set; }
        [Required]
        [Range(0, 9999, ErrorMessage = "Price must be between 0 and 9999")]
        public decimal Cost { get; set; }
    }
}
