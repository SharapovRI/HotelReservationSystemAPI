using HotelReservationSystemAPI.Data.Interfaces;
using HotelReservationSystemAPI.Data.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace HotelReservationSystemAPI.Data.Repositories
{
    public class AdditionalFacilityRepository : Repository<AdditionalFacilityEntity>, IAdditionalFacilityRepository
    {
        public AdditionalFacilityRepository(NpgsqlContext npgsqlContext)
            : base(npgsqlContext)
        {

        }

        protected override IQueryable<AdditionalFacilityEntity> SetWithIncludes => _set
            .Include(p => p.Hotel)
            .Include(p => p.FacilityOrders);
    }
}
