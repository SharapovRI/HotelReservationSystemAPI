using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelReservationSystemAPI.Models
{
    public class OrderViewModel
    {
        public int RoomId { get; set; }
        
        public int PersonId { get; set; }
        
        public DateTimeOffset CheckInTime { get; set; }
        public DateTimeOffset CheckOutTime { get; set; }

        public decimal Cost { get; set; }

        public string AdditionalFacilities { get; set; }
    }
}
