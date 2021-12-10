using System.Collections.Generic;
using System.Threading.Tasks;
using HotelReservationSystemAPI.Business.Models;
using HotelReservationSystemAPI.Business.Models.Response;

namespace HotelReservationSystemAPI.Business.Interfaces
{
    public interface IRoomTypeService
    {
        Task<RoomTypeResponseModel> CreateAsync(RoomTypeRequestModel roomTypeModel);

        Task<RoomTypeResponseModel> GetAsync(int id);

        Task<IEnumerable<RoomTypeResponseModel>> GetListAsync();

        Task<IEnumerable<RoomTypeResponseModel>> GetListAsync(int hotelId);

        Task UpdateAsync(RoomTypeRequestModel roomTypeModel);

        Task<RoomTypeResponseModel> DeleteAsync(int id);
    }
}