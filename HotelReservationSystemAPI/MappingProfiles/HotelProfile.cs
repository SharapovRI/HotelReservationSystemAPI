using AutoMapper;
using HotelReservationSystemAPI.Business.Models;
using HotelReservationSystemAPI.Business.Models.Request;
using HotelReservationSystemAPI.Models;
using HotelReservationSystemAPI.Models.RequestModels;
using HotelReservationSystemAPI.Models.ResponseModels;

namespace HotelReservationSystemAPI.MappingProfiles
{
    public class HotelProfile : Profile
    {
        public HotelProfile()
        {
            CreateMap<HotelModel, HotelViewModel>();

            CreateMap<HotelPutModel, HotelRequestModel>();

            CreateMap<RoomPostModel, RoomCreationRangeModel>()
                .ForMember(dest => dest.HotelId, act => act.Ignore())
                .ReverseMap();

            CreateMap<HotelRequestModel, HotelPostModel>().ReverseMap();

            CreateMap<PhotoModel, PhotoViewModel>().ReverseMap();
        }
    }
}
