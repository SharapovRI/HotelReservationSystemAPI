using System;

namespace HotelReservationSystemAPI.Business.Models
{
    public class OrderModel
    {
        public int RoomId { get; set; }

        public int PersonId { get; set; }

        public DateTimeOffset CheckInTime { get; set; }

        public DateTimeOffset CheckOutTime { get; set; }

        public decimal Cost { get; set; }

        public int[] AdditionalFacilities { get; set; }
    }
}
