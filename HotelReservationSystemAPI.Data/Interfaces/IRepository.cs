using System.Collections.Generic;
using System.Threading.Tasks;
using HotelReservationSystemAPI.Data.Models;

namespace HotelReservationSystemAPI.Data.Interfaces
{
    public interface IRepository<TEntity> where TEntity : IEntity
    {
        Task<TEntity> CreateAsync(TEntity entity);
        Task<TEntity> GetAsync(int id);
        Task<IEnumerable<TEntity>> GetListAsync();
        Task<TEntity> Update(TEntity entity);
        Task<TEntity> DeleteAsync(int id);
    }
}
