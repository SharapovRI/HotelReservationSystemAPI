using System.ComponentModel.DataAnnotations.Schema;

namespace HotelReservationSystemAPI.Data.Models
{
    public class AdditionalServicesOrderEntity :Entity
    {
        public int OrderId { get; set; }

        [ForeignKey("OrderId")] 
        public virtual OrderEntity Order { get; set; }

        public int AdditionServiceId { get; set; }

        [ForeignKey("AdditionServiceId")]
        public virtual AdditionalServiceEntity AdditionalService { get; set; }
    }
}
