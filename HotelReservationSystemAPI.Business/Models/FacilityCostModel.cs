namespace HotelReservationSystemAPI.Business.Models
{
    public class FacilityCostModel
    {
        public int Id { get; set; }

        public int HotelId { get; set; }

        public HotelModel Hotel { get; set; }

        public int AdditionalFacilityId { get; set; }

        public AdditionalFacilityModel AdditionalFacility { get; set; }

        public decimal Cost { get; set; }
    }
}
