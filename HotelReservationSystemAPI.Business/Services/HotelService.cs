﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using HotelReservationSystemAPI.Business.Exceptions;
using HotelReservationSystemAPI.Business.Interfaces;
using HotelReservationSystemAPI.Business.Models;
using HotelReservationSystemAPI.Business.Models.Request;
using HotelReservationSystemAPI.Business.QueryModels;
using HotelReservationSystemAPI.Data;
using HotelReservationSystemAPI.Data.Interfaces;
using HotelReservationSystemAPI.Data.Models;
using HotelReservationSystemAPI.Data.Query;
using Microsoft.EntityFrameworkCore;

namespace HotelReservationSystemAPI.Business.Services
{
    public class HotelService : IHotelService
    {
        private readonly IMapper _mapper;
        private readonly IHotelRepository _hotelRepository;
        private readonly IRoomService _roomService;
        private readonly IHotelPhotoService _hotelPhotoService;
        private readonly IAdditionalFacilityService _additionalFacilityService;
        private readonly IRoomTypeService _roomTypeService;
        private readonly NpgsqlContext _context;

        public HotelService(IMapper mapper, IHotelRepository hotelRepository, IRoomService roomService, IHotelPhotoService hotelPhotoService,
            IAdditionalFacilityService additionalFacilityService, IRoomTypeService roomTypeService, NpgsqlContext context)
        {
            _mapper = mapper;
            _hotelRepository = hotelRepository;
            _roomService = roomService;
            _hotelPhotoService = hotelPhotoService;
            _additionalFacilityService = additionalFacilityService;
            _roomTypeService = roomTypeService;
            _context = context;
        }

        public async Task<HotelModel> CreateAsync(HotelRequestModel hotelModel)
        {
            await using var transaction = await _context.Database.BeginTransactionAsync(IsolationLevel.Serializable);
            try
            {
                var rooms = hotelModel.Rooms;
                var hotel = _mapper.Map<HotelRequestModel, HotelEntity>(hotelModel);
                hotel.Photos = null;

                hotel = await _hotelRepository.CreateAsync(hotel);

                if (hotel == null)
                    throw new SomethingWrong("Something went wrong!\nHotel is not created.");

                foreach (var photo in hotelModel.HotelPhotos)
                {
                    var entity = _mapper.Map<HotelPhotoCreationModel, HotelPhotoEntity>(photo);
                    entity.HotelId = hotel.Id;
                    _ = await _hotelPhotoService.CreateAsync(entity);
                }

                foreach (var room in rooms)
                {
                    room.HotelId = hotel.Id;
                    int roomTypeId = -1;
                    for (int i = 0; i < room.RoomCount; i++)
                    {
                        room.TypeId = roomTypeId;
                        var createdRoom = await _roomService.CreateAsync(room);
                        roomTypeId = createdRoom.TypeId;
                    }
                }

                foreach (var facility in hotelModel.Facilities)
                {
                    var newFacility = new FacilityRequestModel()
                    {
                        HotelId = hotel.Id,
                        Name = facility.Name,
                        Cost = facility.Cost,
                    };

                    _ = await _additionalFacilityService.CreateAsync(newFacility);
                }

                var createdEntity = _mapper.Map<HotelEntity, HotelModel>(hotel);

                await _context.SaveChangesAsync();
                await transaction.CommitAsync();
                return createdEntity;
            }
            catch (Exception)
            {
                await transaction.RollbackAsync();
                throw new Exception("Transaction is canceled!");
            }
        }

        public async Task DeactivateHotel(int id)
        {
            await using var transaction = await _context.Database.BeginTransactionAsync(IsolationLevel.Serializable);
            try
            {
                var hotel = await _hotelRepository.GetAsync(id);
                hotel.IsActive = false;
                foreach (var item in hotel.Rooms)
                {
                    _ = _roomService.DeactivateRoom(item.Id);
                }
                foreach (var item in hotel.FacilitiesCosts)
                {
                    _ = _additionalFacilityService.DeactivateFacility(item.Id);
                }

                _ = _hotelRepository.UpdateAsync(hotel);
                _ = _context.SaveChangesAsync();
                await transaction.CommitAsync();
            }
            catch (Exception)
            {
                await transaction.RollbackAsync();
                throw new Exception("Transaction is canceled!");
            }
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

            if (hotel == null || !hotel.IsActive)
                throw new NoContent("Hotel with this id doesn't exists.");

            return _mapper.Map<HotelEntity, HotelModel>(hotel);
        }

