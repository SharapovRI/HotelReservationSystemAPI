using System.Collections.Generic;

namespace HotelReservationSystemAPI.Data.Models
{
    public class CountryEntity : Entity
    {
        public string Name { get; set; }

        public virtual List<CityEntity> Cities { get; set; }

        public virtual List<HotelEntity> Hotels { get; set; }
    }
}
