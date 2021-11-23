using System.Collections.Generic;

namespace HotelReservationSystemAPI.Business.Models.Request
{
    public class RoomPhotosCreationListModel
    {
        public IList<RoomPhotoCreationModel> RoomPhotos { get; set; }
    }
}
