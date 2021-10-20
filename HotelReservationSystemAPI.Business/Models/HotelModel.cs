using System;
using System.Collections.Generic;
using System.Text;

namespace HotelReservationSystemAPI.Business.Models
{
    public class HotelModel
    {
        public int id { get; set; }

        public string country { get; set; }

        public string city { get; set; }

        public string address { get; set; }

        public string name { get; set; }

        public ICollection<CostsOfServicesModel> CostsOfServices { get; set; }

        public ICollection<RoomModel> Rooms { get; set; }

        public ICollection<CostOfRoomsModel> CostsOfRooms { get; set; }
    }
}
