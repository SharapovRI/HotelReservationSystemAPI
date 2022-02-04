namespace HotelReservationSystemAPI.Business.Models
{
    public class FacilityPatchRequestModel
    {
        public int Id { get; set; }

        public int HotelId { get; set; }

        public string Name { get; set; }

        public decimal Cost { get; set; }
    }
}
