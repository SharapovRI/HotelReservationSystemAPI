using System.Collections.Generic;
using System.Threading.Tasks;
using HotelReservationSystemAPI.Business.Models;
using HotelReservationSystemAPI.Business.QueryModels;

namespace HotelReservationSystemAPI.Business.Interfaces
{
    public interface IRoomService
    {
        Task CreateAsync(RoomRequestModel roomModel);
        Task<IList<RoomModel>> GetListAsync(FreeRoomsQueryModel queryModel);
        Task<bool> IsDateValid(OrderModel orderModel);
    }
}