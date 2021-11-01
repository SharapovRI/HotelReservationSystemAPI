using AutoMapper;
using HotelReservationSystemAPI.Business.Models;
using HotelReservationSystemAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
