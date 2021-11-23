using System.Linq;
using HotelReservationSystemAPI.Data.Interfaces;
using HotelReservationSystemAPI.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelReservationSystemAPI.Data.Repositories
{
    public class RoomPhotoLinksRepository : Repository<RoomPhotoLinksEntity>, IRoomPhotoLinksRepository
    {
        public RoomPhotoLinksRepository(NpgsqlContext npgsqlContext)
            : base(npgsqlContext)
        {

        }

        protected override IQueryable<RoomPhotoLinksEntity> SetWithIncludes => _set
            .Include(p => p.Room)
            .Include(p => p.RoomPhoto);
    }
}