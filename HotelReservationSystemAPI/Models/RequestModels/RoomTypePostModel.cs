using System.ComponentModel.DataAnnotations;

namespace HotelReservationSystemAPI.Models.RequestModels
{
    public class RoomTypePostModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Room type name length must be between 2 and 20 characters")]
        public string Name { get; set; }

        [Required]
        [Range(0, 99, ErrorMessage = "Count of seats must be between 0 and 99")]
        public int SeatsCount { get; set; }

        [Required]
        public int HotelId { get; set; }

        [Required]
        [Range(0, 9999, ErrorMessage = "Price must be between 0 and 9999")]
        public decimal Cost { get; set; }
    }
}
