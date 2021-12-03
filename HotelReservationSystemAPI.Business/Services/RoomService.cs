using AutoMapper;
using HotelReservationSystemAPI.Business.Interfaces;
using HotelReservationSystemAPI.Business.Models;
using HotelReservationSystemAPI.Business.QueryModels;
using HotelReservationSystemAPI.Data.Interfaces;
using HotelReservationSystemAPI.Data.Models;
using HotelReservationSystemAPI.Data.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelReservationSystemAPI.Business.Exceptions;
using HotelReservationSystemAPI.Business.Models.Request;
using HotelReservationSystemAPI.Business.Models.Response;

namespace HotelReservationSystemAPI.Business.Services
{
    public class RoomService : IRoomService
    {
        private readonly IMapper _mapper;
        private readonly IRoomPhotoService _roomPhotoService;
        private readonly IRoomRepository _roomRepository;
        private readonly IRoomTypeService _roomTypeService;

        public RoomService(IMapper mapper, IRoomPhotoService roomPhotoService, IRoomRepository roomRepository, IRoomTypeService roomTypeService)
        {
            _mapper = mapper;
            _roomPhotoService = roomPhotoService;
            _roomRepository = roomRepository;
            _roomTypeService = roomTypeService;
        }

        public async Task<RoomEntity> CreateAsync(RoomCreationRangeModel roomModel)
        {
            var roomType = new RoomTypeModel()
            {
                HotelId = (int) roomModel.HotelId,
                Name = roomModel.TypeName,
                SeatsCount = roomModel.SeatsCount,
                Cost = roomModel.Cost
            };

            roomType = _roomTypeService.CreateAsync(roomType).Result;
            roomModel.TypeId = roomType.RoomTypeId;

            var room = _mapper.Map<RoomCreationRangeModel, RoomEntity>(roomModel);

            var entity = await _roomRepository.CreateAsync(room);

            if (entity == null)
                throw new SomethingWrong("Something went wrong!\nRoom is not created.");

            var roomPhotos = await _roomPhotoService.CreateAsync(roomModel.RoomPhotos);
            var roomPhotosIds = roomPhotos.RoomPhotos.Select(p => p.Id).ToArray();
            
            await _roomPhotoService.CreateLinksAsync(entity.Id, roomPhotosIds);

            return entity;
        }

        public async Task<RoomModel> GetRoom(int id, int hotelId)
        {
            var room = await _roomRepository.GetAsync(id);

            if (room == null)
                throw new BadRequest("Room with this id doesn't exists.");

            if (room.HotelId != hotelId)
                throw new BadRequest("Room with this id doesn't exists in this hotel.");

            return _mapper.Map<RoomEntity, RoomModel>(room);
        }

        public async Task UpdateAsync(RoomUpdateModel roomModel)
        {
            var room = await _roomRepository.GetAsync(roomModel.Id);
            room.TypeId = room.TypeId;

            var entity = await _roomRepository.UpdateAsync(room);

            if (entity == null)
                throw new BadRequest("This room doesn't exists.");

            if (roomModel.RoomPhotos != null)
            {
                await _roomPhotoService.UpdatePhotos(entity.Id, roomModel.RoomPhotos);
            }
        }

        public async Task<(IList<RoomModel>, int)> GetListAsync(FreeRoomsQueryModel queryModel)
        {
            var queryParameters = GetQueryParameters(queryModel);

            var (entities, pageCount) = await _roomRepository.GetListAsync(queryParameters);

            return (_mapper.Map<IList<RoomEntity>, IList<RoomModel>>(entities), pageCount);
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
                    (room.Orders == null || room.Orders != null 
                        && !room.Orders.AsQueryable().Any(time => 
                            (time.CheckInTime < model.CheckIn ? model.CheckIn : time.CheckInTime) < (time.CheckOutTime < model.CheckOut ? time.CheckOutTime : model.CheckOut)))
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

        public async Task<bool> IsDateValid(OrderModel orderModel)
        {
            var room = await _roomRepository.GetAsync(orderModel.RoomId);

            var isValid = room != null && !room.Orders.AsQueryable().Any(time => 
                (time.CheckInTime < orderModel.CheckInTime ? orderModel.CheckInTime : time.CheckInTime) < 
                (time.CheckOutTime < orderModel.CheckOutTime ? time.CheckOutTime : orderModel.CheckOutTime));

            return isValid;
        }
        
    }
}