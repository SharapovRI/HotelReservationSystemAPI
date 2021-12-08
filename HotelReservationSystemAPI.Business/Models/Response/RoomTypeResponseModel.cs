namespace HotelReservationSystemAPI.Business.Models.Response
{
    public class RoomTypeResponseModel
    {
        public int RoomTypeId { get; set; }

        public string Name { get; set; }

        public int SeatsCount { get; set; }

        public int HotelId { get; set; }

        public decimal Cost { get; set; }
    }
}
