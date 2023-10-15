using HMS.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Application.Repositories
{
    public interface IWriteRepository<T> : IRepository<T> where T : BaseEntity, new()
    {
        Task<bool> AddAsync(T model);
        Task<bool> AddRangeAsync(List<T> datas);
        bool Update(T model);
        //Task<bool> UpdateRange(List<T> datas);
        bool Delete(T model);
        bool DeleteRange(List<T> datas);
        Task<bool> DeleteAsync(string id);
        Task<int> SaveAsync();
    }
}
