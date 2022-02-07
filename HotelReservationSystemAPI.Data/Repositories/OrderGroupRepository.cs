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
            .Include(p => p.Orders).ThenInclude(p => p.Room).ThenInclude(p => p.Hotel)
            .Include(p => p.Orders).ThenInclude(p => p.AdditionalFacilities).ThenInclude(p => p.AdditionFacility)
            .Include(p => p.Person);
    }
}
