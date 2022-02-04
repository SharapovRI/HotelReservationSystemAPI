using System.Collections.Generic;

namespace HotelReservationSystemAPI.Business.Models.Response
{
    public class OrderGroupResponseModel
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public virtual List<OrderResponseModel> Orders { get; set; }
    }
}
