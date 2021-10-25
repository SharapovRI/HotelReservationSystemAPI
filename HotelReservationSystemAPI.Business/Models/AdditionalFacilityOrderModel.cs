namespace HotelReservationSystemAPI.Business.Models
{
    public class AdditionalFacilityOrderModel 
    {
        public int Id { get; set; }

        public int OrderId { get; set; }
        public OrderModel Order { get; set; }

        public int AdditionFacilityId { get; set; }

        public AdditionalFacilityModel AdditionalFacility { get; set; }
    }
}
