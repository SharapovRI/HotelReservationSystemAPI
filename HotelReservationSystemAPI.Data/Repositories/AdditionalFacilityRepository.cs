using System.Linq;
using HotelReservationSystemAPI.Data.Interfaces;
using HotelReservationSystemAPI.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelReservationSystemAPI.Data.Repositories
{
    public class AdditionalFacilityRepository : Repository<AdditionalFacilityEntity>, IAdditionalFacilityRepository
    {
        public AdditionalFacilityRepository(NpgsqlContext npgsqlContext)
            : base(npgsqlContext)
        {

        }

        protected override IQueryable<AdditionalFacilityEntity> SetWithIncludes => _set
            .Include(p => p.FacilityCosts);
    }
}
