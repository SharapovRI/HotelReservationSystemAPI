using System.ComponentModel.DataAnnotations;

namespace HotelReservationSystemAPI.Models.RequestModels
{
    public class FacilityCostPostModel
    {
        public int? HotelId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [Range(0, 9999, ErrorMessage = "Price must be between 0 and 9999")]
        public decimal Cost { get; set; }
    }
}
