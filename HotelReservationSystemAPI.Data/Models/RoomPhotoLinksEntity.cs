namespace HotelReservationSystemAPI.Data.Models
{
    public class RoomPhotoLinksEntity : Entity
    {
        public int RoomId { get; set; }
        public virtual RoomEntity Room { get; set; }
        public int PhotoId { get; set; }
        public virtual  RoomPhotoEntity RoomPhoto { get; set; }
    }
}