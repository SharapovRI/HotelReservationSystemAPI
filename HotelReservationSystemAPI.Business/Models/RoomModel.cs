namespace HotelReservationSystemAPI.Business.Models
{
    public class RoomModel
    {
        public int Id { get; set; }

        public string HotelName { get; set; }

        public string Type { get; set; }

        public int SeatsCount { get; set; }

        public decimal Cost { get; set; }
    }
}
