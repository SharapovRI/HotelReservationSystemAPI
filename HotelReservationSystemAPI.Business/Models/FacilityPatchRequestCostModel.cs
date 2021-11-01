namespace HotelReservationSystemAPI.Business.Models
{
    public class FacilityPatchRequestCostModel
    {
        public int Id { get; set; }

        public int HotelId { get; set; }

        public int AdditionalFacilityId { get; set; }

        public decimal Cost { get; set; }
    }
}
