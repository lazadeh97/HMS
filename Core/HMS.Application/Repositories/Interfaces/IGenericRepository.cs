using HMS.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Persistence.Repositories.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity : BaseEntity, new()
    {
        Task<TEntity> GetByIdAsync(string id);
        IQueryable<TEntity> GetAll();

        Task<TEntity> Create(TEntity entity);
        Task<TEntity> Update(TEntity entity);
        Task<TEntity> DeleteByIdAsync(string id);
    }
}
