using AutoMapper;
using HotelReservationSystemAPI.Business.Models;
using HotelReservationSystemAPI.Business.Models.Request;
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
                .ForMember(dest => dest.RoomTypeId, act => act.MapFrom(src => src.Id));

            CreateMap<RoomCreationRangeModel, RoomTypeRequestModel>()
                .ForMember(dest => dest.RoomTypeId, act => act.MapFrom(src => src.TypeId))
                .ForMember(dest => dest.Name, act => act.MapFrom(src => src.TypeName));
        }
    }
}
