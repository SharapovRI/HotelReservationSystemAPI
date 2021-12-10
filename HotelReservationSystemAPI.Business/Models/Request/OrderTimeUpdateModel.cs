using System;
using System.Collections.Generic;
using System.Text;

namespace HotelReservationSystemAPI.Business.Models.Request
{
    public class OrderTimeUpdateModel
    {
        public int Id { get; set; }

        public DateTimeOffset CheckInTime { get; set; }
    }
}
