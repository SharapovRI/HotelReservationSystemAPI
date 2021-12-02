using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HotelReservationSystemAPI.Models.RequestModels
{
    public class  HotelPostModel
    {
        [Required]
        public int CountryId { get; set; }
        [Required]
        public int CityId { get; set; }
        [Required]
        [StringLength(60, MinimumLength = 5, ErrorMessage = "Address length must be between 5 and 60 characters")]
        public string Address { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Hotel name length must be between 2 and 20 characters")]
        public string Name { get; set; }

        public List<PhotoViewModel> HotelPhotos { get; set; }

        public IEnumerable<RoomPostModel> Rooms { get; set; }
    }
}
