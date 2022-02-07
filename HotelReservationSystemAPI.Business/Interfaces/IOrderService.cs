using System.Collections.Generic;
using System.Threading.Tasks;
using HotelReservationSystemAPI.Business.Models;
using HotelReservationSystemAPI.Business.Models.Request;
using HotelReservationSystemAPI.Business.Models.Response;
using HotelReservationSystemAPI.Business.QueryModels;

namespace HotelReservationSystemAPI.Business.Interfaces
{
    public interface IOrderService
    {
        Task<OrderResponseModel> CreateAsync(OrderModel orderModel, int groupId);

        Task<OrderResponseModel> GetAsync(int id);

        Task<(IEnumerable<OrderResponseModel>, int)> GetListAsync();

        Task Update(OrderModel orderModel);

        Task UpdateArrivalTime(OrderTimeUpdateModel orderTimeUpdateModel);

        Task<OrderModel> DeleteAsync(int id);

        Task<(IList<OrderGroupResponseModel>, int)> GetListAsync(OrderQueryModel queryModel);

        Task<OrderGroupResponseModel> CreateGroupOrder(OrderGroupModel orderGroupModel);
    }
}