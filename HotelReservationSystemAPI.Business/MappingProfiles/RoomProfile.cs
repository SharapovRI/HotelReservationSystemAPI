using System.Linq;
using AutoMapper;
using HotelReservationSystemAPI.Business.Models;
using HotelReservationSystemAPI.Data.Models;

namespace HotelReservationSystemAPI.Business.MappingProfiles
{
    public class RoomProfile : Profile
    {
        public RoomProfile()
        {
            CreateMap<RoomEntity, RoomModel>()
                .ForMember(dest => dest.HotelName, act => act.MapFrom(src => src.Hotel.Name))
                .ForMember(dest => dest.Type, act => act.MapFrom(src => src.RoomType.Name))
                .ForMember(dest => dest.SeatsCount, act => act.MapFrom(src => src.RoomType.SeatsCount))
                .ForMember(dest => dest.Cost, act => act.MapFrom(src =>
                    src.RoomType.RoomsCosts.FirstOrDefault(cost => cost.HotelId == src.HotelId).Cost));
        }
    }
}
