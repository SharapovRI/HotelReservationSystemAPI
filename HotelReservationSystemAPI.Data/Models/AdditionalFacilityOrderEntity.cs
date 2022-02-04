namespace HotelReservationSystemAPI.Data.Models
{
    public class AdditionalFacilityOrderEntity : Entity
    {
        public int OrderId { get; set; }
        
        public virtual OrderEntity Order { get; set; }

        public int AdditionFacilityId { get; set; }

        public virtual AdditionalFacilityEntity AdditionFacility { get; set; }
    }
}
