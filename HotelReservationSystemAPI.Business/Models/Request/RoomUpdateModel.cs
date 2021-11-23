using System.Collections.Generic;

namespace HotelReservationSystemAPI.Business.Models.Request
{
    public class RoomUpdateModel
    {
        public int Id { get; set; }

        public string HotelName { get; set; }

        public string Type { get; set; }

        public int SeatsCount { get; set; }

        public decimal Cost { get; set; }

        public List<RoomPhotoUpdateModel> RoomPhotos { get; set; }
    }
}