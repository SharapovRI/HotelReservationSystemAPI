using System;
using System.Collections.Generic;
using System.Text;

namespace HotelReservationSystemAPI.Business.Interfaces
{
    public interface IBusinessMapper
    {
        public TDestination Map<TSource, TDestination>(TSource source);
    }
}
