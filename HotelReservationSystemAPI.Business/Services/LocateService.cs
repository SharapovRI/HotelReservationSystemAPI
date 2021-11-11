using AutoMapper;
using HotelReservationSystemAPI.Business.Interfaces;
using HotelReservationSystemAPI.Business.Models;
using HotelReservationSystemAPI.Data.Interfaces;
using HotelReservationSystemAPI.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotelReservationSystemAPI.Business.Services
{
    public class LocateService : ILocateService
    {
        public LocateService(IMapper mapper, ICityRepository cityRepository)
        {
            _mapper = mapper;
            _cityRepository = cityRepository;
        }

        private readonly IMapper _mapper;
        private readonly ICityRepository _cityRepository;
        public async Task<IEnumerable<LocateModel>> GetListAsync()
        {
            var (cities, pageCount) = await _cityRepository.GetListAsync();

            return _mapper.Map<IEnumerable<CityEntity>, IEnumerable<LocateModel>>(cities);
        }
    }
}
