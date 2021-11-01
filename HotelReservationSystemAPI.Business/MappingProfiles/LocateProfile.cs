using AutoMapper;
using HotelReservationSystemAPI.Business.Models;
using HotelReservationSystemAPI.Data.Models;

namespace HotelReservationSystemAPI.Business.MappingProfiles
{
    public class LocateProfile : Profile
    {
        public LocateProfile()
        {
            CreateMap<CityEntity, LocateModel>()
                .ForMember(dest => dest.Country, act => act.MapFrom(src => src.Country.Name))
                .ForMember(dest => dest.City, act => act.MapFrom(src => src.Name))
                .ForMember(dest => dest.Id, act => act.MapFrom(src => src.Id))
                .ReverseMap();
        }
    }
}
