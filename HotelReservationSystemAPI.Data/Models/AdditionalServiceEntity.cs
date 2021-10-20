using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HotelReservationSystemAPI.Data.Models
{
    public class AdditionalServiceEntity: Entity
    {
        public string Name { get; set; }

        public List<ServiceCostEntity> ServiceCosts { get; set; }
    }
}
