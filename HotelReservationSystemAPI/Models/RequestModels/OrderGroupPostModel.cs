using System.Collections.Generic;

namespace HotelReservationSystemAPI.Models.RequestModels
{
    public class OrderGroupPostModel
    {
        public int PersonId { get; set; }

        public virtual List<OrderPostModel> Orders { get; set; }

        public int TotalCost { get; set; }
    }
}
