using System;
using System.Collections.Generic;
using System.Text;

namespace HotelReservationSystemAPI.Business.Models.Request
{
    public class HotelPatchRequestModel
    {
        public int? Id { get; set; }
        public int CountryId { get; set; }

        public int CityId { get; set; }

        public string Address { get; set; }

        public string Discription { get; set; }

        public string Name { get; set; }

        public IEnumerable<HotelPhotoCreationModel> HotelPhotos { get; set; }

        public IEnumerable<RoomCreationRangeModel> Rooms { get; set; }

        public IEnumerable<FacilityPatchRequestModel> Facilities { get; set; }
    }
}
