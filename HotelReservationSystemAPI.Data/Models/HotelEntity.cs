using System.Collections.Generic;

namespace HotelReservationSystemAPI.Data.Models
{
    public class HotelEntity : Entity
    {
        public int CountryId { get; set; }
        
        public virtual CountryEntity? Country { get; set; }

        public int CityId { get; set; }
        
        public virtual CityEntity? City { get; set; }

        public string Address { get; set; }

        public string Name { get; set; }
        
        public virtual List<HotelPhotoEntity> Photos { get; set; }

        public virtual List<FacilityCostEntity> FacilitiesCosts { get; set; }

        public virtual List<RoomEntity> Rooms { get; set; }

        public virtual List<RoomTypeEntity> RoomTypes { get; set; }
    }
}
