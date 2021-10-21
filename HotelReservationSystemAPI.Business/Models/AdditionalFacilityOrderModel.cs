﻿using System;
using System.Collections.Generic;
using System.Text;

namespace HotelReservationSystemAPI.Business.Models
{
    public class AdditionalFacilityOrderModel 
    {
        public int Id { get; set; }

        public int OrderId { get; set; }
        public OrderModel Order { get; set; }

        public int AdditionServiceId { get; set; }

        public AdditionalFacilityModel AdditionalFacility { get; set; }
    }
}
