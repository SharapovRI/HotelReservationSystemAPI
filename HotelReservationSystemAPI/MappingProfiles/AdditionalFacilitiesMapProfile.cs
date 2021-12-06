using AutoMapper;
using HotelReservationSystemAPI.Business.Models;
using HotelReservationSystemAPI.Business.Models.Request;
using HotelReservationSystemAPI.Models.RequestModels;
using HotelReservationSystemAPI.Models.ResponseModels;

namespace HotelReservationSystemAPI.MappingProfiles
{
    public class AdditionalFacilitiesMapProfile : Profile
    {
        public AdditionalFacilitiesMapProfile()
        {
            CreateMap<AdditionalFacilityModel, AdditionalFacilityViewModel>();
            CreateMap<FacilityPostModel, FacilityRequestModel>();
            CreateMap<FacilityCostPostModel, FacilityRequestCostModel>()
                .ForMember(dest => dest.FacilityName, act => act.MapFrom(src
                    => src.Name));
            CreateMap<FacilityCostPutModel, FacilityPatchRequestCostModel>();
        }
    }
}
