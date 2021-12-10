using System.Collections.Generic;
using System.Threading.Tasks;
using HotelReservationSystemAPI.Business.Models.Request;
using HotelReservationSystemAPI.Data.Models;

namespace HotelReservationSystemAPI.Business.Interfaces
{
    public interface IHotelPhotoService
    {
        Task<HotelPhotoEntity> CreateAsync(HotelPhotoEntity hotelPhoto);
        Task UpdateAsync(IEnumerable<HotelPhotoCreationModel> listPhotos, List<HotelPhotoEntity> oldHotelPhotos, int hotelId);
    }
}