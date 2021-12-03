using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using HotelReservationSystemAPI.Business.Interfaces;
using HotelReservationSystemAPI.Business.Models.Request;
using HotelReservationSystemAPI.Business.Models.Response;
using HotelReservationSystemAPI.Data.Interfaces;
using HotelReservationSystemAPI.Data.Models;

namespace HotelReservationSystemAPI.Business.Services
{
    public class RoomPhotoService : IRoomPhotoService
    {
        private readonly IMapper _mapper;
        private readonly IRoomPhotoRepository _roomPhotoRepository;
        private readonly IRoomPhotoLinksRepository _roomPhotoLinksRepository;

        public RoomPhotoService(IMapper mapper, IRoomPhotoRepository roomPhotoRepository,
            IRoomPhotoLinksRepository roomPhotoLinksRepository)
        {
            _mapper = mapper;
            _roomPhotoRepository = roomPhotoRepository;
            _roomPhotoLinksRepository = roomPhotoLinksRepository;
        }

        public async Task<RoomPhotoListModel> CreateAsync(List<RoomPhotoCreationModel> photos)
        {
            var photoList = photos;

            var responseList = new RoomPhotoListModel();
            responseList.RoomPhotos = new List<RoomPhotoModel>();
            foreach (var photo in photoList)
            {
                var responseEntity = await CreateAsync(photo);
                responseList.RoomPhotos.Add(responseEntity);
            }

            return responseList;
        }

        public async Task<RoomPhotoModel> CreateAsync(RoomPhotoCreationModel photo)
        {
            var entity = _mapper.Map<RoomPhotoCreationModel, RoomPhotoEntity>(photo);
            var existingEntity = await _roomPhotoRepository.GetRoomPhoto(entity);

            if (existingEntity != null)
            {
                var result = _mapper.Map<RoomPhotoEntity, RoomPhotoModel>(existingEntity);
                return result;
            }

            var createdEntity = await _roomPhotoRepository.CreateAsync(entity);
            var responseEntity = _mapper.Map<RoomPhotoEntity, RoomPhotoModel>(createdEntity);
            return responseEntity;
        }

        public async Task CreateLinksAsync(int roomId, int[] photosId)
        {
            foreach (var photo in photosId)
            {
                var link = new RoomPhotoLinksEntity()
                {
                    RoomId = roomId,
                    PhotoId = photo
                };

                await _roomPhotoLinksRepository.CreateAsync(link);
            }
        }

        public async Task UpdatePhotos(int roomId, List<RoomPhotoUpdateModel> photos)
        {
            foreach (var photo in photos)
            {
                var oldPhoto = await _roomPhotoRepository.GetAsync(photo.Id);
                var link = oldPhoto.RoomsLinks.FirstOrDefault(p => p.RoomId == roomId);
                if (link == null)
                    throw new Exception("");//TODO write exception
                var entity = _mapper.Map<RoomPhotoUpdateModel, RoomPhotoEntity>(photo);

                if (oldPhoto.RoomsLinks.Count > 1)
                {
                    var createdEntity = await _roomPhotoRepository.CreateAsync(entity);

                    link.PhotoId = createdEntity.Id;
                    await _roomPhotoLinksRepository.UpdateAsync(link);
                }
                else
                {
                    await _roomPhotoRepository.UpdateAsync(entity);
                }
            }
        }
    }
}