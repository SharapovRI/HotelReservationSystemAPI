namespace HotelReservationSystemAPI.Models.RequestModels
{
    public class FacilityCostPutModel
    {
        public int Id { get; set; }

        public int HotelId { get; set; }

        public int AdditionalFacilityId { get; set; }

        public decimal Cost { get; set; }
    }
}
