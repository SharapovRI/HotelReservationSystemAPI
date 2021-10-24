using System.ComponentModel.DataAnnotations.Schema;

namespace HotelReservationSystemAPI.Data.Models
{
    public class ServiceCostEntity:Entity
    {
        public int HotelId { get; set; }

        [ForeignKey("HotelId")]
        public virtual HotelEntity Hotel { get; set; }

        public int AdditionalServicesId { get; set; }

        [ForeignKey("AdditionalServicesId")]
        public virtual AdditionalFacilityEntity AdditionalFacility { get; set; }

        public decimal Cost { get; set; }
    }
}
