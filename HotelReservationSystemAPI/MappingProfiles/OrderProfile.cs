using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using HotelReservationSystemAPI.Business.Models;
using HotelReservationSystemAPI.Models;

namespace HotelReservationSystemAPI.MappingProfiles
{
    public class OrderProfile : Profile
    {
        /*public OrderProfile()
        {
            CreateMap<OrderModel, OrderViewModel>()
                .ForMember(dest => dest.AdditionalFacilities, act => act.MapFrom(scr => scr.AdditionalFacilities))
                .ForMember(dest => dest.Type, act => act.MapFrom(src => src.RoomType.Name));
        }*/
    }
}
