using System.Threading.Tasks;
using AutoMapper;
using HotelReservationSystemAPI.Business.Exceptions;
using HotelReservationSystemAPI.Business.Interfaces;
using HotelReservationSystemAPI.Data.Interfaces;
using HotelReservationSystemAPI.Data.Models;

namespace HotelReservationSystemAPI.Business.Services
{
    public class HotelPhotoService : IHotelPhotoService
    {
        private readonly IMapper _mapper;
        private readonly IHotelPhotoRepository _hotelPhotoRepository;
        public HotelPhotoService(IMapper mapper, IHotelPhotoRepository hotelPhotoRepository)
        {
            _mapper = mapper;
            _hotelPhotoRepository = hotelPhotoRepository;
        }

        public async Task<HotelPhotoEntity> CreateAsync(HotelPhotoEntity hotelPhoto)
        {
            var entity = await _hotelPhotoRepository.CreateAsync(hotelPhoto);

            if (entity == null)
                throw new SomethingWrong("Something went wrong!\nPhoto is not added.");

            return entity;
        }

        public async Task UpdateAsync(HotelPhotoEntity facilityPatchRequestCostModel)
        {
            var entity = await _hotelPhotoRepository.UpdateAsync(facilityPatchRequestCostModel);

            if (entity == null)
                throw new BadRequest("Photo with this id doesn't exists.");
        }
    }
}
