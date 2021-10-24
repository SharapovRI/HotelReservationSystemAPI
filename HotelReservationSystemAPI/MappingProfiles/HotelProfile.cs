using AutoMapper;
using HotelReservationSystemAPI.Business.Models;
using HotelReservationSystemAPI.Models;

namespace HotelReservationSystemAPI.MappingProfiles
{
    public class HotelProfile : Profile
    {
        public HotelProfile()
        {
            CreateMap<HotelModel, HotelViewModel>();
        }
    }
}
