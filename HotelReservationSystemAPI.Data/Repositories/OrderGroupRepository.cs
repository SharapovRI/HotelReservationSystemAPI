using HotelReservationSystemAPI.Data.Interfaces;
using HotelReservationSystemAPI.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace HotelReservationSystemAPI.Data.Repositories
{
    public class OrderGroupRepository : Repository<OrderGroupEntity>, IOrderGroupRepository
    {
        public OrderGroupRepository(NpgsqlContext npgsqlContext)
            : base(npgsqlContext)
        {

        }

        protected override IQueryable<OrderGroupEntity> SetWithIncludes => _set
            .Include(p => p.Orders)
            .Include(p => p.Person);
    }
}
