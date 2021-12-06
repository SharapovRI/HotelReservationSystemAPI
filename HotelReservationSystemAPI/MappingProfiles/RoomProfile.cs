using AutoMapper;
using HotelReservationSystemAPI.Business.Models.Request;
using HotelReservationSystemAPI.Business.Models.Response;
using HotelReservationSystemAPI.Models.RequestModels;
using HotelReservationSystemAPI.Models.ResponseModels;

namespace HotelReservationSystemAPI.MappingProfiles
{
    public class RoomProfile : Profile
    {
        public RoomProfile()
        {
            CreateMap<RoomPhotoPostModel, RoomPhotoCreationModel>();
            CreateMap<RoomPhotosCreationListModel, RoomPhotoListPostModel>();
            CreateMap<RoomPutModel, RoomUpdateModel>();
            CreateMap<RoomPhotoPutModel, RoomPhotoUpdateModel>();

            CreateMap<RoomPostModel, RoomCreationRangeModel>()
                .ForMember(dest => dest.HotelId, act => act.Ignore())
                .ForMember(dest => dest.TypeId, act => act.Ignore());

            CreateMap<RoomModel, RoomViewModel>()
                .ForMember(dest => dest.Photos, act => act
                    .MapFrom(src => src.RoomPhotos));
        }
    }
}
