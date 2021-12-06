using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using HotelReservationSystemAPI.Business.Exceptions;
using HotelReservationSystemAPI.Business.Interfaces;
using HotelReservationSystemAPI.Business.Models.Request;
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

        /*public async Task UpdateAsync(HotelPhotoEntity photo)
        {
            var entity = await _hotelPhotoRepository.UpdateAsync(photo);

            if (entity == null)
                throw new BadRequest("Photo with this id doesn't exists.");
        }*/

        public async Task UpdateAsync(IEnumerable<HotelPhotoCreationModel> listPhotos, List<HotelPhotoEntity> oldHotelPhotos, int hotelId)
        {
            HotelPhotoEntity[] oldPhotosList = oldHotelPhotos.ToArray();

            foreach (var oldPhoto in oldPhotosList)
            {
                _ = await _hotelPhotoRepository.DeleteAsync(oldPhoto.Id);
            }

            foreach (var photo in listPhotos)
            {
                var hotelPhoto = _mapper.Map<HotelPhotoCreationModel, HotelPhotoEntity>(photo);
                hotelPhoto.HotelId = hotelId;
                _ = await CreateAsync(hotelPhoto);
            }
        }
    }
}
