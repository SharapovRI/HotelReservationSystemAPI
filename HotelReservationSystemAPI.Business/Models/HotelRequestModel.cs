using System.Collections.Generic;

namespace HotelReservationSystemAPI.Business.Models
{
    public class HotelRequestModel
    {
        public int CountryId { get; set; }

        public int CityId { get; set; }

        public string Address { get; set; }

        public string Name { get; set; }

        public List<PhotoModel> HotelPhotos { get; set; }

        public IEnumerable<RoomRequestModel> Rooms { get; set; }
    }
}
