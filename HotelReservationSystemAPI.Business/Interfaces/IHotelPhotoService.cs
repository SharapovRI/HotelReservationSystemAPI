using System.Threading.Tasks;
using HotelReservationSystemAPI.Data.Models;

namespace HotelReservationSystemAPI.Business.Interfaces
{
    public interface IHotelPhotoService
    {
        Task<HotelPhotoEntity> CreateAsync(HotelPhotoEntity hotelPhoto);
        Task UpdateAsync(HotelPhotoEntity facilityPatchRequestCostModel);
    }
}