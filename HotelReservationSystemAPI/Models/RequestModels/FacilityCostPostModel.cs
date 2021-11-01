namespace HotelReservationSystemAPI.Models.RequestModels
{
    public class FacilityCostPostModel
    {
        public int HotelId { get; set; }

        public int AdditionalFacilityId { get; set; }

        public decimal Cost { get; set; }
    }
}
