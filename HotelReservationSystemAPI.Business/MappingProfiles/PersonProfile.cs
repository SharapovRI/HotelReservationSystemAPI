using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using HotelReservationSystemAPI.Business.Models;

namespace HotelReservationSystemAPI.Business.MappingProfiles
{
    public class PersonProfile : Profile
    {
        /*public PersonProfile()
        {
            CreateMap<PersonEntity, PersonModel>()
                .ForMember(dest => dest.Country, act => act.MapFrom(src => src.Location.Country))
                .ForMember(dest => dest.City, act => act.MapFrom(src => src.Location.City))
                .ForMember(dest => dest.Address, act => act.MapFrom(src => src.Location.Address))
                .ForMember(dest => dest.Title, act => act.MapFrom(src => src.Title));
        }*/
    }
}
