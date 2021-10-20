using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;
using System.Text;

namespace HotelReservationSystemAPI.Data.Models
{
    public class TypesOfRoomsEntity:Entity
    {
        public string Name { get; set; }

        public int AmountOfSeats { get; set; }

        public List<CostOfRoomsEntity> CostsOfRooms { get; set; }

        public List<RoomEntity> Rooms { get; set; }
    }
}
