using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HotelReservationSystemAPI.Models.RequestModels
{
    public class RoomPostModel
    {
        [Required]
        public int TypeId { get; set; }

        [Required]
        [Range(0, 999, ErrorMessage = "Count of room must be between 0 and 999")]
        public int RoomCount { get; set; }

        public List<PhotoViewModel> RoomPhotos { get; set; }
    }
}
