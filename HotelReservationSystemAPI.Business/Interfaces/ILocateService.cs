using System.Collections.Generic;
using System.Threading.Tasks;
using HotelReservationSystemAPI.Business.Models.Response;

namespace HotelReservationSystemAPI.Business.Interfaces
{
    public interface ILocateService
    {
        Task<IEnumerable<LocateModel>> GetListAsync();
    }
}
