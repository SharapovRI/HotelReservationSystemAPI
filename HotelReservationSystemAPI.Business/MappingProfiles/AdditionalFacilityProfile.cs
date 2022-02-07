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
            CreateMap<AdditionalFacilityEntity, AdditionalFacilityModel>();
            CreateMap<AdditionalFacilityOrderEntity, AdditionalFacilityOrderModel>()
                .ForMember(dest => dest.Name, act => act.MapFrom(src => src.AdditionFacility.Name))
                .ForMember(dest => dest.Cost, act => act.MapFrom(src => src.AdditionFacility.Cost))
                .ForMember(dest => dest.AdditionFacilityId, act => act.MapFrom(src => src.AdditionFacility.Id))
                .ForMember(dest => dest.FacilityCount, act => act.Ignore());
        }
    }
}
