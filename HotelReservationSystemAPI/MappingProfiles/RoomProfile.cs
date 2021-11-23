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
            CreateMap<RoomPhotoCreationModel, RoomPhotoPostModel>();
            CreateMap<RoomPhotosCreationListModel, RoomPhotoListPostModel>();
            CreateMap<RoomPutModel, RoomUpdateModel>();
            CreateMap<RoomPhotoPutModel, RoomPhotoUpdateModel>();
        }
    }
}
