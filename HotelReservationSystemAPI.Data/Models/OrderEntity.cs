using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelReservationSystemAPI.Data.Models
{
    public class OrderEntity : Entity
    {
        public int RoomId { get; set; }

        [ForeignKey("RoomId")]
        public RoomEntity Room { get; set; }

        public int PersonId { get; set; }

        [ForeignKey("PersonId")]
        public PersonEntity Person { get; set; }

        public DateTimeOffset CheckInTime { get; set; }
        public DateTimeOffset CheckOutTime { get; set; }

        public decimal Cost { get; set; }

        public List<AdditionalServicesOrderEntity> AdditionalServices { get; set; }
    }
}
