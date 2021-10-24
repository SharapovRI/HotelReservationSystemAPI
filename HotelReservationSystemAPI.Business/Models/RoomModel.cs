using System.Collections.Generic;

namespace HotelReservationSystemAPI.Business.Models
{
    public class RoomModel
    {
        public int Id { get; set; }

        public int HotelId { get; set; }

        public HotelModel Hotel { get; set; }

        public int TypeId { get; set; }

        public RoomTypeModel RoomType { get; set; }

        private ICollection<OrderModel> Orders { get; set; }

    }
}
