using System.Collections.Generic;

namespace HotelReservationSystemAPI.Data.Models
{
    public class RoomPhotoEntity : PhotoEntity
    {
        public IList<RoomPhotoLinksEntity> RoomsLinks { get; set; }
    }
}
