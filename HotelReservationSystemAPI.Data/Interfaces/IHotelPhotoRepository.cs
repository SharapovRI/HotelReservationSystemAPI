using System.Threading.Tasks;
using HotelReservationSystemAPI.Data.Models;

namespace HotelReservationSystemAPI.Data.Interfaces
{
    public interface IHotelPhotoRepository : IRepository<HotelPhotoEntity>
    {
        Task<HotelPhotoEntity> GetHotelPhoto(RoomPhotoEntity entity);
    }
}