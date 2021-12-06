using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.Internal;
using HotelReservationSystemAPI.Business.Exceptions;
using HotelReservationSystemAPI.Business.Interfaces;
using HotelReservationSystemAPI.Business.Models;
using HotelReservationSystemAPI.Business.Models.Request;
using HotelReservationSystemAPI.Data.Interfaces;
using HotelReservationSystemAPI.Data.Models;

namespace HotelReservationSystemAPI.Business.Services
{
    public class AdditionalFacilityService : IAdditionalFacilityService
    {
        private readonly IMapper _mapper;
        private readonly IAdditionalFacilityRepository _additionalFacilityRepository;
        private readonly IFacilityCostRepository _facilityCostRepository;
        public AdditionalFacilityService(IMapper mapper, IAdditionalFacilityRepository additionalFacilityRepository, IFacilityCostRepository facilityCostRepository)
        {
            _mapper = mapper;
            _additionalFacilityRepository = additionalFacilityRepository;
            _facilityCostRepository = facilityCostRepository;
        }


        public async Task<AdditionalFacilityModel> CreateAsync(FacilityRequestModel additionalFacilityModel)
        {

            var additionalFacility = _mapper.Map<FacilityRequestModel, AdditionalFacilityEntity>(additionalFacilityModel);
            var existingEntity = await _additionalFacilityRepository.GetFacility(additionalFacility);

            if (existingEntity != null)
            {
                var result = _mapper.Map<AdditionalFacilityEntity, AdditionalFacilityModel>(existingEntity);
                return result;
            }

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
            var (additionalFacilities, pageCount) = await _additionalFacilityRepository.GetListAsync();

            return _mapper.Map<IEnumerable<AdditionalFacilityEntity>, IEnumerable<AdditionalFacilityModel>>(additionalFacilities);
        }

        public async Task UpdateAsync(FacilityRequestCostModel additionalFacilityModel)
        {
            var additionalFacility = _mapper.Map<FacilityRequestCostModel, AdditionalFacilityEntity>(additionalFacilityModel);
            var existingEntity = await _additionalFacilityRepository.GetFacility(additionalFacility);

            if (existingEntity != null && existingEntity.FacilityCosts != null)
            {
                existingEntity.FacilityCosts.Where(p => p.HotelId == additionalFacilityModel.HotelId).ForAll(p => _facilityCostRepository.DeleteAsync(p.Id));
            }
            else
            {
                existingEntity = await _additionalFacilityRepository.CreateAsync(additionalFacility);
            }

            var entity = await _facilityCostRepository.CreateAsync(new FacilityCostEntity()
            {
                HotelId = (int)additionalFacilityModel.HotelId,
                Cost = additionalFacilityModel.Cost,
                AdditionalFacilityId = existingEntity.Id,
            });

            if (entity == null)
                throw new BadRequest("Additional facility with this id doesn't exists.");
        }
    }
}
