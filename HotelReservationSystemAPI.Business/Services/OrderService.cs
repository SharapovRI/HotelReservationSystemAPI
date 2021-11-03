using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using HotelReservationSystemAPI.Business.Interfaces;
using HotelReservationSystemAPI.Business.Models;
using HotelReservationSystemAPI.Business.QueryModels;
using HotelReservationSystemAPI.Business.Validation;
using HotelReservationSystemAPI.Data.Interfaces;
using HotelReservationSystemAPI.Data.Models;
using HotelReservationSystemAPI.Data.Query;

namespace HotelReservationSystemAPI.Business.Services
{
    public class OrderService : IOrderService
    {
        private readonly IMapper _mapper;
        private readonly IOrderRepository _orderRepository;
        private readonly IAdditionalFacilityOrderRepository _additionalFacilityOrderRepository;
        private readonly IRoomService _roomService;
        private readonly IFacilityCostService _facilityCostService;
        public OrderService(IMapper mapper, IOrderRepository orderRepository, IRoomService roomService, IFacilityCostService facilityCostService, IAdditionalFacilityOrderRepository additionalFacilityOrderRepository)
        {
            _mapper = mapper;
            _orderRepository = orderRepository;
            _additionalFacilityOrderRepository = additionalFacilityOrderRepository;
            _roomService = roomService;
            _facilityCostService = facilityCostService;
        }

        public async Task<OrderModel> CreateAsync(OrderModel orderModel)
        {
            var validationParameters = await IsOrderValid(orderModel);

            if (!validationParameters)
            {
                throw new Exception(); //TODO complete exception
            }

            var order = _mapper.Map<OrderModel, OrderEntity>(orderModel);

            var createdOrder = await _orderRepository.CreateAsync(order);

            foreach (var orderModelAdditionalFacility in orderModel.AdditionalFacilities)
            {
                var facilityOrder = new AdditionalFacilityOrderEntity()
                {
                    OrderId = createdOrder.Id,
                    AdditionFacilityId = orderModelAdditionalFacility
                };

                await _additionalFacilityOrderRepository.CreateAsync(facilityOrder);
            }

            return orderModel;
        }

        private async Task<bool> IsOrderValid(OrderModel orderModel)
        {
            if (orderModel == null)
                throw new ArgumentNullException($"{nameof(orderModel)}");
            
            var validationParameters = new OrderValidationParameters()
            {
                IsDateValid = await _roomService.IsDateValid(orderModel),
                IsFacilitiesValid = await  _facilityCostService.IsFacilitiesValid(orderModel),
                IsCostValid = await  _facilityCostService.IsCostValid(orderModel)
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

        public async Task<IList<OrderModel>> GetListAsync(OrderQueryModel queryModel)
        {
            var queryParameters = GetQueryParameters(queryModel);

            var entities = await _orderRepository.GetListAsync(queryParameters);

            return _mapper.Map<IList<OrderEntity>, IList<OrderModel>>(entities);
        }

        private QueryParameters<OrderEntity> GetQueryParameters(OrderQueryModel model)
        {
            if (model == null)
                throw new ArgumentNullException($"{nameof(model)}");

            var queryParameters = new QueryParameters<OrderEntity>
            {
                FilterRule = GetFilterRule(model),
                PaginationRule = GetPageRule(model)
            };

            return queryParameters;
        }

        private FilterRule<OrderEntity> GetFilterRule(OrderQueryModel model)
        {
            var dateNow = DateTimeOffset.Now;
            var filterRule = new FilterRule<OrderEntity>
            {
                FilterExpression = order =>
                    (
                        (order.PersonId == model.UserId) &&
                        (((model.CityId == null) && ((model.CountryId == null) || (order.Room.Hotel.CountryId == model.CountryId))) || (order.Room.Hotel.CityId == model.CityId)) &&
                        ((model.WhichTime == null) || (model.WhichTime == false && order.CheckInTime < dateNow) || 
                            (model.WhichTime == true && order.CheckInTime > dateNow))
                    )
            };

            return filterRule;
        }

        private PaginationRule GetPageRule(OrderQueryModel model)
        {
            var pageRule = new PaginationRule();

            if (!model.IsValidPageModel)
                return pageRule;

            pageRule.Index = model.Index;
            pageRule.Size = model.Size;

            return pageRule;
        }
    }
}
