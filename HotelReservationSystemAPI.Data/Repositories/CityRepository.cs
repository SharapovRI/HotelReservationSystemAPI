using System.Linq;
using HotelReservationSystemAPI.Data.Interfaces;
using HotelReservationSystemAPI.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelReservationSystemAPI.Data.Repositories
{
    public class CityRepository : Repository<CityEntity>, ICityRepository
    {
        public CityRepository(NpgsqlContext npgsqlContext)
            : base(npgsqlContext)
        {

        }

        protected override IQueryable<CityEntity> SetWithIncludes => _set
            .Include(p => p.Country)
            .Include(p => p.Hotels);
    }
}
