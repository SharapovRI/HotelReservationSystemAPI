using System.Linq;
using System.Threading.Tasks;
using HotelReservationSystemAPI.Data.Interfaces;
using HotelReservationSystemAPI.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelReservationSystemAPI.Data.Repositories
{
    public class RoomTypeRepository : Repository<RoomTypeEntity>, IRoomTypeRepository
    {
        public RoomTypeRepository(NpgsqlContext npgsqlContext)
            : base(npgsqlContext)
        {

        }

        protected override IQueryable<RoomTypeEntity> SetWithIncludes => _set
            .Include(p => p.RoomsCosts)
            .Include(p => p.Rooms);

        public async Task<RoomTypeEntity> GetRoomType(RoomTypeEntity entity)
        {
            var result = await SetWithIncludes.FirstOrDefaultAsync(p =>
                p.Name == entity.Name && p.SeatsCount == entity.SeatsCount);
            return result;
        }
    }
}