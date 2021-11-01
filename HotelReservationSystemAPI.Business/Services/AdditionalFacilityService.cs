using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using HotelReservationSystemAPI.Business.Interfaces;
using HotelReservationSystemAPI.Business.Models;
using HotelReservationSystemAPI.Data.Interfaces;
using HotelReservationSystemAPI.Data.Models;

namespace HotelReservationSystemAPI.Business.Services
{
    public class AdditionalFacilityService : IAdditionalFacilityService
    {
        public AdditionalFacilityService(IMapper mapper, IAdditionalFacilityRepository additionalFacilityRepository)
        {
            _mapper = mapper;
            _additionalFacilityRepository = additionalFacilityRepository;
        }

        private readonly IMapper _mapper;
        private readonly IAdditionalFacilityRepository _additionalFacilityRepository;

        public async Task<AdditionalFacilityModel> CreateAsync(FacilityRequestModel additionalFacilityModel)
        {
            var additionalFacility = _mapper.Map<FacilityRequestModel, AdditionalFacilityEntity>(additionalFacilityModel);

            var entity = await _additionalFacilityRepository.CreateAsync(additionalFacility);

            return _mapper.Map<AdditionalFacilityEntity, AdditionalFacilityModel>(entity);
        }

        public async Task<AdditionalFacilityModel> DeleteAsync(int id)
        {
            var additionalFacility = _additionalFacilityRepository.DeleteAsync(id);

            return _mapper.Map<AdditionalFacilityEntity, AdditionalFacilityModel>(await additionalFacility);
        }

        public async Task<AdditionalFacilityModel> GetAsync(int id)
        {
            var additionalFacility = _additionalFacilityRepository.GetAsync(id);

            return _mapper.Map<AdditionalFacilityEntity, AdditionalFacilityModel>(await additionalFacility);
        }

        public async Task<IEnumerable<AdditionalFacilityModel>> GetListAsync()
        {
            var additionalFacilities = _additionalFacilityRepository.GetListAsync();

            return _mapper.Map<IEnumerable<AdditionalFacilityEntity>, IEnumerable<AdditionalFacilityModel>>(await additionalFacilities);
        }

        public async Task Update(AdditionalFacilityModel additionalFacilityModel)
        {
            var additionalFacility = _mapper.Map<AdditionalFacilityModel, AdditionalFacilityEntity>(additionalFacilityModel);

            await _additionalFacilityRepository.Update(additionalFacility);
        }
    }
}
