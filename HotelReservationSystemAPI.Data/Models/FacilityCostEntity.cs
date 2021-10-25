using System.ComponentModel.DataAnnotations.Schema;

namespace HotelReservationSystemAPI.Data.Models
{
    public class FacilityCostEntity : Entity
    {
        public int HotelId { get; set; }

        [ForeignKey("HotelId")]
        public virtual HotelEntity Hotel { get; set; }

        public int AdditionalFacilitiesId { get; set; }

        [ForeignKey("AdditionalFacilitiesId")]
        public virtual AdditionalFacilityEntity AdditionalFacility { get; set; }

        public decimal Cost { get; set; }
    }
}
