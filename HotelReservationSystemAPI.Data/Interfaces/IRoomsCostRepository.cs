using System.Collections.Generic;
using System.Threading.Tasks;
using HotelReservationSystemAPI.Data.Models;

namespace HotelReservationSystemAPI.Data.Interfaces
{
    public interface IRoomsCostRepository:IRepository<RoomsCostEntity>
    {
        Task<IEnumerable<RoomsCostEntity>> GetListAsync(int hotelId);
    }
}