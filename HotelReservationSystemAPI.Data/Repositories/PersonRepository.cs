using System.Linq;
using HotelReservationSystemAPI.Data.Interfaces;
using HotelReservationSystemAPI.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelReservationSystemAPI.Data.Repositories
{
    public class PersonRepository : Repository<PersonEntity>, IPersonRepository
    {
        public PersonRepository(NpgsqlContext npgsqlContext)
            : base(npgsqlContext)
        {

        }

        protected override IQueryable<PersonEntity> SetWithIncludes => _set
            .Include(p => p.Orders)
            .Include(p => p.Role);
    }
}
