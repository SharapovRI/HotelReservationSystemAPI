using System;

namespace HotelReservationSystemAPI.Business.Exceptions
{
    public class NoContent : Exception
    {
        public NoContent(string message)
            : base(message)
        {

        }
}
}
