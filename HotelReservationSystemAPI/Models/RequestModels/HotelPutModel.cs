using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HotelReservationSystemAPI.Models.RequestModels
{
    public class HotelPutModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public int CountryId { get; set; }

        [Required]
        public int CityId { get; set; }

        [Required]
        [StringLength(60, MinimumLength = 5, ErrorMessage = "Address length must be between 5 and 60 characters")]
        public string Address { get; set; }

        public string Discription { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Hotel name length must be between 2 and 50 characters")]
        public string Name { get; set; }

        public IEnumerable<HotelPhotoPostModel> HotelPhotos { get; set; }
        public IEnumerable<FacilityPutModel> Facilities { get; set; }

        public IEnumerable<RoomRangePostModel> Rooms { get; set; }
    }
}
