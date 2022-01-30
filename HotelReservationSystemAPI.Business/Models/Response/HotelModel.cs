using System.Collections.Generic;
using HotelReservationSystemAPI.Business.Models.Response;

namespace HotelReservationSystemAPI.Business.Models
{
    public class HotelModel
    {
        public int Id { get; set; }

        public string Country { get; set; }

        public string City { get; set; }

        public string Address { get; set; }

        public string Discription { get; set; }

        public string Name { get; set; }

        public List<PhotoModel> Photos { get; set; }
    }
}
