using HotelReservationSystemAPI.Data.IRepositories;
using HotelReservationSystemAPI.Data.Models;

namespace HotelReservationSystemAPI.Data.Repositories
{
    public class HotelRepository : Repository<HotelEntity>, IHotelRepository
    {
        public HotelRepository(NpgsqlContext npgsqlContext)
            : base(npgsqlContext)
        {

        }
    }
}
