using System;

namespace HotelReservationSystemAPI.Business.Exceptions
{
    public class NotFound : Exception
    {
        public NotFound(string message)
            : base(message)
        {

        }
    }
}
