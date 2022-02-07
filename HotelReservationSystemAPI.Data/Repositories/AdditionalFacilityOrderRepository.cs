using System.Linq;
using HotelReservationSystemAPI.Data.Interfaces;
using HotelReservationSystemAPI.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelReservationSystemAPI.Data.Repositories
{
    public class AdditionalFacilityOrderRepository : Repository<AdditionalFacilityOrderEntity>, IAdditionalFacilityOrderRepository
    {
        public AdditionalFacilityOrderRepository(NpgsqlContext npgsqlContext)
            : base(npgsqlContext)
        {
            
        }

        protected override IQueryable<AdditionalFacilityOrderEntity> SetWithIncludes => _set
            .Include(p => p.AdditionFacility)
            .Include(p => p.Order).ThenInclude(p => p.OrderGroup);
    }
}
