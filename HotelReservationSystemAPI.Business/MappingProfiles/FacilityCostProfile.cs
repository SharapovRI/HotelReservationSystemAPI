using AutoMapper;
using HotelReservationSystemAPI.Business.Models;
using HotelReservationSystemAPI.Data.Models;

namespace HotelReservationSystemAPI.Business.MappingProfiles
{
    public class FacilityCostProfile : Profile
    {
        public FacilityCostProfile()
        {
            CreateMap<FacilityCostEntity, AdditionalFacilityModel>()
                .ForMember(dest => dest.Id, act => act.MapFrom(scr => scr.Id))
                .ForMember(dest => dest.Cost, act => act.MapFrom(scr => scr.Cost))
                .ForMember(dest => dest.Name, act => act.MapFrom(src => src.AdditionalFacility.Name));

            CreateMap<FacilityRequestCostModel, FacilityCostEntity>()
                .ForMember(dest => dest.AdditionalFacility, act => act.Ignore())
                .ForMember(dest => dest.Hotel, act => act.Ignore())
                .ForMember(dest => dest.Id, act => act.Ignore());

            CreateMap<FacilityPatchRequestCostModel, FacilityCostEntity>()
                .ForMember(dest => dest.AdditionalFacility, act => act.Ignore())
                .ForMember(dest => dest.Hotel, act => act.Ignore());
        }
    }
}
