using System.Collections.Generic;
using System.Threading.Tasks;
using HotelReservationSystemAPI.Business.Models;
using HotelReservationSystemAPI.Business.QueryModels;

namespace HotelReservationSystemAPI.Business.Interfaces
{
    public interface IOrderService
    {
        Task<OrderModel> CreateAsync(OrderModel orderModel);

        Task<OrderModel> GetAsync(int id);

        Task<(IEnumerable<OrderModel>, int)> GetListAsync();

        Task Update(OrderModel orderModel);

        Task<OrderModel> DeleteAsync(int id);

        Task<(IList<OrderModel>, int)> GetListAsync(OrderQueryModel queryModel);
    }
}