using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelReservationSystemAPI.Data.Interfaces;
using HotelReservationSystemAPI.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelReservationSystemAPI.Data.Repositories
{
    public class RoomsCostRepository : Repository<RoomsCostEntity>, IRoomsCostRepository
    {
        public RoomsCostRepository(NpgsqlContext npgsqlContext)
            : base(npgsqlContext)
        {

        }

        public async Task<IEnumerable<RoomsCostEntity>> GetListAsync(int hotelId)
        {
            return await SetWithIncludes.Where(roomCost => roomCost.HotelId == hotelId).ToListAsync();
        }

        protected override IQueryable<RoomsCostEntity> SetWithIncludes => _set
            .Include(p => p.Hotel)
            .Include(p => p.RoomType);
    }
}