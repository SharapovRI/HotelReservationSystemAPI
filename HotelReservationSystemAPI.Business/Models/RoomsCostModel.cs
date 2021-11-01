﻿namespace HotelReservationSystemAPI.Business.Models
{
    public class RoomsCostModel
    {
        public int Id { get; set; }

        public int HotelId { get; set; }

        public HotelModel Hotel { get; set; }

        public int TypeId { get; set; }

        public RoomTypeModel RoomTypes { get; set; }

        public decimal Cost { get; set; }
    }
}
