using System.Collections.Generic;

namespace HotelReservationSystemAPI.Data.Models
{
    public class AdditionalFacilityEntity : Entity
    {
        public string Name { get; set; }

        public virtual List<FacilityCostEntity> FacilityCosts { get; set; }

        public virtual List<AdditionalFacilityOrderEntity> FacilityOrders { get; set; }
    }
}
