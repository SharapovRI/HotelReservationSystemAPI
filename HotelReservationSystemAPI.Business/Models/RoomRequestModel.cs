namespace HotelReservationSystemAPI.Business.Models
{
    public class RoomRequestModel
    {
        public int TypeId { get; set; }

        public int RoomCount { get; set; }

        public int? HotelId { get; set; }
    }
}