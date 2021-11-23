using System.Linq;
using HotelReservationSystemAPI.Data.Interfaces;
using HotelReservationSystemAPI.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelReservationSystemAPI.Data.Repositories
{
    public class HotelRepository : Repository<HotelEntity>, IHotelRepository
    {
        public HotelRepository(NpgsqlContext npgsqlContext)
            : base(npgsqlContext)
        {

        }

        protected override IQueryable<HotelEntity> SetWithIncludes => _set
            .Include(p => p.Rooms).ThenInclude(p => p.Orders)
            .Include(p => p.RoomsCosts)
            .Include(p => p.City)
            .Include(p => p.Country)
            .Include(p => p.Photos);
    }
}
