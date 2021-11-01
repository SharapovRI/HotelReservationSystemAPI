using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using HotelReservationSystemAPI.Business.Models;
using HotelReservationSystemAPI.Data.Models;

namespace HotelReservationSystemAPI.Business.MappingProfiles
{
    public class RoomTypeProfile: Profile
    {
        public RoomTypeProfile()
        {
            CreateMap<RoomTypeModel, RoomTypeEntity>()
                .ForMember(dest => dest.RoomsCosts, act => act.Ignore())
                .ForMember(dest => dest.Rooms, act => act.Ignore());
        }
    }
}
