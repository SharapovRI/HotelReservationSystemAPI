using System.Collections.Generic;
using HotelReservationSystemAPI.Business.Models.Request;

namespace HotelReservationSystemAPI.Business.Models
{
    public class HotelRequestModel
    {
        public int? Id { get; set; }
        public int CountryId { get; set; }

        public int CityId { get; set; }

        public string Address { get; set; }

        public string Name { get; set; }

        public IEnumerable<HotelPhotoCreationModel> HotelPhotos { get; set; }

        public IEnumerable<RoomCreationRangeModel> Rooms { get; set; }

        public IEnumerable<FacilityRequestCostModel> Facilities { get; set; }
    }
}
