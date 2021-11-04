using System;

namespace HotelReservationSystemAPI.Business.Exceptions
{
    public class SomethingWrong : Exception
    {
        public SomethingWrong(string message)
            : base(message)
        {

        }
    }
}
