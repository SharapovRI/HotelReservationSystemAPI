namespace HotelReservationSystemAPI.Models.ResponseModels
{
    public class AdditionFacilityOrderViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Cost { get; set; }

        public int AdditionFacilityId { get; set; }

        public int FacilityCount { get; set; }
    }
}
