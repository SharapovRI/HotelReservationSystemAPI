using System;

namespace HotelReservationSystemAPI.Business.Models.Response
{
    public class OrderResponseModel
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
