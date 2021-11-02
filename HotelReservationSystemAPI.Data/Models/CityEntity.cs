using System.Collections.Generic;

namespace HotelReservationSystemAPI.Data.Models
{
    public class CityEntity : Entity
    {
        public string Name { get; set; }

        public int CountryId { get; set; }
        
        public virtual CountryEntity Country { get; set; }

        public virtual List<HotelEntity> Hotels { get; set; }
    }
}
