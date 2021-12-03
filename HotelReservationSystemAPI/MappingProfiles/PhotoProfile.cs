using AutoMapper;
using HotelReservationSystemAPI.Business.Models.Response;
using HotelReservationSystemAPI.Models;

namespace HotelReservationSystemAPI.MappingProfiles
{
    public class PhotoProfile : Profile
    {
        public PhotoProfile()
        {
            CreateMap<PhotoModel, PhotoViewModel>();
        }
    }
}
