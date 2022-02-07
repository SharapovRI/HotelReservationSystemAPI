using System;
using System.Collections.Generic;
using System.Linq;
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
using HotelReservationSystemAPI.Data.Repositories;

namespace HotelReservationSystemAPI.Business.Services
{
    public class OrderService : IOrderService
    {
        private readonly IMapper _mapper;
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderGroupRepository _orderGroupRepository;
        private readonly IAdditionalFacilityOrderRepository _additionalFacilityOrderRepository;
        private readonly IRoomService _roomService;
        private readonly IAdditionalFacilityService _additionalFacilityService;
        public OrderService(IMapper mapper, IOrderRepository orderRepository, IRoomService roomService, 
            IAdditionalFacilityOrderRepository additionalFacilityOrderRepository, IOrderGroupRepository orderGroupRepository, IAdditionalFacilityService additionalFacilityService)
        {
            _mapper = mapper;
            _orderRepository = orderRepository;
            _additionalFacilityOrderRepository = additionalFacilityOrderRepository;
            _roomService = roomService;
            _orderGroupRepository = orderGroupRepository;
            _additionalFacilityService = additionalFacilityService;
        }

        public async Task<OrderResponseModel> CreateAsync(OrderModel orderModel, int groupId)
        {
            var validationParameters = await IsOrderValid(orderModel);

            if (!validationParameters)
                throw new BadRequest("Order is not valid.");
            

            var order = _mapper.Map<OrderModel, OrderEntity>(orderModel);
            order.OrderGroupId = groupId;

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

                _ = await _additionalFacilityOrderRepository.CreateAsync(facilityOrder);
            }

            var result = _mapper.Map<OrderEntity, OrderResponseModel>(createdOrder);

            return result;
        }

        public async Task<OrderGroupResponseModel> CreateGroupOrder(OrderGroupModel orderGroupModel)
        {
            var days = 0;
            for (var day = orderGroupModel.Orders.First().CheckInTime; day < orderGroupModel.Orders.First().CheckOutTime; day += TimeSpan.FromDays(1))
            {
                days++;
            }

            decimal totalCost = 0;

            foreach (var item in orderGroupModel.Orders)
            {
                totalCost += item.Cost;
            }

            if (totalCost * days != orderGroupModel.TotalCost)
                throw new BadRequest("Order is not valid");
             
            var orderGroup = _mapper.Map<OrderGroupModel, OrderGroupEntity>(orderGroupModel);
            orderGroup.Orders = null;
            var createdOrderGroup = await _orderGroupRepository.CreateAsync(orderGroup);

            List<OrderResponseModel> orderList = new List<OrderResponseModel>();


            foreach (var item in orderGroupModel.Orders)
            {
                orderList.Add(await CreateAsync(item, createdOrderGroup.Id));
            }

            var responseGroupModel = _mapper.Map<OrderGroupEntity, OrderGroupResponseModel>(createdOrderGroup);

            return responseGroupModel;
        }

        private async Task<bool> IsOrderValid(OrderModel orderModel)
        {
            if (orderModel == null)
                throw new ArgumentNullException($"{nameof(orderModel)}");
            
            var validationParameters = new OrderValidationParameters()
            {
                IsDateValid = await _roomService.IsDateValid(orderModel),
                IsFacilitiesValid = await  _additionalFacilityService.IsFacilitiesValid(orderModel),
                IsCostValid = await  _additionalFacilityService.IsCostValid(orderModel)
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

        public async Task<(IList<OrderGroupResponseModel>, int)> GetListAsync(OrderQueryModel queryModel)
        {
            var queryParameters = GetQueryParameters(queryModel);

            var (entities, pageCount) = await _orderGroupRepository.GetListAsync(queryParameters);

            return (_mapper.Map<IList<OrderGroupEntity>, IList<OrderGroupResponseModel>>(entities), pageCount);
        }

        public async Task UpdateArrivalTime(OrderTimeUpdateModel orderTimeUpdateModel)
        {
            var entity = await _orderRepository.GetAsync(orderTimeUpdateModel.Id);
            entity.CheckInTime = orderTimeUpdateModel.CheckInTime;
            _ = await _orderRepository.UpdateAsync(entity);
        }

        private QueryParameters<OrderGroupEntity> GetQueryParameters(OrderQueryModel model)
        {
            if (model == null)
                throw new ArgumentNullException($"{nameof(model)}");

            var queryParameters = new QueryParameters<OrderGroupEntity>
            {
                FilterRule = GetFilterRule(model),
                PaginationRule = GetPageRule(model)
            };

            return queryParameters;
        }

        private FilterRule<OrderGroupEntity> GetFilterRule(OrderQueryModel model)
        {
            var dateNow = DateTimeOffset.Now;
            var filterRule = new FilterRule<OrderGroupEntity>
            {
                FilterExpression = orderGroup =>
                    (
                        (orderGroup.PersonId == model.UserId) &&
                        (((model.CityId == null) && ((model.CountryId == null) || (orderGroup.Orders.First().Room.Hotel.CountryId == model.CountryId))) || (orderGroup.Orders.First().Room.Hotel.CityId == model.CityId)) &&
                        ((model.WhichTime == null) || (model.WhichTime == false && orderGroup.Orders.First().CheckInTime < dateNow) || 
                            (model.WhichTime == true && orderGroup.Orders.First().CheckInTime > dateNow)) &&
                        (string.IsNullOrWhiteSpace(model.HotelNamePart) || orderGroup.Orders.First().Room.Hotel.Name.Contains(model.HotelNamePart))
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
