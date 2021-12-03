using AutoMapper;
using HotelReservationSystemAPI.Business.Models;
using HotelReservationSystemAPI.Data.Models;

namespace HotelReservationSystemAPI.Business.MappingProfiles
{
    public class RoomsCostProfile : Profile
    {
        public RoomsCostProfile()
        {
            CreateMap<RoomTypeModel, RoomsCostEntity>()
                .ForMember(dest => dest.HotelId, act => act.MapFrom(scr => scr.HotelId))
                .ForMember(dest => dest.Cost, act => act.MapFrom(scr => scr.Cost))
                .ForMember(dest => dest.TypeId, act => act.MapFrom(scr => scr.RoomTypeId))
                .ForMember(dest => dest.RoomType, act => act.Ignore())
                .ForMember(dest => dest.Hotel, act => act.Ignore())
                .ForMember(dest => dest.Id, act => act.Ignore());

            CreateMap<RoomsCostEntity, RoomTypeModel>()
                .ForMember(dest => dest.RoomTypeId, act => act.MapFrom(scr => scr.TypeId))
                .ForMember(dest => dest.HotelId, act => act.MapFrom(scr => scr.HotelId))
                .ForMember(dest => dest.Cost, act => act.MapFrom(scr => scr.Cost))
                .ForMember(dest => dest.Name, act => act.MapFrom(scr => scr.RoomType.Name))
                .ForMember(dest => dest.SeatsCount, act => act.MapFrom(src => src.RoomType.SeatsCount));
        }
    }
}
