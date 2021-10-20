using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using HotelReservationSystemAPI.Data.Models;

namespace HotelReservationSystemAPI.Data.Query
{
    public class FilterRule<TEntity> where TEntity : IEntity
    {
        public Expression<Func<TEntity, bool>> FilterExpression { get; set; }
    }
}
