using System.Collections.Generic;
using System.Threading.Tasks;
using HotelReservationSystemAPI.Business.Models;
using HotelReservationSystemAPI.Business.Models.Request;
using HotelReservationSystemAPI.Business.QueryModels;

namespace HotelReservationSystemAPI.Business.Interfaces
{
    public interface IHotelService
    {
        Task<HotelModel> CreateAsync(HotelRequestModel hotelModel);

        Task<HotelModel> GetAsync(int id);

        Task<IEnumerable<HotelModel>> GetListAsync();

        Task<(IList<HotelModel>, int)> GetListAsync(HotelFreeSeatsQueryModel queryModel);

        Task UpdateAsync(HotelPatchRequestModel hotelModel);

        Task<HotelModel> DeleteAsync(int id);

        Task DeactivateHotel(int id);
    }
}