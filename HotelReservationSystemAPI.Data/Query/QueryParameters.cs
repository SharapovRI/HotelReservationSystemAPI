using System;
using System.Collections.Generic;
using System.Text;
using HotelReservationSystemAPI.Data.Models;

namespace HotelReservationSystemAPI.Data.Query
{
    public class QueryParameters<TEntity> where TEntity : class, IEntity
    {
        public FilterRule<TEntity> FilterRule { get; set; }
        public PaginationRule PaginationRule { get; set; }
    }
}
