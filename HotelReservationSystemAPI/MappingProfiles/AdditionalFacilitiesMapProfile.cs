using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using HotelReservationSystemAPI.Business.Models;
using HotelReservationSystemAPI.Models;

namespace HotelReservationSystemAPI.MappingProfiles
{
    public class AdditionalFacilitiesMapProfile : Profile
    {
        public AdditionalFacilitiesMapProfile()
        {
            CreateMap<AdditionalFacilityModel, AdditionalFacilityViewModel>();
            CreateMap<FacilityRequestViewModel, FacilityRequestModel>();
            CreateMap<FacilityCostRequestViewModel, FacilityRequestCostModel>();
        }
    }
}
