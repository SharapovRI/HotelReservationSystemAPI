using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelReservationSystemAPI.Data.Models
{
    public class RoomEntity:Entity
    {
        public int HotelId { get; set; }

        [ForeignKey("HotelId")]
        public HotelEntity Hotel { get; set; }

        public int TypeId { get; set; }

        [ForeignKey("TypeId")]
        public RoomTypeEntity RoomTypes { get; set; }

        private List<OrderEntity> Orders { get; set; }
    }
}
