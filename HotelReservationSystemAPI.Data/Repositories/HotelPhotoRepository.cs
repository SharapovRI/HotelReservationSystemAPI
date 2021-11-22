using System.Linq;
using HotelReservationSystemAPI.Data.Interfaces;
using HotelReservationSystemAPI.Data.Models;

namespace HotelReservationSystemAPI.Data.Repositories
{
    public class HotelPhotoRepository : Repository<HotelPhotoEntity>, IHotelPhotoRepository
    {
    public HotelPhotoRepository(NpgsqlContext npgsqlContext)
        : base(npgsqlContext)
    {

    }

    protected override IQueryable<HotelPhotoEntity> SetWithIncludes => _set;
    }
}
