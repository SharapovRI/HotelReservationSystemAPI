using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HotelReservationSystemAPI.Data.Models
{
    public class CostsOfServicesEntity
    {
        [Key]
        public int id { get; set; }

        public int hotel_id { get; set; }

        [ForeignKey("hotel_id")]
        public HotelEntity Hotel { get; set; }

        public int additional_services_id { get; set; }

        [ForeignKey("additional_services_id")]
        public AdditionalServiceEntity AdditionalService { get; set; }

        public decimal cost { get; set; }
    }
}
