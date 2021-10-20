using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using HotelReservationSystemAPI.Data.Models;

namespace HotelReservationSystemAPI.Data.IRepositories
{
    public interface IRepository<TEntity> where TEntity : IEntity
    {
        Task<TEntity> CreateAsync(TEntity entity);
        Task<TEntity> GetAsync(int id);
        Task<IList<TEntity>> GetListAsync();
        TEntity Update(TEntity entity);
        Task<TEntity> DeleteAsync(int id);
    }
}
