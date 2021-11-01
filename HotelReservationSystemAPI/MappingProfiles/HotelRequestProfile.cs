using AutoMapper;
using HotelReservationSystemAPI.Business.Models;
using HotelReservationSystemAPI.Models;

namespace HotelReservationSystemAPI.MappingProfiles
{
    public class HotelRequestProfile : Profile
    {
        public HotelRequestProfile()
        {
            CreateMap<RoomRequestViewModel, RoomRequestModel>()
                .ForMember(dest => dest.HotelId, act => act.Ignore())
                .ReverseMap();

            CreateMap<HotelRequestModel, HotelRequestViewModel>().ReverseMap();
        }
    }
}
