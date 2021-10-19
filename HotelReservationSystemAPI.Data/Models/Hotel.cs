using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HotelReservationSystemAPI.Data.Models
{
    public class Hotel
    {
        [Key]
        public int id { get; set; }

        public string country { get; set; }

        public string city { get; set; }

        public string address { get; set; }

        public string name { get; set; }

        public List<CostsOfServices> CostsOfServices { get; set; }

        public List<Room> Rooms { get; set; }

        public List<CostOfRooms> CostsOfRooms { get; set; }
    }
}
