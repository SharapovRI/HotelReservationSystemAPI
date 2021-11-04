﻿using System.Collections.Generic;
using System.Threading.Tasks;
using HotelReservationSystemAPI.Data.Query;

namespace HotelReservationSystemAPI.Data.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class, IEntity
    {
        Task<TEntity> CreateAsync(TEntity entity);

        Task<TEntity> GetAsync(int id);
        
        Task<IList<TEntity>> GetListAsync(QueryParameters<TEntity> parameters = null);

        Task<TEntity> UpdateAsync(TEntity entity);

        Task<TEntity> DeleteAsync(int id);
    }
}
