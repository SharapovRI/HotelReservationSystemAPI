using AutoMapper;
using HotelReservationSystemAPI.Business.Models;
using HotelReservationSystemAPI.Models.RequestModels;

namespace HotelReservationSystemAPI.MappingProfiles
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<OrderModel, OrderPostModel>().ReverseMap();
        }
    }
}
