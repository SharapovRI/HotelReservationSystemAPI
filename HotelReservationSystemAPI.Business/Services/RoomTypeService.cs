using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using HotelReservationSystemAPI.Business.Exceptions;
using HotelReservationSystemAPI.Business.Interfaces;
using HotelReservationSystemAPI.Business.Models;
using HotelReservationSystemAPI.Data.Interfaces;
using HotelReservationSystemAPI.Data.Models;

namespace HotelReservationSystemAPI.Business.Services
{
    public class RoomTypeService : IRoomTypeService
    {
        private readonly IMapper _mapper;
        private readonly IRoomTypeRepository _roomTypeRepository;
        private readonly IRoomsCostRepository _roomsCostRepository;

        public RoomTypeService(IMapper mapper, IRoomTypeRepository roomTypeRepository, IRoomsCostRepository roomsCostRepository)
        {
            _mapper = mapper;
            _roomTypeRepository = roomTypeRepository;
            _roomsCostRepository = roomsCostRepository;
        }

        public async Task<RoomTypeModel> CreateAsync(RoomTypeModel roomTypeModel)
        {
            var roomType = _mapper.Map<RoomTypeModel, RoomTypeEntity>(roomTypeModel);
            roomType = await _roomTypeRepository.CreateAsync(roomType);

            if (roomType == null)
                throw new SomethingWrong("Something went wrong!\nType of room is not created.");

            roomTypeModel.Id = roomType.Id;
            var typeCost = _mapper.Map<RoomTypeModel, RoomsCostEntity>(roomTypeModel);
            
            var entity = await _roomsCostRepository.CreateAsync(typeCost);

            if (entity == null)
                throw new SomethingWrong("Something went wrong!\nType of room is not created.");

            return _mapper.Map<RoomsCostEntity, RoomTypeModel>(entity);
        }

        public async Task<RoomTypeModel> DeleteAsync(int id)
        {
            var roomType = _roomTypeRepository.DeleteAsync(id);

            if (roomType == null)
                throw new BadRequest("Type of room with this id doesn't exists.");

            return _mapper.Map<RoomTypeEntity, RoomTypeModel>(await roomType);
        }

        public async Task<RoomTypeModel> GetAsync(int id)
        {
            var roomType = _roomTypeRepository.GetAsync(id);

            if (roomType == null)
                throw new BadRequest("Type of room with this id doesn't exists.");

            return _mapper.Map<RoomTypeEntity, RoomTypeModel>(await roomType);
        }

        public async Task<IEnumerable<RoomTypeModel>> GetListAsync()
        {
            var (roomTypes, pageCount) = await _roomTypeRepository.GetListAsync();

            return _mapper.Map<IEnumerable<RoomTypeEntity>, IEnumerable<RoomTypeModel>>(roomTypes);
        }

        public async Task<IEnumerable<RoomTypeModel>> GetListAsync(int hotelId)
        {
            var roomCosts = await _roomsCostRepository.GetListAsync(hotelId);

            return _mapper.Map<IEnumerable<RoomsCostEntity>, IEnumerable<RoomTypeModel>>(roomCosts);
        }

        public async Task UpdateAsync(RoomTypeModel roomTypeModel)
        {
            var roomType = _mapper.Map<RoomTypeModel, RoomTypeEntity>(roomTypeModel);

            var entity = await _roomTypeRepository.UpdateAsync(roomType);

            if (entity == null)
                throw new BadRequest("Type of room with this id doesn't exists.");
        }
    }
}
