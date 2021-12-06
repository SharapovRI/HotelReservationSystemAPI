using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelReservationSystemAPI.Data.Interfaces;
using HotelReservationSystemAPI.Data.Query;
using Microsoft.EntityFrameworkCore;

namespace HotelReservationSystemAPI.Data.Repositories
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity
    {
        protected readonly DbSet<TEntity> _set;
        protected readonly NpgsqlContext _context;
        protected abstract IQueryable<TEntity> SetWithIncludes { get; }

        protected Repository(NpgsqlContext npgsqlContext)
        {
            _context = npgsqlContext;
            _set = _context.Set<TEntity>();
        }

        public async Task<TEntity> CreateAsync(TEntity entity)
        {
            var createdEntity = _set.Add(entity);

            await _context.SaveChangesAsync();

            return createdEntity.Entity;
        }

        public async Task<TEntity> DeleteAsync(int id)
        {
            var entity = await _set.FindAsync(id);

            //if (entity is null)
            //{
            //    throw new ArgumentNullException(); // TODO: Write the exception
            //}

            _set.Remove(entity);

            await _context.SaveChangesAsync();

            return entity;         
        }

        public async Task<TEntity> GetAsync(int id)
        {
            //var entity = await _set.FindAsync(id);

            var entity = await SetWithIncludes.FirstOrDefaultAsync(p => p.Id == id);

            //if (entity is null)
            //{
            //    throw new ArgumentNullException(); // TODO: Write the exception
            //}

            return entity;
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            var updatedEntity = _set.Update(entity);

            await _context.SaveChangesAsync();

            return updatedEntity.Entity;
        }

        public async Task<TEntity> UpdateReturnIncludesAsync(TEntity entity)
        {
            var updatedEntity = _set.Update(entity);

            await _context.SaveChangesAsync();

            var entityWithIncludes = await SetWithIncludes.FirstOrDefaultAsync(p => p.Id == updatedEntity.Entity.Id);

            return entityWithIncludes;
        }

        public async Task<(IList<TEntity>, int)> GetListAsync(QueryParameters<TEntity> parameters)
        {
            int count = 0;
            return (await Query(parameters, ref count).ToListAsync(), count);
        }

        protected IQueryable<TEntity> Query(QueryParameters<TEntity> queryParameters, ref int count)
        {
            var query = SetWithIncludes.AsQueryable();

            if (queryParameters == null)
                return query;

            if (queryParameters.FilterRule != null && queryParameters.FilterRule.IsValid)
            {
                query = query.Where(queryParameters.FilterRule.FilterExpression);
            }

            if (queryParameters.PaginationRule.Size > 0)
            {
                count = Decimal.ToInt32(Math.Ceiling((decimal) query.Count() /
                                                     (decimal) queryParameters.PaginationRule.Size));
            }

            if (queryParameters.PaginationRule != null && queryParameters.PaginationRule.IsValid)
                query = query.Skip(queryParameters.PaginationRule.Size * queryParameters.PaginationRule.Index).Take(queryParameters.PaginationRule.Size);

            return query;
        }
    }
}
