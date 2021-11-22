using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using HotelReservationSystemAPI.Business.Exceptions;
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
        private readonly IHotelPhotoService _hotelPhotoService;

        public HotelService(IMapper mapper, IHotelRepository hotelRepository, IRoomService roomService, IHotelPhotoService hotelPhotoService)
        {
            _mapper = mapper;
            _hotelRepository = hotelRepository;
            _roomService = roomService;
            _hotelPhotoService = hotelPhotoService;
        }

        public async Task<HotelModel> CreateAsync(HotelRequestModel hotelModel)
        {
            var rooms = hotelModel.Rooms;
            var hotel = _mapper.Map<HotelRequestModel, HotelEntity>(hotelModel);

            hotel = await _hotelRepository.CreateAsync(hotel);

            if (hotel == null)
                throw new SomethingWrong("Something went wrong!\nHotel is not created.");

            var photos = hotel.Photos;
            foreach (var photo in photos)
            {
                await _hotelPhotoService.CreateAsync(photo);
            }

            foreach (var room in rooms)
            {
                room.HotelId = hotel.Id;
                for (int i = 0; i < room.RoomCount; i++)
                {
                    var entity = await _roomService.CreateAsync(room);
                }
            }

            var createdEntity = _mapper.Map<HotelEntity, HotelModel>(hotel);

            return createdEntity;
        }

        public async Task<HotelModel> DeleteAsync(int id)
        {
            var hotel = _hotelRepository.DeleteAsync(id);

            if (hotel == null)
                throw new BadRequest("Hotel with this id doesn't exists.");

            return _mapper.Map<HotelEntity, HotelModel>(await hotel);
        }

        public async Task<HotelModel> GetAsync(int id)
        {
            var hotel = await _hotelRepository.GetAsync(id);

            if (hotel == null)
                throw new BadRequest("Hotel with this id doesn't exists.");

            return _mapper.Map<HotelEntity, HotelModel>(hotel);
        }

        public async Task<IEnumerable<HotelModel>> GetListAsync()
        {
            var (hotels, pageCount) = await _hotelRepository.GetListAsync();

            return _mapper.Map<IEnumerable<HotelEntity>, IEnumerable<HotelModel>>(hotels);
        }

        public async Task UpdateAsync(HotelModel hotelModel)
        {
            var hotel = _mapper.Map<HotelModel, HotelEntity>(hotelModel);

            var entity = await _hotelRepository.UpdateAsync(hotel);

            if (entity == null)
                throw new BadRequest("Hotel with this id doesn't exists.");

            var photos = hotel.Photos;

            foreach (var photo in photos)
            {
                await _hotelPhotoService.UpdateAsync(photo);
            }
        }
        
        public async Task<(IList<HotelModel>, int)> GetListAsync(HotelFreeSeatsQueryModel queryModel)
        {
            var queryParameters = GetQueryParameters(queryModel);

            var (entities, pageCount) = await _hotelRepository.GetListAsync(queryParameters);

            return (_mapper.Map<IList<HotelEntity>, IList<HotelModel>>(entities), pageCount);
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
                    ((model.Id == null) ||
                    (hotel.CityId == model.Id)) &&
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
