using System.Collections.Generic;
using System.Threading.Tasks;
using HotelReservationSystemAPI.Business.Models.Request;
using HotelReservationSystemAPI.Business.Models.Response;

namespace HotelReservationSystemAPI.Business.Interfaces
{
    public interface IRoomPhotoService
    {
        Task<RoomPhotoListModel> CreateAsync(List<RoomPhotoCreationModel> photos);
        Task<RoomPhotoModel> CreateAsync(RoomPhotoCreationModel photo);
        Task CreateLinksAsync(int roomId, int[] photosId);
        Task UpdatePhotos(int roomId, List<RoomPhotoUpdateModel> photos);
    }
}