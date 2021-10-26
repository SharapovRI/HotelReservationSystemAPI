using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using HotelReservationSystemAPI.Business.Interfaces;
using HotelReservationSystemAPI.Business.Models;
using HotelReservationSystemAPI.Business.Validation;
using HotelReservationSystemAPI.Data.Interfaces;
using HotelReservationSystemAPI.Data.Models;

namespace HotelReservationSystemAPI.Business.Services
{
    public class OrderService : IOrderService
    {
        public OrderService(IMapper mapper, IOrderRepository orderRepository, IRoomService roomService, IFacilityCostService facilityCostService)
        {
            _mapper = mapper;
            _orderRepository = orderRepository;
            _roomService = roomService;
            _facilityCostService = facilityCostService;
        }

        private readonly IMapper _mapper;
        private readonly IOrderRepository _orderRepository;
        private readonly IRoomService _roomService;
        private readonly IFacilityCostService _facilityCostService;

        public async Task<OrderModel> CreateAsync(OrderModel orderModel)
        {
            var validationParameters = await IsOrderValid(orderModel);

            if (!validationParameters)
            {
                throw new Exception(); //TODO complete exception
            }


            var order = _mapper.Map<OrderModel, OrderEntity>(orderModel);

            await _orderRepository.CreateAsync(order);

            return orderModel;
        }

        private async Task<bool> IsOrderValid(OrderModel orderModel)
        {
            if (orderModel == null)
                throw new ArgumentNullException($"{nameof(orderModel)}");

            var validationParameters = new OrderValidationParameters()
            {
                IsDateValid = await _roomService.IsDateValid(orderModel),
                IsFacilitiesValid = await  _facilityCostService.IsFacilitiesValid(orderModel)
            };

            return validationParameters.IsValid;
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
