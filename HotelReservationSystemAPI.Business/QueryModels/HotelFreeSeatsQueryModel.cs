using System;
using System.Collections.Generic;
using System.Text;

namespace HotelReservationSystemAPI.Business.QueryModels
{
    public class HotelFreeSeatsQueryModel : QueryModel
    {
        public int Id { get; set; }

        public DateTimeOffset CheckIn { get; set; }

        public DateTimeOffset CheckOut { get; set; }

        public int FreeSeatsCount { get; set; }
    }
}
