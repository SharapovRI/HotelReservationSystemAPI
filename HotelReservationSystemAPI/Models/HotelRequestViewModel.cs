using System.Collections.Generic;

namespace HotelReservationSystemAPI.Models
{
    public class HotelRequestViewModel
    {
        public int CountryId { get; set; }

        public int CityId { get; set; }

        public string Address { get; set; }

        public string Name { get; set; }

        public IEnumerable<RoomRequestViewModel> Rooms { get; set; }
    }
}
