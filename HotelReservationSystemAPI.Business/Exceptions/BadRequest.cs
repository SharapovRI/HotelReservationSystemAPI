using System;

namespace HotelReservationSystemAPI.Business.Exceptions
{
    public class BadRequest : Exception
    {
        public BadRequest(string message)
            : base(message)
        {

        }
    }
}
