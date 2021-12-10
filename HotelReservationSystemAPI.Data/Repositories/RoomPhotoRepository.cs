using System.Linq;
using System.Threading.Tasks;
using HotelReservationSystemAPI.Data.Interfaces;
using HotelReservationSystemAPI.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelReservationSystemAPI.Data.Repositories
{
    public class RoomPhotoRepository : Repository<RoomPhotoEntity>, IRoomPhotoRepository
    {
        public RoomPhotoRepository(NpgsqlContext npgsqlContext)
            : base(npgsqlContext)
        {

        }

        protected override IQueryable<RoomPhotoEntity> SetWithIncludes => _set;

        public async Task<RoomPhotoEntity> GetRoomPhoto(RoomPhotoEntity entity)
        {
            var result = await SetWithIncludes.FirstOrDefaultAsync(p =>
                p.Title == entity.Title && p.Extension == entity.Extension && p.Data == entity.Data);
            return result;
        }
    }
}
