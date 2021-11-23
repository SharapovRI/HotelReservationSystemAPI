namespace HotelReservationSystemAPI.Business.Models.Request
{
    public class RoomCreationRangeModel
    {
        public int TypeId { get; set; }

        public int RoomCount { get; set; }

        public int? HotelId { get; set; }

        public int[] RoomPhotos { get; set; }
    }
}