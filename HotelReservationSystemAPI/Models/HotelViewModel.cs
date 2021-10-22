using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelReservationSystemAPI.Models
{
    public class HotelViewModel
    {
        public int Id { get; set; }

        public string Country { get; set; }

        public string City { get; set; }

        public string Address { get; set; }

        public string Name { get; set; }
    }
}
