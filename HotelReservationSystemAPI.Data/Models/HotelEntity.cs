using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelReservationSystemAPI.Data.Models
{
    public class HotelEntity : Entity
    {
        public int CountryId { get; set; }

        [ForeignKey("CountryId")]
        public virtual CountryEntity Country { get; set; }

        public int CityId { get; set; }

        [ForeignKey("CityId")]
        public virtual CityEntity City { get; set; }

        public string Address { get; set; }

        public string Name { get; set; }

        public virtual List<FacilityCostEntity> FacilitiesCosts { get; set; }

        public virtual List<RoomEntity> Rooms { get; set; }

        public virtual List<RoomsCostEntity> RoomsCosts { get; set; }
    }
}
