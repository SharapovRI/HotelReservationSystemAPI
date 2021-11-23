using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HotelReservationSystemAPI.Models.RequestModels
{
    public class RoomPutModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public int TypeId { get; set; }

        public List<RoomPhotoPutModel> RoomPhotos { get; set; }
    }
}
