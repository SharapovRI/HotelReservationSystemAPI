using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelReservationSystemAPI.Models.ResponseModels
{
    public class RoomGroupViewModel
    {
        public int Id { get; set; }


        public string HotelName { get; set; }

        public string Type { get; set; }

        public int SeatsCount { get; set; }

        public decimal Cost { get; set; }

        public List<PhotoViewModel> Photos { get; set; }

        public int[] FreeRoomsId { get; set; }
    }
}
