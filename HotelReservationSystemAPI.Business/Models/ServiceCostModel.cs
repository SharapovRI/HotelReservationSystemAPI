using System;
using System.Collections.Generic;
using System.Text;

namespace HotelReservationSystemAPI.Business.Models
{
    public class ServiceCostModel
    {
        public int Id { get; set; }

        public int HotelId { get; set; }

        public HotelModel Hotel { get; set; }

        public int AdditionalServicesId { get; set; }

        public AdditionalServiceModel AdditionalService { get; set; }

        public decimal Cost { get; set; }
    }
}
