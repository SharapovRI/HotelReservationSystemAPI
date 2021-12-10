using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HotelReservationSystemAPI.Models.RequestModels
{
    public class RoomPutModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public int HotelId { get; set; }

        [Required]
        public string TypeName { get; set; }

        [Required]
        public int SeatsCount { get; set; }

        [Required]
        public int Cost { get; set; }

        public List<RoomPhotoPutModel> RoomPhotos { get; set; }
    }
}
