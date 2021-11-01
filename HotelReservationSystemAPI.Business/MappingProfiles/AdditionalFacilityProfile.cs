using AutoMapper;
using HotelReservationSystemAPI.Business.Models;
using HotelReservationSystemAPI.Data.Models;

namespace HotelReservationSystemAPI.Business.MappingProfiles
{
    public class AdditionalFacilityProfile : Profile
    {
        public AdditionalFacilityProfile()
        {
            CreateMap<FacilityRequestModel, AdditionalFacilityEntity>();
            CreateMap<AdditionalFacilityEntity, AdditionalFacilityModel>()
                .ForMember(dest => dest.Cost, act => act.Ignore());
        }
    }
}
