using System;

namespace HotelReservationSystemAPI.Business.Models.Request
{
    public class OrderTimeUpdateModel
    {
        public int Id { get; set; }

        public DateTimeOffset CheckInTime { get; set; }
    }
}
