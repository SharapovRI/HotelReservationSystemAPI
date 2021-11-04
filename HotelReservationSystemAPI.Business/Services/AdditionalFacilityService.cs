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

            if (entity == null)
                throw new SomethingWrong("Something went wrong!\nAdditional facility is not created.");

            return _mapper.Map<AdditionalFacilityEntity, AdditionalFacilityModel>(entity);
        }

        public async Task<AdditionalFacilityModel> DeleteAsync(int id)
        {
            var additionalFacility = await _additionalFacilityRepository.DeleteAsync(id);

            if (additionalFacility == null)
                throw new BadRequest("Additional facility with this id doesn't exists.");

            return _mapper.Map<AdditionalFacilityEntity, AdditionalFacilityModel>(additionalFacility);
        }

        public async Task<AdditionalFacilityModel> GetAsync(int id)
        {
            var additionalFacility = await _additionalFacilityRepository.GetAsync(id);

            if (additionalFacility == null)
                throw new BadRequest("Additional facility with this id doesn't exists.");

            return _mapper.Map<AdditionalFacilityEntity, AdditionalFacilityModel>(additionalFacility);
        }

        public async Task<IEnumerable<AdditionalFacilityModel>> GetListAsync()
        {
            var additionalFacilities = await _additionalFacilityRepository.GetListAsync();

            return _mapper.Map<IEnumerable<AdditionalFacilityEntity>, IEnumerable<AdditionalFacilityModel>>(additionalFacilities);
        }

        public async Task UpdateAsync(AdditionalFacilityModel additionalFacilityModel)
        {
            var additionalFacility = _mapper.Map<AdditionalFacilityModel, AdditionalFacilityEntity>(additionalFacilityModel);

            var entity = await _additionalFacilityRepository.UpdateAsync(additionalFacility);

            if (entity == null)
                throw new BadRequest("Additional facility with this id doesn't exists.");
        }
    }
}
