using System;
using System.Collections.Generic;
using System.Text;

namespace HotelReservationSystemAPI.Business.Models
{
    public class AdditionalServicesInOrderModel
    {
        public int id { get; set; }

        public int order_id { get; set; }
        public OrderModel Order { get; set; }

        public int addition_service_id { get; set; }

        public AdditionalServiceModel AdditionalService { get; set; }
    }
}
