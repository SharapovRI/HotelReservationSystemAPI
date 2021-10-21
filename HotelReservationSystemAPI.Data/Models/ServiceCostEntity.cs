using System.ComponentModel.DataAnnotations.Schema;

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
