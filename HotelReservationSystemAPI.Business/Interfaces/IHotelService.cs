using System.Collections.Generic;
using System.Threading.Tasks;
using HotelReservationSystemAPI.Business.Models;

namespace HotelReservationSystemAPI.Business.Interfaces
{
    public interface IHotelService
    {
        Task CreateAsync(HotelModel hotelModel);
        Task<HotelModel> GetAsync(int id);
        Task<IEnumerable<HotelModel>> GetListAsync();
        Task Update(HotelModel hotelModel);
        Task<HotelModel> DeleteAsync(int id);
    }
}