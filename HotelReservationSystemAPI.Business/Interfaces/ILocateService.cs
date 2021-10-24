using HotelReservationSystemAPI.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservationSystemAPI.Business.Interfaces
{
    public interface ILocateService
    {
        Task<IEnumerable<LocateModel>> GetListAsync();
    }
}
