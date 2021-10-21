using System;
using System.Collections.Generic;
using System.Text;
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
        public RoomTypeService(IMapper mapper, IRoomTypeRepository roomTypeRepository)
        {
            _mapper = mapper;
            _roomTypeRepository = roomTypeRepository;
        }

        private readonly IMapper _mapper;
        private readonly IRoomTypeRepository _roomTypeRepository;

        public async Task CreateAsync(RoomTypeModel roomTypeModel)
        {
            var roomType = _mapper.Map<RoomTypeModel, RoomTypeEntity>(roomTypeModel);

            await _roomTypeRepository.CreateAsync(roomType);
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

        public async Task Update(RoomTypeModel roomTypeModel)
        {
            var roomType = _mapper.Map<RoomTypeModel, RoomTypeEntity>(roomTypeModel);

            await _roomTypeRepository.Update(roomType);
        }
    }
}
