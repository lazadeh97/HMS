using HMS.Application.DTOs;
using HMS.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Application.Services.Interfaces
{
    public interface IGenericService<TDTO, TEntity> where TDTO : BaseDTO where TEntity : BaseEntity, new()
    {
        Task<TDTO> GetByIdAsync(Guid id);
        Task<IEnumerable<TDTO>> GetAllAsync();

        Task<TDTO> Create(TDTO entity);
        Task<TDTO> Update(TDTO entity);
        Task<TDTO> DeleteByIdAsync(Guid id);
    }
}
