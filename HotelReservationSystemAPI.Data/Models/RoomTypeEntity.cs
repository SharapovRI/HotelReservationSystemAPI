using System.Collections.Generic;

namespace HotelReservationSystemAPI.Data.Models
{
    public class RoomTypeEntity : Entity
    {
        public string Name { get; set; }

        public int SeatsCount { get; set; }
        
        public decimal Cost { get; set; }

        public int HotelId { get; set; }

        public virtual HotelEntity? Hotel { get; set; }

        public virtual List<RoomEntity> Rooms { get; set; }
    }
}