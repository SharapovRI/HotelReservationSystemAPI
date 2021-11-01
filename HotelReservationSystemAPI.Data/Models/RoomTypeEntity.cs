using System.Collections.Generic;

namespace HotelReservationSystemAPI.Data.Models
{
    public class RoomTypeEntity : Entity
    {
        public string Name { get; set; }

        public int SeatsCount { get; set; }

        public virtual List<RoomsCostEntity> RoomsCosts { get; set; }

        public virtual List<RoomEntity> Rooms { get; set; }
    }
}
