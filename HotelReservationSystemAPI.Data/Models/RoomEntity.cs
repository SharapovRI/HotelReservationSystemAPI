using System;
using System.Collections.Generic;

namespace HotelReservationSystemAPI.Data.Models
{
    public class RoomEntity : Entity
    {
        public int HotelId { get; set; }
        
        public virtual HotelEntity? Hotel { get; set; }

        public int TypeId { get; set; }
        
        public virtual RoomTypeEntity? RoomType { get; set; }

        public DateTimeOffset? LastView { get; set; }

        public virtual IList<RoomPhotoLinksEntity> PhotoLinks { get; set; }

        public virtual IEnumerable<OrderEntity> Orders { get; set; }
    }
}
