namespace HotelReservationSystemAPI.Models.RequestModels
{
    public class RoomTypePostModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int SeatsCount { get; set; }

        public int HotelId { get; set; }

        public decimal Cost { get; set; }
    }
}