        public async Task<IEnumerable<HotelModel>> GetListAsync()
        {
            var (hotels, pageCount) = await _hotelRepository.GetListAsync();

            return _mapper.Map<IEnumerable<HotelEntity>, IEnumerable<HotelModel>>(hotels);
        }

        public async Task UpdateAsync(HotelPatchRequestModel hotelModel)
        {
            await using var transaction = await _context.Database.BeginTransactionAsync(IsolationLevel.Serializable);
            try
            {
                var hotel = _mapper.Map<HotelPatchRequestModel, HotelEntity>(hotelModel);
                hotel.Rooms = null;
                var entity = await _hotelRepository.UpdateReturnIncludesAsync(hotel);

                if (entity == null)
                    throw new BadRequest("Hotel with this id doesn't exists.");

                var photos = hotelModel.HotelPhotos;
                await _hotelPhotoService.UpdateAsync(photos, entity.Photos, hotel.Id);

                var requestedIds = hotelModel.Facilities.Select(p => p.Id);
                var responsedIds = entity.FacilitiesCosts.Select(p => p.Id);
                var facilityDifference = responsedIds.Except(requestedIds);
                foreach (var item in facilityDifference)
                {
                    _ = _additionalFacilityService.DeactivateFacility(item);
                }

                foreach (var item in hotelModel.Facilities)
                {
                    item.HotelId = hotel.Id; //TODO update facil
                    await _additionalFacilityService.UpdateAsync(item);
                }

                foreach (var item in hotelModel.Rooms)
                {
                    item.HotelId = hotel.Id;
                    var entityTypeRooms = entity.Rooms.Where(p => p.RoomType.Name == item.TypeName);
                    if (entityTypeRooms.Count() == 0)
                    {
                        await _roomService.CreateAsync(item);
                    }
                    else
                    {
                        var room = entityTypeRooms.First();
                        item.TypeId = room.TypeId;
                        var entitiesToDeact = entityTypeRooms.Skip(item.RoomCount);

                        foreach (var roomToDeact in entitiesToDeact)
                        {
                            await _roomService.DeactivateRoom(roomToDeact.Id);
                        }

                        var roomType = _mapper.Map<RoomCreationRangeModel, RoomTypeRequestModel>(item);
                        await _roomTypeService.UpdateAsync(roomType);

                        int roomToCreate = item.RoomCount - entityTypeRooms.Count();
                        if (roomToCreate > 0)
                        {
                            item.RoomCount = roomToCreate;
                            await _roomService.CreateAsync(item);
                        }
                    }
                }

                await _context.SaveChangesAsync();
                await transaction.CommitAsync();
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                throw new Exception("Transaction is canceled!");
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
                    hotel.IsActive &&
                    ((model.Id == null) || (model.Id == hotel.Id))
                    &&
                    (model.CityId == null && (model.CountryId == null || model.CountryId == hotel.CountryId) || model.CityId == hotel.CityId)
                    &&
                    ((hotel.Rooms == null) || (model.CheckIn == null) || (model.CheckOut == null) ||
                    (hotel.Rooms.Where(room => (room.Orders.Count() == 0) ||
                                                (room.Orders.AsQueryable().FirstOrDefault(time => time.CheckInTime > model.CheckIn && time.CheckInTime >= model.CheckOut ||
                                                                                                time.CheckOutTime <= model.CheckIn && time.CheckOutTime < model.CheckOut) != null)
                                                )
                    )
                    .Sum(room => room.RoomType.SeatsCount) >= model.FreeSeatsCount)
                    &&
                    (string.IsNullOrWhiteSpace(model.NamePart) || hotel.Name.Contains(model.NamePart))

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
