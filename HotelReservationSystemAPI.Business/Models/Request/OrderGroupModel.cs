using System;
using System.Collections.Generic;
using System.Text;

namespace HotelReservationSystemAPI.Business.Models.Request
{
    public class OrderGroupModel
    {
        public int PersonId { get; set; }

        public virtual List<OrderModel> Orders { get; set; }
    }
}
