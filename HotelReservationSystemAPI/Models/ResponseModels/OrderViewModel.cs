using System;

namespace HotelReservationSystemAPI.Models.ResponseModels
{
    public class OrderViewModel
    {
        public int Id { get; set; }

        public int RoomId { get; set; }

        public int GroupId { get; set; }

        public DateTimeOffset CheckInTime { get; set; }

        public DateTimeOffset CheckOutTime { get; set; }

        public decimal Cost { get; set; }

        public int[] AdditionalFacilities { get; set; }
    }
}
