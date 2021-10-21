using System;
using System.Collections.Generic;
using System.Text;

namespace HotelReservationSystemAPI.Business.Models
{
    public class RoomModel
    {
        public int Id { get; set; }

        public int HotelId { get; set; }

        public HotelModel Hotel { get; set; }

        public int TypeId { get; set; }

        public RoomTypeModel RoomTypes { get; set; }

        private ICollection<OrderModel> Orders { get; set; }
    }
}
