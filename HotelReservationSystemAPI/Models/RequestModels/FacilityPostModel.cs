using System.ComponentModel.DataAnnotations;

namespace HotelReservationSystemAPI.Models.RequestModels
{
    public class FacilityPostModel
    {
        [Required(ErrorMessage = "Enter additional facility name")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Additional facility name length must be between 3 and 20 characters")]
        public string Name { get; set; }
    }
}
