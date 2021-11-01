using System.ComponentModel.DataAnnotations.Schema;

namespace HotelReservationSystemAPI.Data.Models
{
    public class AdditionalFacilityOrderEntity : Entity
    {
        public int OrderId { get; set; }

        [ForeignKey("OrderId")]
        public virtual OrderEntity Order { get; set; }

        public int AdditionFacilityId { get; set; }

        [ForeignKey("AdditionFacilityId")]
        public virtual AdditionalFacilityEntity AdditionalFacility { get; set; }
    }
}
