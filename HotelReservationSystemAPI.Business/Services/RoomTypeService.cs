using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using HotelReservationSystemAPI.Business.Interfaces;
using HotelReservationSystemAPI.Business.Models;
using HotelReservationSystemAPI.Data.Interfaces;
using HotelReservationSystemAPI.Data.Models;

namespace HotelReservationSystemAPI.Business.Services
{
    public class RoomTypeService : IRoomTypeService
    {
        public RoomTypeService(IMapper mapper, IRoomTypeRepository roomTypeRepository, IRoomsCostRepository roomsCostRepository)
        {
            _mapper = mapper;
            _roomTypeRepository = roomTypeRepository;
            _roomsCostRepository = roomsCostRepository;
        }

        private readonly IMapper _mapper;
        private readonly IRoomTypeRepository _roomTypeRepository;
        private readonly IRoomsCostRepository _roomsCostRepository;

        public async Task<RoomTypeModel> CreateAsync(RoomTypeModel roomTypeModel)
        {
            var roomType = _mapper.Map<RoomTypeModel, RoomTypeEntity>(roomTypeModel);
            roomType = await _roomTypeRepository.CreateAsync(roomType);
            roomTypeModel.Id = roomType.Id;
            var typeCost = _mapper.Map<RoomTypeModel, RoomsCostEntity>(roomTypeModel);
            
            var entity = await _roomsCostRepository.CreateAsync(typeCost);

            return _mapper.Map<RoomsCostEntity, RoomTypeModel>(entity);
        }

        public async Task<RoomTypeModel> DeleteAsync(int id)
        {
            var roomType = _roomTypeRepository.DeleteAsync(id);

            return _mapper.Map<RoomTypeEntity, RoomTypeModel>(await roomType);
        }

        public async Task<RoomTypeModel> GetAsync(int id)
        {
            var roomType = _roomTypeRepository.GetAsync(id);

            return _mapper.Map<RoomTypeEntity, RoomTypeModel>(await roomType);
        }

        public async Task<IEnumerable<RoomTypeModel>> GetListAsync()
        {
            var roomTypes = _roomTypeRepository.GetListAsync();

            return _mapper.Map<IEnumerable<RoomTypeEntity>, IEnumerable<RoomTypeModel>>(await roomTypes);
        }

        public async Task<IEnumerable<RoomTypeModel>> GetListAsync(int hotelId)
        {
            var roomCosts = await _roomsCostRepository.GetListAsync(hotelId);

            return _mapper.Map<IEnumerable<RoomsCostEntity>, IEnumerable<RoomTypeModel>>(roomCosts);
        }

        public async Task Update(RoomTypeModel roomTypeModel)
        {
            var roomType = _mapper.Map<RoomTypeModel, RoomTypeEntity>(roomTypeModel);

            await _roomTypeRepository.Update(roomType);
        }
    }
}
