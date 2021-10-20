﻿using System;
using System.Collections.Generic;
using System.Text;

namespace HotelReservationSystemAPI.Business.Models
{
    public class CostOfRoomsModel
    {
        public int Id { get; set; }

        public int HotelId { get; set; }

        public HotelModel Hotel { get; set; }

        public int TypeId { get; set; }

        public TypesOfRoomsModel TypeOfRooms { get; set; }

        public decimal Cost { get; set; }
    }
}
