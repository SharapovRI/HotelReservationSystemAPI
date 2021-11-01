using System.Linq;
using AutoMapper;
using HotelReservationSystemAPI.Business.Models;
using HotelReservationSystemAPI.Data.Models;

namespace HotelReservationSystemAPI.Business.MappingProfiles
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<OrderModel, OrderEntity>()
                .ForMember(dest => dest.AdditionalFacilities, act => act.Ignore());
            CreateMap<OrderEntity, OrderModel>()
                .ForMember(dest => dest.AdditionalFacilities, act => act.MapFrom(src
                => src.AdditionalFacilities.Select(facility => facility.AdditionFacilityId)));
        }
    }
}
