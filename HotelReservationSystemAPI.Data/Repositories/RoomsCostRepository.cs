using HotelReservationSystemAPI.Data.IRepositories;
using HotelReservationSystemAPI.Data.Models;

namespace HotelReservationSystemAPI.Data.Repositories
{
    public class RoomsCostRepository: Repository<RoomsCostEntity>, IRoomsCostRepository
    {
        public RoomsCostRepository(NpgsqlContext npgsqlContext)
            : base(npgsqlContext)
        {

        }
    }
}