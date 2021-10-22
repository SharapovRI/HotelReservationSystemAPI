using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using HotelReservationSystemAPI.Business.Models;
using HotelReservationSystemAPI.Models;

namespace HotelReservationSystemAPI.MappingProfiles
{
    public class RoomProfile : Profile
    {
        public RoomProfile()
        {
            CreateMap<RoomModel, RoomViewModel>()
                .ForMember(dest => dest.HotelName, act => act.MapFrom(src => src.Hotel.Name))
                .ForMember(dest => dest.Type, act => act.MapFrom(src => src.RoomType.Name));
        }
    }
}
