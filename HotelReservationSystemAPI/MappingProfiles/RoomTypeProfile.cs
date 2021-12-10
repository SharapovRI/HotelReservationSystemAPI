using AutoMapper;
using HotelReservationSystemAPI.Business.Models;
using HotelReservationSystemAPI.Models.RequestModels;
using HotelReservationSystemAPI.Models.ResponseModels;

namespace HotelReservationSystemAPI.MappingProfiles
{
    public class RoomTypeProfile : Profile
    {
        public RoomTypeProfile()
        {
            CreateMap<RoomTypePostModel, RoomTypeRequestModel>();
            CreateMap<RoomTypeViewModel, RoomTypeRequestModel>().ReverseMap();
        }
    }
}
