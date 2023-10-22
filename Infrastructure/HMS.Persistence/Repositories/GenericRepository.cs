using HMS.Application.DTOs;
using HMS.Domain.Entities.Common;
using HMS.Persistence.Contexts;
using HMS.Persistence.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Persistence.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity, new()
    {
        private readonly HMSDbContext _dbContext;
        private DbSet<TEntity> _entities;
        public GenericRepository(HMSDbContext dbContext)
        {
            _dbContext = dbContext;
            _entities = _dbContext.Set<TEntity>();
        }

        public async Task<TEntity> Create(TEntity entity)
        {
            _entities.Add(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<TEntity> DeleteByIdAsync(string id)
        {
            var existingEntity = await _entities.FirstOrDefaultAsync(x => x.Id == Guid.Parse(id));
            if (existingEntity != null)
            {
                _entities.Remove(existingEntity);
                await _dbContext.SaveChangesAsync();
            }
            else
            {
                return (TEntity)Enumerable.Empty<TEntity>();
            }
            return existingEntity;
        }

        public IQueryable<TEntity> GetAll()
        {
            var list = _entities.AsQueryable();
            return list;
        }

        public async Task<TEntity> GetByIdAsync(string id)
        {
            var entity = await _entities.FirstOrDefaultAsync(x => x.Id == Guid.Parse(id));
            if (entity == null)
            {
                return (TEntity)Enumerable.Empty<TEntity>();
            }
            return entity;
        }

        public async Task<TEntity> Update(TEntity entity)
        {
            _dbContext.ChangeTracker.Clear();
            _entities.Update(entity);        
            await _dbContext.SaveChangesAsync();
            return entity;
        }
    }
}
