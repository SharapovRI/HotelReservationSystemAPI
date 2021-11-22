using System.Linq;
using HotelReservationSystemAPI.Data.Interfaces;
using HotelReservationSystemAPI.Data.Models;

namespace HotelReservationSystemAPI.Data.Repositories
{
    public class PhotoRepository : Repository<PhotoEntity>, IPhotoRepository
    {
        public PhotoRepository(NpgsqlContext npgsqlContext)
            : base(npgsqlContext)
        {

        }

        protected override IQueryable<PhotoEntity> SetWithIncludes => _set;
    }
}
