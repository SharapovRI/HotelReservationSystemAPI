using System;
using AutoMapper;
using HotelReservationSystemAPI.Business.Models;
using HotelReservationSystemAPI.Business.Models.Request;
using HotelReservationSystemAPI.Business.Models.Response;
using HotelReservationSystemAPI.Data.Models;

namespace HotelReservationSystemAPI.Business.MappingProfiles
{
    public class HotelProfile : Profile
    {
        public HotelProfile()
        {
            CreateMap<HotelEntity, HotelModel>()
                    .ForMember(dest => dest.Country, act => act.MapFrom(scr => scr.Country.Name))
                    .ForMember(dest => dest.City, act => act.MapFrom(src => src.City.Name))
                    .ForMember(dest => dest.Discription, act => act.MapFrom(src => src.Discription));

            CreateMap<HotelRequestModel, HotelEntity>()
                .ForMember(dest => dest.RoomTypes, act => act.Ignore())
                .ForMember(dest => dest.City, act => act.Ignore())
                .ForMember(dest => dest.Country, act => act.Ignore())
                .ForMember(dest => dest.FacilitiesCosts, act => act.Ignore())
                .ForMember(dest => dest.Rooms, act => act.Ignore())
                .ForMember(dest => dest.Photos, act => act.Ignore());

            CreateMap<PhotoModel, HotelPhotoEntity>()
                .ForMember(dest => dest.Data, 
                    act => act.MapFrom(scr => Convert.FromBase64String(scr.Data)));

            CreateMap<HotelPhotoCreationModel, HotelPhotoEntity>()
                .ForMember(dest => dest.HotelId, act => act.Ignore())
                .ForMember(dest => dest.Hotel, act => act.Ignore())
                .ForMember(dest => dest.Id, act => act.Ignore())
                .ForMember(dest => dest.Data,
                    act => act.MapFrom(scr => Convert.FromBase64String(scr.Data)));

            CreateMap<HotelPhotoEntity, PhotoModel>()
                .ForMember(dest => dest.Data,
                    act => act.MapFrom(scr => Convert.ToBase64String(scr.Data)));
        }
    }
}
