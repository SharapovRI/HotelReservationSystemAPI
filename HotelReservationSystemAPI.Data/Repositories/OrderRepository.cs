using System.Linq;
using HotelReservationSystemAPI.Data.Interfaces;
using HotelReservationSystemAPI.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelReservationSystemAPI.Data.Repositories
{
    public class OrderRepository : Repository<OrderEntity>, IOrderRepository
    {
        public OrderRepository(NpgsqlContext npgsqlContext)
            : base(npgsqlContext)
        {

        }

        protected override IQueryable<OrderEntity> SetWithIncludes => _set
            .Include(p => p.Room).ThenInclude(p => p.Hotel)
            .Include(p => p.AdditionalFacilities)
            .Include(p => p.OrderGroup);
    }
}
