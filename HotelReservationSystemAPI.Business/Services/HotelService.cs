using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using HotelReservationSystemAPI.Business.Interfaces;
using HotelReservationSystemAPI.Business.Models;
using HotelReservationSystemAPI.Business.QueryModels;
using HotelReservationSystemAPI.Data.Interfaces;
using HotelReservationSystemAPI.Data.Models;
using HotelReservationSystemAPI.Data.Query;

namespace HotelReservationSystemAPI.Business.Services
{
    public class HotelService : IHotelService
    {
        private readonly IMapper _mapper;
        private readonly IHotelRepository _hotelRepository;
        private readonly IRoomService _roomService;

        public HotelService(IMapper mapper, IHotelRepository hotelRepository, IRoomService roomService)
        {
            _mapper = mapper;
            _hotelRepository = hotelRepository;
            _roomService = roomService;
        }

        public async Task<HotelModel> CreateAsync(HotelRequestModel hotelModel)
        {
            var rooms = hotelModel.Rooms;
            var hotel = _mapper.Map<HotelRequestModel, HotelEntity>(hotelModel);

            hotel = await _hotelRepository.CreateAsync(hotel);

            foreach (var room in rooms)
            {
                room.HotelId = hotel.Id;
                for (int i = 0; i < room.RoomCount; i++)
                {
                    await _roomService.CreateAsync(room);
                }
            }

            var createdEntity = _mapper.Map<HotelEntity, HotelModel>(hotel);

            return createdEntity;
        }

        public async Task<HotelModel> DeleteAsync(int id)
        {
            var hotel = _hotelRepository.DeleteAsync(id);

            return _mapper.Map<HotelEntity, HotelModel>(await hotel);
        }

        public async Task<HotelModel> GetAsync(int id)
        {
            var hotel = _hotelRepository.GetAsync(id);

            return _mapper.Map<HotelEntity, HotelModel>(await hotel);
        }

        public async Task<IEnumerable<HotelModel>> GetListAsync()
        {
            var hotels = _hotelRepository.GetListAsync();

            return _mapper.Map<IEnumerable<HotelEntity>, IEnumerable<HotelModel>>(await hotels);
        }

        public async Task UpdateAsync(HotelModel hotelModel)
        {
            var hotel = _mapper.Map<HotelModel, HotelEntity>(hotelModel);

            await _hotelRepository.Update(hotel);
        }
        
        public async Task<IList<HotelModel>> GetListAsync(HotelFreeSeatsQueryModel queryModel)
        {
            var queryParameters = GetQueryParameters(queryModel);

            var entities = await _hotelRepository.GetListAsync(queryParameters);

            return _mapper.Map<IList<HotelEntity>, IList<HotelModel>>(entities);
        }

        private QueryParameters<HotelEntity> GetQueryParameters(HotelFreeSeatsQueryModel model)
        {
            if (model == null)
                throw new ArgumentNullException($"{nameof(model)}");

            var queryParameters = new QueryParameters<HotelEntity>
            {
                FilterRule = GetFilterRule(model),
                PaginationRule = GetPageRule(model)
            };

            return queryParameters;
        }

        private FilterRule<HotelEntity> GetFilterRule(HotelFreeSeatsQueryModel model)
        {
            var filterRule = new FilterRule<HotelEntity>
            {
                FilterExpression = hotel =>
                    (hotel.CityId == model.Id) &&
                    (hotel.Rooms != null) &&
                    (hotel.Rooms.Where(room => room.Orders != null && room.Orders.AsQueryable().FirstOrDefault(time => time.CheckInTime > model.CheckIn && 
                    time.CheckInTime >= model.CheckOut || time.CheckOutTime <= model.CheckIn && time.CheckOutTime < model.CheckOut) != null))
                    .Sum(room => room.RoomType.SeatsCount) >= model.FreeSeatsCount
            };

            return filterRule;
        }

        private PaginationRule GetPageRule(HotelFreeSeatsQueryModel model)
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
