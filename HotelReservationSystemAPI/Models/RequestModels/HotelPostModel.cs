using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HotelReservationSystemAPI.Models.RequestModels
{
    public class  HotelPostModel
    {
        public int CountryId { get; set; }
        [Required]
        public int CityId { get; set; }
        [Required]
        [StringLength(60, MinimumLength = 5, ErrorMessage = "Address length must be between 5 and 60 characters")]
        public string Address { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Hotel name length must be between 2 and 100 characters")]
        public string Name { get; set; }

        public string Discription { get; set; }

        public IEnumerable<HotelPhotoPostModel> HotelPhotos { get; set; }

        public IEnumerable<RoomPostModel> Rooms { get; set; }

        public IEnumerable<FacilityPostModel> Facilities { get; set; }
    }
}
