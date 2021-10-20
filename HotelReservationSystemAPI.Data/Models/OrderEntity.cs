using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HotelReservationSystemAPI.Data.Models
{
    public class OrderEntity
    {
        [Key]
        public int id { get; set; }

        public int room_id { get; set; }

        [ForeignKey("room_id")]
        public RoomEntity Room { get; set; }

        public int person_id { get; set; }

        [ForeignKey("person_id")]
        public RoomEntity Person { get; set; }

        public DateTimeOffset check_in_time { get; set; }
        public DateTimeOffset check_out_time { get; set; }

        public decimal cost { get; set; }

        public List<AdditionalServicesInOrderEntity> AdditionalServices { get; set; }
    }
}
