using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HotelReservationSystemAPI.Data.Models
{
    public class HotelEntity
    {
        [Key]
        public int id { get; set; }

        public string country { get; set; }

        public string city { get; set; }

        public string address { get; set; }

        public string name { get; set; }

        public List<CostsOfServicesEntity> CostsOfServices { get; set; }

        public List<RoomEntity> Rooms { get; set; }

        public List<CostOfRoomsEntity> CostsOfRooms { get; set; }
    }
}
