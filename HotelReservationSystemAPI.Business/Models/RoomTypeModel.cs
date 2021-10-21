using System;
using System.Collections.Generic;
using System.Text;

namespace HotelReservationSystemAPI.Business.Models
{
    public class RoomTypeModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int AmountOfSeats { get; set; }

        public ICollection<RoomsCostModel> RoomsCosts { get; set; }

        public ICollection<RoomModel> Rooms { get; set; }
    }
}
