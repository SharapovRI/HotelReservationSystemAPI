using System.Collections.Generic;
using System.Threading.Tasks;
using HotelReservationSystemAPI.Business.Models;
using HotelReservationSystemAPI.Business.Models.Request;
using HotelReservationSystemAPI.Business.Models.Response;
using HotelReservationSystemAPI.Business.QueryModels;
using HotelReservationSystemAPI.Data.Models;

namespace HotelReservationSystemAPI.Business.Interfaces
{
    public interface IRoomService
    {
        Task<RoomEntity> CreateAsync(RoomCreationRangeModel roomModel);

        Task<RoomModel> GetRoom(int id, int hotelId);

        Task UpdateAsync(RoomUpdateModel roomModel);

        Task<(IList<RoomModel>, int)> GetListAsync(FreeRoomsQueryModel queryModel);

        Task<bool> IsDateValid(OrderModel orderModel);
    }
}