using System.Collections.Generic;

namespace HotelReservationSystemAPI.Models.ResponseModels
{
    public class OrderGroupViewModel
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public virtual List<OrderViewModel> Orders { get; set; }
    }
}
