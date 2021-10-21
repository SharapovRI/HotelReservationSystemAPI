using HotelReservationSystemAPI.Data.Interfaces;
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