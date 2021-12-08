using System.Linq;
using HotelReservationSystemAPI.Data.Interfaces;
using HotelReservationSystemAPI.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelReservationSystemAPI.Data.Repositories
{
    public class RoomRepository : Repository<RoomEntity>, IRoomRepository
    {
        public RoomRepository(NpgsqlContext npgsqlContext)
            : base(npgsqlContext)
        {

        }

        protected override IQueryable<RoomEntity> SetWithIncludes => _set
            .Include(p => p.Hotel)
            .Include(p => p.Orders)
            .Include(p => p.RoomType)
            .Include(p => p.PhotoLinks).ThenInclude(p => p.RoomPhoto);
    }
}
