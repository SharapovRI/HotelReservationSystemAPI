using System.Collections.Generic;
using System.Threading.Tasks;
using HotelReservationSystemAPI.Business.Models;
using HotelReservationSystemAPI.Business.QueryModels;
using HotelReservationSystemAPI.Data.Models;

namespace HotelReservationSystemAPI.Business.Interfaces
{
    public interface IRoomService
    {
        Task<RoomEntity> CreateAsync(RoomRequestModel roomModel);

        Task<RoomModel> GetRoom(int id);

        Task UpdateAsync(RoomModel roomModel);

        Task<(IList<RoomModel>, int)> GetListAsync(FreeRoomsQueryModel queryModel);

        Task<bool> IsDateValid(OrderModel orderModel);
    }
}