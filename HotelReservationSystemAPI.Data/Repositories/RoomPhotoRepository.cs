using System.Linq;
using HotelReservationSystemAPI.Data.Interfaces;
using HotelReservationSystemAPI.Data.Models;

namespace HotelReservationSystemAPI.Data.Repositories
{
    public class RoomPhotoRepository : Repository<RoomPhotoEntity>, IRoomPhotoRepository
    {
        public RoomPhotoRepository(NpgsqlContext npgsqlContext)
            : base(npgsqlContext)
        {

        }

        protected override IQueryable<RoomPhotoEntity> SetWithIncludes => _set;
    }
}
