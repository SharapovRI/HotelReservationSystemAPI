using HotelReservationSystemAPI.Data.IRepositories;
using HotelReservationSystemAPI.Data.Models;

namespace HotelReservationSystemAPI.Data.Repositories
{
    public class RoomTypeRepository : Repository<RoomTypeEntity>, IRoomTypeRepository
    {
        public RoomTypeRepository(NpgsqlContext npgsqlContext)
            : base(npgsqlContext)
        {

        }
    }
}