namespace HotelReservationSystemAPI.Business.QueryModels
{
    public class HotelAdminQueryModel : QueryModel
    {
        public int CountryId { get; set; }
        public int? CityId { get; set; }
        public string Name { get; set; }
    }
}