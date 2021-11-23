namespace HotelReservationSystemAPI.Data.Models
{
    public class HotelPhotoEntity : PhotoEntity
    {
        public int HotelId { get; set; }
        public virtual HotelEntity Hotel { get; set; }
    }
}
