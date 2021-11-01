using HotelReservationSystemAPI.Data.Interfaces;

namespace HotelReservationSystemAPI.Data.Query
{
    public class QueryParameters<TEntity> where TEntity : class, IEntity
    {
        public FilterRule<TEntity> FilterRule { get; set; }
        public PaginationRule PaginationRule { get; set; }
    }
}
