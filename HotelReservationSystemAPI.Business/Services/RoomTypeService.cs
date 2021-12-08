using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using HotelReservationSystemAPI.Business.Exceptions;
using HotelReservationSystemAPI.Business.Interfaces;
using HotelReservationSystemAPI.Business.Models;
using HotelReservationSystemAPI.Business.Models.Response;
using HotelReservationSystemAPI.Data.Interfaces;
using HotelReservationSystemAPI.Data.Models;

namespace HotelReservationSystemAPI.Business.Services
{
    public class RoomTypeService : IRoomTypeService
    {
        private readonly IMapper _mapper;
        private readonly IRoomTypeRepository _roomTypeRepository;

        public RoomTypeService(IMapper mapper, IRoomTypeRepository roomTypeRepository)
        {
            _mapper = mapper;
            _roomTypeRepository = roomTypeRepository;
        }

        public async Task<RoomTypeResponseModel> CreateAsync(RoomTypeRequestModel roomTypeModel)
        {
            var roomType = _mapper.Map<RoomTypeRequestModel, RoomTypeEntity>(roomTypeModel);

            var existingEntity = await _roomTypeRepository.CreateAsync(roomType);            

            var result = _mapper.Map<RoomTypeEntity, RoomTypeResponseModel>(existingEntity);

            return result;
        }

        public async Task<RoomTypeResponseModel> DeleteAsync(int id)
        {
            var roomType = _roomTypeRepository.DeleteAsync(id);

            if (roomType == null)
                throw new BadRequest("Type of room with this id doesn't exists.");

            return _mapper.Map<RoomTypeEntity, RoomTypeResponseModel>(await roomType);
        }

        public async Task<RoomTypeResponseModel> GetAsync(int id)
        {
            var roomType = _roomTypeRepository.GetAsync(id);

            if (roomType == null)
                throw new BadRequest("Type of room with this id doesn't exists.");

            return _mapper.Map<RoomTypeEntity, RoomTypeResponseModel>(await roomType);
        }

        public async Task<IEnumerable<RoomTypeResponseModel>> GetListAsync()
        {
            var (roomTypes, pageCount) = await _roomTypeRepository.GetListAsync();

            return _mapper.Map<IEnumerable<RoomTypeEntity>, IEnumerable<RoomTypeResponseModel>>(roomTypes);
        }

        public async Task<IEnumerable<RoomTypeResponseModel>> GetListAsync(int hotelId)
        {
            var roomCosts = await _roomTypeRepository.GetListAsync(hotelId);

            return _mapper.Map<IEnumerable<RoomTypeEntity>, IEnumerable<RoomTypeResponseModel>>(roomCosts);
        }

        public async Task UpdateAsync(RoomTypeRequestModel roomTypeModel)
        {
            var roomType = await _roomTypeRepository.GetAsync(roomTypeModel.RoomTypeId);

            if (roomType == null)
                throw new BadRequest("Type of room with this id doesn't exists.");

            roomType.Name = roomTypeModel.Name;
            roomType.SeatsCount = roomTypeModel.SeatsCount;
            roomType.HotelId = roomTypeModel.HotelId;
            roomType.Cost = roomTypeModel.Cost;

            _ = await _roomTypeRepository.UpdateAsync(roomType);
        }
    }
}
