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
    public class HotelService : IHotelService
    {
        public HotelService(IMapper mapper, IHotelRepository hotelRepository)
        {
            _mapper = mapper;
            _hotelRepository = hotelRepository;
        }

        private readonly IMapper _mapper;
        private readonly IHotelRepository _hotelRepository;

        public async Task CreateAsync(HotelModel hotelModel)
        {
            var hotel = _mapper.Map<HotelModel, HotelEntity>(hotelModel);

            await _hotelRepository.CreateAsync(hotel);
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

        public async Task Update(HotelModel hotelModel)
        {
            var hotel = _mapper.Map<HotelModel, HotelEntity>(hotelModel);

            await _hotelRepository.Update(hotel);
        }
    }
}
