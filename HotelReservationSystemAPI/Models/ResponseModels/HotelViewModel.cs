using System.Collections.Generic;

namespace HotelReservationSystemAPI.Models.ResponseModels
{
    public class HotelViewModel
    {
        public int Id { get; set; }

        public string Country { get; set; }

        public string City { get; set; }

        public string Address { get; set; }

        public string Name { get; set; }

        public List<PhotoViewModel> Photos { get; set; }
    }
}
