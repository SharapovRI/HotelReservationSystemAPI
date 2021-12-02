using System;

namespace HotelReservationSystemAPI.Business.QueryModels
{
    public class HotelFreeSeatsQueryModel : QueryModel
    {
        public int? CountryId { get; set; }

        public int? CityId { get; set; }//TODO validation

        public DateTimeOffset CheckIn { get; set; }

        public DateTimeOffset CheckOut { get; set; }

        public int FreeSeatsCount { get; set; }

        public string NamePart { get; set; }
    }
}
