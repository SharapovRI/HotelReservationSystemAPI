namespace HotelReservationSystemAPI.Business.QueryModels
{
    public class OrderQueryModel : QueryModel
    {
        public int UserId { get; set; }

        public int? CountryId { get; set; }

        public int? CityId { get; set; }

        //null == all
        //false == past
        //true == future
        public bool? WhichTime { get; set; } 
    }
}
