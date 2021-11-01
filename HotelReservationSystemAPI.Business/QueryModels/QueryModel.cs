using System;
using System.Collections.Generic;
using System.Text;

namespace HotelReservationSystemAPI.Business.QueryModels
{
    public abstract class QueryModel
    {
        public int Index { get; set; }

        public int Size { get; set; }

        public bool IsValidPageModel => Size > 0 && Index >= 0;
    }
}
