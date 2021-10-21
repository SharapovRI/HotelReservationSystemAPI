using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HotelReservationSystemAPI.Data.IRepositories;
using HotelReservationSystemAPI.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelReservationSystemAPI.Data.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity
    {
        public Repository(NpgsqlContext npgsqlContext)
        {
            _context = npgsqlContext;
            _set = _context.Set<TEntity>();
        }

        private readonly DbSet<TEntity> _set;
        private readonly NpgsqlContext _context;

        public async Task<TEntity> CreateAsync(TEntity entity)
        {
            var createdEntity = _set.Add(entity);

            await _context.SaveChangesAsync();

            return createdEntity.Entity;
        }

        public async Task<TEntity> DeleteAsync(int id)
        {
            var entity = _set.FindAsync(id);

            if (entity.Result is null)
            {
                throw new Exception(); // TODO: Write the exception
            }

            _set.Remove(entity.Result);

            await _context.SaveChangesAsync();

            return entity.Result;          // TODO: Check when everything is done, maybe a return is not needed
        }

        public TEntity GetAsync(int id)
        {
            var entity = _set.FindAsync(id);

            if (entity.Result is null)
            {
                throw new Exception(); // TODO: Write the exception
            }

            return entity.Result;
        }

        public async Task<IList<TEntity>> GetListAsync()
        {
            return await _set.ToListAsync();
        }

        public async Task<TEntity> Update(TEntity entity)
        {
            var updatedEntity = _set.Update(entity);

            await _context.SaveChangesAsync();

            return updatedEntity.Entity;
        }
    }
}
