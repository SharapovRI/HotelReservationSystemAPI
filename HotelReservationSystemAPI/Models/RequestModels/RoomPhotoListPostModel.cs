using System.Collections.Generic;

namespace HotelReservationSystemAPI.Models.RequestModels
{
    public class RoomPhotoListPostModel
    {
        public IList<RoomPhotoPostModel> RoomPhotos { get; set; }
    }
}
