using System;
using System.Collections.Generic;
using System.Text;

namespace HotelReservationSystemAPI.Business.Models
{
    public class CostOfRoomsModel
    {
        public int id { get; set; }

        public int hotel_id { get; set; }

        public HotelModel Hotel { get; set; }

        public int type_id { get; set; }

        public TypesOfRoomsModel TypeOfRooms { get; set; }

        public decimal cost { get; set; }
    }
}
