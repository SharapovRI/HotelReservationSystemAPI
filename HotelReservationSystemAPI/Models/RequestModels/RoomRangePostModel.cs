using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HotelReservationSystemAPI.Models.RequestModels
{
    public class RoomRangePostModel
    {
        [Required]
        public int Cost { get; set; }

        [Required]
        public int SeatsCount { get; set; }

        [Required]
        public string TypeName { get; set; }

        [Required]
        [Range(1, 999, ErrorMessage = "Count of room must be between 0 and 999")]
        public int RoomCount { get; set; }

        public List<PhotoViewModel> RoomPhotos { get; set; }
    }
}