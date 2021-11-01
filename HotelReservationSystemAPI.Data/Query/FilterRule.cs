using System;
using System.Linq.Expressions;
using HotelReservationSystemAPI.Data.Models;

namespace HotelReservationSystemAPI.Data.Query
{
    public class FilterRule<TEntity> where TEntity : IEntity
    {
        public Expression<Func<TEntity, bool>> FilterExpression { get; set; }

        public bool IsValid => FilterExpression != null;
    }
}
