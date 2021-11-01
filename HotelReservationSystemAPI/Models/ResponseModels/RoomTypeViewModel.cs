namespace HotelReservationSystemAPI.Models.ResponseModels
{
    public class RoomTypeViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int SeatsCount { get; set; }

        public int HotelId { get; set; }

        public decimal Cost { get; set; }
    }
}
