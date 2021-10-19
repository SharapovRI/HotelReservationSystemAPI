using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HotelReservationSystemAPI.Data.Models
{
    public class Order
    {
        [Key]
        public int id { get; set; }

        public int room_id { get; set; }

        [ForeignKey("room_id")]
        public Room Room { get; set; }

        public DateTimeOffset check_in_time { get; set; }
        public DateTimeOffset check_out_time { get; set; }

        public decimal cost { get; set; }

        public List<AdditionalServicesInOrder> AdditionalServices { get; set; }
    }
}
