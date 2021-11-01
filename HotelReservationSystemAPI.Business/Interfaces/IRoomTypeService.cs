using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper.Configuration.Conventions;
using HotelReservationSystemAPI.Business.Models;

namespace HotelReservationSystemAPI.Business.Interfaces
{
    public interface IRoomTypeService
    {
        Task CreateAsync(RoomTypeModel roomTypeModel);
        Task<RoomTypeModel> GetAsync(int id);
        Task<IEnumerable<RoomTypeModel>> GetListAsync();
        Task<IEnumerable<RoomTypeModel>> GetListAsync(int hotelId);
        Task Update(RoomTypeModel roomTypeModel);
        Task<RoomTypeModel> DeleteAsync(int id);
    }
}