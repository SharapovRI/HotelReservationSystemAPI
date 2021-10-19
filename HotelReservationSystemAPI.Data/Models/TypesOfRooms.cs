using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;
using System.Text;

namespace HotelReservationSystemAPI.Data.Models
{
    public class TypesOfRooms
    {
        [Key]
        public int id { get; set; }

        public string name { get; set; }

        public int amount_of_seats { get; set; }

        public List<CostOfRooms> CostsOfRooms { get; set; }

        public List<Room> Rooms { get; set; }
    }
}
