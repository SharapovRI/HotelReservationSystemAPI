using System.Linq;
using HotelReservationSystemAPI.Data.Interfaces;
using HotelReservationSystemAPI.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelReservationSystemAPI.Data.Repositories
{
    public class RoleRepository : Repository<RoleEntity>, IRoleRepository
    {
        public RoleRepository(NpgsqlContext npgsqlContext)
            : base(npgsqlContext)
        {

        }

        protected override IQueryable<RoleEntity> SetWithIncludes => _set
            .Include(p => p.Persons);
    }
}
