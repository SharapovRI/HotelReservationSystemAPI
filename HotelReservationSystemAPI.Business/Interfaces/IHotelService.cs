using System.Collections.Generic;
using System.Threading.Tasks;
using HotelReservationSystemAPI.Business.Models;
using HotelReservationSystemAPI.Business.QueryModels;

namespace HotelReservationSystemAPI.Business.Interfaces
{
    public interface IHotelService
    {
        Task CreateAsync(HotelRequestModel hotelModel);
        Task<HotelModel> GetAsync(int id);
        Task<IEnumerable<HotelModel>> GetListAsync();
        Task<IList<HotelModel>> GetListAsync(HotelFreeSeatsQueryModel queryModel);
        Task Update(HotelModel hotelModel);
        Task<HotelModel> DeleteAsync(int id);
    }
}