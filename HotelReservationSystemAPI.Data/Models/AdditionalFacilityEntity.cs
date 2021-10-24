using System.Collections.Generic;

namespace HotelReservationSystemAPI.Data.Models
{
    public class AdditionalFacilityEntity : Entity
    {
        public string Name { get; set; }

        public virtual List<ServiceCostEntity> ServiceCosts { get; set; }
    }
}
