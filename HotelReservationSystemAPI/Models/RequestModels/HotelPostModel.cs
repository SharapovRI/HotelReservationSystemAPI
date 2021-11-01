using System.Collections.Generic;

namespace HotelReservationSystemAPI.Models.RequestModels
{
    public class HotelPostModel
    {
        public int CountryId { get; set; }

        public int CityId { get; set; }

        public string Address { get; set; }

        public string Name { get; set; }

        public IEnumerable<RoomPostModel> Rooms { get; set; }
    }
}
