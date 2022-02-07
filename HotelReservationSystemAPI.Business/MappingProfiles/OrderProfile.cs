using System.Linq;
using AutoMapper;
using HotelReservationSystemAPI.Business.Models;
using HotelReservationSystemAPI.Business.Models.Request;
using HotelReservationSystemAPI.Business.Models.Response;
using HotelReservationSystemAPI.Data.Models;

namespace HotelReservationSystemAPI.Business.MappingProfiles
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<OrderModel, OrderEntity>()
                .ForMember(dest => dest.AdditionalFacilities, act => act.Ignore())
                .ForMember(dest => dest.OrderGroup, act => act.Ignore());

            CreateMap<OrderEntity, OrderModel>()
                .ForMember(dest => dest.AdditionalFacilities, act => act.MapFrom(src
                => src.AdditionalFacilities.Select(facility => facility.AdditionFacilityId)));

            CreateMap<OrderEntity, OrderResponseModel>()
                .ForMember(dest => dest.AdditionalFacilities, act => act.MapFrom(src
                => src.AdditionalFacilities.Select(facility => facility.Id)));

            CreateMap<OrderGroupModel, OrderGroupEntity>()
                .ForMember(dest => dest.Orders, act => act.MapFrom(src
                => src.Orders))
                .ForMember(dest => dest.Id, act => act.Ignore());

            CreateMap<OrderGroupEntity, OrderGroupResponseModel>()
                .ForMember(dest => dest.Orders, act => act.MapFrom(src
                => src.Orders))
                .ForMember(dest => dest.Id, act => act.MapFrom(src
                => src.Id))
                .ForMember(dest => dest.PersonId, act => act.MapFrom(src
                => src.PersonId));
        }
    }
}
