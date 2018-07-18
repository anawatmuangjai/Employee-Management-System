using AutoMapper;
using EMS.ApplicationCore.Interfaces.Repositories;
using EMS.ApplicationCore.Interfaces.Services;
using EMS.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EMS.ApplicationCore.Services
{
    public abstract class BaseService<M, E, R> : IService<M, E, R>
        where R : IAsyncRepository<E>
        where E : BaseEntity
    {
        protected readonly IMapper _mapper;
        protected readonly R _repository;

        protected BaseService(R repository)
        {
            _repository = repository;

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<E, M>().ReverseMap();
            });

            _mapper = config.CreateMapper();
        }

        public async Task<M> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return _mapper.Map<E, M>(entity);
        }

        public async Task<M> GetSingleAsync(Expression<Func<E, bool>> filter)
        {
            var entity = await _repository.GetSingleAsync(filter);
            return _mapper.Map<E, M>(entity);
        }

        public async Task<List<M>> GetAllAsync()
        {
            var entities = await _repository.GetAllAsync();
            return _mapper.Map<List<E>, List<M>>(entities);
        }

        public async Task<List<M>> GetAsync(Expression<Func<E, bool>> filter)
        {
            var entities = await _repository.GetAsync(filter);
            return _mapper.Map<List<E>, List<M>>(entities);
        }

        public async Task<M> AddAsync(M model)
        {
            var entity = _mapper.Map<M, E>(model);
            var newEntity = await _repository.AddAsync(entity);
            return _mapper.Map<E, M>(newEntity);
        }

        public async Task UpdateAsync(M model)
        {


             var entity = _mapper.Map<M, E>(model);
             await _repository.UpdateAsync(entity);
        }

        public async Task DeleteAsync(M model)
        {
            var entity = _mapper.Map<M, E>(model);
            await _repository.DeleteAsync(entity);
        }
    }
}
