﻿using System.Collections.Generic;
using System.Threading.Tasks;
using HotelReservationSystemAPI.Data.Models;

namespace HotelReservationSystemAPI.Data.IRepositories
{
    public interface IRepository<TEntity> where TEntity : IEntity
    {
        Task<TEntity> CreateAsync(TEntity entity);
        TEntity GetAsync(int id);
        Task<IList<TEntity>> GetListAsync();
        Task<TEntity> Update(TEntity entity);
        Task<TEntity> DeleteAsync(int id);
    }
}
