﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelReservationSystemAPI.Data.Interfaces;
using HotelReservationSystemAPI.Data.Models;
using HotelReservationSystemAPI.Data.Query;
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

            if (await entity is null)
            {
                throw new Exception(); // TODO: Write the exception
            }

            _set.Remove(await entity);

            await _context.SaveChangesAsync();

            return await entity;          // TODO: Check when everything is done, maybe a return is not needed
        }

        public async Task<TEntity> GetAsync(int id)
        {
            var entity = _set.FindAsync(id);

            if (await entity is null)
            {
                throw new Exception(); // TODO: Write the exception
            }

            return await entity;
        }

        public async Task<IEnumerable<TEntity>> GetListAsync()
        {
            return await _set.ToListAsync();
        }

        public async Task<TEntity> Update(TEntity entity)
        {
            var updatedEntity = _set.Update(entity);

            await _context.SaveChangesAsync();

            return updatedEntity.Entity;
        }

        public async Task<IList<TEntity>> GetListAsync(QueryParameters<TEntity> parameters = null)
        {
            return await Query(parameters).ToListAsync();
        }

        protected IQueryable<TEntity> Query(QueryParameters<TEntity> queryParameters)
        {
            var query = _set.AsQueryable();

            if (queryParameters == null)
                return query;

            if (queryParameters.FilterRule != null && queryParameters.FilterRule.IsValid)
            {
                query = query.Where(queryParameters.FilterRule.FilterExpression);
            }

            if (queryParameters.PaginationRule != null && queryParameters.PaginationRule.IsValid)
                query = query.Skip(queryParameters.PaginationRule.Size * queryParameters.PaginationRule.Index).Take(queryParameters.PaginationRule.Size);

            return query;
        }
    }
}
