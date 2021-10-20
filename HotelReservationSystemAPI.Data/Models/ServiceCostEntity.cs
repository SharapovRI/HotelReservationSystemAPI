using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HotelReservationSystemAPI.Data.Models
{
    public class ServiceCostEntity:Entity
    {
        public int HotelId { get; set; }

        [ForeignKey("HotelId")]
        public HotelEntity Hotel { get; set; }

        public int AdditionalServicesId { get; set; }

        [ForeignKey("AdditionalServicesId")]
        public AdditionalServiceEntity AdditionalService { get; set; }

        public decimal Cost { get; set; }
    }
}
