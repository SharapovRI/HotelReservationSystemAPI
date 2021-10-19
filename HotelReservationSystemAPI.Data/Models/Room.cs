using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HotelReservationSystemAPI.Data.Models
{
    public class Room
    {
        [Key]
        public int id { get; set; }

        public int hotel_id { get; set; }

        [ForeignKey("hotel_id")]
        public Hotel Hotel { get; set; }

        public int type_id { get; set; }

        [ForeignKey("type_id")]
        public TypesOfRooms TypeOfRooms { get; set; }
    }
}
