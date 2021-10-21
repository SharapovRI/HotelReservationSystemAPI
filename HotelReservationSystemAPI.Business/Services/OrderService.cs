using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using HotelReservationSystemAPI.Business.Interfaces;
using HotelReservationSystemAPI.Business.Models;
using HotelReservationSystemAPI.Data.Interfaces;
using HotelReservationSystemAPI.Data.Models;

namespace HotelReservationSystemAPI.Business.Services
{
    public class OrderService : IOrderService
    {
        public OrderService(IMapper mapper, IOrderRepository orderRepository)
        {
            _mapper = mapper;
            _orderRepository = orderRepository;
        }

        private readonly IMapper _mapper;
        private readonly IOrderRepository _orderRepository;

        public async Task CreateAsync(OrderModel orderModel)
        {
            var order = _mapper.Map<OrderModel, OrderEntity>(orderModel);

            await _orderRepository.CreateAsync(order);
        }

        public async Task<OrderModel> DeleteAsync(int id)
        {
            var order = _orderRepository.DeleteAsync(id);

            return _mapper.Map<OrderEntity, OrderModel>(await order);
        }

        public async Task<OrderModel> GetAsync(int id)
        {
            var order = _orderRepository.GetAsync(id);

            return _mapper.Map<OrderEntity, OrderModel>(await order);
        }

        public async Task<IEnumerable<OrderModel>> GetListAsync()
        {
            var orders = _orderRepository.GetListAsync();

            return _mapper.Map<IEnumerable<OrderEntity>, IEnumerable<OrderModel>>(await orders);
        }

        public async Task Update(OrderModel orderModel)
        {
            var order = _mapper.Map<OrderModel, OrderEntity>(orderModel);

            await _orderRepository.Update(order);
        }
    }
}
