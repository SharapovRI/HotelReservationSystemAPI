using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelReservationSystemAPI.Models
{
    public class FacilityCostRequestViewModel
    {
        public int HotelId { get; set; }
        public int AdditionalFacilityId { get; set; }
        public decimal Cost { get; set; }
    }
}
