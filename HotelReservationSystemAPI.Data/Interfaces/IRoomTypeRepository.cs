using System.Threading.Tasks;
using HotelReservationSystemAPI.Data.Models;

namespace HotelReservationSystemAPI.Data.Interfaces
{
    public interface IRoomTypeRepository : IRepository<RoomTypeEntity>
    {
        Task<RoomTypeEntity> GetRoomType(RoomTypeEntity entity);
    }
}