using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelReservationSystemAPI.Models
{
    public class RoomViewModel
    {
        public int Id { get; set; }

        public string HotelName { get; set; }
        
        public string Type { get; set; }
    }
}
