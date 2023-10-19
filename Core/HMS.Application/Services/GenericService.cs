using AutoMapper;
using HMS.Application.DTOs;
using HMS.Application.Services.Interfaces;
using HMS.Domain.Entities.Common;
using HMS.Persistence.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Application.Services
{
    public class GenericService<TDTO, TEntity> : IGenericService<TDTO, TEntity> where TDTO : BaseDTO where TEntity : BaseEntity, new()
    {
        private readonly IGenericRepository<TEntity> _genericRepository;
        private readonly IMapper _mapper;
        public GenericService(IGenericRepository<TEntity> genericRepository, IMapper mapper)
        {
            _genericRepository = genericRepository;
            _mapper = mapper;
        }
        public async Task<TDTO> Create(TDTO entity)
        {
            var newentity = _mapper.Map<TEntity>(entity);
            var addedEntity = await _genericRepository.Create(newentity);
            return _mapper.Map<TDTO>(addedEntity);

        }
        public Task<TDTO> Update(TDTO entity)
        {
            throw new NotImplementedException();
        }

        public Task<TDTO> DeleteByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<TDTO> DeleteByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<TDTO>> GetAllAsync()
        {
            var entitylist = await _genericRepository.GetAll().ToListAsync();
            return _mapper.Map<IEnumerable<TDTO>>(entitylist);
        }

        public async Task<TDTO> GetByIdAsync(string id)
        {
            var exsitingEntity = await _genericRepository.GetByIdAsync(id);
            return _mapper.Map<TDTO>(exsitingEntity);
        }    
    }
}
