using System.ComponentModel.DataAnnotations.Schema;

namespace HotelReservationSystemAPI.Data.Models
{
    public class FacilityCostEntity : Entity
    {
        public int HotelId { get; set; }
        
        public virtual HotelEntity Hotel { get; set; }

        public int AdditionalFacilityId { get; set; }
        
        public virtual AdditionalFacilityEntity AdditionalFacility { get; set; }

        public decimal Cost { get; set; }
    }
}
