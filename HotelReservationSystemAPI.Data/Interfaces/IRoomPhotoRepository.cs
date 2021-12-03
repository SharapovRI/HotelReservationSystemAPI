using System.Threading.Tasks;
using HotelReservationSystemAPI.Data.Models;

namespace HotelReservationSystemAPI.Data.Interfaces
{
    public interface IRoomPhotoRepository : IRepository<RoomPhotoEntity>
    {
        Task<RoomPhotoEntity> GetRoomPhoto(RoomPhotoEntity entity);
    }
}