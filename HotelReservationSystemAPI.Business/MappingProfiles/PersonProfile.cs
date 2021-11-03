using AutoMapper;
using HotelReservationSystemAPI.Business.Models;
using HotelReservationSystemAPI.Data.Models;

namespace HotelReservationSystemAPI.Business.MappingProfiles
{
    public class PersonProfile : Profile
    {
        public PersonProfile()
        {
            CreateMap<RegistrationModel, PersonEntity>()
                .ForMember(dest => dest.Orders, act => act.Ignore())
                .ForMember(dest => dest.RefreshToken, act => act.Ignore())
                .ForMember(dest => dest.Login, act => act.MapFrom(src => src.Username))
                .ForMember(dest => dest.Password, act => act.MapFrom(src => src.Password))
                .ForMember(dest => dest.Role, act => act.Ignore());
        }
    }
}
