using AutoMapper;
using HotelReservationSystemAPI.Business.Models;
using HotelReservationSystemAPI.Models.RequestModels;

namespace HotelReservationSystemAPI.MappingProfiles
{
    public class AuthenticateProfile : Profile
    {
        public AuthenticateProfile()
        {
            CreateMap<AuthRequestModel, AuthenticateRequestModel>().ReverseMap();
        }
    }
}
