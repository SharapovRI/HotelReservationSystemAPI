using System.Linq;
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
    }
}