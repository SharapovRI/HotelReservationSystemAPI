using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelReservationSystemAPI.Models
{
    public class RoomTypeViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int SeatsCount { get; set; }

        public int HotelId { get; set; }

        public decimal Cost { get; set; }
    }
}
