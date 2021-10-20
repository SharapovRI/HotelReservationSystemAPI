using System;
using System.Collections.Generic;
using System.Text;

namespace HotelReservationSystemAPI.Business.Models
{
    public class TypesOfRoomsModel
    {
        public int id { get; set; }

        public string name { get; set; }

        public int amount_of_seats { get; set; }

        public ICollection<CostOfRoomsModel> CostsOfRooms { get; set; }

        public ICollection<RoomModel> Rooms { get; set; }
    }
}
