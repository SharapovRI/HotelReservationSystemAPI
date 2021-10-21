﻿using System.Collections.Generic;
using System.Threading.Tasks;
using HotelReservationSystemAPI.Business.Models;

namespace HotelReservationSystemAPI.Business.Interfaces
{
    public interface IRoomTypeService
    {
        Task CreateAsync(RoomTypeModel roomTypeModel);
        Task<RoomTypeModel> GetAsync(int id);
        Task<IEnumerable<RoomTypeModel>> GetListAsync();
        Task Update(RoomTypeModel roomTypeModel);
        Task<RoomTypeModel> DeleteAsync(int id);
    }
}