using System;
using System.Collections.Generic;

namespace HotelReservationSystemAPI.Models
{
    public class OrderViewModel
    {
        public int RoomId { get; set; }
        
        public int PersonId { get; set; }
        
        public DateTimeOffset CheckInTime { get; set; }
        public DateTimeOffset CheckOutTime { get; set; }

        public decimal Cost { get; set; }

        public ICollection<AdditionalFacilityViewModel> AdditionalFacilities { get; set; }
    }
}
