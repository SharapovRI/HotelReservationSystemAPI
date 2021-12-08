using AutoMapper;
using HotelReservationSystemAPI.Business.Models;
using HotelReservationSystemAPI.Business.Models.Response;
using HotelReservationSystemAPI.Data.Models;

namespace HotelReservationSystemAPI.Business.MappingProfiles
{
    public class RoomTypeProfile : Profile
    {
        public RoomTypeProfile()
        {
            CreateMap<RoomTypeRequestModel, RoomTypeEntity>()
                .ForMember(dest => dest.Rooms, act => act.Ignore());

            CreateMap<RoomTypeEntity, RoomTypeResponseModel>()
                .ForMember(dest => dest.RoomTypeId, act => act.MapFrom(src => src.Id))
                ;
        }
    }
}
