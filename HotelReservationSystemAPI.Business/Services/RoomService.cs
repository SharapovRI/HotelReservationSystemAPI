using HotelReservationSystemAPI.Business.Interfaces;
using HotelReservationSystemAPI.Business.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using HotelReservationSystemAPI.Business.QueryModels;
using HotelReservationSystemAPI.Data.Interfaces;
using HotelReservationSystemAPI.Data.Models;
using HotelReservationSystemAPI.Data.Query;
using System;
using System.Linq;

namespace HotelReservationSystemAPI.Business.Services
{
    public class RoomService : IRoomService
    {
        public RoomService(IMapper mapper, IRoomRepository roomRepository)
        {
            _mapper = mapper;
            _roomRepository = roomRepository;
        }

        private readonly IMapper _mapper;
        private readonly IRoomRepository _roomRepository;

        public async Task<IList<RoomModel>> GetListAsync(FreeRoomsQueryModel queryModel)
        {
            var queryParameters = GetQueryParameters(queryModel);

            var entities = await _roomRepository.GetListAsync(queryParameters);

            return _mapper.Map<IList<RoomEntity>, IList<RoomModel>>(entities);
        }

        private QueryParameters<RoomEntity> GetQueryParameters(FreeRoomsQueryModel model)
        {
            if (model == null)
                throw new ArgumentNullException($"{nameof(model)}");

            var queryParameters = new QueryParameters<RoomEntity>
            {
                FilterRule = GetFilterRule(model),
                PaginationRule = GetPageRule(model)
            };

            return queryParameters;
        }

        private FilterRule<RoomEntity> GetFilterRule(FreeRoomsQueryModel model)
        {
            var filterRule = new FilterRule<RoomEntity>
            {
                FilterExpression = room =>
                    room.HotelId == model.HotelId &&
                    room.Orders != null && room.Orders.AsQueryable().FirstOrDefault(time => time.CheckInTime > model.CheckIn &&
                        time.CheckInTime >= model.CheckOut || time.CheckOutTime <= model.CheckIn && time.CheckOutTime < model.CheckOut) != null
            };

            return filterRule;
        }

        private PaginationRule GetPageRule(FreeRoomsQueryModel model)
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