namespace HotelReservationSystemAPI.Business.Models
{
    public class RoomTypeRequestModel
    {
        public int RoomTypeId { get; set; }

        public string Name { get; set; }

        public int SeatsCount { get; set; }

        public int HotelId { get; set; }

        public decimal Cost { get; set; }
    }
}
