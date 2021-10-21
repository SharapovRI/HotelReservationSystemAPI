using HotelReservationSystemAPI.Data.IRepositories;
using HotelReservationSystemAPI.Data.Models;

namespace HotelReservationSystemAPI.Data.Repositories
{
    public class OrderRepository : Repository<OrderEntity>, IOrderRepository
    {
        public OrderRepository(NpgsqlContext npgsqlContext)
            : base(npgsqlContext)
        {

        }
    }
}
