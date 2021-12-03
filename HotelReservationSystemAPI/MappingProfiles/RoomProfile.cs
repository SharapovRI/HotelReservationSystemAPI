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
            CreateMap<RoomModel, RoomViewModel>();
            CreateMap<RoomPhotoPostModel, RoomPhotoCreationModel>();
            CreateMap<RoomPhotosCreationListModel, RoomPhotoListPostModel>();
            CreateMap<RoomPutModel, RoomUpdateModel>();
            CreateMap<RoomPhotoPutModel, RoomPhotoUpdateModel>();

            CreateMap<RoomPostModel, RoomCreationRangeModel>()
                .ForMember(dest => dest.HotelId, act => act.Ignore())
                .ForMember(dest => dest.TypeId, act => act.Ignore());
        }
    }
}
