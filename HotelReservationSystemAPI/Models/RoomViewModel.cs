namespace HotelReservationSystemAPI.Models
{
    public class RoomViewModel
    {
        public int Id { get; set; }

        public string HotelName { get; set; }
        
        public string Type { get; set; }

        public int SeatsCount { get; set; }
    }
}
