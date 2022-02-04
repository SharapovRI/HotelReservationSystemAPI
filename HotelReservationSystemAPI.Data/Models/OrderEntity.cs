using System;
using System.Collections.Generic;

namespace HotelReservationSystemAPI.Data.Models
{
    public class OrderEntity : Entity
    {
        public int RoomId { get; set; }
        
        public virtual RoomEntity Room { get; set; }

        public int OrderGroupId { get; set; }
        
        public virtual OrderGroupEntity OrderGroup { get; set; }

        public DateTimeOffset CheckInTime { get; set; }
        public DateTimeOffset CheckOutTime { get; set; }

        public decimal Cost { get; set; }

        public virtual List<AdditionalFacilityOrderEntity> AdditionalFacilities { get; set; }
    }
}
