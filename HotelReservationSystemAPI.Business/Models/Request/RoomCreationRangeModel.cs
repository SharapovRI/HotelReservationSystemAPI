using System.Collections.Generic;

namespace HotelReservationSystemAPI.Business.Models.Request
{
    public class RoomCreationRangeModel
    {
        public int Cost { get; set; }

        public int SeatsCount { get; set; }

        public string TypeName { get; set; }

        public int? TypeId { get; set; }

        public int RoomCount { get; set; }

        public int? HotelId { get; set; }

        public List<RoomPhotoCreationModel> RoomPhotos { get; set; }
    }
}