using System;
using System.Collections.Generic;
using System.Text;

namespace HotelReservationSystemAPI.Business.Models
{
    public class OrderModel
    {
        public int id { get; set; }

        public int room_id { get; set; }

        public RoomModel Room { get; set; }

        public int person_id { get; set; }

        public PersonModel Person { get; set; }

        public DateTimeOffset check_in_time { get; set; }
        public DateTimeOffset check_out_time { get; set; }

        public decimal cost { get; set; }

        public ICollection<AdditionalServicesInOrderModel> AdditionalServices { get; set; }
    }
}
