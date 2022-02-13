using AutoMapper;
using HotelReservationSystemAPI.Business.Models;
using HotelReservationSystemAPI.Business.Models.Request;
using HotelReservationSystemAPI.Models.RequestModels;
using HotelReservationSystemAPI.Models.ResponseModels;

namespace HotelReservationSystemAPI.MappingProfiles
{
    public class HotelProfile : Profile
    {
        public HotelProfile()
        {
            CreateMap<HotelModel, HotelViewModel>();

            CreateMap<HotelPostModel, HotelRequestModel>()
                .ForMember(dest => dest.Id, act => act.Ignore());

            CreateMap<HotelPutModel, HotelRequestModel>()
                .ForMember(dest => dest.Rooms, act => act.Ignore());

            CreateMap<RoomPostModel, RoomCreationRangeModel>()
                .ForMember(dest => dest.HotelId, act => act.Ignore())
                .ReverseMap();

            CreateMap<HotelRequestModel, HotelPostModel>().ReverseMap();

            CreateMap<HotelPhotoPostModel, HotelPhotoCreationModel>();

            CreateMap<HotelPutModel, HotelPatchRequestModel>();
        }
    }
}
