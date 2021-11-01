using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelReservationSystemAPI.Data.Models
{
    public class CityEntity : Entity
    {
        public string Name { get; set; }

        public int CountryId { get; set; }

        [ForeignKey("CountryId")]
        public virtual CountryEntity Country { get; set; }

        public virtual List<HotelEntity> Hotels { get; set; }
    }
}
