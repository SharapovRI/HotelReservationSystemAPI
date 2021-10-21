using System.ComponentModel.DataAnnotations.Schema;

namespace HotelReservationSystemAPI.Data.Models
{
    public class AdditionalFacilityOrderEntity : Entity
    {
        public int OrderId { get; set; }

        [ForeignKey("OrderId")]
        public OrderEntity Order { get; set; }

        public int AdditionServiceId { get; set; }

        [ForeignKey("AdditionServiceId")]
        public AdditionalFacilityEntity AdditionalFacility { get; set; }
    }
}
