using System.Collections.Generic;

namespace HotelReservationSystemAPI.Data.Models
{
    public class OrderGroupEntity : Entity
    {
        public int PersonId { get; set; }

        public virtual PersonEntity Person { get; set; }

        public virtual List<OrderEntity> Orders { get; set; }
    }
}
