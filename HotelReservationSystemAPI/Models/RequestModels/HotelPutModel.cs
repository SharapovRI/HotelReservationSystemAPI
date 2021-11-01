namespace HotelReservationSystemAPI.Models.RequestModels
{
    public class HotelPutModel
    {
        public int Id { get; set; }

        public int CountryId { get; set; }

        public int CityId { get; set; }

        public string Address { get; set; }

        public string Name { get; set; }
    }
}
