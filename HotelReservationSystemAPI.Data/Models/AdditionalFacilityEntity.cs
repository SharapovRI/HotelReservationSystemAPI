using System.Collections.Generic;

namespace HotelReservationSystemAPI.Data.Models
{
    public class AdditionalFacilityEntity : Entity
    {
        public int HotelId { get; set; }

        public string Name { get; set; }

        public virtual HotelEntity Hotel { get; set; }

        public decimal Cost { get; set; }

        public virtual List<AdditionalFacilityOrderEntity> FacilityOrders { get; set; }

        public bool IsActive { get; set; } = true;
    }
}
