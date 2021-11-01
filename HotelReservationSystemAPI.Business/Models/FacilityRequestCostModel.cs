namespace HotelReservationSystemAPI.Business.Models
{
    public class FacilityRequestCostModel
    {
        public int HotelId { get; set; }
        
        public int AdditionalFacilityId { get; set; }
        
        public decimal Cost { get; set; }
    }
}
