﻿using System.Collections.Generic;
using System.Threading.Tasks;
using HotelReservationSystemAPI.Business.Models;

namespace HotelReservationSystemAPI.Business.Interfaces
{
    public interface IOrderService
    {
        Task CreateAsync(OrderModel orderModel);
        Task<OrderModel> GetAsync(int id);
        Task<IEnumerable<OrderModel>> GetListAsync();
        Task Update(OrderModel orderModel);
        Task<OrderModel> DeleteAsync(int id);
    }
}