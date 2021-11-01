using System;
using System.Collections.Generic;
using System.Text;

namespace HotelReservationSystemAPI.Business.Models
{
    public class HotelRequestModel
    {
        public int CountryId { get; set; }

        public int CityId { get; set; }

        public string Address { get; set; }

        public string Name { get; set; }

        public IEnumerable<RoomRequestModel> Rooms { get; set; }
    }
}
