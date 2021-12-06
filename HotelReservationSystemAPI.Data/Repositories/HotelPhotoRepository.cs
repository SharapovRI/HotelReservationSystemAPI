using System.Linq;
using System.Threading.Tasks;
using HotelReservationSystemAPI.Data.Interfaces;
using HotelReservationSystemAPI.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelReservationSystemAPI.Data.Repositories
{
    public class HotelPhotoRepository : Repository<HotelPhotoEntity>, IHotelPhotoRepository
    {
        public HotelPhotoRepository(NpgsqlContext npgsqlContext)
            : base(npgsqlContext)
        {

        }

        protected override IQueryable<HotelPhotoEntity> SetWithIncludes => _set;

        public async Task<HotelPhotoEntity> GetHotelPhoto(RoomPhotoEntity entity)
        {
            var result = await SetWithIncludes.FirstOrDefaultAsync(p =>
                p.Title == entity.Title && p.Extension == entity.Extension && p.Data == entity.Data);
            return result;
        }
    }
}
