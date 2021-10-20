﻿using System;
using System.Collections.Generic;
using System.Text;

namespace HotelReservationSystemAPI.Business.Models
{
    public class HotelModel
    {
        public int Id { get; set; }

        public string Country { get; set; }

        public string City { get; set; }

        public string Address { get; set; }

        public string Name { get; set; }

        public ICollection<CostsOfServicesModel> CostsOfServices { get; set; }

        public ICollection<RoomModel> Rooms { get; set; }

        public ICollection<CostOfRoomsModel> CostsOfRooms { get; set; }
    }
}
