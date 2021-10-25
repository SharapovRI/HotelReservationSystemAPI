using System;

namespace HotelReservationSystemAPI.Business.QueryModels
{
    public class FreeRoomsQueryModel : QueryModel
    {
        public int HotelId { get; set; }

        public DateTimeOffset CheckIn { get; set; }

        public DateTimeOffset CheckOut { get; set; }
    }
}