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
            if (roomModel.TypeId == -1)
            {
                var roomTypeRequest = new RoomTypeRequestModel()
                {
                    HotelId = (int)roomModel.HotelId,
                    Name = roomModel.TypeName,
                    SeatsCount = roomModel.SeatsCount,
                    Cost = roomModel.Cost
                };

                var roomTypeResponse = await _roomTypeService.CreateAsync(roomTypeRequest);
                roomModel.TypeId = roomTypeResponse.RoomTypeId;
            }

            var room = _mapper.Map<RoomCreationRangeModel, RoomEntity>(roomModel);

            var entity = await _roomRepository.CreateAsync(room);

            if (entity == null)
                throw new SomethingWrong("Something went wrong!\nRoom is not created.");

            var roomPhotos = await _roomPhotoService.CreateAsync(roomModel.RoomPhotos);
            var roomPhotosIds = roomPhotos.RoomPhotos.Select(p => p.Id).ToArray();
            
            await _roomPhotoService.CreateLinksAsync(entity.Id, roomPhotosIds);

            return entity;
        }

        public async Task<(RoomModel, int)> GetRoom(int id)
        {
            var room = await _roomRepository.GetAsync(id);

            if (room == null)
                throw new BadRequest("Room with this id doesn't exists.");

            return (_mapper.Map<RoomEntity, RoomModel>(room), room.HotelId);
        }

        public async Task<(List<RoomModel>, int)> GetRoomsRange(int[] ids)
        {
            List<RoomModel> roomList = new List<RoomModel>();
            int hotelId = -1;
            foreach (var id in ids)
            {
                var (room, hotel_Id) = await GetRoom(id);
                roomList.Add(room);

                if(hotelId != -1 && hotelId != hotel_Id)
                {
                    throw new BadRequest("Rooms from different hotels");
                }

                hotelId = hotel_Id;
            }

            return (roomList, hotelId);
        }

        public async Task UpdateAsync(RoomUpdateModel roomModel)
        {
            var types = await _roomTypeService.GetListAsync(roomModel.HotelId);
            var type = types.FirstOrDefault(p =>
                p.Name == roomModel.TypeName && p.Cost == roomModel.Cost && p.SeatsCount == roomModel.SeatsCount);

            RoomTypeResponseModel createdType;
            if (type == null)
            {
                var roomTypeRequest = new RoomTypeRequestModel()
                {
                    HotelId = (int) roomModel.HotelId,
                    Name = roomModel.TypeName,
                    SeatsCount = roomModel.SeatsCount,
                    Cost = roomModel.Cost
                };

                createdType = await _roomTypeService.CreateAsync(roomTypeRequest);
            }
            else createdType = type;

            var room = await _roomRepository.GetAsync(roomModel.Id);
            room.TypeId = createdType.RoomTypeId;

            var entity = await _roomRepository.UpdateAsync(room);

            if (entity == null)
                throw new BadRequest("This room doesn't exists.");

            if (roomModel.RoomPhotos != null)
            {
                await _roomPhotoService.UpdatePhotos(entity.Id, roomModel.RoomPhotos);
            }
        }

        /*public async Task<(IList<RoomModel>, int)> GetListAsync(FreeRoomsQueryModel queryModel)
        {
            var queryParameters = GetQueryParameters(queryModel);

            var (entities, pageCount) = await _roomRepository.GetListAsync(queryParameters);

            return (_mapper.Map<IList<RoomEntity>, IList<RoomModel>>(entities), pageCount);
        }*/

        public async Task<(IList<RoomGroupModel>, int)> GetListAsync(FreeRoomsQueryModel queryModel)
        {
            var queryParameters = GetQueryParameters(queryModel);

            var (entities, pageCount) = await _roomRepository.GetListAsync(queryParameters);

            var roomModels = _mapper.Map<IList<RoomEntity>, IList<RoomModel>>(entities);

            var roomsList = new List<RoomGroupModel>();

            var roomGroups = entities.GroupBy(p => p.TypeId);

            foreach (var group in roomGroups)
            {
                var prototype = _mapper.Map<RoomEntity, RoomGroupModel>(group.First());
                prototype.FreeRoomsId = new List<int>();
                foreach (var room in group)
                {
                    prototype.FreeRoomsId.Add(room.Id);
                }
                roomsList.Add(prototype);
            }

            return (roomsList, pageCount);
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