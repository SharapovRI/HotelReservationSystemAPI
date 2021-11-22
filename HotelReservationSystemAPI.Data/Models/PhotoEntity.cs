namespace HotelReservationSystemAPI.Data.Models
{
    public class PhotoEntity : Entity
    {
        public string Title { get; set; }

        public byte[] Data { get; set; }
    }
}
