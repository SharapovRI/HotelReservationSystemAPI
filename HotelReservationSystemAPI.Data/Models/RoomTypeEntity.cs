using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;
using System.Text;

namespace HotelReservationSystemAPI.Data.Models
{
    public class RoomTypeEntity:Entity
    {
        public string Name { get; set; }

        public int SeatsCount { get; set; }

        public List<RoomsCostEntity> RoomsCosts { get; set; }

        public List<RoomEntity> Rooms { get; set; }
    }
}
