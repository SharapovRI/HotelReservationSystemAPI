using System.ComponentModel.DataAnnotations;

namespace HotelReservationSystemAPI.Models.RequestModels
{
    public class RefreshRequestModel
    {
        [Required]
        public string RefreshToken { get; set; }
    }
}
