using AutoMapper;
using HotelReservationSystemAPI.Business.Models;
using HotelReservationSystemAPI.Models;

namespace HotelReservationSystemAPI.MappingProfiles
{
    public class RoomTypeProfile : Profile
    {
        public RoomTypeProfile()
        {
            CreateMap<RoomTypeModel, RoomTypeViewModel>().ReverseMap();
        }
    }
}
