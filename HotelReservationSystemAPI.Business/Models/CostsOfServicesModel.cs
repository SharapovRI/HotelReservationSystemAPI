using System;
using System.Collections.Generic;
using System.Text;

namespace HotelReservationSystemAPI.Business.Models
{
    public class CostsOfServicesModel
    {
        public int id { get; set; }

        public int hotel_id { get; set; }

        public HotelModel Hotel { get; set; }

        public int additional_services_id { get; set; }

        public AdditionalServiceModel AdditionalService { get; set; }

        public decimal cost { get; set; }
    }
}
