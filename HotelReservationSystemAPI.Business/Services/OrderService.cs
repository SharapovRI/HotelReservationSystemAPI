using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using HotelReservationSystemAPI.Business.Exceptions;
using HotelReservationSystemAPI.Business.Interfaces;
using HotelReservationSystemAPI.Business.Models;
using HotelReservationSystemAPI.Business.Models.Request;
using HotelReservationSystemAPI.Business.Models.Response;
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

        public async Task<OrderResponseModel> CreateAsync(OrderModel orderModel)
        {
            var validationParameters = await IsOrderValid(orderModel);

            if (!validationParameters)
                throw new BadRequest("Order is not valid.");
            

            var order = _mapper.Map<OrderModel, OrderEntity>(orderModel);

            var createdOrder = await _orderRepository.CreateAsync(order);

            if (createdOrder == null)
                throw new SomethingWrong("Something went wrong!\nOrder is not created.");

            foreach (var orderModelAdditionalFacility in orderModel.AdditionalFacilities)
            {
                var facilityOrder = new AdditionalFacilityOrderEntity()
                {
                    OrderId = createdOrder.Id,
                    AdditionFacilityId = orderModelAdditionalFacility
                };

                await _additionalFacilityOrderRepository.CreateAsync(facilityOrder);
            }

            var result = _mapper.Map<OrderEntity, OrderResponseModel>(createdOrder);

            return result;
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

            if (order == null)
                throw new BadRequest("Order with this id doesn't exists.");

            return _mapper.Map<OrderEntity, OrderModel>(await order);
        }

        public async Task<OrderResponseModel> GetAsync(int id)
        {
            var order = _orderRepository.GetAsync(id);

            if (order == null)
                throw new BadRequest("Order with this id doesn't exists.");

            return _mapper.Map<OrderEntity, OrderResponseModel>(await order);
        }

        public async Task<(IEnumerable<OrderResponseModel>, int)> GetListAsync()
        {
            var (orders, pageCount) = await _orderRepository.GetListAsync();

            return (_mapper.Map<IEnumerable<OrderEntity>, IEnumerable<OrderResponseModel>>(orders), pageCount);
        }

        public async Task Update(OrderModel orderModel)
        {
            var order = _mapper.Map<OrderModel, OrderEntity>(orderModel);

            var entity = await _orderRepository.UpdateAsync(order);

            if (order == null)
                throw new BadRequest("Order with this id doesn't exists.");
        }

        public async Task<(IList<OrderResponseModel>, int)> GetListAsync(OrderQueryModel queryModel)
        {
            var queryParameters = GetQueryParameters(queryModel);

            var (entities, pageCount) = await _orderRepository.GetListAsync(queryParameters);

            return (_mapper.Map<IList<OrderEntity>, IList<OrderResponseModel>>(entities), pageCount);
        }

        public async Task UpdateArrivalTime(OrderTimeUpdateModel orderTimeUpdateModel)
        {
            var entity = await _orderRepository.GetAsync(orderTimeUpdateModel.Id);
            entity.CheckInTime = orderTimeUpdateModel.CheckInTime;
            _ = await _orderRepository.UpdateAsync(entity);
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
