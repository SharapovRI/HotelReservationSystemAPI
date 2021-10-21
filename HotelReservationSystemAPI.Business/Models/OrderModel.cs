using System;
using System.Collections.Generic;
using System.Text;

namespace HotelReservationSystemAPI.Business.Models
{
    public class OrderModel
    {
        public int Id { get; set; }

        public int RoomId { get; set; }

        public RoomModel Room { get; set; }

        public int PersonId { get; set; }

        public PersonModel Person { get; set; }

        public DateTimeOffset CheckInTime { get; set; }
        public DateTimeOffset CheckOutTime { get; set; }

        public decimal Cost { get; set; }

        public ICollection<AdditionalServiceOrderModel> AdditionalServices { get; set; }
    }
}
