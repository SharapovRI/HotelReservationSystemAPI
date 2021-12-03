namespace HotelReservationSystemAPI.Business.Models.Request
{
    public class FacilityRequestCostModel
    {
        public int HotelId { get; set; }
        
        public string FacilityName { get; set; }
        
        public decimal Cost { get; set; }
    }
}
