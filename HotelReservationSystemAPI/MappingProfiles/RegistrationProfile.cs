using AutoMapper;
using HotelReservationSystemAPI.Business.Models;
using HotelReservationSystemAPI.Models.RequestModels;

namespace HotelReservationSystemAPI.MappingProfiles
{
    public class RegistrationProfile : Profile
    {
        public RegistrationProfile()
        {
            CreateMap<RegistrationRequestModel, RegistrationModel>()
                .ForMember(dest => dest.RoleId, act => act.Ignore());
        }
    }
}
