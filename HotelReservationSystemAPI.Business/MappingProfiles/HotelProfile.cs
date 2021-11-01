﻿using AutoMapper;
using HotelReservationSystemAPI.Business.Models;
using HotelReservationSystemAPI.Data.Models;

namespace HotelReservationSystemAPI.Business.MappingProfiles
{
    public class HotelProfile : Profile
    {
        public HotelProfile()
        {
            CreateMap<HotelEntity, HotelModel>()
                    .ForMember(dest => dest.Country, act => act.MapFrom(scr => scr.Country.Name))
                    .ForMember(dest => dest.City, act => act.MapFrom(src => src.City.Name));

            CreateMap<HotelModel, HotelEntity>()
                .ForMember(dest => dest.RoomsCosts, act => act.Ignore())
                .ForMember(dest => dest.City, act => act.Ignore())
                .ForMember(dest => dest.Country, act => act.Ignore())
                .ForMember(dest => dest.FacilitiesCosts, act => act.Ignore())
                .ForMember(dest => dest.Rooms, act => act.Ignore());
        }
    }
}
