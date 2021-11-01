using HotelReservationSystemAPI.Business.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotelReservationSystemAPI.Business.Interfaces
{
    public interface ILocateService
    {
        Task<IEnumerable<LocateModel>> GetListAsync();
    }
}
