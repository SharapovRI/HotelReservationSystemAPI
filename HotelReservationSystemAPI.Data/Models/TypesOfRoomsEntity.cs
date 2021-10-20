using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;
using System.Text;

namespace HotelReservationSystemAPI.Data.Models
{
    public class TypesOfRoomsEntity
    {
        [Key]
        public int id { get; set; }

        public string name { get; set; }

        public int amount_of_seats { get; set; }

        public List<CostOfRoomsEntity> CostsOfRooms { get; set; }

        public List<RoomEntity> Rooms { get; set; }
    }
}
