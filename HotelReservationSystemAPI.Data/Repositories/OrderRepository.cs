using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using HotelReservationSystemAPI.Data.IRepositories;
using HotelReservationSystemAPI.Data.Models;

namespace HotelReservationSystemAPI.Data.Repositories
{
    public class OrderRepository : Repository<OrderEntity>, IOrderRepository
    {
    }
}
