﻿using AutoMapper;
using HotelReservationSystemAPI.Business.Models;
using HotelReservationSystemAPI.Models.ResponseModels;

namespace HotelReservationSystemAPI.MappingProfiles
{
    public class LocateProfile : Profile
    {
        public LocateProfile()
        {
            CreateMap<LocateModel, LocateViewModel>();
        }
    }
}
