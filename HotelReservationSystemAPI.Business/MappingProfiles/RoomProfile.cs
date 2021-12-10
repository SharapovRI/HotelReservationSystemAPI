using System;
using System.Linq;
using AutoMapper;
using HotelReservationSystemAPI.Business.Models.Request;
using HotelReservationSystemAPI.Business.Models.Response;
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
                    src.RoomType.Cost))
                .ForMember(dest => dest.RoomPhotos,
                    act => act.MapFrom(src => src.PhotoLinks.Select(p => p.RoomPhoto)));

            CreateMap<RoomCreationRangeModel, RoomEntity>()
                .ForMember(dest => dest.Hotel, act => act.Ignore())
                .ForMember(dest => dest.LastView, act => act.Ignore())
                .ForMember(dest => dest.Orders, act => act.Ignore());

            CreateMap<RoomPhotoCreationModel, RoomPhotoEntity>()
                .ForMember(dest => dest.Data,
                    act => act.MapFrom(scr => Convert.FromBase64String(scr.Data)));

            CreateMap<RoomPhotoUpdateModel, RoomPhotoEntity>()
                .ForMember(dest => dest.Data,
                    act => act.MapFrom(scr => Convert.FromBase64String(scr.Data)));

            CreateMap<RoomPhotoEntity, RoomPhotoModel>()
                .ForMember(dest => dest.Data,
                    act => act.MapFrom(scr => Convert.ToBase64String(scr.Data)));
        }
    }
}
