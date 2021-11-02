using HotelReservationSystemAPI.Data.Interfaces;
using HotelReservationSystemAPI.Data.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace HotelReservationSystemAPI.Data.Repositories
{
    public class FacilityCostRepository : Repository<FacilityCostEntity>, IFacilityCostRepository
    {
        public FacilityCostRepository(NpgsqlContext npgsqlContext)
            : base(npgsqlContext)
        {

        }

        protected override IQueryable<FacilityCostEntity> SetWithIncludes => _set
            .Include(p => p.AdditionalFacility)
            .Include(p => p.Hotel);
    }
}
