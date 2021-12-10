using System;

namespace HotelReservationSystemAPI.Models.RequestModels
{
    public class OrderUpdateTimeModel
    {
        public int Id { get; set; }

        public DateTimeOffset CheckInTime { get; set; }
    }
}
