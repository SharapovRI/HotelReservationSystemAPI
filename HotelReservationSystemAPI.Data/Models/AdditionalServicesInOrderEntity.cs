using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HotelReservationSystemAPI.Data.Models
{
    public class AdditionalServicesInOrderEntity
    {
        [Key]
        public int id { get; set; }

        public int order_id { get; set; }

        [ForeignKey("order_id")] 
        public OrderEntity Order { get; set; }

        public int addition_service_id { get; set; }

        [ForeignKey("addition_service_id")]
        public AdditionalServiceEntity AdditionalService { get; set; }
    }
}
